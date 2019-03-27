﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace App.Components
{
    public class CategoryMenuComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public CategoryMenuComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult)View("_categoryMenuComponent",await _categoryService.GetAllCategories()));
        }
    }
}