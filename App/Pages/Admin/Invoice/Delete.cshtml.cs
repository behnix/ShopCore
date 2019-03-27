using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using App.Data;
using App.Domain.Entities.Product;
using App.Services.Interfaces;

namespace App.Pages.Admin.Invoice
{
    public class DeleteModel : PageModel
    {
        private readonly IInvoiceService _invoiceService;

        public DeleteModel(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [BindProperty]
        public Domain.Entities.Invoice.Invoice Invoice { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Invoice = await _invoiceService.GetInvoiceById(id);

            if (Invoice == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            Invoice = await _invoiceService.GetInvoiceById(id);

            if (Invoice != null)
            {
                _invoiceService.RemoveInvoiceAsync(Invoice.Id);
            }

            return RedirectToPage("./Index");
        }
    }
}
