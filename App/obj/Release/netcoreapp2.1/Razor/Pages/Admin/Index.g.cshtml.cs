#pragma checksum "C:\Users\behna\Desktop\ShopCore\ShopCore\App\Pages\Admin\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "32f99628f9793ae2ac2814d4accb9b34b5e92a38"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(App.Pages.Admin.Pages_Admin_Index), @"mvc.1.0.razor-page", @"/Pages/Admin/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/Admin/Index.cshtml", typeof(App.Pages.Admin.Pages_Admin_Index), null)]
namespace App.Pages.Admin
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"32f99628f9793ae2ac2814d4accb9b34b5e92a38", @"/Pages/Admin/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c82f81092aec1670d635e1fcc2d670210c89248a", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Admin_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "C:\Users\behna\Desktop\ShopCore\ShopCore\App\Pages\Admin\Index.cshtml"
  
    ViewData["Title"] = "وردپرس دات نت";
    Layout = "_Admin";

#line default
#line hidden
            BeginContext(115, 1932, true);
            WriteLiteral(@"
<div class=""row wrapper border-bottom white-bg page-heading"">
    <div class=""col-lg-9"">
        <h2>داشبورد</h2>
        <ol class=""breadcrumb"">
            <li class=""active"">
                <a href=""/admin"">خانه</a>
            </li>
        </ol>
    </div>
</div>
<div class=""wrapper wrapper-content animated fadeInRight"">
    <div class=""row"">
        <div class=""col-lg-12"">
        <div class=""wrapper wrapper-content"">
            <div class=""row"">
                <div class=""col-md-12"">
                    <div class=""panel panel-primary"">
                        <div class=""panel-heading""> <i class=""fa fa-info-circle"" aria-hidden=""true""></i>  لیست آخرین تغییرات  ( چهارشنبه دهم بهمن 97)</div>
                        <div class=""panel-body"">
                            <ul>
                                <li class=""text-primary"">برخی تغییرات در سئو سایت</li>
                                <li class=""text-primary"">فایل Robots.txt اضافه شد</li>
                                <li");
            WriteLiteral(@" class=""text-primary"">سیستم اتوماتیک تولید نقشه سایت اضافه شد</li>
                                <li class=""text-primary"">باگ صفحه اول در نسخه موبایل برطرف شد</li>
                                <li class=""text-primary"">مقدمات Minify کردن فایلهای CSS و Js برنامه ریزی شد</li>
                                <li class=""text-primary"">بخش راهنمای استفاده راه اندازی شد</li>
                                <li class=""text-primary"">سبک های جدید به ویرایشگر اضافه شد</li>
                                <li class=""text-primary"">اصلاح آیکن ها در کنترل پنل</li>
                                <li class=""text-primary"">تغییر حروف مجاز در توضیحات موتورهای جستجو به بیشتر از 120 کاراکتر و کمتر از 155 کاراکتر</li>
                            </ul>
                        </div>
                    </div>
                </div>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<App.Pages.Admin.IndexModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<App.Pages.Admin.IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<App.Pages.Admin.IndexModel>)PageContext?.ViewData;
        public App.Pages.Admin.IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591