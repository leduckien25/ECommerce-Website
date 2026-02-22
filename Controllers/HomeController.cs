using Microsoft.AspNetCore.Mvc;
using WebApplicationMvc.Services;
using WebApplicationMvc.Services.Interfaces;

namespace WebApplicationMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICartService _cartService;

        public HomeController(ICartService cartService)
        {
            _cartService = cartService;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Home";
            if (User?.Identity != null && User.Identity.IsAuthenticated)
                HttpContext.Session.SetInt32("CartCount", _cartService.GetItemCount(User.GetUserId()));

            return View();
        }
    }
}
