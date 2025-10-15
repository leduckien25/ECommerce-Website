using Microsoft.AspNetCore.Mvc;

namespace WebApplicationMvc.Controllers
{
    public class ContactController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
