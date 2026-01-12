using Microsoft.AspNetCore.Mvc;

namespace WebApplicationMvc.Controllers
{

    public class ProductController : BaseController
    {
        const int pageSize = 9;

        [HttpGet("/product/index/{p?}")]
        public IActionResult Index(int p = 1)
        {
            ViewData["Title"] = "Product";

            ViewBag.Categories = Provider.Category.GetCategoryViewModels();
            ViewBag.Suppliers = Provider.Supplier.GetSupplierViewModels();
            ViewBag.Products = Provider.Product.GetProductViewModels(pageSize, p, out int pages);
            ViewBag.TotalPages = pages;
            ViewBag.CurrentPage = p;

            return View();
        }
        [HttpGet("/product/category/{id}/{p?}")]
        public IActionResult Category(short id, int p = 1)
        {
            ViewData["Title"] = "Product";

            ViewBag.Categories = Provider.Category.GetCategoryViewModels();
            ViewBag.Suppliers = Provider.Supplier.GetSupplierViewModels();

            var products = Provider.Product.GetProductViewModelsByCategory(id, pageSize, p, out int pages).ToList();

            if (products.Count == 0)
            {
                return Redirect("/product");
            }
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
            ViewBag.Categories = Provider.Category.GetCategoryViewModels();
            ViewBag.Suppliers = Provider.Supplier.GetSupplierViewModels();
            var products = Provider.Product.GetProductViewModelsBySupplier(id, pageSize, p, out int pages).ToList();
            if (products.Count == 0)
            {
                return Redirect("/product");
            }
            ViewBag.Products = products;
            ViewBag.TotalPages = pages;
            ViewBag.CurrentPage = p;
            ViewBag.SupplierId = id;
            return View();
        }

        public IActionResult Details(int id)
        {
            ViewData["Title"] = "Detail";

            var product = Provider.Product.GetProductViewModel(id);

            if (product == null)
            {
                return Redirect("/product");
            }

            ViewBag.Product = product;
            ViewBag.Categories = Provider.Category.GetCategoryViewModels();
            ViewBag.Suppliers = Provider.Supplier.GetSupplierViewModels();
            ViewBag.ProductsRelation = Provider.Product.GetProductViewModelsRelation(product.ProductId, 6, 1, out int pages);

            return View();
        }



    }
}
