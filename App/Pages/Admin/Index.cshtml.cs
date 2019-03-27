using App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.Pages.Admin
{
    public class IndexModel : PageModel
    {
        private readonly ISettingService _settingService;

        public IndexModel(ISettingService settingService)
        {
            _settingService = settingService;
        }

        public void OnGet()
        {
            ViewData["Setting"] = _settingService.GetSetting();
        }
    }
}