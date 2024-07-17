using E_Commerce_App.Core.Entities;
using E_Commerce_App.Core.Services;
using E_Commerce_App.Core.Shared.DTOs;
using E_Commerce_App.WebUI.Identity;
using E_Commerce_App.WebUI.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_App.WebUI.Helpers
{
    public class CartHelper
    {
        public static async Task<CartViewModel> GetProductsFromCart(ICartService _cartService, UserManager<User> _userManager, System.Security.Claims.ClaimsPrincipal User)
        {
            var userId = _userManager.GetUserId(User);
            var cart = await _cartService.GetCartByUserId(userId);

            if (cart == null)
            {
                // Retorna un modelo de carrito vacío o maneja según sea necesario
                return new CartViewModel()
                {
                    CartItems = new List<CartItemViewModel>()
                };
            }

            var model = new CartViewModel()
            {
                CartId = cart.Id,
                CartItems = cart.CartItems.Where(i => i.Product != null).Select(i => new CartItemViewModel()
                {
                    CartItemDto = new CartItemDto
                    {
                        // Propiedades
                        Id = i.Id,
                        ProductId = i.ProductId,
                        Price = (double)i.Price,
                        Quantity = i.Quantity,
                        Color = i.Color
                    },
                    Name = i.Product.Name,
                    ImageUrl = i.Product.MainImage,
                }).ToList()
            };

            return model;
        }


        public static CartViewModel TransformSessionCartToViewModel(List<CartItemDto> sessionCartItems)
        {
            var cartViewModel = new CartViewModel
            {
                CartItems = sessionCartItems.Select(ci => new CartItemViewModel
                {
                    CartItemDto = ci, // Directamente asignamos el DTO a la propiedad
                    Name = ci.Product?.Name, // Asumimos que Product puede ser nulo
                    ImageUrl = ci.Product?.MainImage // Asumimos que Product puede ser nulo
                }).ToList()
            };

            return cartViewModel;
        }

    }
}
