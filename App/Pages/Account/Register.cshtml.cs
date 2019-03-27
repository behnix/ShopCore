using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using App.Data;
using App.Domain.Identity;
using App.DTOs.Account;
using App.Services.Identity;
using App.Services.Identity.Managers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace App.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly AppUserManager _userManager;
        private readonly AppSignInManager _signInManager;
        private readonly ISmsSender _smsSender;
        private readonly IEmailSender _emailSender;

        public RegisterModel(AppUserManager userManager, AppSignInManager signInManager, IEmailSender emailSender, ISmsSender smsSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _smsSender = smsSender;
        }

        public IActionResult OnGet(string returnTo)
        {
            return Page();
        }

        [BindProperty]
        public RegisterAccountViewModel User { get; set; }

        public async Task<IActionResult> OnPostAsync(string returnTo)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var user = new User()
            {
                FirstName = User.FirstName,
                LastName = User.LastName,
                UserName = User.UserName,
                Email = User.Email,
                RegisteredOn = User.RegisteredOn,
                GeneratedKey = Guid.NewGuid().ToString("N")
            };
            var result = await _userManager.CreateAsync(user, User.Password);

            if (result.Succeeded)
            {
                if (_userManager.Options.SignIn.RequireConfirmedEmail)
                {
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { key = user.GeneratedKey, code = code },
                        protocol: Request.Scheme);

                    var message = $"<a href=\'{callbackUrl}\'> Confirm Email </a>";

                    await _emailSender.SendEmailAsync(user.Email, "Confirm Email", message);

                    await _signInManager.SignInAsync(user, false);

                    return RedirectToLocal("/VerificationAccount");
                }

                await _signInManager.SignInAsync(user, true);

                RedirectToLocal("/account/userArea");

            }
            this.AddErrors(result);

            return Page();
        }

        private IActionResult RedirectToLocal(string returnTo)
        {
            return Redirect(Url.IsLocalUrl(returnTo) ? returnTo : "/Index");
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
                if (!ModelState.Keys.Contains(error.Code))
                    ModelState.AddModelError(error.Code, error.Description);
        }
    }
}