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
    public class IndexModel : PageModel
    {
        private readonly IInvoiceService _invoiceService;

        public IndexModel(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        public IList<Domain.Entities.Invoice.Invoice> Invoice { get;set; }

        public async Task OnGetAsync()
        {
            Invoice = await _invoiceService.GetAllInvoices();
        }
    }
}
