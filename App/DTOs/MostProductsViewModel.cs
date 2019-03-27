using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Domain.Entities.Product;

namespace App.DTOs
{
    public class MostProductsViewModel
    {
        public IEnumerable<Product> MostVisitProducs { get; set; }
        public IEnumerable<Product> MostSalesProducs { get; set; }
        public IEnumerable<Product> MostNewProducs { get; set; }
    }
}
