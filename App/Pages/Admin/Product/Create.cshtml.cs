using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.Convertors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using App.Data;
using App.Domain.Entities.Product;
using App.Domain.Enums;
using App.Services.Interfaces;
using Microsoft.AspNetCore.Http;

namespace App.Pages.Admin.Product
{
    public class CreateModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly IBrandService _brandService;
        private readonly ICategoryService _categoryService;

        public CreateModel(IProductService productService, IBrandService brandService, ICategoryService categoryService)
        {
            _productService = productService;
            _brandService = brandService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            ViewData["BrandId"] = new SelectList(await _brandService.GetAllBrands(), "Id", "Name");
            ViewData["CategoryId"] = new SelectList(await _categoryService.GetAllSubCategories(), "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Domain.Entities.Product.Product Product { get; set; }

        public async Task<IActionResult> OnPostAsync(IFormFile productImageUp)
        {
            if (!ModelState.IsValid)
                return Page();
            
            if (await _productService.IsProductMetaTitleInBrowserRepeated(TextConvertor.ReplaceLetters(TextConvertor.FixingText(Product.MetaTitle), ' ', '-')))
            {
                ModelState.AddModelError("Product.MetaTitle", "قبلا محصولی با این عنوان برای مرورگر ثبت شده است!");
                ViewData["BrandId"] = new SelectList(await _brandService.GetAllBrands(), "Id", "Name");
                ViewData["CategoryId"] = new SelectList(await _categoryService.GetAllCategories(), "Id", "Name");
                return Page();
            }

            await _productService.AddProduct(Product, productImageUp);

            return RedirectToPage("./Index");
        }
    }
}