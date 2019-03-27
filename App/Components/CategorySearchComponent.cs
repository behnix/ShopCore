using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace App.Components
{
    public class CategorySearchComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public CategorySearchComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult)View("_categorySearchComponent", await _categoryService.GetAllCategories()));
        }
    }
}
