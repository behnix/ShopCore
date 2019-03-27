using System.Threading.Tasks;
using App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.Pages.Admin.Setting
{
    public class EditModel : PageModel
    {
        private readonly ISettingService _settingService;

        public EditModel(ISettingService settingService)
        {
            _settingService = settingService;
        }


        public async Task<IActionResult> OnGetAsync()
        {
            Setting = await _settingService.GetSetting();

            if (Setting == null)
            {
                return NotFound();
            }
            return Page();
        }

        [BindProperty]
        public Domain.Entities.Setting.Setting Setting { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var setting = await _settingService.GetSetting();
            setting.SiteNameInEnglish = Setting.SiteNameInEnglish;
            setting.Slogan1 = Setting.Slogan1;
            setting.Slogan2 = Setting.Slogan2;
            setting.SiteEmail = Setting.SiteEmail;
            setting.SiteEmailPassword = Setting.SiteEmailPassword;
            setting.SiteSmtp = Setting.SiteSmtp;
            setting.SmtpPort = Setting.SmtpPort;
            setting.SiteSmsNumber = Setting.SiteSmsNumber;
            setting.SiteSmsSigniture = Setting.SiteSmsSigniture;
            setting.SiteTelegramId = Setting.SiteTelegramId;
            setting.SiteInstagramId = Setting.SiteInstagramId;
            setting.SiteTwitterId = Setting.SiteTwitterId;
            setting.SiteFacebookId = Setting.SiteFacebookId;
            setting.SiteCopyRightText = Setting.SiteCopyRightText;
            await _settingService.UpdateSetting(setting);

            return Page();
        }
    }
}
