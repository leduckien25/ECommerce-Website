using Microsoft.AspNetCore.Mvc;
using WebApplicationMvc.Providers;

namespace WebApplicationMvc.Controllers
{
    public abstract class BaseController : Controller
    {
        UnitOfWork provider;
        public UnitOfWork Provider
        {
            get
            {
                return provider ??= HttpContext.RequestServices.GetRequiredService<UnitOfWork>();
            }
        }
        protected string PreviousPageUrl => Request.Headers["Referer"].ToString();
    }
}
