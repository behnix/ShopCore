using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.DTOs.Account;
using App.Services.Identity.Managers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.Pages.Account
{
    public class VerifyCodeModel : PageModel
    {
        private readonly AppSignInManager _signInManager;
        private readonly AppUserManager _userManager;

        public VerifyCodeModel(AppSignInManager signInManager, AppUserManager userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> OnGet(string returnTo, bool rememberMe, string provider)
        {
            var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();

            if (user == null)
            {
                return RedirectToPage("/Error");
            }

            VerifyCode = new VerifyCode
            {
                RememberMe = rememberMe,
                ReturnTo = returnTo,
                Provider = provider
            };

            return Page();
        }
        [BindProperty]
        public VerifyCode VerifyCode { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }


            var result = await _signInManager.TwoFactorSignInAsync(
                provider: VerifyCode.Provider,
                code: VerifyCode.Code,
                isPersistent: VerifyCode.RememberMe,
                rememberClient: VerifyCode.BrowserRemember
            );


            if (result.Succeeded)
            {
                return RedirectToLocal(VerifyCode.ReturnTo);
            }

            if (result.IsLockedOut)
            {
                return RedirectToPage("/Lockout");
            }

            ModelState.AddModelError(nameof(VerifyCode.Code), "کد وارد شده معتبر نمی باشد");

            return Page();
        }

        private IActionResult RedirectToLocal(string returnTo)
        {
            return Redirect(Url.IsLocalUrl(returnTo) ? returnTo : "/Index");
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
                ModelState.AddModelError(string.Empty, error.Description);
        }
    }
}