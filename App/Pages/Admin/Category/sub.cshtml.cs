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
    public class subModel : PageModel
    {

        private readonly ICategoryService _categoryService;

        public subModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IList<Domain.Entities.Product.Category> Category { get;set; }

        public async Task<IActionResult> OnGetAsync(int parentId)
        {
            Category = await _categoryService.GetCategoryByParentId(parentId);

            return Page();
        }
    }
}
