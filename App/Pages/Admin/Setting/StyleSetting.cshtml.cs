using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using App.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace App.Pages.Admin.Setting
{
    public class StyleSettingModel : PageModel
    {
        private readonly ISettingService _settingService;

        public StyleSettingModel(ISettingService settingService)
        {
            _settingService = settingService;
        }

        [BindProperty]
        public Domain.Entities.Setting.Setting Setting { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Setting = await _settingService.GetSetting();

            if (Setting == null)
            {
                return NotFound();
            }
            ViewData["LogoImage"] = Setting.Logo ?? "no-image.png";
            var directories = Directory.GetDirectories("wwwroot/themes/");
            var themes = directories.ToList();

            ViewData["Themes"] = themes;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(IFormFile logoImageUp, string oldImage)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                await _settingService.UpdateSettingWithImage(Setting, logoImageUp, oldImage);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SettingExists(Setting.SettingId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("../Index");
        }

        private bool SettingExists(int id)
        {
            return _settingService.SettingExists(id);
        }
    }
}
