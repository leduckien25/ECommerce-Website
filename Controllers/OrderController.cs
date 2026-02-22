using AutoMapper;
using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared;
using WebApplicationMvc.Models;
using WebApplicationMvc.Services;
using WebApplicationMvc.Services.Interfaces;
using WebApplicationMvc.Services.Payment;
using WebApplicationMvc.ViewModels;

namespace WebApplicationMvc.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly ICartService _cartService;
        private readonly VnPayService _vnPayService;
        private readonly IOrderService _orderService;
        private readonly IMapper mapper;

        public OrderController(ICartService cartService, VnPayService vnPayService, IOrderService orderService, IMapper mapper)
        {
            _cartService = cartService;
            _vnPayService = vnPayService;
            _orderService = orderService;
            this.mapper = mapper;
        }

        public IActionResult Checkout()
        {
            ViewData["Title"] = "Checkout";

            var userId = User.GetUserId();
            var cart = _cartService.GetCart(userId);

            if (cart == null || cart.CartItems.Count == 0)
            {
                TempData["ErrorMessage"] = "Your cart is empty.";
                return RedirectToAction("Index", "Cart");
            }

            return View(cart);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Checkout(CheckoutViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var userId = User.GetUserId();
            var order = _orderService.Create(userId, model);

            if (order is null)
            {
                ModelState.AddModelError("", "Failed to create order. Please try again.");
                return View(model);
            }

            if (model.PaymentMethod == "COD")
                return RedirectToAction("OrderSuccess", new { id = order.OrderId });

            return Redirect(_vnPayService.CreatePaymentUrl(order));
        }

        [AllowAnonymous]
        public IActionResult VnPayResponse([FromQuery] VnPaymentResponse response)
        {
            if (response.ResponseCode != "00")
                return RedirectToAction("Error", "Order");

            int orderId = int.Parse(response.TxnRef);

            if (_orderService.UpdateStatus(orderId, "Paid"))
                return RedirectToAction("OrderSuccess", new { id = orderId });
            return RedirectToAction("Error");
        }

        public IActionResult OrderSuccess(int id)
        {
            ViewData["Title"] = "Order Success";

            var order = _orderService.GetOrder(id);
            if (order == null)
                return RedirectToAction("Index", "Cart");

            if (!string.IsNullOrEmpty(order.UserId))
            {
                _cartService.ClearCart(order.UserId);
                HttpContext.Session.SetInt32("CartCount", 0);
            }

            return View(order);
        }

        public IActionResult Error()
        {
            return Content("Something went wrong!");
        }
    }
}