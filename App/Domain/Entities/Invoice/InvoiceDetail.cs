using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace App.Domain.Entities.Invoice
{
    public class InvoiceDetail
    {
        [Key]
        public int Id { get; set; }

        public int InvoiceId { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public Product.Product Product { get; set; }

        public int ProductId { get; set; }
    }
}
