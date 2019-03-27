using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Data;
using App.Domain.Entities.Invoice;
using App.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace App.Services
{
    public class InvoiceDetailService : IInvoiceDetailService
    {
        private readonly ApplicationDbContext _context;

        public InvoiceDetailService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<InvoiceDetail>> GetAllInvoiceDetails(int invoiceId)
        {
            return await _context.InvoiceDetails.Include(id => id.Product).Where(id => id.InvoiceId == invoiceId).ToListAsync();
        }

        public async Task<InvoiceDetail> GetInvoiceDetailById(int? invoiceDetailId)
        {
            return await _context.InvoiceDetails.SingleOrDefaultAsync(id => id.Id == invoiceDetailId);
        }

        public async Task<int> AddNewInvoiceDetail(InvoiceDetail invoiceDetail)
        {
            _context.InvoiceDetails.Add(invoiceDetail);
            await _context.SaveChangesAsync();
            return invoiceDetail.Id;
        }

        public async void RemoveInvoiceDetailAsync(int invoiceDetailId)
        {
            var invoiceDetailSelect = await GetInvoiceDetailById(invoiceDetailId);
            if (invoiceDetailSelect != null) _context.InvoiceDetails.Remove(invoiceDetailSelect);
        }

        public void UpdateInvoiceDetail(InvoiceDetail invoiceDetail)
        {
            _context.InvoiceDetails.Update(invoiceDetail);
        }

        public bool InvoiceDetailExists(int invoiceDetailId)
        {
            return _context.InvoiceDetails.Any(id => id.Id == invoiceDetailId);
        }

        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
