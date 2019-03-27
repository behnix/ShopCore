using System.Threading.Tasks;
using App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.Pages.Admin.Setting
{
    public class ServiceModel : PageModel
    {
        private readonly ISettingService _settingService;

        public ServiceModel(ISettingService settingService)
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
            setting.Service1 = Setting.Service1;
            setting.Service1Icon = Setting.Service1Icon;
            setting.Service1Description = Setting.Service1Description;
            setting.Service2 = Setting.Service2;
            setting.Service2Icon = Setting.Service2Icon;
            setting.Service2Description = Setting.Service2Description;
            setting.Service3 = Setting.Service3;
            setting.Service3Icon = Setting.Service3Icon;
            setting.Service3Description = Setting.Service3Description;
            setting.Service4 = Setting.Service4;
            setting.Service4Icon = Setting.Service4Icon;
            setting.Service4Description = Setting.Service4Description;
            await _settingService.UpdateSetting(setting);

            return Page();
        }
    }
}
