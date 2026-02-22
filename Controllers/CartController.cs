using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplicationMvc.Models;
using WebApplicationMvc.Services;
using WebApplicationMvc.Services.Interfaces;
using WebApplicationMvc.Services.Payment;
using WebApplicationMvc.ViewModels;

namespace WebApplicationMvc.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly VnPayService _vnPayService;
        private readonly ICartService _cartService;

        public CartController(VnPayService service, ICartService cartService)
        {
            this._vnPayService = service;
            this._cartService = cartService;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Shopping Cart";

            var userId = User.GetUserId();
            return View(_cartService.GetCart(userId));
        }
        public IActionResult AddToCart(int productId, int quantity = 1)
        {
            var userId = User.GetUserId();

            int ret = _cartService.AddItem(userId, productId, quantity);

            if (ret > 0)
            {
                HttpContext.Session.SetInt32("CartCount", _cartService.GetItemCount(userId));
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int cartItemId)
        {
            int ret = _cartService.RemoveItem(cartItemId);

            if (ret > 0)
            {
                HttpContext.Session.SetInt32("CartCount", _cartService.GetItemCount(User.GetUserId()));
            }
            return RedirectToAction("Index");
        }

    }
}

