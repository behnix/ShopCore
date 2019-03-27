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

namespace App.Pages.Admin.ConfigGroup
{
    public class DeleteModel : PageModel
    {
        private readonly IConfigGroupService _configGroupService;

        public DeleteModel(IConfigGroupService configGroupService)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ConfigGroup = await _configGroupService.GetConfigGroupById(id);

            if (ConfigGroup != null)
            {
                await _configGroupService.RemoveConfigGroup(ConfigGroup.CategoryId, ConfigGroup.Id);
            }

            return RedirectToPage("../ConfigChart/Index");
        }
    }
}
