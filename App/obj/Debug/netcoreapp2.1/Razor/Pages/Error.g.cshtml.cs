#pragma checksum "C:\Users\behna\Desktop\ShopCore\ShopCore\App\Pages\Error.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2825a34f6a5179a7c00d8fcc000ee84d55844c00"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(App.Pages.Pages_Error), @"mvc.1.0.razor-page", @"/Pages/Error.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/Error.cshtml", typeof(App.Pages.Pages_Error), @"/error")]
namespace App.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemMetadataAttribute("RouteTemplate", "/error")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2825a34f6a5179a7c00d8fcc000ee84d55844c00", @"/Pages/Error.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c82f81092aec1670d635e1fcc2d670210c89248a", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Error : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "C:\Users\behna\Desktop\ShopCore\ShopCore\App\Pages\Error.cshtml"
  
    ViewData["Title"] = "بروز خطا";

#line default
#line hidden
            BeginContext(79, 284, true);
            WriteLiteral(@"<div class=""breadcrumb-area bg-gray"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-lg-12"">
                <ul>
                    <li class=""breadcrumb-item""><a href=""/"">خانه</a></li>
                    <li class=""breadcrumb-item active"">");
            EndContext();
            BeginContext(364, 17, false);
#line 12 "C:\Users\behna\Desktop\ShopCore\ShopCore\App\Pages\Error.cshtml"
                                                  Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(381, 293, true);
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
                <div class=""about-info-wrapper py-5"">
                    <h2>");
            EndContext();
            BeginContext(675, 17, false);
#line 23 "C:\Users\behna\Desktop\ShopCore\ShopCore\App\Pages\Error.cshtml"
                   Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(692, 7, true);
            WriteLiteral("</h2>\r\n");
            EndContext();
#line 24 "C:\Users\behna\Desktop\ShopCore\ShopCore\App\Pages\Error.cshtml"
                     if (Model.ShowRequestId)
                    {

#line default
#line hidden
            BeginContext(769, 249, true);
            WriteLiteral("                        <p>متاسفانه در پردازش درخواست شما خطایی بوجود آمد. این خطا به صورت خودکار برای مدیر سایت ارسال می شود. لطفا بعدا تلاش بفرمائید.</p>\r\n                        <p>\r\n                            <strong>Request ID:</strong> <code>");
            EndContext();
            BeginContext(1019, 15, false);
#line 28 "C:\Users\behna\Desktop\ShopCore\ShopCore\App\Pages\Error.cshtml"
                                                          Write(Model.RequestId);

#line default
#line hidden
            EndContext();
            BeginContext(1034, 39, true);
            WriteLiteral("</code>\r\n                        </p>\r\n");
            EndContext();
#line 30 "C:\Users\behna\Desktop\ShopCore\ShopCore\App\Pages\Error.cshtml"
                    }

#line default
#line hidden
            BeginContext(1096, 84, true);
            WriteLiteral("                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ErrorModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ErrorModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ErrorModel>)PageContext?.ViewData;
        public ErrorModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
