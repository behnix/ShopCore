using System.Threading.Tasks;
using App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.Pages.Admin.Faq
{
    public class FaqPageModel : PageModel
    {
        private readonly ISettingService _settingService;

        public FaqPageModel(ISettingService settingService)
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
            setting.FaqTitle = Setting.FaqTitle;
            setting.FaqDescription = Setting.FaqDescription;
            setting.FaqText = Setting.FaqText;
            await _settingService.UpdateSetting(setting);

            return RedirectToPage("./Index");
        }
    }
}
