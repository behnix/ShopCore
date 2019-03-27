using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace App.Components
{
    public class CategoryMenuMobileComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public CategoryMenuMobileComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult)View("_categoryMenuMobileComponent", await _categoryService.GetAllCategories()));
        }
    }
}
