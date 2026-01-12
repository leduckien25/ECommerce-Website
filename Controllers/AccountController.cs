using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json;
using WebApplicationMvc.Controllers;
using WebApplicationMvc.ViewModels;

public class AccountController : BaseController
{
    SignInManager<IdentityUser> _signInManager;
    UserManager<IdentityUser> _userManager;


    public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }

    public IActionResult Login()
    {
        ViewData["Title"] = "Login";
        return View();
    }

    /// <summary>
    /// Authenticate the user with the provided credentials.
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>

    [HttpPost]
    public async Task<IActionResult> LoginAsync(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, false);

            if (result.Succeeded)
            {
                return Redirect("/");
            }
            ModelState.AddModelError("", "Invalid login attempt");
        }
        return View(model);
    }
    public IActionResult Register()
    {
        ViewData["Title"] = "Register";
        return View();
    }

    /// <summary>
    /// Register a new user with the provided details.
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> RegisterAsync(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            if (model.Password == model.ConfirmPassword)
            {
                var user = new IdentityUser
                {
                    UserName = model.Username,
                    Email = model.Email
                };

                var result = await _userManager.CreateAsync(user, model.Password);
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
        return View(model);
    }


    /// <summary>
    /// Logout the current user and clear session and cookies.
    /// </summary>
    /// <returns></returns>
    [Authorize]
    public async Task<IActionResult> LogoutAsync()
    {
        await _signInManager.SignOutAsync();

        HttpContext.Session.Clear();

        foreach (var cookie in Request.Cookies.Keys)
        {
            Response.Cookies.Delete(cookie);
        }
        return Redirect("/account/login");
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
    public async Task<IActionResult> ManageAsync()
    {
        ViewData["ActivePage"] = "Manage";

        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return RedirectToAction("Login");
        }

        var model = new UserViewModel
        {
            Username = user.UserName,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
        };

        ViewData["ActivePage"] = "Manage";
        return View(model);
    }


    [Authorize]
    public async Task<IActionResult> EditProfile()
    {
        var errorMessage = TempData["ErrorMessage"] as string;

        if (!string.IsNullOrEmpty(errorMessage))
        {
            ModelState.AddModelError("", errorMessage);
        }

        ViewData["ActivePage"] = "EditProfile";
        return View();
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> EditProfile(UserViewModel model)
    {
        ViewData["ActivePage"] = "EditProfile";
        ModelState.Remove("Username");

        if (ModelState.IsValid)
        {
            TempData["PendingUser"] = JsonSerializer.Serialize(model);

            return RedirectToAction("ConfirmPassword", new { returnUrl = "/account/applyprofilechanges" });
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
    public async Task<IActionResult> ApplyProfileChanges()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return RedirectToAction("Login", "Account");

        if (TempData["PendingUser"] == null)
        {
            TempData["ErrorMessage"] = "No pending changes found.";
            return RedirectToAction("EditProfile");
        }
        else
        {
            var model = JsonSerializer.Deserialize<UserViewModel>(TempData["PendingUser"] as string);
            if (model == null)
            {
                TempData["ErrorMessage"] = "Error retrieving pending changes.";
                return RedirectToAction("EditProfile");
            }
            user.Email = model.Email;
            user.PhoneNumber = model.PhoneNumber;
        }

        var result = await _userManager.UpdateAsync(user);

        if (result.Succeeded)
        {
            TempData["SuccessMessage"] = "Profile updated successfully!";
            return RedirectToAction("Manage");
        }

        foreach (var error in result.Errors)
        {
            ModelState.AddModelError("", error.Description);
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

    [Authorize]
    public IActionResult DeleteAccount()
    {
        ViewData["ActivePage"] = "DeleteAccount";
        return View();

    }
    [Authorize, HttpPost]
    public IActionResult DeleteAccountConfirm()
    {
        return RedirectToAction("ConfirmPassword", new { returnUrl = "/account/ApplyDeleteAccount" });
    }
    [Authorize]
    public async Task<IActionResult> ApplyDeleteAccount()
    {
        var user = await _userManager.GetUserAsync(User);

        if (user == null)
        {
            return Redirect("/account/Login");
        }
        var result = await _userManager.DeleteAsync(user);

        if (result.Succeeded)
        {

            return RedirectToAction("Logout");
        }
        else
        {
            return Redirect("/account/manage");
        }
    }

}