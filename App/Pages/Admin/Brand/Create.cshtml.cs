using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using App.Data;
using App.Domain.Entities.Product;
using App.Services.Interfaces;
using Microsoft.AspNetCore.Http;

namespace App.Pages.Admin.Brand
{
    public class CreateModel : PageModel
    {
        private readonly IBrandService _brandService;

        public CreateModel(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Domain.Entities.Product.Brand Brand { get; set; }

        public async Task<IActionResult> OnPostAsync(IFormFile brandImageUp)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _brandService.AddNewBrand(Brand, brandImageUp);

            return RedirectToPage("./Index");
        }
    }
}