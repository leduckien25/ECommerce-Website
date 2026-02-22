using Microsoft.AspNetCore.Mvc;

namespace WebApplicationMvc.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
