using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.Pay.App.Core.Pay;
using App.Domain.Entities.Invoice;
using App.Domain.Entities.NoDataBase;
using App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace App.Pages
{
    public class PeymentResultModel : PageModel
    {
        private readonly IInvoiceService _invoiceService;
        private readonly ISettingService _settingService;

        public PeymentResultModel(IInvoiceService invoiceService, ISettingService settingService)
        {
            _invoiceService = invoiceService;
            _settingService = settingService;
        }

        public Invoice Invoice { get; set; }
        public async Task<IActionResult> OnGet([FromQuery]string status,[FromQuery]string token)
        {
            try
            {
                if (!string.IsNullOrEmpty(token))
                {
                    Invoice = await _invoiceService.GetInvoiceByCId(token);
                    var ob = new Payment();
                    var api = _settingService.GetSetting().Result.MerchantId;
                    api = string.IsNullOrWhiteSpace(api) ? "test" : api;
                    var result = ob.Verify(token, api);
                    var parameters = JsonConvert.DeserializeObject<JsonResult>(result);
                    if (parameters.Status == 1 && await _invoiceService.IsInvoiceByRefNum(parameters.TraceNumber) == false)
                    {
                        var message = "پرداخت با موفقیت انجام شد.";
                        Invoice.State = message;
                        Invoice.RefNum = parameters.TraceNumber;
                        Invoice.Amount = Convert.ToInt64(parameters.Amount);
                        Invoice.StateCode = parameters.Status.ToString();
                        Invoice.Purchased = true;
                        _invoiceService.UpdateInvoice(Invoice);
                        await _invoiceService.SaveChangeAsync();
                        HttpContext.Session.Remove(Invoice.SessionId);
                        HttpContext.Session.Remove("cart");
                    }
                    else
                    {
                        Invoice.State = ".عملیات پرداخت لغو شد <br /> توضیحات: " + parameters.ErrorMessage + " <br /> کد صادر شده: " + parameters.ErrorCode;
                        Invoice.RefNum = "";
                        Invoice.StateCode = parameters.ErrorCode;
                        Invoice.Purchased = false;
                        _invoiceService.UpdateInvoice(Invoice);
                        await _invoiceService.SaveChangeAsync();
                    }
                }
            }
            catch (Exception)
            {
                Invoice.State = "متاسفانه پرداخت ناموفق بوده است.";
                Invoice.RefNum = "";
                Invoice.Purchased = false;
                _invoiceService.UpdateInvoice(Invoice);
                await _invoiceService.SaveChangeAsync();
            }
            
            return Page();
        }


        public class JsonResult
        {
            public int Status { get; set; }

            public string Amount { get; set; }

            public string TransId { get; set; }

            public string FactorNumber { get; set; }

            public string Mobile { get; set; }

            public string Description { get; set; }

            public string CardNumber { get; set; }

            public string TraceNumber { get; set; }

            public string Message { get; set; }

            public string ErrorCode { get; set; }

            public string ErrorMessage { get; set; }

            public JsonResult()
            {

            }
        }
    }
}