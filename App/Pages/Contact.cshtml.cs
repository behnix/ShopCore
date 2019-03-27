using System.Collections.Generic;
using System.Threading.Tasks;
using App.Domain.Entities.Setting;
using App.Domain.Identity;
using App.Services.Identity.Managers;
using App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.Pages
{
    public class ContactModel : PageModel
    {
        private readonly ISettingService _settingService;

        public ContactModel(ISettingService settingService)
        {
            _settingService = settingService;
        }

        public Task<List<User>> Users { get; set; }
        public Task<Setting> Setting { get; set; }

        public void OnGet()
        {
            Setting = _settingService.GetSetting();
        }
    }
}
