using E_Commerce_App.Core.Services;
using E_Commerce_App.Core.Shared;
using E_Commerce_App.WebUI.Helpers;
using E_Commerce_App.WebUI.Identity;
using E_Commerce_App.WebUI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_App.WebUI.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private ICartService _cartService;
        private UserManager<User> _userManager;
        private readonly IProductService _productService;

        public CartController(ICartService cartService, UserManager<User> userManager, IProductService productService)
        {
            _cartService = cartService;
            _userManager = userManager;
            _productService = productService;
        }
        [HttpGet]
        [Route("/cart")]
        public async Task<IActionResult> Index()
        {
            var model = await CartHelper.GetProductsFromCart(_cartService, _userManager, User);
            return View(model);
        }
        [Route("/GetCartItems")]
        public async Task<IActionResult> GetCartItems()
        {
            var model = await CartHelper.GetProductsFromCart(_cartService, _userManager, User);
            return Json(new { data = model });
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(string productId, string color, int quantity, double price)
        {
            var userId = _userManager.GetUserId(User);

            if (string.IsNullOrEmpty(userId))
            {
                return Json(new { success = false, redirectUrl = "/Account/Login" });
            }

            // Obtener detalles del producto para verificar la cantidad en stock
            var product = await _productService.GetProductByIdAsync(productId);

            if (product == null)
            {
                return Json(new { success = false, message = "Producto no encontrado." });
            }

            if (product.CountInStock < quantity)
            {
                // Producto no disponible en la cantidad solicitada
                return Json(new { success = false, message = "No hay suficiente stock disponible." });
            }

            await _cartService.AddToCart(userId, productId, quantity, price, color);

            return Json(new { success = true, message = "El producto ha sido añadido al carrito." });
        }


        [HttpPost]
        [Route("/RemoveFromCart/{productId}")]
        public async Task<IActionResult> DeleteFromCart(string productId)
        {
            var userId = _userManager.GetUserId(User);
            await _cartService.DeleteProductFromCart(userId, productId);

            return Json(new
            {
                success = true,
                message = Messages.JSON_REMOVE_MESSAGE("Producto"),
                data = await CartHelper.GetProductsFromCart(_cartService, _userManager, User)
            });
        }
        private async Task ResetCart(int cartId)
        {
            await _cartService.ResetCart(cartId);
        }
    }
}
