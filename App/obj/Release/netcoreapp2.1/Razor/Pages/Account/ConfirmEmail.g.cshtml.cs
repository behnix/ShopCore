#pragma checksum "C:\Users\behna\Desktop\ShopCore\ShopCore\App\Pages\Account\ConfirmEmail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8eed63559faf4a855e06dcae09b04254007a2101"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(App.Pages.Account.Pages_Account_ConfirmEmail), @"mvc.1.0.razor-page", @"/Pages/Account/ConfirmEmail.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/Account/ConfirmEmail.cshtml", typeof(App.Pages.Account.Pages_Account_ConfirmEmail), @"/confirmEmail")]
namespace App.Pages.Account
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemMetadataAttribute("RouteTemplate", "/confirmEmail")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8eed63559faf4a855e06dcae09b04254007a2101", @"/Pages/Account/ConfirmEmail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c82f81092aec1670d635e1fcc2d670210c89248a", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Account_ConfirmEmail : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "C:\Users\behna\Desktop\ShopCore\ShopCore\App\Pages\Account\ConfirmEmail.cshtml"
  
    ViewData["Title"] = "ارسال تائیدیه ایمیل";

#line default
#line hidden
            BeginContext(122, 286, true);
            WriteLiteral(@"
<div class=""breadcrumb-area bg-gray"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-lg-12"">
                <ul>
                    <li class=""breadcrumb-item""><a href=""/"">خانه</a></li>
                    <li class=""breadcrumb-item active"">");
            EndContext();
            BeginContext(409, 17, false);
#line 13 "C:\Users\behna\Desktop\ShopCore\ShopCore\App\Pages\Account\ConfirmEmail.cshtml"
                                                  Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(426, 288, true);
            WriteLiteral(@"</li>
                </ul>
            </div>
        </div>
    </div>
</div>
<div class=""content-wraper mt-60"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-lg-6"">
                <div class=""about-info-wrapper"">
                    <h2>");
            EndContext();
            BeginContext(715, 17, false);
#line 24 "C:\Users\behna\Desktop\ShopCore\ShopCore\App\Pages\Account\ConfirmEmail.cshtml"
                   Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(732, 314, true);
            WriteLiteral(@"</h2>
                    <p>حساب کاربری شما با موفقیت فعال شد. برای تکمیل مشخصات خود میتوانید به ناحیه کاربری مراجعه نمائید</p>
                    
                    <a href=""/userarea"" class=""text-success"">ناحیه کاربری</a>
                </div>
            </div>
        </div>
    </div>
</div>

");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<App.Pages.Account.ConfirmEmailModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<App.Pages.Account.ConfirmEmailModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<App.Pages.Account.ConfirmEmailModel>)PageContext?.ViewData;
        public App.Pages.Account.ConfirmEmailModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591