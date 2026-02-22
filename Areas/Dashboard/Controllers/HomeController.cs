using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplicationMvc.Services.Interfaces;

namespace WebApplicationMvc.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize(Roles = "Admin, Manager")]
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly ISupplierService _supplierService;
        private readonly IOrderService _orderService;

        public HomeController(IProductService productService, ICategoryService categoryService, ISupplierService supplierService, IOrderService orderService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _supplierService = supplierService;
            _orderService = orderService;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Dashboard";
            ViewBag.TotalCategories = _categoryService.GetCategoriesCount();
            ViewBag.TotalSuppliers = _supplierService.GetSuppliersCount();
            ViewBag.TotalProducts = _productService.GetProductsCount();
            ViewBag.TotalOrders = _orderService.GetOrdersCount();
            ViewBag.TotalRevenue = _orderService.GetTotalRevenue();
            var orders = _orderService.GetRecentOrders();
            return View(orders);
        }
    }
}
