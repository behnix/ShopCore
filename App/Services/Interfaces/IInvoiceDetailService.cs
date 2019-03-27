using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Domain.Entities.Invoice;

namespace App.Services.Interfaces
{
    public interface IInvoiceDetailService
    {
        Task<List<InvoiceDetail>> GetAllInvoiceDetails(int invoiceId);

        Task<InvoiceDetail> GetInvoiceDetailById(int? invoiceDetailId);

        Task<int> AddNewInvoiceDetail(InvoiceDetail invoiceDetail);

        void RemoveInvoiceDetailAsync(int invoiceDetailId);

        void UpdateInvoiceDetail(InvoiceDetail invoiceDetail);

        bool InvoiceDetailExists(int invoiceDetailId);

        Task SaveChangeAsync();
    }
}
