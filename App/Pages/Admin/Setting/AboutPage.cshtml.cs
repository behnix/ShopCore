using System.Threading.Tasks;
using App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.Pages.Admin.Setting
{
    public class AboutPageModel : PageModel
    {
        private readonly ISettingService _settingService;

        public AboutPageModel(ISettingService settingService)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var setting = await _settingService.GetSetting();
            setting.AboutUs = Setting.AboutUs;
            setting.AboutUsTitle = Setting.AboutUsTitle;
            setting.AboutUsDescription = Setting.AboutUsDescription;
            await _settingService.UpdateSetting(setting);

            return Page();
        }
    }
}
