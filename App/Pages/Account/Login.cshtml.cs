using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using App.Domain.Identity;
using App.DTOs.Account;
using App.Services.Identity.Managers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly AppUserManager _userManager;
        private readonly AppSignInManager _signInManager;

        public LoginModel(AppUserManager userManager, AppSignInManager signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult OnGet(string returnTo)
        {
            return Page();
        }

        [BindProperty]
        public LoginAccountViewModel Account { get; set; }

        public async Task<IActionResult> OnPostAsync(string returnTo)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(
                    userName: Account.UserName,
                    password: Account.Password,
                    isPersistent: Account.RememberMe,
                    lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    return RedirectToLocal(returnTo);
                }

                if (result.RequiresTwoFactor)
                {
                    return RedirectToPage("SendCode", new { returnTo, rememberMe = Account.RememberMe });
                }

                if (result.IsLockedOut)
                {
                    // todo create lockout view
                    return RedirectToPage("/LockOut");
                }

                if (result.IsNotAllowed)
                {
                    if (_userManager.Options.SignIn.RequireConfirmedPhoneNumber)
                    {
                        if (!await _userManager.IsPhoneNumberConfirmedAsync(new User { UserName = Account.UserName }))
                        {
                            ModelState.AddModelError(string.Empty, "شماره تلفن شما تایید نشده است.");
                            return RedirectToPage("/Login");
                        }
                    }

                    if (_userManager.Options.SignIn.RequireConfirmedEmail)
                    {
                        if (!await _userManager.IsEmailConfirmedAsync(new User { UserName = Account.UserName }))
                        {
                            ModelState.AddModelError(string.Empty, "آدرس اییل شما تایید نشده است.");
                            return RedirectToPage("/Login");
                        }
                    }

                }
            }
            return RedirectToPage();
        }

        private IActionResult RedirectToLocal(string returnTo)
        {
            if (string.IsNullOrWhiteSpace(returnTo))
            {
                return Redirect("/userarea");
            }
            var slash = returnTo.IndexOf("/");
            var page = returnTo.Substring(0, slash);
            var parameter = returnTo.Substring(slash + 1);

            if (page == "product")
            {
                return RedirectToPage("/" + page, new {metaTitle = parameter});
            }

            if (page == "post")
            {
                return RedirectToPage("/" + page, new {metaTitle = parameter});
            }

            if (string.IsNullOrWhiteSpace(parameter))
            {
                return RedirectToPage("/" + page);
            }
            return Redirect("/");
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
                ModelState.AddModelError(string.Empty, error.Description);
        }
    }
}