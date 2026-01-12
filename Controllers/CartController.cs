using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplicationMvc.Models;
using WebApplicationMvc.Services;
using WebApplicationMvc.Services.Payment;
using WebApplicationMvc.ViewModels;

namespace WebApplicationMvc.Controllers
{
    [Authorize]
    public class CartController : BaseController
    {
        VnPayService service;
        public CartController(VnPayService service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Shopping Cart";

            var userId = User.GetUserId();
            return View(Provider.Cart.GetCart(userId));
        }
        public IActionResult AddToCart(int productId, int quantity = 1)
        {
            var userId = User.GetUserId();

            try
            {
                int ret = Provider.Cart.AddToCart(userId, productId, quantity);
            }
            catch
            {
                return NotFound();
            }

            HttpContext.Session.SetInt32("CartCount", Provider.Cart.GetCartItemCount(userId));

            if (string.IsNullOrEmpty(PreviousPageUrl))
            {
                return RedirectToAction("Index");
            }
            return Redirect(PreviousPageUrl);
        }

        public IActionResult Delete(int id)
        {
            int ret = -1;
            try
            {
                ret = Provider.Cart.Delete(id);
            }
            catch
            {
                return NotFound();
            }

            if (ret > 0)
            {
                HttpContext.Session.SetInt32("CartCount", Provider.Cart.GetCartItemCount(User.GetUserId()));
                if (string.IsNullOrEmpty(PreviousPageUrl))
                {
                    return RedirectToAction("Index");
                }
                return Redirect(PreviousPageUrl);
            }
            return NotFound();
        }

        public IActionResult Checkout()
        {
            ViewData["Title"] = "Checkout";
            var userId = User.GetUserId();
            var cart = Provider.Cart.GetCart(userId);
            if (cart == null || cart.CartItems.Count == 0)
            {
                TempData["ErrorMessage"] = "Your cart is empty.";
                return RedirectToAction("Index");
            }

            Console.WriteLine(Provider.Cart.GetTotalAmount(userId));
            return View(cart);
        }

        [HttpPost]
        public IActionResult Checkout(OrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                var order = new Order
                {
                    UserId = User.GetUserId(),
                    OrderDate = DateTime.Now,
                    TotalAmount = Provider.Cart.GetTotalAmount(User.GetUserId()) * 1000,
                    PaymentMethod = model.PaymentMethod,
                    FullName = $"{model.FirstName} {model.LastName}",
                    Address = model.Address,
                    City = model.City,
                    Country = model.Country,
                    PostalCode = model.PostalCode,
                    PhoneNumber = model.PhoneNumber,
                    Note = model.Note
                };
                order.OrderDetails = Provider.Cart.GetCart(User.GetUserId()).CartItems.Select(ci => new OrderDetail
                {
                    ProductId = ci.ProductId,
                    Quantity = ci.Quantity,
                }).ToList();

                int ret = Provider.Order.CreateOrder(order);

                if (ret > 0)
                {
                    if (model.PaymentMethod == "COD")
                    {
                        return RedirectToAction("OrderSuccess", order);
                    }
                    else
                    {
                        return Redirect(service.CreatePaymentUrl(order));
                    }
                }
                ModelState.AddModelError("", "Failed to create order. Please try again.");
            }
            return View(model);
        }
        [HttpGet("cart/VnPayResponse")]
        public IActionResult VnPaymentResponse([FromQuery] VnPaymentResponse obj)
        {
            if (obj.ResponseCode == "00")
            {
                int ret = Provider.Order.UpdateOrder(int.Parse(obj.TxnRef), "Paid");
                if (ret > 0)
                {
                    return RedirectToAction("OrderSuccess", Provider.Order.GetOrderById(int.Parse(obj.TxnRef)));
                }
            }

            return Redirect("/cart/error");
        }

        public IActionResult OrderSuccess(Order order)
        {
            ViewData["Title"] = "Order Success";
            var userId = User.GetUserId();
            Provider.Cart.ClearCart(userId);
            HttpContext.Session.SetInt32("CartCount", 0);
            return View(order);
        }
    }
}

