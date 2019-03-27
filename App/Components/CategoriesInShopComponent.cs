using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace App.Components
{
    public class CategoriesInShopComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public CategoriesInShopComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync(List<int> selectedCategory)
        {
            ViewData["selectedCategory"] = selectedCategory;
            return await Task.FromResult((IViewComponentResult)View("_categoriesInShopComponent", await _categoryService.GetAllCategories()));
        }
    }
}
