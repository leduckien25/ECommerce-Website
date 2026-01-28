using Microsoft.AspNetCore.Mvc;
using WebApplicationMvc.Services.Interfaces;

namespace WebApplicationMvc.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly ISupplierService _supplierService;

        const int pageSize = 9;

        public ProductController(
            IProductService productService,
            ICategoryService categoryService,
            ISupplierService supplierService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _supplierService = supplierService;
        }

        [HttpGet("/product/index/{p?}")]
        public IActionResult Index(int p = 1)
        {
            ViewData["Title"] = "Product";

            ViewBag.Categories = _categoryService.GetCategories();
            ViewBag.Suppliers = _supplierService.GetSuppliers();
            ViewBag.Products = _productService.GetProducts(pageSize, p, out int pages);

            ViewBag.TotalPages = pages;
            ViewBag.CurrentPage = p;

            return View();
        }

        [HttpGet("/product/category/{id}/{p?}")]
        public IActionResult Category(short id, int p = 1)
        {
            ViewData["Title"] = "Product";

            var products = _productService
                .GetProductsByCategory(id, pageSize, p, out int pages)
                .ToList();

            ViewBag.Categories = _categoryService.GetCategories();
            ViewBag.Suppliers = _supplierService.GetSuppliers();
            ViewBag.Products = products;
            ViewBag.TotalPages = pages;
            ViewBag.CurrentPage = p;
            ViewBag.CategoryId = id;

            return View();
        }

        [HttpGet("/product/supplier/{id}/{p?}")]
        public IActionResult Supplier(string id, int p = 1)
        {
            ViewData["Title"] = "Product";

            var products = _productService
                .GetProductsBySupplier(id, pageSize, p, out int pages)
                .ToList();

            ViewBag.Categories = _categoryService.GetCategories();
            ViewBag.Suppliers = _supplierService.GetSuppliers();
            ViewBag.Products = products;
            ViewBag.TotalPages = pages;
            ViewBag.CurrentPage = p;
            ViewBag.SupplierId = id;

            return View();
        }

        public IActionResult Details(int id)
        {
            ViewData["Title"] = "Detail";

            var product = _productService.GetProduct(id);
            if (product == null)
                return NotFound();

            ViewBag.Product = product;
            ViewBag.Categories = _categoryService.GetCategories();
            ViewBag.Suppliers = _supplierService.GetSuppliers();
            ViewBag.ProductsRelation =
                _productService.GetRelatedProducts(product.ProductId, 6);

            return View();
        }

    }
}