#pragma checksum "C:\Users\behna\Desktop\ShopCore\ShopCore\App\Pages\Shared\Components\MostProductsComponent\_mostProductsComponent.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fcfaec4852a42c8ada47e4e063915707268723c0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(App.Pages.Shared.Components.MostProductsComponent.Pages_Shared_Components_MostProductsComponent__mostProductsComponent), @"mvc.1.0.view", @"/Pages/Shared/Components/MostProductsComponent/_mostProductsComponent.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Pages/Shared/Components/MostProductsComponent/_mostProductsComponent.cshtml", typeof(App.Pages.Shared.Components.MostProductsComponent.Pages_Shared_Components_MostProductsComponent__mostProductsComponent))]
namespace App.Pages.Shared.Components.MostProductsComponent
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\behna\Desktop\ShopCore\ShopCore\App\Pages\Shared\Components\MostProductsComponent\_mostProductsComponent.cshtml"
using App.Core.Convertors;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fcfaec4852a42c8ada47e4e063915707268723c0", @"/Pages/Shared/Components/MostProductsComponent/_mostProductsComponent.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c82f81092aec1670d635e1fcc2d670210c89248a", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Shared_Components_MostProductsComponent__mostProductsComponent : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<App.DTOs.MostProductsViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(67, 978, true);
            WriteLiteral(@"<div class=""product-area box-module"">
    <div class=""row"">
        <div class=""col-lg-12"">
            <div class=""tabs-categorys-list secton-title"">
                <ul class=""nav"" role=""tablist"">
                    <li role=""presentation"" class=""active""><a href=""#new-arrivals"" aria-controls=""new-arrivals"" role=""tab"" data-toggle=""tab"">جدید ترین ها</a></li>
                    <li role=""presentation""><a href=""#best-sellers"" aria-controls=""best-sellers"" role=""tab"" data-toggle=""tab"">پرفروش ها</a></li>
                    <li role=""presentation""><a href=""#on-sellers"" aria-controls=""on-sellers"" role=""tab"" data-toggle=""tab"">پربازدیدترین ها</a></li>
                </ul>
            </div>
        </div>
    </div>
    <div class=""tab-content"">
        <div role=""tabpanel"" class=""tab-pane active"" id=""new-arrivals"">
            <div class=""product-wrapper"">
                <div class=""row"">
                    <div class=""prodict-active owl-carousel"">
");
            EndContext();
#line 20 "C:\Users\behna\Desktop\ShopCore\ShopCore\App\Pages\Shared\Components\MostProductsComponent\_mostProductsComponent.cshtml"
                         foreach (var product in Model.MostNewProducs)
                        {

#line default
#line hidden
            BeginContext(1144, 225, true);
            WriteLiteral("                            <div class=\"col-lg-3\">\r\n                                <div class=\"sinle-product-item\">\r\n                                    <div class=\"product-thumb\">\r\n                                        <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1369, "\"", 1403, 2);
            WriteAttributeValue("", 1376, "/product/", 1376, 9, true);
#line 25 "C:\Users\behna\Desktop\ShopCore\ShopCore\App\Pages\Shared\Components\MostProductsComponent\_mostProductsComponent.cshtml"
WriteAttributeValue("", 1385, product.MetaTitle, 1385, 18, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1404, 73, true);
            WriteLiteral(">\r\n                                            <img class=\"primary-image\"");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 1477, "\"", 1520, 2);
            WriteAttributeValue("", 1483, "/assets/products/thumb/", 1483, 23, true);
#line 26 "C:\Users\behna\Desktop\ShopCore\ShopCore\App\Pages\Shared\Components\MostProductsComponent\_mostProductsComponent.cshtml"
WriteAttributeValue("", 1506, product.Image, 1506, 14, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 1521, "\"", 1541, 1);
#line 26 "C:\Users\behna\Desktop\ShopCore\ShopCore\App\Pages\Shared\Components\MostProductsComponent\_mostProductsComponent.cshtml"
WriteAttributeValue("", 1527, product.Title, 1527, 14, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1542, 179, true);
            WriteLiteral(">\r\n                                        </a>\r\n                                        <div class=\"add-to-cart\">\r\n                                            <a class=\"btn-cart\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1721, "\"", 1757, 2);
            WriteAttributeValue("", 1728, "/AddToCart/", 1728, 11, true);
#line 29 "C:\Users\behna\Desktop\ShopCore\ShopCore\App\Pages\Shared\Components\MostProductsComponent\_mostProductsComponent.cshtml"
WriteAttributeValue("", 1739, product.ProductId, 1739, 18, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1758, 954, true);
            WriteLiteral(@"><span> افزودن به سبد </span></a>
                                        </div>
                                    </div>
                                    <div class=""product-info"">
                                        <div class=""rating-box"">
                                            <ul class=""rating d-flex"">
                                                <li><i class=""ion-ios-star""></i></li>
                                                <li><i class=""ion-ios-star""></i></li>
                                                <li><i class=""ion-ios-star""></i></li>
                                                <li><i class=""ion-android-star-outline""></i></li>
                                                <li><i class=""ion-android-star-outline""></i></li>
                                            </ul>
                                        </div>
                                        <h4 class=""product-name""><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2712, "\"", 2746, 2);
            WriteAttributeValue("", 2719, "/product/", 2719, 9, true);
#line 42 "C:\Users\behna\Desktop\ShopCore\ShopCore\App\Pages\Shared\Components\MostProductsComponent\_mostProductsComponent.cshtml"
WriteAttributeValue("", 2728, product.MetaTitle, 2728, 18, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2747, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(2749, 13, false);
#line 42 "C:\Users\behna\Desktop\ShopCore\ShopCore\App\Pages\Shared\Components\MostProductsComponent\_mostProductsComponent.cshtml"
                                                                                                  Write(product.Title);

#line default
#line hidden
            EndContext();
            BeginContext(2762, 144, true);
            WriteLiteral("</a></h4>\r\n                                        <div class=\"price-box\">\r\n                                            <span class=\"new-price\">");
            EndContext();
            BeginContext(2907, 23, false);
#line 44 "C:\Users\behna\Desktop\ShopCore\ShopCore\App\Pages\Shared\Components\MostProductsComponent\_mostProductsComponent.cshtml"
                                                               Write(product.Price.ToPrice());

#line default
#line hidden
            EndContext();
            BeginContext(2930, 183, true);
            WriteLiteral(" تومان</span>\r\n                                        </div>\r\n                                    </div>\r\n                                </div>\r\n                            </div>\r\n");
            EndContext();
#line 49 "C:\Users\behna\Desktop\ShopCore\ShopCore\App\Pages\Shared\Components\MostProductsComponent\_mostProductsComponent.cshtml"
                        }

#line default
#line hidden
            BeginContext(3140, 295, true);
            WriteLiteral(@"                    </div>
                </div>
            </div>
        </div>
        <div role=""tabpanel"" class=""tab-pane"" id=""best-sellers"">
            <div class=""product-wrapper"">
                <div class=""row"">
                    <div class=""prodict-active owl-carousel"">
");
            EndContext();
#line 58 "C:\Users\behna\Desktop\ShopCore\ShopCore\App\Pages\Shared\Components\MostProductsComponent\_mostProductsComponent.cshtml"
                         foreach (var product in Model.MostSalesProducs)
                        {

#line default
#line hidden
            BeginContext(3536, 209, true);
            WriteLiteral("                        <div class=\"col-lg-3\">\r\n                            <div class=\"sinle-product-item\">\r\n                                <div class=\"product-thumb\">\r\n                                    <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 3745, "\"", 3779, 2);
            WriteAttributeValue("", 3752, "/product/", 3752, 9, true);
#line 63 "C:\Users\behna\Desktop\ShopCore\ShopCore\App\Pages\Shared\Components\MostProductsComponent\_mostProductsComponent.cshtml"
WriteAttributeValue("", 3761, product.MetaTitle, 3761, 18, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3780, 69, true);
            WriteLiteral(">\r\n                                        <img class=\"primary-image\"");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 3849, "\"", 3892, 2);
            WriteAttributeValue("", 3855, "/assets/products/thumb/", 3855, 23, true);
#line 64 "C:\Users\behna\Desktop\ShopCore\ShopCore\App\Pages\Shared\Components\MostProductsComponent\_mostProductsComponent.cshtml"
WriteAttributeValue("", 3878, product.Image, 3878, 14, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 3893, "\"", 3913, 1);
#line 64 "C:\Users\behna\Desktop\ShopCore\ShopCore\App\Pages\Shared\Components\MostProductsComponent\_mostProductsComponent.cshtml"
WriteAttributeValue("", 3899, product.Title, 3899, 14, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3914, 1078, true);
            WriteLiteral(@">
                                    </a>
                                    <div class=""add-to-cart"">
                                        <a class=""btn-cart"" href=""#""><span> افزودن به سبد </span></a>
                                    </div>
                                </div>
                                <div class=""product-info"">
                                    <div class=""rating-box"">
                                        <ul class=""rating d-flex"">
                                            <li><i class=""ion-ios-star""></i></li>
                                            <li><i class=""ion-ios-star""></i></li>
                                            <li><i class=""ion-ios-star""></i></li>
                                            <li><i class=""ion-android-star-outline""></i></li>
                                            <li><i class=""ion-android-star-outline""></i></li>
                                        </ul>
                                    </div>
         ");
            WriteLiteral("                           <h4 class=\"product-name\"><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 4992, "\"", 5026, 2);
            WriteAttributeValue("", 4999, "/product/", 4999, 9, true);
#line 80 "C:\Users\behna\Desktop\ShopCore\ShopCore\App\Pages\Shared\Components\MostProductsComponent\_mostProductsComponent.cshtml"
WriteAttributeValue("", 5008, product.MetaTitle, 5008, 18, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(5027, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(5029, 13, false);
#line 80 "C:\Users\behna\Desktop\ShopCore\ShopCore\App\Pages\Shared\Components\MostProductsComponent\_mostProductsComponent.cshtml"
                                                                                              Write(product.Title);

#line default
#line hidden
            EndContext();
            BeginContext(5042, 136, true);
            WriteLiteral("</a></h4>\r\n                                    <div class=\"price-box\">\r\n                                        <span class=\"new-price\">");
            EndContext();
            BeginContext(5179, 23, false);
#line 82 "C:\Users\behna\Desktop\ShopCore\ShopCore\App\Pages\Shared\Components\MostProductsComponent\_mostProductsComponent.cshtml"
                                                           Write(product.Price.ToPrice());

#line default
#line hidden
            EndContext();
            BeginContext(5202, 167, true);
            WriteLiteral(" تومان</span>\r\n                                    </div>\r\n                                </div>\r\n                            </div>\r\n                        </div>\r\n");
            EndContext();
#line 87 "C:\Users\behna\Desktop\ShopCore\ShopCore\App\Pages\Shared\Components\MostProductsComponent\_mostProductsComponent.cshtml"
                        }

#line default
#line hidden
            BeginContext(5396, 293, true);
            WriteLiteral(@"                    </div>
                </div>
            </div>
        </div>
        <div role=""tabpanel"" class=""tab-pane"" id=""on-sellers"">
            <div class=""product-wrapper"">
                <div class=""row"">
                    <div class=""prodict-active owl-carousel"">
");
            EndContext();
#line 96 "C:\Users\behna\Desktop\ShopCore\ShopCore\App\Pages\Shared\Components\MostProductsComponent\_mostProductsComponent.cshtml"
                         foreach (var product in Model.MostVisitProducs)
                        {

#line default
#line hidden
            BeginContext(5790, 209, true);
            WriteLiteral("                        <div class=\"col-lg-3\">\r\n                            <div class=\"sinle-product-item\">\r\n                                <div class=\"product-thumb\">\r\n                                    <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 5999, "\"", 6033, 2);
            WriteAttributeValue("", 6006, "/product/", 6006, 9, true);
#line 101 "C:\Users\behna\Desktop\ShopCore\ShopCore\App\Pages\Shared\Components\MostProductsComponent\_mostProductsComponent.cshtml"
WriteAttributeValue("", 6015, product.MetaTitle, 6015, 18, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(6034, 69, true);
            WriteLiteral(">\r\n                                        <img class=\"primary-image\"");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 6103, "\"", 6146, 2);
            WriteAttributeValue("", 6109, "/assets/products/thumb/", 6109, 23, true);
#line 102 "C:\Users\behna\Desktop\ShopCore\ShopCore\App\Pages\Shared\Components\MostProductsComponent\_mostProductsComponent.cshtml"
WriteAttributeValue("", 6132, product.Image, 6132, 14, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 6147, "\"", 6167, 1);
#line 102 "C:\Users\behna\Desktop\ShopCore\ShopCore\App\Pages\Shared\Components\MostProductsComponent\_mostProductsComponent.cshtml"
WriteAttributeValue("", 6153, product.Title, 6153, 14, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(6168, 1078, true);
            WriteLiteral(@">
                                    </a>
                                    <div class=""add-to-cart"">
                                        <a class=""btn-cart"" href=""#""><span> افزودن به سبد </span></a>
                                    </div>
                                </div>
                                <div class=""product-info"">
                                    <div class=""rating-box"">
                                        <ul class=""rating d-flex"">
                                            <li><i class=""ion-ios-star""></i></li>
                                            <li><i class=""ion-ios-star""></i></li>
                                            <li><i class=""ion-ios-star""></i></li>
                                            <li><i class=""ion-android-star-outline""></i></li>
                                            <li><i class=""ion-android-star-outline""></i></li>
                                        </ul>
                                    </div>
         ");
            WriteLiteral("                           <h4 class=\"product-name\"><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 7246, "\"", 7280, 2);
            WriteAttributeValue("", 7253, "/product/", 7253, 9, true);
#line 118 "C:\Users\behna\Desktop\ShopCore\ShopCore\App\Pages\Shared\Components\MostProductsComponent\_mostProductsComponent.cshtml"
WriteAttributeValue("", 7262, product.MetaTitle, 7262, 18, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(7281, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(7283, 13, false);
#line 118 "C:\Users\behna\Desktop\ShopCore\ShopCore\App\Pages\Shared\Components\MostProductsComponent\_mostProductsComponent.cshtml"
                                                                                              Write(product.Title);

#line default
#line hidden
            EndContext();
            BeginContext(7296, 136, true);
            WriteLiteral("</a></h4>\r\n                                    <div class=\"price-box\">\r\n                                        <span class=\"new-price\">");
            EndContext();
            BeginContext(7433, 23, false);
#line 120 "C:\Users\behna\Desktop\ShopCore\ShopCore\App\Pages\Shared\Components\MostProductsComponent\_mostProductsComponent.cshtml"
                                                           Write(product.Price.ToPrice());

#line default
#line hidden
            EndContext();
            BeginContext(7456, 167, true);
            WriteLiteral(" تومان</span>\r\n                                    </div>\r\n                                </div>\r\n                            </div>\r\n                        </div>\r\n");
            EndContext();
#line 125 "C:\Users\behna\Desktop\ShopCore\ShopCore\App\Pages\Shared\Components\MostProductsComponent\_mostProductsComponent.cshtml"
                        }

#line default
#line hidden
            BeginContext(7650, 106, true);
            WriteLiteral("                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<App.DTOs.MostProductsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
