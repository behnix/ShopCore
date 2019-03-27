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

namespace App.Pages.Admin.ConfigChart
{
    public class EditModel : PageModel
    {
        private readonly App.Data.ApplicationDbContext _context;

        public EditModel(App.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Domain.Entities.Product.ConfigChart ConfigChart { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ConfigChart = await _context.ConfigCharts
                .Include(c => c.Category)
                .Include(c => c.ConfigGroup).FirstOrDefaultAsync(m => m.Id == id);

            if (ConfigChart == null)
            {
                return NotFound();
            }
           ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id");
           ViewData["ConfigGroupId"] = new SelectList(_context.ConfigGroups, "Id", "Id");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ConfigChart).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConfigChartExists(ConfigChart.Id))
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

        private bool ConfigChartExists(int id)
        {
            return _context.ConfigCharts.Any(e => e.Id == id);
        }
    }
}
