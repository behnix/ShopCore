#pragma checksum "C:\Users\behna\Desktop\ShopCore\ShopCore\App\Pages\Shared\_Layout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "084717ba16a59a6e90dbf2b608df6ca56ee2381f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(App.Pages.Shared.Pages_Shared__Layout), @"mvc.1.0.view", @"/Pages/Shared/_Layout.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Pages/Shared/_Layout.cshtml", typeof(App.Pages.Shared.Pages_Shared__Layout))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"084717ba16a59a6e90dbf2b608df6ca56ee2381f", @"/Pages/Shared/_Layout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c82f81092aec1670d635e1fcc2d670210c89248a", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Shared__Layout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a51905bfc11242b3b9578f2d338455dd", async() => {
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
#line 9 "C:\Users\behna\Desktop\ShopCore\ShopCore\App\Pages\Shared\_Layout.cshtml"
Write(await Component.InvokeAsync("LayoutComponent"));

#line default
#line hidden
                EndContext();
                BeginContext(362, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(368, 26, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "e982249f1d324c46a90c737e90ac767a", async() => {
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
#line 11 "C:\Users\behna\Desktop\ShopCore\ShopCore\App\Pages\Shared\_Layout.cshtml"
Write(await Component.InvokeAsync("ThemeComponent"));

#line default
#line hidden
                EndContext();
                BeginContext(446, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(452, 58, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7966d802a8064ac8affc553af96a137e", async() => {
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
            BeginContext(521, 5371, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1d1fcda85d55432784b544ff31a49698", async() => {
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
#line 23 "C:\Users\behna\Desktop\ShopCore\ShopCore\App\Pages\Shared\_Layout.cshtml"
                   Write(await Component.InvokeAsync("LogoComponent"));

#line default
#line hidden
                EndContext();
                BeginContext(1010, 26, true);
                WriteLiteral("\r\n                        ");
                EndContext();
                BeginContext(1037, 54, false);
#line 24 "C:\Users\behna\Desktop\ShopCore\ShopCore\App\Pages\Shared\_Layout.cshtml"
                   Write(await Component.InvokeAsync("CategorySearchComponent"));

#line default
#line hidden
                EndContext();
                BeginContext(1091, 26, true);
                WriteLiteral("\r\n                        ");
                EndContext();
                BeginContext(1118, 44, false);
#line 25 "C:\Users\behna\Desktop\ShopCore\ShopCore\App\Pages\Shared\_Layout.cshtml"
                   Write(await Component.InvokeAsync("CartComponent"));

#line default
#line hidden
                EndContext();
                BeginContext(1162, 243, true);
                WriteLiteral("\r\n                    </div>\r\n                </div>\r\n            </div>\r\n            <div class=\"main-menu-area sticky-header bg-white\">\r\n                <div class=\"container\">\r\n                    <div class=\"row\">\r\n                        ");
                EndContext();
                BeginContext(1406, 52, false);
#line 32 "C:\Users\behna\Desktop\ShopCore\ShopCore\App\Pages\Shared\_Layout.cshtml"
                   Write(await Component.InvokeAsync("CategoryMenuComponent"));

#line default
#line hidden
                EndContext();
                BeginContext(1458, 998, true);
                WriteLiteral(@"
                        <div class=""col-lg-6"">
                            <div class=""main-menu d-none d-lg-block"">
                                <nav>
                                    <ul>
                                        <li>
                                            <a href=""/"">خانه</a>
                                        </li>
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
#line 51 "C:\Users\behna\Desktop\ShopCore\ShopCore\App\Pages\Shared\_Layout.cshtml"
                                     if (User.Identity.IsAuthenticated)
                                    {

#line default
#line hidden
                BeginContext(2568, 326, true);
                WriteLiteral(@"                                        <li class=""currency"">
                                            <div class=""btn-group"">
                                                <a href=""/userarea"" class=""btn-link"">
                                                    <i class=""fa fa-user-circle-o"" aria-hidden=""true""></i> ");
                EndContext();
                BeginContext(2895, 29, false);
#line 56 "C:\Users\behna\Desktop\ShopCore\ShopCore\App\Pages\Shared\_Layout.cshtml"
                                                                                                      Write(User.Claims.ToList()[4].Value);

#line default
#line hidden
                EndContext();
                BeginContext(2924, 1, true);
                WriteLiteral(" ");
                EndContext();
                BeginContext(2926, 29, false);
#line 56 "C:\Users\behna\Desktop\ShopCore\ShopCore\App\Pages\Shared\_Layout.cshtml"
                                                                                                                                     Write(User.Claims.ToList()[5].Value);

#line default
#line hidden
                EndContext();
                BeginContext(2955, 633, true);
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
#line 67 "C:\Users\behna\Desktop\ShopCore\ShopCore\App\Pages\Shared\_Layout.cshtml"
                                    }
                                    else
                                    {

#line default
#line hidden
                BeginContext(3708, 972, true);
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
#line 84 "C:\Users\behna\Desktop\ShopCore\ShopCore\App\Pages\Shared\_Layout.cshtml"
                                    }

#line default
#line hidden
                BeginContext(4719, 928, true);
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
                BeginContext(5648, 58, false);
#line 105 "C:\Users\behna\Desktop\ShopCore\ShopCore\App\Pages\Shared\_Layout.cshtml"
   Write(await Component.InvokeAsync("CategoryMenuMobileComponent"));

#line default
#line hidden
                EndContext();
                BeginContext(5706, 10, true);
                WriteLiteral("\r\n        ");
                EndContext();
                BeginContext(5717, 12, false);
#line 106 "C:\Users\behna\Desktop\ShopCore\ShopCore\App\Pages\Shared\_Layout.cshtml"
   Write(RenderBody());

#line default
#line hidden
                EndContext();
                BeginContext(5729, 10, true);
                WriteLiteral("\r\n        ");
                EndContext();
                BeginContext(5740, 46, false);
#line 107 "C:\Users\behna\Desktop\ShopCore\ShopCore\App\Pages\Shared\_Layout.cshtml"
   Write(await Component.InvokeAsync("FooterComponent"));

#line default
#line hidden
                EndContext();
                BeginContext(5786, 22, true);
                WriteLiteral("\r\n    </div>\r\n\r\n\r\n    ");
                EndContext();
                BeginContext(5808, 27, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "d374fbfb69944d73bbc01b0051ee0709", async() => {
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
                BeginContext(5835, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(5842, 41, false);
#line 112 "C:\Users\behna\Desktop\ShopCore\ShopCore\App\Pages\Shared\_Layout.cshtml"
Write(RenderSection("Scripts", required: false));

#line default
#line hidden
                EndContext();
                BeginContext(5883, 2, true);
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
            BeginContext(5892, 11, true);
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
