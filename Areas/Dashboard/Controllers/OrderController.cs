using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplicationMvc.Services.Interfaces;

namespace WebApplicationMvc.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize(Roles = "Admin, Manager")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly int pageSize = 12;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public IActionResult Index([FromRoute(Name = "id")] int page = 1)
        {
            ViewData["Title"] = "Orders";

            var orders = _orderService.GetOrders(page, pageSize);
            ViewBag.TotalPages = _orderService.GetTotalPages(pageSize);
            ViewBag.CurrentPage = page;
            return View(orders);
        }


        public IActionResult Details(int id)
        {
            return View(_orderService.GetOrder(id));
        }

        public IActionResult UpdateStatus(int id, string status)
        {
            if (_orderService.UpdateStatus(id, status))
                TempData["Message"] = "Update order successfully";
            else
                TempData["Message"] = "Failed to update order";

            return Redirect("/dashboard/order");
        }

    }

}
