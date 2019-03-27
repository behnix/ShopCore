using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Domain.Entities.Invoice;
using App.Domain.Identity;
using App.Services.Identity.Managers;
using App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.Pages.Account
{
    public class UserAreaModel : PageModel
    {
        private readonly AppUserManager _userManager;
        private readonly AppSignInManager _signInManager;
        private readonly IInvoiceService _invoiceService;

        public UserAreaModel(AppUserManager userManager, AppSignInManager signInManager, IInvoiceService invoiceService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _invoiceService = invoiceService;
        }
        public User UserArea { get; set; }
        public List<Invoice> Invoice { get; set; }
        public async Task<IActionResult> OnGet()
        {
            UserArea = await _userManager.FindByNameAsync(User.Identity.Name);
            Invoice = await _invoiceService.GetAllInvoiceByUserId(UserArea.Id);
            return Page();
        }
        
    }
}