using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App.Data;
using App.Domain.Enums;
using App.Domain.Identity;
using App.Services.Identity.Managers;
using App.Services.Interfaces;

namespace App.Pages.Account
{
    public class EditProfileModel : PageModel
    {
        private readonly AppUserManager _userManager;
        private readonly AppSignInManager _signInManager;
        private readonly IInvoiceService _invoiceService;
        private readonly ApplicationDbContext _context;

        public EditProfileModel(AppUserManager userManager, AppSignInManager signInManager, IInvoiceService invoiceService, ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _invoiceService = invoiceService;
            _context = context;
        }

        [BindProperty]
        public User UserArea { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            UserArea = await _userManager.FindByNameAsync(User.Identity.Name);

            if (User == null)
            {
                return NotFound();
            }
            return Page();
        }

        public User User1 { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            try
            {
                 _context.Update(UserArea);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(UserArea.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./UserArea");
        }

        private bool UserExists(int id)
        {
            return _userManager.Users.Any(u => u.Id == id);
        }
    }
}
