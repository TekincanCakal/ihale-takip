#pragma checksum "C:\Users\yukse\Documents\GitHub\ihale-takip\WebUI\İhaleTakip.WebUI.Site\Views\Electricity\ElectricitySubscriber\Observer\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "824de147c481bcbfebcc40a713d899e19ad8ed3b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Electricity_ElectricitySubscriber_Observer_Index), @"mvc.1.0.view", @"/Views/Electricity/ElectricitySubscriber/Observer/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"824de147c481bcbfebcc40a713d899e19ad8ed3b", @"/Views/Electricity/ElectricitySubscriber/Observer/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"386bedd329dfc2110bc5199d87da40c236d575f1", @"/Views/_ViewImports.cshtml")]
    public class Views_Electricity_ElectricitySubscriber_Observer_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"row py-3\">\r\n    <div class=\"col\">\r\n        <input class=\"form-control\" onchange=\"onDateChange(this)\" type=\"month\"");
            BeginWriteAttribute("value", " value=\"", 125, "\"", 150, 1);
#nullable restore
#line 3 "C:\Users\yukse\Documents\GitHub\ihale-takip\WebUI\İhaleTakip.WebUI.Site\Views\Electricity\ElectricitySubscriber\Observer\Index.cshtml"
WriteAttributeValue("", 133, ViewBag.DateText, 133, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" />
    </div>
    <div class=""col"">
        <input class=""form-control"" id=""search"" type=""text"" placeholder=""Ara"" />
    </div>
</div>

<table id=""table""
       data-toggle=""table""
       data-search=""true""
       data-search-on-enter-key=""false""
       data-pagination=""true""
       data-page-list=""[10, 25, 50, 100, all]""
       data-search-selector=""#search"">
    <thead>
        <tr>
            <th class=""text-center"">Tesisat Numarası</th>
            <th class=""text-center"">Sözleşme Numarası</th>
            <th class=""text-center"" data-sortable=""true"">Abone Türü</th>
            <th class=""text-center"">Birim Fiyat</th>
            <th class=""text-center"">Harcanma Miktarı</th>
            <th class=""text-center"">Fatura Borcu</th>
            <th class=""text-center"">Hesaplanmış Borç</th>
            <th class=""text-center"" data-sortable=""true"">Firma</th>
            <th class=""text-center"">Adres</th>
            <th class=""text-center"">Diğer Açıklamalar</th>
        </tr>
    </t");
            WriteLiteral("head>\r\n    <tbody>\r\n");
#nullable restore
#line 32 "C:\Users\yukse\Documents\GitHub\ihale-takip\WebUI\İhaleTakip.WebUI.Site\Views\Electricity\ElectricitySubscriber\Observer\Index.cshtml"
         foreach (dynamic obj in ViewBag.Subscriptions)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n");
#nullable restore
#line 35 "C:\Users\yukse\Documents\GitHub\ihale-takip\WebUI\İhaleTakip.WebUI.Site\Views\Electricity\ElectricitySubscriber\Observer\Index.cshtml"
             if (@obj.Subscriber.SubscriberStatus == "On")
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td><i class=\"fa fa-circle text-success\" aria-hidden=\"true\"></i> ");
#nullable restore
#line 37 "C:\Users\yukse\Documents\GitHub\ihale-takip\WebUI\İhaleTakip.WebUI.Site\Views\Electricity\ElectricitySubscriber\Observer\Index.cshtml"
                                                                            Write(obj.Subscriber.InstallationNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 38 "C:\Users\yukse\Documents\GitHub\ihale-takip\WebUI\İhaleTakip.WebUI.Site\Views\Electricity\ElectricitySubscriber\Observer\Index.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td><i class=\"fa fa-circle text-danger\" aria-hidden=\"true\"></i> ");
#nullable restore
#line 41 "C:\Users\yukse\Documents\GitHub\ihale-takip\WebUI\İhaleTakip.WebUI.Site\Views\Electricity\ElectricitySubscriber\Observer\Index.cshtml"
                                                                           Write(obj.Subscriber.InstallationNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 42 "C:\Users\yukse\Documents\GitHub\ihale-takip\WebUI\İhaleTakip.WebUI.Site\Views\Electricity\ElectricitySubscriber\Observer\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("            <td>");
#nullable restore
#line 43 "C:\Users\yukse\Documents\GitHub\ihale-takip\WebUI\İhaleTakip.WebUI.Site\Views\Electricity\ElectricitySubscriber\Observer\Index.cshtml"
           Write(obj.Subscriber.ContractNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 44 "C:\Users\yukse\Documents\GitHub\ihale-takip\WebUI\İhaleTakip.WebUI.Site\Views\Electricity\ElectricitySubscriber\Observer\Index.cshtml"
           Write(obj.SubscriptionType.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 45 "C:\Users\yukse\Documents\GitHub\ihale-takip\WebUI\İhaleTakip.WebUI.Site\Views\Electricity\ElectricitySubscriber\Observer\Index.cshtml"
             if (obj.CurrentUnitPrice != null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td>");
#nullable restore
#line 47 "C:\Users\yukse\Documents\GitHub\ihale-takip\WebUI\İhaleTakip.WebUI.Site\Views\Electricity\ElectricitySubscriber\Observer\Index.cshtml"
               Write(obj.CurrentUnitPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 48 "C:\Users\yukse\Documents\GitHub\ihale-takip\WebUI\İhaleTakip.WebUI.Site\Views\Electricity\ElectricitySubscriber\Observer\Index.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td></td>\r\n");
#nullable restore
#line 52 "C:\Users\yukse\Documents\GitHub\ihale-takip\WebUI\İhaleTakip.WebUI.Site\Views\Electricity\ElectricitySubscriber\Observer\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 53 "C:\Users\yukse\Documents\GitHub\ihale-takip\WebUI\İhaleTakip.WebUI.Site\Views\Electricity\ElectricitySubscriber\Observer\Index.cshtml"
             if (obj.CurrentBill != null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td>");
#nullable restore
#line 55 "C:\Users\yukse\Documents\GitHub\ihale-takip\WebUI\İhaleTakip.WebUI.Site\Views\Electricity\ElectricitySubscriber\Observer\Index.cshtml"
               Write(obj.CurrentBill.Amount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 56 "C:\Users\yukse\Documents\GitHub\ihale-takip\WebUI\İhaleTakip.WebUI.Site\Views\Electricity\ElectricitySubscriber\Observer\Index.cshtml"
               Write(obj.CurrentBill.Debt);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 57 "C:\Users\yukse\Documents\GitHub\ihale-takip\WebUI\İhaleTakip.WebUI.Site\Views\Electricity\ElectricitySubscriber\Observer\Index.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td></td>\r\n                <td></td>\r\n");
#nullable restore
#line 62 "C:\Users\yukse\Documents\GitHub\ihale-takip\WebUI\İhaleTakip.WebUI.Site\Views\Electricity\ElectricitySubscriber\Observer\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 63 "C:\Users\yukse\Documents\GitHub\ihale-takip\WebUI\İhaleTakip.WebUI.Site\Views\Electricity\ElectricitySubscriber\Observer\Index.cshtml"
             if (obj.CurrentUnitPriceDebt != null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td>");
#nullable restore
#line 65 "C:\Users\yukse\Documents\GitHub\ihale-takip\WebUI\İhaleTakip.WebUI.Site\Views\Electricity\ElectricitySubscriber\Observer\Index.cshtml"
               Write(obj.CurrentUnitPriceDebt);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 66 "C:\Users\yukse\Documents\GitHub\ihale-takip\WebUI\İhaleTakip.WebUI.Site\Views\Electricity\ElectricitySubscriber\Observer\Index.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td></td>\r\n");
#nullable restore
#line 70 "C:\Users\yukse\Documents\GitHub\ihale-takip\WebUI\İhaleTakip.WebUI.Site\Views\Electricity\ElectricitySubscriber\Observer\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("            <td>");
#nullable restore
#line 71 "C:\Users\yukse\Documents\GitHub\ihale-takip\WebUI\İhaleTakip.WebUI.Site\Views\Electricity\ElectricitySubscriber\Observer\Index.cshtml"
           Write(obj.Company.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 72 "C:\Users\yukse\Documents\GitHub\ihale-takip\WebUI\İhaleTakip.WebUI.Site\Views\Electricity\ElectricitySubscriber\Observer\Index.cshtml"
           Write(obj.Subscriber.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 73 "C:\Users\yukse\Documents\GitHub\ihale-takip\WebUI\İhaleTakip.WebUI.Site\Views\Electricity\ElectricitySubscriber\Observer\Index.cshtml"
           Write(obj.Subscriber.ExtraInformation);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tr>\r\n");
#nullable restore
#line 75 "C:\Users\yukse\Documents\GitHub\ihale-takip\WebUI\İhaleTakip.WebUI.Site\Views\Electricity\ElectricitySubscriber\Observer\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n<script>\r\n    function onDateChange(element) {\r\n        let year = parseInt(element.value.split(\"-\")[0]);\r\n        let month = parseInt(element.value.split(\"-\")[1]);\r\n        window.location = \'");
#nullable restore
#line 83 "C:\Users\yukse\Documents\GitHub\ihale-takip\WebUI\İhaleTakip.WebUI.Site\Views\Electricity\ElectricitySubscriber\Observer\Index.cshtml"
                      Write(Url.Action("Index", "ElectricitySubscriber"));

#line default
#line hidden
#nullable disable
            WriteLiteral("?Year=\' + year + \'&Month=\' + month;\r\n    }\r\n</script>\r\n\r\n");
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
