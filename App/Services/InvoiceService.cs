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
    public class InvoiceService : IInvoiceService
    {
        private readonly ApplicationDbContext _context;

        public InvoiceService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Invoice>> GetAllInvoices()
        {
            return await _context.Invoices.ToListAsync();
        }

        public async Task<Invoice> GetInvoiceById(int? invoiceId)
        {
            return await _context.Invoices.SingleOrDefaultAsync(i => i.Id == invoiceId);
        }

        public async Task<Invoice> GetInvoiceBySessionId(string sessionId)
        {
            return await _context.Invoices.SingleOrDefaultAsync(i => i.SessionId == sessionId);
        }

        public async Task<bool> IsInvoiceBySessionId(string sessionId)
        {
            return _context.Invoices.Any(i => i.SessionId == sessionId);
        }

        public async Task<bool> IsInvoiceByRefNum(string refNum)
        {
            return _context.Invoices.Any(i => i.RefNum == refNum);
        }

        public async Task<List<Invoice>> GetAllInvoiceByUserId(int userId)
        {
            return await _context.Invoices.Where(i => i.UserId == userId).OrderByDescending(i=>i.FactoredOn).ToListAsync();
        }

        public async Task<Invoice> GetInvoiceByCId(string cId)
        {
            return await _context.Invoices.SingleOrDefaultAsync(i => i.CId == cId);
        }

        public async Task<int> AddNewInvoice(Invoice invoice)
        {
            _context.Invoices.Add(invoice);
            await _context.SaveChangesAsync();
            return invoice.Id;
        }

        public async Task RemoveInvoiceAsync(int invoiceId)
        {
            var invoiceSelect = await GetInvoiceById(invoiceId);
            if (invoiceSelect != null) _context.Invoices.Remove(invoiceSelect);
            await _context.SaveChangesAsync();
        }

        public void UpdateInvoice(Invoice invoice)
        {
            _context.Invoices.Update(invoice);
        }

        public bool InvoiceExists(int invoiceId)
        {
            return _context.Invoices.Any(i => i.Id == invoiceId);
        }

        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
