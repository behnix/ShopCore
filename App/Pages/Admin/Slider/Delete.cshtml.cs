using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using App.Data;
using App.Domain.Entities.Slider;

namespace App.Pages.Admin.Slider
{
    public class DeleteModel : PageModel
    {
        private readonly App.Data.ApplicationDbContext _context;

        public DeleteModel(App.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Domain.Entities.Slider.Slider Slider { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Slider = await _context.Sliders.FirstOrDefaultAsync(m => m.SliderId == id);

            if (Slider == null)
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

            Slider = await _context.Sliders.FindAsync(id);

            if (Slider != null)
            {
                _context.Sliders.Remove(Slider);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
