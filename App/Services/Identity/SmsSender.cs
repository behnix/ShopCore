using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Services.Interfaces;
using Kavenegar;
using Microsoft.Extensions.Configuration;


namespace App.Services.Identity
{
    public class SmsSender : ISmsSender
    {
        private readonly ISettingService _settingService;

        public SmsSender(ISettingService settingService)
        {
            _settingService = settingService;
        }

        public async Task SendSmsAsync(string phoneNumber, string message)
        {
            var sender = _settingService.GetSetting().Result.SiteSmsNumber;

            var apiKey = _settingService.GetSetting().Result.SiteSmsSigniture;

            var kavenegarApi = new KavenegarApi(apiKey);

            var result = await kavenegarApi.Send(sender, phoneNumber, message);
        }
    }
}
