#pragma checksum "C:\Users\behna\Desktop\ShopCore\ShopCore\App\Pages\Shared\_Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1e35971fe5f01819cfb0b84910dc1eecf294ad9a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(App.Pages.Shared.Pages_Shared__Default), @"mvc.1.0.view", @"/Pages/Shared/_Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Pages/Shared/_Default.cshtml", typeof(App.Pages.Shared.Pages_Shared__Default))]
namespace App.Pages.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1e35971fe5f01819cfb0b84910dc1eecf294ad9a", @"/Pages/Shared/_Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c82f81092aec1670d635e1fcc2d670210c89248a", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Shared__Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_Styles", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/vendor/modernizr-2.8.3.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_Scripts", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 25, true);
            WriteLiteral("<!DOCTYPE html>\r\n<html>\r\n");
            EndContext();
            BeginContext(25, 494, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fb3cf0e46c0e48199c8c6c29ff4a271e", async() => {
                BeginContext(31, 284, true);
                WriteLiteral(@"
    <meta charset=""utf-8"" />
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"" />
    <meta http-equiv=""x-ua-compatible"" content=""ie=edge"">
    <meta name=""description"" content="""">
    <link rel=""shortcut icon"" type=""image/png"" href=""/favicon.ico"">
    ");
                EndContext();
                BeginContext(316, 46, false);
#line 9 "C:\Users\behna\Desktop\ShopCore\ShopCore\App\Pages\Shared\_Default.cshtml"
Write(await Component.InvokeAsync("LayoutComponent"));

#line default
#line hidden
                EndContext();
                BeginContext(362, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(368, 26, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "76a239f834ab41bebba89565339d03ca", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(394, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(401, 45, false);
#line 11 "C:\Users\behna\Desktop\ShopCore\ShopCore\App\Pages\Shared\_Default.cshtml"
Write(await Component.InvokeAsync("ThemeComponent"));

#line default
#line hidden
                EndContext();
                BeginContext(446, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(452, 58, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "47e95f6c38df4a27b7e05f28c32efdca", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(510, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(519, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(521, 5281, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7a9cb80b8fbb4b31b1a236e5c83a4173", async() => {
                BeginContext(527, 438, true);
                WriteLiteral(@"
    <!--[if lt IE 8]>
        <p class=""browserupgrade"">مرورگر شما <strong>قدیمی</strong> است. لطفا مرورگر خود را <a href=""http://browsehappy.com/"">به روز رسانی نمایید</a> تا تجربه بهتری داشته باشید. با تشکر</p>
    <![endif]-->
    <div class=""wrapper home-4"">
        <header>
            <div class=""header-area bg-white"">
                <div class=""container"">
                    <div class=""row"">
                        ");
                EndContext();
                BeginContext(966, 44, false);
#line 23 "C:\Users\behna\Desktop\ShopCore\ShopCore\App\Pages\Shared\_Default.cshtml"
                   Write(await Component.InvokeAsync("LogoComponent"));

#line default
#line hidden
                EndContext();
                BeginContext(1010, 26, true);
                WriteLiteral("\r\n                        ");
                EndContext();
                BeginContext(1037, 54, false);
#line 24 "C:\Users\behna\Desktop\ShopCore\ShopCore\App\Pages\Shared\_Default.cshtml"
                   Write(await Component.InvokeAsync("CategorySearchComponent"));

#line default
#line hidden
                EndContext();
                BeginContext(1091, 26, true);
                WriteLiteral("\r\n                        ");
                EndContext();
                BeginContext(1118, 44, false);
#line 25 "C:\Users\behna\Desktop\ShopCore\ShopCore\App\Pages\Shared\_Default.cshtml"
                   Write(await Component.InvokeAsync("CartComponent"));

#line default
#line hidden
                EndContext();
                BeginContext(1162, 243, true);
                WriteLiteral("\r\n                    </div>\r\n                </div>\r\n            </div>\r\n            <div class=\"main-menu-area sticky-header bg-white\">\r\n                <div class=\"container\">\r\n                    <div class=\"row\">\r\n                        ");
                EndContext();
                BeginContext(1406, 52, false);
#line 32 "C:\Users\behna\Desktop\ShopCore\ShopCore\App\Pages\Shared\_Default.cshtml"
                   Write(await Component.InvokeAsync("CategoryMenuComponent"));

#line default
#line hidden
                EndContext();
                BeginContext(1458, 910, true);
                WriteLiteral(@"
                        <div class=""col-lg-6"">
                            <div class=""main-menu d-none d-lg-block"">
                                <nav>
                                    <ul>
                                        <li><a href=""/"">خانه</a></li>
                                        <li><a href=""/blog"">بلاگ</a></li>
                                        <li><a href=""/shop"">فروشگاه</a></li>
                                        <li><a href=""/about"">درباره ما</a></li>
                                        <li><a href=""/contact"">تماس با ما</a></li>
                                    </ul>
                                </nav>
                            </div>
                        </div>
                        <div class=""col-lg-3"">
                            <div class=""top-box-lang top-box-lang-4 text-right"">
                                <ul>
");
                EndContext();
#line 49 "C:\Users\behna\Desktop\ShopCore\ShopCore\App\Pages\Shared\_Default.cshtml"
                                     if (User.Identity.IsAuthenticated)
                                    {

#line default
#line hidden
                BeginContext(2480, 326, true);
                WriteLiteral(@"                                        <li class=""currency"">
                                            <div class=""btn-group"">
                                                <a href=""/userarea"" class=""btn-link"">
                                                    <i class=""fa fa-user-circle-o"" aria-hidden=""true""></i> ");
                EndContext();
                BeginContext(2807, 29, false);
#line 54 "C:\Users\behna\Desktop\ShopCore\ShopCore\App\Pages\Shared\_Default.cshtml"
                                                                                                      Write(User.Claims.ToList()[4].Value);

#line default
#line hidden
                EndContext();
                BeginContext(2836, 1, true);
                WriteLiteral(" ");
                EndContext();
                BeginContext(2838, 29, false);
#line 54 "C:\Users\behna\Desktop\ShopCore\ShopCore\App\Pages\Shared\_Default.cshtml"
                                                                                                                                     Write(User.Claims.ToList()[5].Value);

#line default
#line hidden
                EndContext();
                BeginContext(2867, 633, true);
                WriteLiteral(@"
                                                </a>
                                            </div>
                                        </li>
                                        <li class=""language"">
                                            <div class=""btn-group"">
                                                <a href=""/logout"" class=""btn-link"">
                                                    <i class=""fa fa-sign-out"" aria-hidden=""true""></i> خروج
                                                </a>
                                            </div>
                                        </li>
");
                EndContext();
#line 65 "C:\Users\behna\Desktop\ShopCore\ShopCore\App\Pages\Shared\_Default.cshtml"
                                    }
                                    else
                                    {

#line default
#line hidden
                BeginContext(3620, 972, true);
                WriteLiteral(@"                                        <li class=""currency"">
                                            <div class=""btn-group"">
                                                <a href=""/login"" class=""btn-link"">
                                                    <i class=""fa fa-sign-in"" aria-hidden=""true""></i> ورود به سایت
                                                </a>
                                            </div>
                                        </li>
                                        <li class=""language"">
                                            <div class=""btn-group"">
                                                <a href=""/register"" class=""btn-link"">
                                                    <i class=""fa fa-user-circle-o"" aria-hidden=""true""></i> ثبت نام
                                                </a>
                                            </div>
                                        </li>
");
                EndContext();
#line 82 "C:\Users\behna\Desktop\ShopCore\ShopCore\App\Pages\Shared\_Default.cshtml"
                                    }

#line default
#line hidden
                BeginContext(4631, 928, true);
                WriteLiteral(@"                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class=""mobile-menu-area d-block d-lg-none"">
                        <div class=""mobile-menu"">
                            <nav id=""mobile-menu-active"">
                                <ul>
                                    <li><a href=""/"">خانه</a></li>
                                    <li><a href=""/blog"">بلاگ</a></li>
                                    <li><a href=""/shop"">فروشگاه</a></li>
                                    <li><a href=""/about"">درباره ما</a></li>
                                    <li><a href=""/contact"">تماس با ما</a></li>
                                </ul>
                            </nav>
                        </div>
                    </div>
                </div>
            </div>
        </header>
        ");
                EndContext();
                BeginContext(5560, 58, false);
#line 103 "C:\Users\behna\Desktop\ShopCore\ShopCore\App\Pages\Shared\_Default.cshtml"
   Write(await Component.InvokeAsync("CategoryMenuMobileComponent"));

#line default
#line hidden
                EndContext();
                BeginContext(5618, 10, true);
                WriteLiteral("\r\n        ");
                EndContext();
                BeginContext(5629, 12, false);
#line 104 "C:\Users\behna\Desktop\ShopCore\ShopCore\App\Pages\Shared\_Default.cshtml"
   Write(RenderBody());

#line default
#line hidden
                EndContext();
                BeginContext(5641, 10, true);
                WriteLiteral("\r\n        ");
                EndContext();
                BeginContext(5652, 46, false);
#line 105 "C:\Users\behna\Desktop\ShopCore\ShopCore\App\Pages\Shared\_Default.cshtml"
   Write(await Component.InvokeAsync("FooterComponent"));

#line default
#line hidden
                EndContext();
                BeginContext(5698, 20, true);
                WriteLiteral("\r\n    </div>\r\n\r\n    ");
                EndContext();
                BeginContext(5718, 27, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "943b22c253274477acd84a8473ec448f", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(5745, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(5752, 41, false);
#line 109 "C:\Users\behna\Desktop\ShopCore\ShopCore\App\Pages\Shared\_Default.cshtml"
Write(RenderSection("Scripts", required: false));

#line default
#line hidden
                EndContext();
                BeginContext(5793, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(5802, 11, true);
            WriteLiteral("\r\n</html>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
