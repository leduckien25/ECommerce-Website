using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplicationMvc.Controllers;
using WebApplicationMvc.Models;
using WebApplicationMvc.Services;

namespace WebApplicationMvc.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize(Roles = "Admin, Manager")]
    public class ProductController : BaseController
    {
        public IActionResult Index([FromRoute(Name = "id")] int page = 1)
        {
            var products = Provider.Product.GetProductsWithDetails(out int pages, page);

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = pages;
            ViewData["Title"] = "Products";

            return View(products);
        }

        public IActionResult Details(int id)
        {
            var categories = Provider.Category.GetCategories();
            var suppliers = Provider.Supplier.GetSuppliers();

            SelectList categoriesList = new SelectList(categories, "CategoryId", "CategoryName");
            SelectList suppliersList = new SelectList(suppliers, "SupplierId", "SupplierName");

            ViewBag.Categories = categoriesList;
            ViewBag.Suppliers = suppliersList;

            var product = Provider.Product.GetProductWithDetails(id);
            if (product == null) return NotFound();
            ViewData["Title"] = "Product Details";
            return View(product);
        }

        [HttpPost]
        public IActionResult Update(Product product, IFormFile? file)
        {
            if (file != null)
            {
                var newImage = Helper.SaveImage(product, file);

                if (newImage != null)
                {
                    product.ImageUrl = newImage;
                }
            }

            int ret = Provider.Product.UpdateProduct(product);

            if (ret > 0)
            {
                TempData["message"] = "Product updated successfully.";

            }
            else
            {
                TempData["message"] = "Failed to update product.";
            }

            return Redirect($"/dashboard/product/details/{product.ProductId}");
        }

        public IActionResult Add()
        {
            var categories = Provider.Category.GetCategories();
            var suppliers = Provider.Supplier.GetSuppliers();

            SelectList categoriesList = new SelectList(categories, "CategoryId", "CategoryName");
            SelectList suppliersList = new SelectList(suppliers, "SupplierId", "SupplierName");

            ViewBag.Categories = categoriesList;
            ViewBag.Suppliers = suppliersList;
            ViewData["Title"] = "Add product";
            return View();
        }

        [HttpPost]
        public IActionResult Add(Product model, IFormFile file)
        {
            model.ImageUrl = Helper.SaveImage(model, file);

            int ret = Provider.Product.Add(model);

            if (ret > 0)
            {
                TempData["message"] = "Add product successfully";
            }
            else
            {
                TempData["message"] = "Failed to add product";
            }
            return Redirect("/dashboard/product");
        }

        public IActionResult Delete(int id)
        {
            int ret = Provider.Product.Delete(id);

            if (ret > 0)
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
