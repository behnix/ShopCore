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

namespace App.Pages.Admin.Brand
{
    public class IndexModel : PageModel
    {
        private readonly IBrandService _brandService;

        public IndexModel(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public IList<Domain.Entities.Product.Brand> Brand { get;set; }

        public async Task OnGetAsync()
        {
            Brand = await _brandService.GetAllBrands();
        }
    }
}
