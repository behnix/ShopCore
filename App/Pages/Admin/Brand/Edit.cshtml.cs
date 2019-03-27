using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App.Data;
using App.Domain.Entities.Product;
using App.Services.Interfaces;
using Microsoft.AspNetCore.Http;

namespace App.Pages.Admin.Brand
{
    public class EditModel : PageModel
    {
        private readonly IBrandService _brandService;

        public EditModel(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [BindProperty]
        public Domain.Entities.Product.Brand Brand { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Brand = await _brandService.GetBrandById(id);

            if (Brand == null)
            {
                return NotFound();
            }
            ViewData["BrandImage"] = Brand.Logo ?? "no-image.png";
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(IFormFile brandImageUp, string oldImage)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                await _brandService.UpdateBrand(Brand, brandImageUp, oldImage);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BrandExists(Brand.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BrandExists(int id)
        {
            return _brandService.BrandExists(id);
        }
    }
}
