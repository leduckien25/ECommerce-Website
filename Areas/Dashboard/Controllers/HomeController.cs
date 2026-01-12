using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplicationMvc.Controllers;

namespace WebApplicationMvc.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize(Roles = "Admin, Manager")]
    public class HomeController : BaseController
    {
        UserManager<IdentityUser> _userManager;

        public HomeController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Dashboard";
            ViewBag.TotalCategories = Provider.Category.GetCategoriesCount();
            ViewBag.TotalSuppliers = Provider.Supplier.GetSuppliersCount();
            ViewBag.TotalProducts = Provider.Product.GetProductsCount();
            ViewBag.TotalOrders = Provider.Order.GetOrdersCount();
            ViewBag.TotalRevenue = Provider.Order.GetTotalRevenue();
            var orders = Provider.Order.GetRecentOrders();
            return View(orders);
        }
    }
}
