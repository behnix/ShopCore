using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.Convertors;
using App.Core.Extensions;
using App.Core.Pay;
using App.Core.Pay.App.Core.Pay;
using App.Domain.Entities.Invoice;
using App.Domain.Entities.NoDataBase;
using App.Domain.Identity;
using App.Services.Identity.Managers;
using App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace App.Pages
{
    public class PayModel : PageModel
    {
        private readonly AppUserManager _userManager;
        private readonly IInvoiceService _invoiceService;
        private readonly IInvoiceDetailService _invoiceDetailService;
        private readonly ISettingService _settingService;

        public PayModel(AppUserManager userManager, IInvoiceService invoiceService, IInvoiceDetailService invoiceDetailService, ISettingService settingService)
        {
            _userManager = userManager;
            _invoiceService = invoiceService;
            _invoiceDetailService = invoiceDetailService;
            _settingService = settingService;
        }
        public List<InvoiceDetail> InvoiceDetails { get; set; }
        public User CurrentUser { get; set; }
        public async Task<IActionResult> OnGet(string sessionId)
        {
            ViewData["Message"] = "";
            if (User.Identity.IsAuthenticated)
                CurrentUser = await _userManager.FindByNameAsync(User.Identity.Name);

            var invoiceCreated = new Invoice();
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("cart");
            ViewData["total"] = cart.Sum(item => item.Product.Price * item.Quantity).ToPrice();
            int invoiceId;
            long amount = 0;
            if (await _invoiceService.IsInvoiceBySessionId(sessionId))
            {
                invoiceCreated.UserId = User.Identity.IsAuthenticated ? CurrentUser.Id : 0;
                invoiceCreated = await _invoiceService.GetInvoiceBySessionId(sessionId);
                invoiceCreated.FactoredOn = DateTime.Now;
                _invoiceService.UpdateInvoice(invoiceCreated);
                await _invoiceService.SaveChangeAsync();
                foreach (var item in await _invoiceDetailService.GetAllInvoiceDetails(invoiceCreated.Id))
                    _invoiceDetailService.RemoveInvoiceDetailAsync(item.Id);

                await _invoiceDetailService.SaveChangeAsync();
                invoiceId = invoiceCreated.Id;
            }
            else
            {
                invoiceCreated.UserId = User.Identity.IsAuthenticated ? CurrentUser.Id : 0;
                invoiceCreated.FactoredOn = DateTime.Now;
                invoiceCreated.State = "در مرحله صدور فاکتور";
                invoiceCreated.Purchased = false;
                invoiceCreated.Transported = false;
                invoiceCreated.SessionId = HttpContext.Session.Id;
                invoiceId = await _invoiceService.AddNewInvoice(invoiceCreated);
                await _invoiceService.SaveChangeAsync();
            }

            foreach (var item in cart)
            {
                var invoiceDetail = new InvoiceDetail()
                {
                    InvoiceId = invoiceId,
                    Quantity = item.Quantity,
                    ProductId = item.Product.ProductId,
                    Price = item.Product.Price
                };

                await _invoiceDetailService.AddNewInvoiceDetail(invoiceDetail);
                await _invoiceDetailService.SaveChangeAsync();
                amount += (item.Product.Price * item.Quantity);
                invoiceCreated.Amount = amount;
                await _invoiceService.SaveChangeAsync();
            }
            Invoice = await _invoiceService.GetInvoiceById(invoiceId);
            InvoiceDetails = await _invoiceDetailService.GetAllInvoiceDetails(invoiceId);
            return Page();
        }

        [BindProperty]
        public Invoice Invoice { get; set; }
        public async Task<IActionResult> OnPostAsync(Transaction model)
        {
            var message = "";
            var api = _settingService.GetSetting().Result.MerchantId;
            api = string.IsNullOrWhiteSpace(api) ? "test" : api;
            model.Amount = Invoice.Amount.ToString();
            try
            {
                var ob = new Payment();
                var result = ob.Pay(model.Amount,api);
                var parameters = JsonConvert.DeserializeObject<JsonParameters>(result);

                if (parameters.Status == 1)
                {
                    message = "ارجاع به درگاه";
                    Invoice.State = message;
                    Invoice.CId = parameters.Token;
                    _invoiceService.UpdateInvoice(Invoice);
                    await _invoiceService.SaveChangeAsync();
                    return Redirect("https://pay.ir/pg/" + parameters.Token);
                }
                else
                {
                    message = "کدخطا : " + parameters.ErrorCode + "<br />" + "پیغام خطا : " + parameters.ErrorMessage;
                    Invoice.State = message;
                    _invoiceService.UpdateInvoice(Invoice);
                    await _invoiceService.SaveChangeAsync();
                }
                message = "";
            }
            catch (Exception exp)
            {
                message = "خطا در اتصال به درگاه پرداخت" + exp.Message;
                Invoice.State = message;
                _invoiceService.UpdateInvoice(Invoice);
                await _invoiceService.SaveChangeAsync();
            }

            return RedirectToPage("./pay", new {Invoice.SessionId, message });
        }



        public class JsonParameters
        {
            public int Status { get; set; }

            public string Token { get; set; }

            public double Amount { get; set; }

            public string ErrorCode { get; set; }

            public string ErrorMessage { get; set; }

            public JsonParameters()
            {

            }
        }
    }
}