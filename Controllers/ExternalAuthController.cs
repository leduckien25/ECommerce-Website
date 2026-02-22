using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebApplicationMvc.Controllers
{
    public class ExternalAuthController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public ExternalAuthController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult LoginGoogle()
        {
            var redirectUrl = "/Account/GoogleResponse";

            var properties = new AuthenticationProperties { RedirectUri = redirectUrl };

            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }

        /// <summary>
        /// Handle the response from Google after authentication.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> GoogleResponse()
        {
            var result = await HttpContext.AuthenticateAsync(GoogleDefaults.AuthenticationScheme);
            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "External authentication error");
                return View("Login");
            }

            var principal = result.Principal;

            var email = principal.FindFirst(ClaimTypes.Email)?.Value;

            if (email == null)
            {
                ModelState.AddModelError(string.Empty, "Email claim not found");
                return View("Login");
            }

            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                user = new IdentityUser
                {
                    UserName = email.Substring(0, email.IndexOf('@')),
                    Email = email
                };
                await _userManager.CreateAsync(user);
            }

            await _signInManager.SignInAsync(user, isPersistent: true);
            return Redirect("/");
        }
    }
}
