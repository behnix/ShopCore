using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace App.Components
{
    public class NewProductInCategoryInIndexComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public NewProductInCategoryInIndexComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult)View("_newProductInCategoryInIndexComponent", await _categoryService.GetAllParentCategoriesWithNewProducts()));
        }
    }
}
