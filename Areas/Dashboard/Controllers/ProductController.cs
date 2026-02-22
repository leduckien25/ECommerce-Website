using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.DotNet.Scaffolding.Shared;
using WebApplicationMvc.Controllers;
using WebApplicationMvc.Models;
using WebApplicationMvc.Services;
using WebApplicationMvc.Services.Interfaces;

namespace WebApplicationMvc.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize(Roles = "Admin, Manager")]
    public class ProductController : Controller
    {
        private readonly int pageSize = 12;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly ISupplierService _supplierService;

        public ProductController(IProductService productService, ICategoryService categoryService, ISupplierService supplierService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _supplierService = supplierService;
        }

        public IActionResult Index([FromRoute(Name = "id")] int page = 1)
        {
            var products = _productService.GetProductsWithDetails(page, pageSize);

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = _productService.GetTotalPages();
            ViewData["Title"] = "Products";

            return View(products);
        }

        public IActionResult Details(int id)
        {
            var categories = _categoryService.GetCategoriesForDisplay();
            var suppliers = _supplierService.GetSuppliersForDisplay();

            ViewBag.CategoriesList = new SelectList(categories, "CategoryId", "CategoryName");
            ViewBag.SuppliersList = new SelectList(suppliers, "SupplierId", "SupplierName");

            var product = _productService.GetProductWithDetails(id);

            if (product == null)
                return NotFound();

            ViewData["Title"] = "Product Details";
            return View(product);
        }

        [HttpPost]
        public IActionResult Update(Product product, IFormFile? file)
        {
            if (_productService.UpdateProduct(product, file))
                TempData["message"] = "Product updated successfully.";
            else
                TempData["message"] = "Failed to update product.";

            return Redirect($"/dashboard/product/details/{product.ProductId}");
        }

        public IActionResult Add()
        {
            var categories = _categoryService.GetCategoriesForDisplay();
            var suppliers = _supplierService.GetSuppliersForDisplay();

            ViewBag.CategoriesList = new SelectList(categories, "CategoryId", "CategoryName");
            ViewBag.SuppliersList = new SelectList(suppliers, "SupplierId", "SupplierName");

            ViewData["Title"] = "Add product";
            return View();
        }

        [HttpPost]
        public IActionResult Add(Product product, IFormFile file)
        {
            if (_productService.AddProduct(product, file))
                TempData["message"] = "Add product successfully";
            else
                TempData["message"] = "Failed to add product";

            return Redirect("/dashboard/product");
        }

        public IActionResult Delete(int id)
        {

            if (_productService.Delete(id))
            {
                return Redirect("/dashboard/product");
            }
            else
            {
                return NotFound();
            }

        }
    }
}