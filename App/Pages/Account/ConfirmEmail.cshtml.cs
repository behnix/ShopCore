using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Services.Identity.Managers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace App.Pages.Account
{
    public class ConfirmEmailModel : PageModel
    {
        private readonly AppUserManager _userManager;

        public ConfirmEmailModel(AppUserManager userManager)
        {
            _userManager = userManager;
        }
        
        public async Task<IActionResult> OnGet(string key, string code)
        {
            if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(code))
            {
                return RedirectToPage("/Error");
            }

            var user = await _userManager.Users.SingleOrDefaultAsync(u=>u.GeneratedKey == key);

            if (user == null)
            {
                return RedirectToPage("/Error");
            }

            var result = await _userManager.ConfirmEmailAsync(user, code);

            if (result.Succeeded)
            {
                return Page();
            }

            return RedirectToPage("/Error");
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