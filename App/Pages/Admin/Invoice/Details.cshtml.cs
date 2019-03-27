using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using App.Data;
using App.Domain.Entities.Invoice;
using App.Services.Interfaces;

namespace App.Pages.Admin.Invoice
{
    public class DetailsModel : PageModel
    {
        private readonly IInvoiceService _invoiceService;
        private readonly IInvoiceDetailService _invoiceDetailService;

        public DetailsModel(IInvoiceService invoiceService, IInvoiceDetailService invoiceDetailService)
        {
            _invoiceService = invoiceService;
            _invoiceDetailService = invoiceDetailService;
        }

        public Domain.Entities.Invoice.Invoice Invoice { get; set; }
        public List<InvoiceDetail> InvoiceDetails { get; set; }
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
            InvoiceDetails = await _invoiceDetailService.GetAllInvoiceDetails(Invoice.Id);
            return Page();
        }
    }
}
