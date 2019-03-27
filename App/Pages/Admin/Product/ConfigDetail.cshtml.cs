using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App.Data;
using App.Domain.Entities.Product;
using App.Services.Interfaces;

namespace App.Pages.Admin.Product
{
    public class ConfigDetailModel : PageModel
    {
        private readonly IConfigDetailService _configDetailService;
        private readonly IConfigChartService _configChartService;
        private readonly IConfigGroupService _configGroupService;
        private readonly IProductService _productService;

        public ConfigDetailModel(IConfigDetailService configDetailService, IConfigChartService configChartService, IConfigGroupService configGroupService, IProductService productService)
        {
            _configDetailService = configDetailService;
            _configChartService = configChartService;
            _configGroupService = configGroupService;
            _productService = productService;
        }
        
        [BindProperty]
        public ConfigDetail ConfigDetail { get; set; }
        public List<ConfigDetail> ConfigDetails { get; set; }
        public List<Domain.Entities.Product.ConfigChart> ConfigCharts { get; set; }
        public List<Domain.Entities.Product.ConfigGroup> ConfigGroups { get; set; }
        public Domain.Entities.Product.Product Product { get; set; }
        public async Task<IActionResult> OnGetAsync(int productId, int categoryId)
        {
            ConfigDetails = await _configDetailService.GetAllConfigDetailsByProductId(productId);
            ConfigCharts = await _configChartService.GetAllConfigChartByCategoryId(categoryId);
            ConfigGroups = await _configGroupService.GetAllConfigGroupByCategoryId(categoryId);
            Product = await _productService.GetProductById(productId);
            ViewData["CategoryId"] = categoryId;
            ViewData["ProductId"] = productId;

            foreach (var chart in ConfigCharts)
            {
                if (!_configDetailService.AnyConfigDetailsByProductIdAndConfigChartId(productId,chart.Id))
                {
                    var configDetail = new ConfigDetail()
                    {
                        ProductId = productId,
                        ConfigGroupId = chart.ConfigGroupId,
                        ConfigChart = chart,
                        ConfigChartId = chart.Id,
                        Value = null
                    };
                    await _configDetailService.AddConfigDetail(configDetail);
                }
            }
            
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _configDetailService.UpdateConfigDetail(ConfigDetail);

            try
            {
                await _configDetailService.SaveChangeAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConfigDetailExists(ConfigDetail.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ConfigDetailExists(int id)
        {
            return _configDetailService.ConfigDetailExists(id);
        }
    }
}
