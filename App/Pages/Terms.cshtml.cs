using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using App.Data;
using App.Domain.Entities.Setting;
using App.Services.Interfaces;

namespace App.Pages
{
    public class TermsModel : PageModel
    {
        private readonly ISettingService _settingService;

        public TermsModel(ISettingService settingService)
        {
            _settingService = settingService;
        }

        public Setting Setting { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {

            Setting = await _settingService.GetSetting();

            if (Setting == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
