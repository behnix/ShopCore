using System.Collections.Generic;
using System.Threading.Tasks;
using App.Domain.Entities.Setting;
using App.Domain.Identity;
using App.Services.Identity.Managers;
using App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace App.Pages
{
    public class AboutModel : PageModel
    {
        private readonly ISettingService _settingService;
        private readonly AppUserManager _userManager;

        public AboutModel(ISettingService settingService, AppUserManager userManager)
        {
            _settingService = settingService;
            _userManager = userManager;
        }

        public Task<List<User>> Users { get; set; }
        public Task<Setting> Setting { get; set; }

        public void OnGet()
        {
            Setting = _settingService.GetSetting();
            Users = _userManager.Users.ToListAsync();
        }
    }
}
