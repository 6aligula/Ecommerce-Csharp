﻿using AutoMapper;
using E_Commerce_App.Core.Entities;
using E_Commerce_App.Core.Services;
using E_Commerce_App.Core.Shared;
using E_Commerce_App.Core.Shared.DTOs;
using E_Commerce_App.Core.Shared.Helper;
using E_Commerce_App.WebUI.Helpers;
using E_Commerce_App.WebUI.Identity;
using E_Commerce_App.WebUI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using static E_Commerce_App.WebUI.Helpers.UIHelper;

namespace E_Commerce_App.WebUI.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IOrderService _orderService;
        private readonly IOrderItemService _orderItemService;
        private readonly IService<Rating> _ratingService;
        private readonly ICartService _cartService;
        private readonly IProductService _productService;
        private IEmailSender _emailSender; // Servicio para enviar emails

        public OrderController(
            IMapper mapper,
            UserManager<User> userManager,
            IOrderService orderService,
            ICartService cartService, IProductService productService, IService<Rating> ratingService, IOrderItemService orderItemService, IEmailSender emailSender)
        {
            _orderService = orderService;
            _mapper = mapper;
            _userManager = userManager;
            _cartService = cartService;
            _productService = productService;
            _ratingService = ratingService;
            _orderItemService = orderItemService;
            _emailSender = emailSender;

        }

        [Route("/my-orders")]
        public async Task<IActionResult> Index()
        {
            string userId = _userManager.GetUserId(User);
            var orderItems = await _orderService.GetByUserIdAsync(userId);
            var orderDates = new List<string>();
            var ratings = new List<RatingDto>();
            var toComment = new List<string>();

            // Ordenar los artículos del pedido, si es igual al anterior agregar, si no, agregar
            //orderItems = orderItems.OrderBy(p => p.ProductId).ToList();

            for (int i = 0; i < orderItems.Count; i++)
            {
                if (i == 0) { toComment.Add("yes"); }
                else if (!orderItems[i].ProductId.Equals(orderItems[i - 1].ProductId))
                    toComment.Add("yes");
                else toComment.Add("no");
            }
            foreach (var item in orderItems)
            {
                var date = item.Order.OrderDate.ToString("dd MMMM yyyy | HH:mm", CultureInfo.CreateSpecificCulture("es-ES"));
                orderDates.Add(date);
                var rating = await _ratingService.SingleOrDefaultAsync(p => p.OrderItemId == item.Id);
                if (rating == null) ratings.Add(new RatingDto());
                else ratings.Add(_mapper.Map<RatingDto>(rating));
            }
            var model = new UserOrderViewModel()
            {
                OrderItems = _mapper.Map<List<OrderItemDto>>(orderItems),
                OrderDates = orderDates,
                Ratings = ratings,
                ToComment = toComment
            };

            return View(model);
        }


        [NoDirectAccess]
        public async Task<IActionResult> CommentAddOrEdit(int orderItemId, int id = 0)
        {
            var rating = await _ratingService.GetByIdAsync(id);
            if (id == 0 && rating == null)
                return View(new CommentViewModel() { Rating = new RatingDto { Id = 0 } });
            else
            {
                var orderItem = await _orderItemService.GetByIdAsync(orderItemId);
                var model = new CommentViewModel() { Rating = _mapper.Map<RatingDto>(rating), HasComment = orderItem.HasComment, OrderItemId = orderItem.Id };
                return View(model);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CommentAddOrEdit([FromForm] CommentViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var orderItem = await _orderItemService.SingleOrDefaultAsync(p => p.Id == model.OrderItemId);
                    model.Rating.ProductId = orderItem.ProductId;
                    model.Rating.OrderItemId = orderItem.Id;
                    await _orderItemService.AddComment(model.OrderItemId);
                    if (model.Rating.Id == 0)
                    {
                        model.Rating.CreationDate = DateTime.Now;
                        await _ratingService.AddAsync(_mapper.Map<Rating>(model.Rating));
                    }
                    else
                    {
                        model.Rating.DateOfUpdate = DateTime.Now;
                        _ratingService.Update(_mapper.Map<Rating>(model.Rating));
                    }
                    return Json(new { isValid = true, success = true, message = Messages.JSON_CREATE_MESSAGE("Comentario"), redirectUrl = "/my-orders" });
                }
                return Json(new { isValid = false, success = false, message = Messages.JSON_CREATE_MESSAGE("Comentario", false), redirectUrl = "/my-orders" });
            }
            catch (Exception)
            {
                return Json(new { isValid = false, success = false, message = Messages.JSON_CREATE_MESSAGE("Comentario", false), redirectUrl = "/my-orders" });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Checkout()
        {
            if (!User.Identity.IsAuthenticated)
            {
                // Opción 1: Redirigir al usuario a la página de inicio de sesión
                return RedirectToAction("Register", "Account");
            }
            var cart = await CartHelper.GetProductsFromCart(_cartService, _userManager, User);
            ViewData["CartItemLength"] = cart.CartItems.Count;
            var model = new OrderViewModel() { CartViewModel = cart };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Checkout(OrderViewModel orderModel)
        {

            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(User);
                var user = await _userManager.GetUserAsync(User);
                if (user != null)
                {
                    // Asegúrarse que asigne al DTO o modelo adecuado
                    orderModel.OrderDto.Email = user.Email;
                }

                var cart = await _cartService.GetCartByUserId(userId);


                orderModel.CartViewModel = new CartViewModel()
                {
                    CartId = cart.Id,
                    CartItems = cart.CartItems.Select(i => new CartItemViewModel()
                    {
                        CartItemDto = new Core.Shared.DTOs.CartItemDto
                        {
                            Id = i.Id,
                            ProductId = i.ProductId,
                            Price = (int)i.Price,
                            Quantity = i.Quantity,
                            Color = i.Color
                        },
                        Name = i.Product.Name,
                        ImageUrl = i.Product.MainImage,
                    }).ToList()
                };

                var payment = PaymentHelper.PaymentProcess(orderModel);

                if (payment.Status == "success")
                {
                    // Guardar la orden y obtener el DTO de la orden guardada
                    var orderDto = await PaymentHelper.SaveOrder(_mapper, _orderService, orderModel, payment, userId);
                    // Aquí es donde podrías actualizar el stock y enviar correos
                    await UpdateStockAndSendEmails(orderDto);

                    await _cartService.ResetCart(cart.Id);
                    return Json(new { success = true, message = "El pedido es exitoso." });
                }
                else
                {
                    return Json(new { success = false, message = payment.ErrorMessage });
                }
            }
            return View(orderModel);
        }

        private async Task UpdateStockAndSendEmails(OrderDto orderDto)
        {
            // Ejemplo de actualización de stock
            foreach (var item in orderDto.OrderItems)
            {
                var product = await _productService.GetProductByIdAsync(item.ProductId);
                if (product != null && product.CountInStock >= item.Quantity)
                {
                    product.CountInStock -= item.Quantity;
                    await _productService.UpdateAsync(product);
                }
            }

            // Envío de correos
            var buyerEmail = orderDto.Email; // Email del comprador
            Console.WriteLine(buyerEmail);
            var sellerEmail = "email_del_vendedor@example.com"; // Define cómo obtener este valor
            await _emailSender.SendEmailAsync(buyerEmail, "Confirmación de pedido", "Su pedido ha sido exitoso.");
            await _emailSender.SendEmailAsync(sellerEmail, "Nuevo pedido", "Has recibido un nuevo pedido.");
        }
    }
}
