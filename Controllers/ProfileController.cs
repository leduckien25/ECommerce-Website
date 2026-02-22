using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebApplicationMvc.ViewModels;

namespace WebApplicationMvc.Controllers
{
    public class ProfileController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public ProfileController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
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
        public async Task<IActionResult> Edit()
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

    }
}
