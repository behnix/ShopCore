using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Domain.Entities.Invoice;
using Microsoft.AspNetCore.Http;

namespace App.Services.Interfaces
{
    public interface IInvoiceService
    {
        Task<List<Invoice>> GetAllInvoices();

        Task<Invoice> GetInvoiceById(int? invoiceId);

        Task<Invoice> GetInvoiceBySessionId(string sessionId);

        Task<bool> IsInvoiceBySessionId(string sessionId);

        Task<bool> IsInvoiceByRefNum(string refNum);

        Task<List<Invoice>> GetAllInvoiceByUserId(int userId);

        Task<Invoice> GetInvoiceByCId(string cId);

        Task<int> AddNewInvoice(Invoice invoice);

        Task RemoveInvoiceAsync(int invoiceId);

        void UpdateInvoice(Invoice invoice);

        bool InvoiceExists(int invoiceId);

        Task SaveChangeAsync();
    }
}
