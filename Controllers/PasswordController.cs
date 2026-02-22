using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplicationMvc.ViewModels;

namespace WebApplicationMvc.Controllers
{
    public class PasswordController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public PasswordController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult ForgotPassword() => View();

        /// <summary>
        /// In a real application, you would handle this by sending an email with a reset link.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    var token = await _userManager.GeneratePasswordResetTokenAsync(user);

                    // resetLink should be sent to email user to handle
                    var resetLink = Url.Action("ResetPassword", "Account",
                        new { token, email = user.Email });

                    return Redirect(resetLink);
                }

                ModelState.AddModelError("", "Email not found.");
            }
            return View(model);
        }

        public IActionResult ResetPassword(string token, string email)
        {
            if (token == null || email == null)
            {
                return BadRequest("Invalid password reset link.");
            }
            return View(new ResetPasswordViewModel { Token = token, Email = email });
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    if (model.NewPassword == model.ConfirmPassword)
                    {
                        var result = await _userManager.ResetPasswordAsync(user, model.Token, model.NewPassword);
                        if (result.Succeeded)
                        {
                            return RedirectToAction("Login");
                        }
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Password and Confirm Password do not match");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Email not found.");
                }
            }
            return View(model);
        }

        [Authorize]
        public IActionResult ConfirmPassword(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ConfirmPassword(ConfirmPasswordViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {

                var user = await _userManager.GetUserAsync(User);

                if (user is null)
                {
                    return RedirectToAction("Login");
                }

                if (await _userManager.CheckPasswordAsync(user, model.Password))
                {
                    return Redirect(returnUrl);
                }

                TempData["ErrorMessage"] = "Incorrect password.";
            }

            return RedirectToAction("EditProfile");
        }

        [Authorize]
        public async Task<IActionResult> ChangePassword()
        {
            ViewData["ActivePage"] = "ChangePassword";
            var user = await _userManager.GetUserAsync(User);
            ViewBag.HasPassword = await _userManager.HasPasswordAsync(user);

            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);

                if (user is null)
                {
                    return RedirectToAction("Login");
                }
                else if (!(await _userManager.HasPasswordAsync(user)))
                {
                    var addPasswordResult = await _userManager.AddPasswordAsync(user, model.NewPassword);
                    if (addPasswordResult.Succeeded)
                    {
                        return RedirectToAction("Logout");
                    }
                    else
                    {
                        foreach (var err in addPasswordResult.Errors)
                        {
                            ModelState.AddModelError("", err.Description);
                        }
                        return View(model);
                    }
                }

                var result = await _signInManager.CheckPasswordSignInAsync(user, model.CurrentPassword, false);

                if (result.Succeeded)
                {
                    var changePasswordResult = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);

                    if (changePasswordResult.Succeeded)
                    {
                        return RedirectToAction("Logout");
                    }
                    foreach (var err in changePasswordResult.Errors)
                    {
                        ModelState.AddModelError("", err.Description);
                    }
                    return View(model);
                }
                ModelState.AddModelError("", "Current password is wrong");
            }

            return View(model);
        }

    }
}
