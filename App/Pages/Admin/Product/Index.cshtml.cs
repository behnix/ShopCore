using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using App.Data;
using App.Domain.Entities.Product;
using App.Services.Interfaces;
using Microsoft.AspNetCore.Identity.UI.Pages.Internal.Account;

namespace App.Pages.Admin.Product
{
    public class IndexModel : PageModel
    {
        private readonly IProductService _productService;

        public IndexModel(IProductService productService)
        {
            _productService = productService;
        }

        public IList<Domain.Entities.Product.Product> Product { get;set; }

        public async Task OnGetAsync()
        {
            Product = await _productService.GetAllProducts();
        }
    }
}
