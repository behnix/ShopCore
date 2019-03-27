using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace App.Components
{
    public class BrandsInShopComponent : ViewComponent
    {
        private readonly IBrandService _brandService;

        public BrandsInShopComponent(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public async Task<IViewComponentResult> InvokeAsync(List<int> selectedBrand)
        {
            ViewData["selectedBrand"] = selectedBrand;
            return await Task.FromResult((IViewComponentResult)View("_brandsInShopComponent", await _brandService.GetAllBrands()));
        }
    }
}
