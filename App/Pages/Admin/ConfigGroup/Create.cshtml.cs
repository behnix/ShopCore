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

namespace App.Pages.Admin.ConfigGroup
{
    public class CreateModel : PageModel
    {
        private readonly IConfigGroupService _configGroupService;

        public CreateModel(IConfigGroupService configGroupService)
        {
            _configGroupService = configGroupService;
        }

        public IActionResult OnGet(int id)
        {
            ViewData["CategoryId"] = id;
            return Page();
        }

        [BindProperty]
        public Domain.Entities.Product.ConfigGroup ConfigGroup { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _configGroupService.CreateConfigGroup(ConfigGroup, ConfigGroup.CategoryId);

            return RedirectToPage("/Admin/ConfigChart/Index");
        }
    }
}