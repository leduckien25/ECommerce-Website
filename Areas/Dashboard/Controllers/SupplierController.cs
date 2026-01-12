using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplicationMvc.Controllers;
using WebApplicationMvc.Models;

namespace WebApplicationMvc.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize(Roles = "Admin, Manager")]
    public class SupplierController : BaseController
    {
        public IActionResult Index([FromRoute(Name = "id")] int page = 1)
        {
            var suppliers = Provider.Supplier.GetSuppliers(out int pages, page);

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = pages;

            return View(suppliers);
        }

        public IActionResult Details(string id)
        {
            ViewData["Title"] = "Supplier Details";
            return View(Provider.Supplier.GetSupplierWithProducts(id));
        }

        public IActionResult Update(Supplier supplier)
        {
            int ret = Provider.Supplier.Update(supplier);

            if (ret > 0)
            {
                TempData["message"] = "Update supplier successfully";
            }
            else
            {
                TempData["message"] = "Failed to update supplier";
            }
            return Redirect("/dashboard/supplier");
        }

        public IActionResult Delete(string id)
        {
            int ret = Provider.Supplier.Delete(id);

            if (ret > 0)
            {
                TempData["message"] = "Delete supplier successfully";
            }
            else
            {
                TempData["message"] = "Failed to delete supplier";
            }
            return Redirect("/dashboard/supplier");
        }

        public IActionResult Add() => View();
        [HttpPost]
        public IActionResult Add(Supplier supplier)
        {

            int ret = Provider.Supplier.Add(supplier);

            if (ret > 0)
            {
                TempData["message"] = "Add supplier successfully";
            }
            else
            {
                TempData["message"] = "Failed to add supplier";
            }
            return Redirect("/dashboard/supplier");
        }
    }
}
