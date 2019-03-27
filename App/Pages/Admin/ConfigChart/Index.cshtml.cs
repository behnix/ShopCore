using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using App.Data;
using App.Domain.Entities.Product;
using App.Services.Interfaces;

namespace App.Pages.Admin.ConfigChart
{
    public class IndexModel : PageModel
    {
        private readonly ICategoryService _categoryService;
        private readonly IConfigChartService _configChartService;
        private readonly IConfigGroupService _configGroupService;

        public IndexModel(ICategoryService categoryService, IConfigChartService configChartService, IConfigGroupService configGroupService)
        {
            _categoryService = categoryService;
            _configChartService = configChartService;
            _configGroupService = configGroupService;
        }

        public IList<Domain.Entities.Product.ConfigChart> ConfigCharts { get; set; }
        public IList<Domain.Entities.Product.Category> Categories { get; set; }
        public IList<Domain.Entities.Product.ConfigGroup> ConfigGroups { get; set; }

        public async Task OnGetAsync()
        {
            ConfigCharts = await _configChartService.GetAllConfigChart();
            Categories = await _categoryService.GetAllCategories();
            ConfigGroups = await _configGroupService.GetAllConfigGroup();
        }

        public async Task<IActionResult> OnPostEdit(int configId, string method)
        {
            await _configChartService.Shift(configId, method);

            return RedirectToPage("/Admin/ConfigChart/Index");
        }
    }
}
