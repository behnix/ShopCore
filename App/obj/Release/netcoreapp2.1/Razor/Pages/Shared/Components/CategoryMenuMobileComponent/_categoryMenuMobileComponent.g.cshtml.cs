#pragma checksum "C:\Users\behna\Desktop\ShopCore\ShopCore\App\Pages\Shared\Components\CategoryMenuMobileComponent\_categoryMenuMobileComponent.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4b57943c5572d62aeb48cd46fa9c50db8174660b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(App.Pages.Shared.Components.CategoryMenuMobileComponent.Pages_Shared_Components_CategoryMenuMobileComponent__categoryMenuMobileComponent), @"mvc.1.0.view", @"/Pages/Shared/Components/CategoryMenuMobileComponent/_categoryMenuMobileComponent.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Pages/Shared/Components/CategoryMenuMobileComponent/_categoryMenuMobileComponent.cshtml", typeof(App.Pages.Shared.Components.CategoryMenuMobileComponent.Pages_Shared_Components_CategoryMenuMobileComponent__categoryMenuMobileComponent))]
namespace App.Pages.Shared.Components.CategoryMenuMobileComponent
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\behna\Desktop\ShopCore\ShopCore\App\Pages\Shared\Components\CategoryMenuMobileComponent\_categoryMenuMobileComponent.cshtml"
using App.Pages.Admin.Category;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4b57943c5572d62aeb48cd46fa9c50db8174660b", @"/Pages/Shared/Components/CategoryMenuMobileComponent/_categoryMenuMobileComponent.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c82f81092aec1670d635e1fcc2d670210c89248a", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Shared_Components_CategoryMenuMobileComponent__categoryMenuMobileComponent : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<App.Domain.Entities.Product.Category>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(91, 332, true);
            WriteLiteral(@"<div class=""container d-block d-lg-none"">
    <div class=""vertical-menu mt-30"">
        <span class=""categorie-title mobile-categorei-menu"">تمامی دسته ها</span>
        <nav>
            <div class=""category-menu sidebar-menu sidbar-style mobile-categorei-menu-list menu-hidden "" id=""cate-mobile-toggle"">
                <ul>
");
            EndContext();
#line 9 "C:\Users\behna\Desktop\ShopCore\ShopCore\App\Pages\Shared\Components\CategoryMenuMobileComponent\_categoryMenuMobileComponent.cshtml"
                     foreach (var category in Model.Where(c=>c.ParentId == 0).ToList())
                    {

#line default
#line hidden
            BeginContext(535, 83, true);
            WriteLiteral("                        <li class=\"has-sub\">\r\n                         <a href=\"#\">");
            EndContext();
            BeginContext(619, 23, false);
#line 12 "C:\Users\behna\Desktop\ShopCore\ShopCore\App\Pages\Shared\Components\CategoryMenuMobileComponent\_categoryMenuMobileComponent.cshtml"
                                Write(Html.Raw(category.Name));

#line default
#line hidden
            EndContext();
            BeginContext(642, 61, true);
            WriteLiteral("</a>\r\n                            <ul class=\"category-sub\">\r\n");
            EndContext();
#line 14 "C:\Users\behna\Desktop\ShopCore\ShopCore\App\Pages\Shared\Components\CategoryMenuMobileComponent\_categoryMenuMobileComponent.cshtml"
                                 foreach (var subCategory in Model.Where(c => c.ParentId == category.Id).ToList())
                                {

#line default
#line hidden
            BeginContext(854, 84, true);
            WriteLiteral("                                    <li>\r\n                                        <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 938, "\"", 983, 2);
            WriteAttributeValue("", 945, "/shop?selectedCategory=", 945, 23, true);
#line 17 "C:\Users\behna\Desktop\ShopCore\ShopCore\App\Pages\Shared\Components\CategoryMenuMobileComponent\_categoryMenuMobileComponent.cshtml"
WriteAttributeValue("", 968, subCategory.Id, 968, 15, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(984, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(986, 26, false);
#line 17 "C:\Users\behna\Desktop\ShopCore\ShopCore\App\Pages\Shared\Components\CategoryMenuMobileComponent\_categoryMenuMobileComponent.cshtml"
                                                                                    Write(Html.Raw(subCategory.Name));

#line default
#line hidden
            EndContext();
            BeginContext(1012, 49, true);
            WriteLiteral("</a>\r\n                                    </li>\r\n");
            EndContext();
#line 19 "C:\Users\behna\Desktop\ShopCore\ShopCore\App\Pages\Shared\Components\CategoryMenuMobileComponent\_categoryMenuMobileComponent.cshtml"
                                }

#line default
#line hidden
            BeginContext(1096, 63, true);
            WriteLiteral("                            </ul>\r\n                     </li>\r\n");
            EndContext();
#line 22 "C:\Users\behna\Desktop\ShopCore\ShopCore\App\Pages\Shared\Components\CategoryMenuMobileComponent\_categoryMenuMobileComponent.cshtml"
                    }

#line default
#line hidden
            BeginContext(1182, 77, true);
            WriteLiteral("                </ul>\r\n            </div>\r\n        </nav>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<App.Domain.Entities.Product.Category>> Html { get; private set; }
    }
}
#pragma warning restore 1591