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

namespace App.Pages.Admin.Category
{
    public class CreateModel : PageModel
    {
        private readonly ICategoryService _categoryService;

        public CreateModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> OnGet()
        {
            ViewData["CategoryId"] = new SelectList(await _categoryService.GetAllParentCategories(), "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Domain.Entities.Product.Category Category { get; set; }

        public async Task<IActionResult> OnPostAsync(IFormFile categoryImageUp, bool categoryParentId)
        {
            if (!ModelState.IsValid)
            {
                ViewData["CategoryId"] = new SelectList(await _categoryService.GetAllParentCategories(), "Id", "Name");
                return Page();
            }

            await _categoryService.AddNewCategory(Category, categoryImageUp, categoryParentId);

            return RedirectToPage("./Index");
        }
    }
}