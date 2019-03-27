using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.Convertors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App.Data;
using App.Domain.Entities.Product;
using App.Services.Interfaces;
using Microsoft.AspNetCore.Http;

namespace App.Pages.Admin.Product
{
    public class EditModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly IBrandService _brandService;
        private readonly ICategoryService _categoryService;

        public EditModel(IProductService productService, IBrandService brandService, ICategoryService categoryService)
        {
            _productService = productService;
            _brandService = brandService;
            _categoryService = categoryService;
        }

        [BindProperty]
        public Domain.Entities.Product.Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _productService.GetProductById(id);

            if (Product == null)
            {
                return NotFound();
            }

            ViewData["ProductImage"] = Product.Image ?? "no-image.png";
            ViewData["BrandId"] = new SelectList(await _brandService.GetAllBrands(), "Id", "Name");
            ViewData["CategoryId"] = new SelectList(await _categoryService.GetAllCategories(), "Id", "Name");
            Product.MetaTitle = TextConvertor.ReplaceLetters(Product.MetaTitle, '-', ' ');
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(IFormFile productImageUp, string oldImage)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _productService.UpdateProductAsync(Product, productImageUp, oldImage);

            try
            {
                await _productService.SaveChangeAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(Product.ProductId))
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

        private bool ProductExists(int id)
        {
            return _productService.ProductExists(id);
        }
    }
}
