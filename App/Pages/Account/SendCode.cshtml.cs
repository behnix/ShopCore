using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Domain.Identity;
using App.DTOs.Account;
using App.Services.Identity;
using App.Services.Identity.Managers;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace App.Pages.Account
{
    public class SendCodeModel : PageModel
    {
        private readonly AppSignInManager _signInManager;
        private readonly AppUserManager _userManager;
        private readonly IEmailSender _emailSender;
        private readonly ISmsSender _smsSender;

        public SendCodeModel(AppSignInManager signInManager, AppUserManager userManager, IEmailSender emailSender, ISmsSender smsSender)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _emailSender = emailSender;
            _smsSender = smsSender;
        }
        public async Task<IActionResult> OnGet(string returnTo, bool rememberMe)
        {
            var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();

            if (user == null)
            {
                return RedirectToPage("/Error");
            }

            var providers = await _userManager.GetValidTwoFactorProvidersAsync(user);


            var providerList = providers.Select(provider => new SelectListItem { Value = provider, Text = provider })
                .ToList();
            SendCode = new SendCode()
            {
                Providers = providerList,
                RememberMe = rememberMe,
                ReturnTo = returnTo
            };

            return Page();
        }
        [BindProperty]
        public SendCode SendCode { get; set; }
        public async Task<IActionResult> OnPostAsync(bool returnTo)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();

            if (user == null)
            {
                return RedirectToPage("/Error");
            }

            var code = await _userManager.GenerateTwoFactorTokenAsync(user, SendCode.SelectedProvider);

            if (string.IsNullOrEmpty(code))
            {
                return RedirectToPage("/Error");
            }

            var message = $"Confirm Code: {code}";

            if (SendCode.SelectedProvider == "Email")
            {
                await _emailSender.SendEmailAsync(user.Email, "Confirm Code", message);
            }
            else if (SendCode.SelectedProvider == "Phone")
            {
                await _smsSender.SendSmsAsync(user.PhoneNumber, message);
            }


            return RedirectToPage("verifyCode",
                new
                {
                    returnTo = returnTo,
                    rememberMe = SendCode.RememberMe,
                    provider = SendCode.SelectedProvider,
                });
        }
    }
}