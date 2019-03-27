using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Domain.Entities.NoDataBase
{
    public class CartItem
    {
        public Product.Product Product { get; set; }
        public string ProductImage { get; set; }
        public int Quantity { get; set; }
    }
}
