using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace App.Components
{
    public class BrandInIndexComponent : ViewComponent
    {
        private readonly IBrandService _brandService;

        public BrandInIndexComponent(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult)View("_brandInIndexComponent", await _brandService.GetAllBrands()));
        }
    }
}
