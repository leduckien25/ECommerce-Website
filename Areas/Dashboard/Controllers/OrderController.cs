using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplicationMvc.Controllers;
using WebApplicationMvc.Models;

namespace WebApplicationMvc.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize(Roles = "Admin, Manager")]
    public class OrderController : BaseController
    {
        public IActionResult Index([FromRoute(Name = "id")] int page = 1)
        {
            ViewData["Title"] = "Orders";
            var orders = Provider.Order.GetOrders(out int totalPages, page);
            ViewBag.TotalPages = totalPages;
            ViewBag.CurrentPage = page;
            return View(orders);
        }


        public IActionResult Details(int id)
        {
            return View(Provider.Order.GetOrderById(id));
        }

        public IActionResult UpdateStatus(int id, string status)
        {
            var order = Provider.Order.GetOrderById(id);
            if (order == null)
                return NotFound();

            int ret = Provider.Order.UpdateOrder(id, status);

            if (ret > 0)
            {
                return Json(new
                {
                    success = true,
                    message = "Order status updated successfully."
                });
            }
            else
            {
                return Json(new
                {
                    success = false,
                    message = "Failed to update order status."
                });
            }

        }

    }

}
