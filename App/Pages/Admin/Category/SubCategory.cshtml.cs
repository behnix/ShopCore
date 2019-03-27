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

namespace App.Pages.Admin.Category
{
    public class SubCategoryModel : PageModel
    {
        private readonly ICategoryService _categoryService;

        public SubCategoryModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IList<Domain.Entities.Product.Category> Category { get; set; }

        public async Task<IActionResult> OnGet()
        {
            Category = await  _categoryService.GetAllParentCategories();

            if (Category == null)
            {
                return NotFound();
            }
            return RedirectToPage("/admin/product/index");
        }
    }
}