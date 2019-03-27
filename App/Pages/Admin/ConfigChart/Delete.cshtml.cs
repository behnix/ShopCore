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
    public class DeleteModel : PageModel
    {
        private readonly IConfigChartService _configChartService;

        public DeleteModel(IConfigChartService configChartService)
        {
            _configChartService = configChartService;
        }

        [BindProperty]
        public Domain.Entities.Product.ConfigChart ConfigChart { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ConfigChart = await _configChartService.GetConfigChartById(id);

            if (ConfigChart == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ConfigChart = await _configChartService.GetConfigChartById(id);

            if (ConfigChart != null)
            {
                await _configChartService.RemoveConfigChart(id);
            }

            return RedirectToPage("./Index");
        }
    }
}
