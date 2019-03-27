using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using App.Services.Interfaces;
using Microsoft.AspNetCore.Identity.UI.Services;


namespace App.Services.Identity
{
    public class EmailSender : IEmailSender
    {
        private readonly ISettingService _settingService;

        public EmailSender(ISettingService settingService)
        {
            _settingService = settingService;
        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var siteEmail = _settingService.GetSetting().Result.SiteEmail;
            var siteEmailPassword = _settingService.GetSetting().Result.SiteEmailPassword;
            var siteSmtp = _settingService.GetSetting().Result.SiteSmtp;
            var siteSmtpPort = _settingService.GetSetting().Result.SmtpPort;
            var message = new MailMessage(siteEmail, email, subject, htmlMessage)
            {
                IsBodyHtml = true,
                BodyEncoding = Encoding.UTF8
            };

            var smtpClient = new SmtpClient(siteSmtp, siteSmtpPort)
            {
                UseDefaultCredentials = true,
                Credentials = new NetworkCredential(siteEmail, siteEmailPassword),
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network
            };

            return smtpClient.SendMailAsync(message);
        }
    }
}
