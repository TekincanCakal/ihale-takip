#pragma checksum "C:\Users\yukse\Documents\GitHub\ihale-takip\WebUI\İhaleTakip.WebUI.Site\Views\Shared\_ElectricityMenu.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1c023feff8b24e357ba4112329df691b56567799"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__ElectricityMenu), @"mvc.1.0.view", @"/Views/Shared/_ElectricityMenu.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 2 "C:\Users\yukse\Documents\GitHub\ihale-takip\WebUI\İhaleTakip.WebUI.Site\Views\_ViewImports.cshtml"
using Microsoft.Extensions.Options;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\yukse\Documents\GitHub\ihale-takip\WebUI\İhaleTakip.WebUI.Site\Views\_ViewImports.cshtml"
using İhaleTakip.WebUI.Site.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\yukse\Documents\GitHub\ihale-takip\WebUI\İhaleTakip.WebUI.Site\Views\_ViewImports.cshtml"
using İhaleTakip.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\yukse\Documents\GitHub\ihale-takip\WebUI\İhaleTakip.WebUI.Site\Views\_ViewImports.cshtml"
using İhaleTakip.Model;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\yukse\Documents\GitHub\ihale-takip\WebUI\İhaleTakip.WebUI.Site\Views\_ViewImports.cshtml"
using System.Security.Claims;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\yukse\Documents\GitHub\ihale-takip\WebUI\İhaleTakip.WebUI.Site\Views\_ViewImports.cshtml"
using İhaleTakip.WebUI.Site.Managers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\yukse\Documents\GitHub\ihale-takip\WebUI\İhaleTakip.WebUI.Site\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1c023feff8b24e357ba4112329df691b56567799", @"/Views/Shared/_ElectricityMenu.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"386bedd329dfc2110bc5199d87da40c236d575f1", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__ElectricityMenu : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"d-flex bg-light text-white text-center\" style=\"background-color: #f5f7fa;\">\r\n    <div class=\"col-sm-6 col-md-2 px-3 py-5 border tab-head\">\r\n        <a");
            BeginWriteAttribute("class", " class=\"", 162, "\"", 269, 1);
#nullable restore
#line 3 "C:\Users\yukse\Documents\GitHub\ihale-takip\WebUI\İhaleTakip.WebUI.Site\Views\Shared\_ElectricityMenu.cshtml"
WriteAttributeValue("", 170, ViewContext.RouteData.Values["controller"].ToString() == "ElectricitySubscriber" ? "active" : "", 170, 99, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("href", " href=\"", 270, "\"", 322, 1);
#nullable restore
#line 3 "C:\Users\yukse\Documents\GitHub\ihale-takip\WebUI\İhaleTakip.WebUI.Site\Views\Shared\_ElectricityMenu.cshtml"
WriteAttributeValue("", 277, Url.Action("Index", "ElectricitySubscriber"), 277, 45, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n            <i class=\"fa fa-3x fa-user\" aria-hidden=\"true\"></i>\r\n            <br />\r\n            <span class=\"h5\">Abonelikler</span>\r\n        </a>\r\n    </div>\r\n    <div class=\"col-sm-6 col-md-2 px-3 py-5 border\">\r\n        <a");
            BeginWriteAttribute("class", " class=\"", 550, "\"", 672, 2);
            WriteAttributeValue("", 558, "tab-head", 558, 8, true);
#nullable restore
#line 10 "C:\Users\yukse\Documents\GitHub\ihale-takip\WebUI\İhaleTakip.WebUI.Site\Views\Shared\_ElectricityMenu.cshtml"
WriteAttributeValue(" ", 566, ViewContext.RouteData.Values["controller"].ToString() == "ElectricitySubscriptionType" ? "active" : "", 567, 105, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("href", " href=\"", 673, "\"", 731, 1);
#nullable restore
#line 10 "C:\Users\yukse\Documents\GitHub\ihale-takip\WebUI\İhaleTakip.WebUI.Site\Views\Shared\_ElectricityMenu.cshtml"
WriteAttributeValue("", 680, Url.Action("Index", "ElectricitySubscriptionType"), 680, 51, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n            <i class=\"fa fa-3x fa-users\" aria-hidden=\"true\"></i>\r\n            <br />\r\n            <span class=\"h5\">Abonelik Türleri</span>\r\n        </a>\r\n    </div>\r\n    <div class=\"col-sm-6 col-md-2 px-3 py-5 border\">\r\n        <a");
            BeginWriteAttribute("class", " class=\"", 965, "\"", 1080, 2);
            WriteAttributeValue("", 973, "tab-head", 973, 8, true);
#nullable restore
#line 17 "C:\Users\yukse\Documents\GitHub\ihale-takip\WebUI\İhaleTakip.WebUI.Site\Views\Shared\_ElectricityMenu.cshtml"
WriteAttributeValue(" ", 981, ViewContext.RouteData.Values["controller"].ToString() == "ElectricityUnitPrice" ? "active" : "", 982, 98, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("href", " href=\"", 1081, "\"", 1132, 1);
#nullable restore
#line 17 "C:\Users\yukse\Documents\GitHub\ihale-takip\WebUI\İhaleTakip.WebUI.Site\Views\Shared\_ElectricityMenu.cshtml"
WriteAttributeValue("", 1088, Url.Action("Index", "ElectricityUnitPrice"), 1088, 44, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n            <i class=\"fa fa-3x fa-try\" aria-hidden=\"true\"></i>\r\n            <br />\r\n            <span class=\"h5\">Birim Fiyatlar</span>\r\n        </a>\r\n    </div>\r\n    <div class=\"col-sm-6 col-md-2 px-3 py-5 border\">\r\n        <a");
            BeginWriteAttribute("class", " class=\"", 1362, "\"", 1480, 2);
            WriteAttributeValue("", 1370, "tab-head", 1370, 8, true);
#nullable restore
#line 24 "C:\Users\yukse\Documents\GitHub\ihale-takip\WebUI\İhaleTakip.WebUI.Site\Views\Shared\_ElectricityMenu.cshtml"
WriteAttributeValue(" ", 1378, ViewContext.RouteData.Values["controller"].ToString() == "ElectricityTenderReport" ? "active" : "", 1379, 101, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("href", " href=\"", 1481, "\"", 1535, 1);
#nullable restore
#line 24 "C:\Users\yukse\Documents\GitHub\ihale-takip\WebUI\İhaleTakip.WebUI.Site\Views\Shared\_ElectricityMenu.cshtml"
WriteAttributeValue("", 1488, Url.Action("Index", "ElectricityTenderReport"), 1488, 47, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n            <i class=\"fa fa-3x fa-flag\" aria-hidden=\"true\"></i>\r\n            <br />\r\n            <span class=\"h5\">Rapor</span>\r\n        </a>\r\n    </div>\r\n</div>");
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
