using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplicationMvc.Controllers;
using WebApplicationMvc.Models;

namespace WebApplicationMvc.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize(Roles = "Admin, Manager")]
    public class CategoryController : BaseController
    {
        public IActionResult Index([FromRoute(Name = "id")] int page = 1)
        {
            var categories = Provider.Category.GetCategories(out int pages, page);

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = pages;

            return View(categories);
        }

        public IActionResult Details(short id)
        {
            ViewData["Title"] = "Category Details";
            return View(Provider.Category.GetCategoryWithProducts(id));
        }

        public IActionResult Update(Category category)
        {
            int ret = Provider.Category.Update(category);

            if (ret > 0)
            {
                TempData["message"] = "Update category successfully";
            }
            else
            {
                TempData["message"] = "Failed to update category";
            }
            return Redirect("/dashboard/category");
        }

        public IActionResult Delete(short id)
        {
            int ret = Provider.Category.Delete(id);

            if (ret > 0)
            {
                TempData["message"] = "Delete category successfully";
            }
            else
            {
                TempData["message"] = "Failed to delete category";
            }
            return Redirect("/dashboard/category");
        }

        public IActionResult Add() => View();
        [HttpPost]
        public IActionResult Add(Category category)
        {
            int ret = Provider.Category.Add(category);

            if (ret > 0)
            {
                TempData["message"] = "Add category successfully";
            }
            else
            {
                TempData["message"] = "Failed to add category";
            }
            return Redirect("/dashboard/category");
        }
    }
}