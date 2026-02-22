using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json;
using WebApplicationMvc.Controllers;
using WebApplicationMvc.ViewModels;

public class AccountController : Controller
{
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;


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
        return View(model);
    }


    /// <summary>
    /// Logout the current user and clear session and cookies.
    /// </summary>
    /// <returns></returns>
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> LogoutAsync()
    {
        await _signInManager.SignOutAsync();
        HttpContext.Session.Clear();

        return Redirect("/account/login");
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
        return RedirectToAction("ConfirmPassword", "Password", new { returnUrl = "/account/ApplyDeleteAccount" });
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