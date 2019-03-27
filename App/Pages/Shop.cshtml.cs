using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using App.Data;
using App.Domain.Entities.Product;
using App.DTOs;
using App.Services.Interfaces;

namespace App.Pages
{
    public class ShopModel : PageModel
    {
        private readonly IProductService _productService;

        public ShopModel(IProductService productService)
        {
            _productService = productService;
        }

        public Tuple<List<SearchProductViewModel>, int> ResultTuple { get; set; }

        public async Task OnGetAsync(int pageId = 1, string filter = ""
            , string orderBy = "date",
            int minPrice = 0, int maxPrice = 0, List<int> selectedCategory = null, List<int> selectedBrand = null, int take = 9)
        {
            long minPriceInAllProducts = 0;
            long maxPriceInAllProducts = 0;
            var products = await _productService.GetAllProducts();
            if (products != null)
            {
                minPriceInAllProducts = products.OrderBy(p => p.Price).FirstOrDefault().Price - 1000;
                maxPriceInAllProducts = products.OrderByDescending(p => p.Price).FirstOrDefault().Price + 1000;
            }

            ViewData["selectedCategory"] = selectedCategory;
            ViewData["selectedBrand"] = selectedBrand;
            ViewData["from"] = (pageId - 1) * take;
            ViewData["to"] = ((pageId - 1) * take) + take;
            ViewData["min"] = (minPrice == 0 ? minPriceInAllProducts : minPrice);
            ViewData["max"] = (maxPrice == 0 ? maxPriceInAllProducts : maxPrice);
            ViewData["minPriceInAllProducts"] = minPriceInAllProducts;
            ViewData["maxPriceInAllProducts"] = maxPriceInAllProducts;
            ViewData["orderBy"] = orderBy;
            ViewData["take"] = take;
            ViewData["page"] = pageId;
            ResultTuple = _productService.SearchProduct(pageId, filter, orderBy, minPrice, maxPrice, selectedCategory, selectedBrand, take);
        }
    }
}
