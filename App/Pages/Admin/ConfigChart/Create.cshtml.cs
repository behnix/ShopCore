using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using App.Data;
using App.Domain.Entities.Product;
using App.Services.Interfaces;

namespace App.Pages.Admin.ConfigChart
{
    public class CreateModel : PageModel
    {
        private readonly IConfigChartService _configChartService;

        public CreateModel(IConfigChartService configChartService)
        {
            _configChartService = configChartService;
        }

        public IActionResult OnGet(int id, int groupId)
        {
            ViewData["CategoryId"] = id;
            ViewData["ConfigGroupId"] = groupId;
            return Page();
        }

        [BindProperty]
        public Domain.Entities.Product.ConfigChart ConfigChart { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _configChartService.CreateConfigChart(ConfigChart, ConfigChart.CategoryId, ConfigChart.ConfigGroupId);

            return RedirectToPage("./Index");
        }
    }
}