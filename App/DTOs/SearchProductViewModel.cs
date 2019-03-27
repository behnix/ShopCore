using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.DTOs
{
    public class SearchProductViewModel
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public string MetaTitle { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public long Price { get; set; }
    }
}
