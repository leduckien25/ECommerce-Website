using Microsoft.AspNetCore.Mvc;
using WebApplicationMvc.Providers;

namespace WebApplicationMvc.Controllers
{
    public abstract class BaseController : Controller
    {
        SiteProvider provider;
        public SiteProvider Provider
        {
            get
            {
                return provider ??= HttpContext.RequestServices.GetRequiredService<SiteProvider>();
            }
        }
        protected string PreviousPageUrl => Request.Headers["Referer"].ToString();
    }
}
