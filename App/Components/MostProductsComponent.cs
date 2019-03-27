using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace App.Components
{
    public class MostProductsComponent : ViewComponent
    {
        private readonly IProductService _productService;

        public MostProductsComponent(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult)View("_mostProductsComponent", await _productService.GetAllMostProducts()));
        }
    }
}
