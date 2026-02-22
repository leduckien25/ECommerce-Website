using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplicationMvc.Controllers;
using WebApplicationMvc.Models;
using WebApplicationMvc.Services.Interfaces;

namespace WebApplicationMvc.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize(Roles = "Admin, Manager")]
    public class SupplierController : Controller
    {
        private readonly ISupplierService _supplierService;
        private readonly int pageSize = 12;

        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        public IActionResult Index([FromRoute(Name = "id")] int page = 1)
        {
            var suppliers = _supplierService.GetSuppliersForAdmin(page, pageSize);

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = _supplierService.GetTotalPages(pageSize);

            return View(suppliers);
        }

        public IActionResult Details(string id)
        {
            ViewData["Title"] = "Supplier Details";
            return View(_supplierService.GetSupplierWithProducts(id));
        }

        public IActionResult Update(Supplier supplier)
        {
            if (_supplierService.Update(supplier))
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

            if (_supplierService.Delete(id))
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

            var newSupplier = _supplierService.Create(supplier);

            if (newSupplier is not null)
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
