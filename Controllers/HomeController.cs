using Microsoft.AspNetCore.Mvc;
using WebApplicationMvc.Services;

namespace WebApplicationMvc.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Home";
            if (User.Identity.IsAuthenticated)
            {
                HttpContext.Session.SetInt32("CartCount", Provider.Cart.GetCartItemCount(User.GetUserId()));
            }

            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
    }
}
