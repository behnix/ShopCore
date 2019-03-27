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

namespace App.Pages.Admin.ConfigGroup
{
    public class EditModel : PageModel
    {
        private readonly IConfigGroupService _configGroupService;

        public EditModel(IConfigGroupService configGroupService)
        {
            _configGroupService = configGroupService;
        }

        [BindProperty]
        public Domain.Entities.Product.ConfigGroup ConfigGroup { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ConfigGroup = await _configGroupService.GetConfigGroupById(id);

            if (ConfigGroup == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _configGroupService.UpdateConfigGroup(ConfigGroup);

            try
            {
                await _configGroupService.SaveChangeAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConfigGroupExists(ConfigGroup.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("../ConfigChart/Index");
        }

        private bool ConfigGroupExists(int id)
        {
            return _configGroupService.ConfigGroupExists(id);
        }
    }
}
