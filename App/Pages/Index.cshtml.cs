using System.Threading.Tasks;
using App.Domain.Entities.Setting;
using App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ISettingService _settingService;

        public IndexModel(ISettingService settingService)
        {
            _settingService = settingService;
        }

        public Setting Setting { get; set; }
        public async Task OnGetAsync()
        {
            Setting = await _settingService.GetSetting();
        }
    }
}
