using AspNetCoreGeneratedDocument;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplicationMvc.Controllers;
using WebApplicationMvc.Models;
using WebApplicationMvc.Services.Interfaces;

namespace WebApplicationMvc.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize(Roles = "Admin, Manager")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly int pageSize = 12;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index(int page = 1)
        {
            var categories = _categoryService.GetCategoriesForAdmin(page, pageSize);

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = _categoryService.GetTotalPages(pageSize);

            return View(categories);
        }

        public IActionResult Details(short id)
        {
            ViewData["Title"] = "Category Details";
            return View(_categoryService.GetCategoryWithProducts(id));
        }

        public IActionResult Update(Category category)
        {
            if (_categoryService.Update(category))
                TempData["message"] = "Update category successfully";
            else
                TempData["message"] = "Failed to update category";

            return Redirect("/dashboard/category");
        }

        public IActionResult Delete(short id)
        {
            if (_categoryService.Delete(id))
                TempData["message"] = "Delete category successfully";
            else
                TempData["message"] = "Failed to delete category";

            return Redirect("/dashboard/category");
        }

        public IActionResult Add() => View();
        [HttpPost]
        public IActionResult Add(Category category)
        {
            var newCategory = _categoryService.Create(category);

            if (newCategory is not null)
                TempData["message"] = "Add category successfully";
            else
                TempData["message"] = "Failed to add category";

            return Redirect("/dashboard/category");
        }
    }
}