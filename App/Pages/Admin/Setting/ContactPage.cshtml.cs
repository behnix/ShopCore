using System.Threading.Tasks;
using App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.Pages.Admin.Setting
{
    public class ContactPageModel : PageModel
    {
        private readonly ISettingService _settingService;

        public ContactPageModel(ISettingService settingService)
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
            setting.SiteAddress = Setting.SiteAddress;
            setting.SiteTel = Setting.SiteTel;
            setting.ContactDescription = Setting.ContactDescription;
            setting.ContactWorkHour = Setting.ContactWorkHour;
            setting.ContactTitle = Setting.ContactTitle;
            await _settingService.UpdateSetting(setting);

            return Page();
        }
    }
}
