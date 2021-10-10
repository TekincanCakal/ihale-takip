#pragma checksum "C:\Users\Chasen\source\repos\İhaleTakip\WebUI\İhaleTakip.WebUI.Site\Views\ElectricitySubscriber\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6b136fc19065d5ca9ca52dfd57d187b220a14dd7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ElectricitySubscriber_Index), @"mvc.1.0.view", @"/Views/ElectricitySubscriber/Index.cshtml")]
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
#line 2 "C:\Users\Chasen\source\repos\İhaleTakip\WebUI\İhaleTakip.WebUI.Site\Views\_ViewImports.cshtml"
using Microsoft.Extensions.Options;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Chasen\source\repos\İhaleTakip\WebUI\İhaleTakip.WebUI.Site\Views\_ViewImports.cshtml"
using İhaleTakip.WebUI.Site.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Chasen\source\repos\İhaleTakip\WebUI\İhaleTakip.WebUI.Site\Views\_ViewImports.cshtml"
using İhaleTakip.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Chasen\source\repos\İhaleTakip\WebUI\İhaleTakip.WebUI.Site\Views\_ViewImports.cshtml"
using İhaleTakip.Model;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Chasen\source\repos\İhaleTakip\WebUI\İhaleTakip.WebUI.Site\Views\_ViewImports.cshtml"
using System.Security.Claims;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Chasen\source\repos\İhaleTakip\WebUI\İhaleTakip.WebUI.Site\Views\_ViewImports.cshtml"
using İhaleTakip.WebUI.Site.Managers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\Chasen\source\repos\İhaleTakip\WebUI\İhaleTakip.WebUI.Site\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6b136fc19065d5ca9ca52dfd57d187b220a14dd7", @"/Views/ElectricitySubscriber/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"386bedd329dfc2110bc5199d87da40c236d575f1", @"/Views/_ViewImports.cshtml")]
    public class Views_ElectricitySubscriber_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"row py-3\">\r\n    <div class=\"col-4\">\r\n        <input class=\"form-control\" onchange=\"onDateChange(this)\" type=\"month\"");
            BeginWriteAttribute("value", " value=\"", 127, "\"", 152, 1);
#nullable restore
#line 3 "C:\Users\Chasen\source\repos\İhaleTakip\WebUI\İhaleTakip.WebUI.Site\Views\ElectricitySubscriber\Index.cshtml"
WriteAttributeValue("", 135, ViewBag.DateText, 135, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n    </div>\r\n    <div class=\"col-4\">\r\n        <a class=\"btn btn-primary w-100\"");
            BeginWriteAttribute("href", " href=\"", 235, "\"", 353, 1);
#nullable restore
#line 6 "C:\Users\Chasen\source\repos\İhaleTakip\WebUI\İhaleTakip.WebUI.Site\Views\ElectricitySubscriber\Index.cshtml"
WriteAttributeValue("", 242, Url.Action("AddElectricitySubscriber", "ElectricitySubscriber", new { Year=ViewBag.Year, Month=ViewBag.Month}), 242, 111, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">Yeni Abonelik Ekle</a>
    </div>
    <div class=""col-4"">
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
");
            WriteLiteral("            <th class=\"text-center\">Abonelik İşlemleri</th>\r\n            <th class=\"text-center\">Fatura İşlemleri</th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 37 "C:\Users\Chasen\source\repos\İhaleTakip\WebUI\İhaleTakip.WebUI.Site\Views\ElectricitySubscriber\Index.cshtml"
         foreach (dynamic obj in ViewBag.Subscriptions)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n");
#nullable restore
#line 40 "C:\Users\Chasen\source\repos\İhaleTakip\WebUI\İhaleTakip.WebUI.Site\Views\ElectricitySubscriber\Index.cshtml"
             if (@obj.Subscriber.SubscriberStatus == "On")
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td><i class=\"fa fa-circle text-success\" aria-hidden=\"true\"></i> ");
#nullable restore
#line 42 "C:\Users\Chasen\source\repos\İhaleTakip\WebUI\İhaleTakip.WebUI.Site\Views\ElectricitySubscriber\Index.cshtml"
                                                                            Write(obj.Subscriber.InstallationNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 43 "C:\Users\Chasen\source\repos\İhaleTakip\WebUI\İhaleTakip.WebUI.Site\Views\ElectricitySubscriber\Index.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td><i class=\"fa fa-circle text-danger\" aria-hidden=\"true\"></i> ");
#nullable restore
#line 46 "C:\Users\Chasen\source\repos\İhaleTakip\WebUI\İhaleTakip.WebUI.Site\Views\ElectricitySubscriber\Index.cshtml"
                                                                           Write(obj.Subscriber.InstallationNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 47 "C:\Users\Chasen\source\repos\İhaleTakip\WebUI\İhaleTakip.WebUI.Site\Views\ElectricitySubscriber\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("            <td>");
#nullable restore
#line 48 "C:\Users\Chasen\source\repos\İhaleTakip\WebUI\İhaleTakip.WebUI.Site\Views\ElectricitySubscriber\Index.cshtml"
           Write(obj.Subscriber.ContractNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 49 "C:\Users\Chasen\source\repos\İhaleTakip\WebUI\İhaleTakip.WebUI.Site\Views\ElectricitySubscriber\Index.cshtml"
           Write(obj.SubscriptionType.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 50 "C:\Users\Chasen\source\repos\İhaleTakip\WebUI\İhaleTakip.WebUI.Site\Views\ElectricitySubscriber\Index.cshtml"
             if (obj.CurrentUnitPrice != null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td>");
#nullable restore
#line 52 "C:\Users\Chasen\source\repos\İhaleTakip\WebUI\İhaleTakip.WebUI.Site\Views\ElectricitySubscriber\Index.cshtml"
               Write(obj.CurrentUnitPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 53 "C:\Users\Chasen\source\repos\İhaleTakip\WebUI\İhaleTakip.WebUI.Site\Views\ElectricitySubscriber\Index.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td></td>\r\n");
#nullable restore
#line 57 "C:\Users\Chasen\source\repos\İhaleTakip\WebUI\İhaleTakip.WebUI.Site\Views\ElectricitySubscriber\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 58 "C:\Users\Chasen\source\repos\İhaleTakip\WebUI\İhaleTakip.WebUI.Site\Views\ElectricitySubscriber\Index.cshtml"
             if (obj.CurrentBill != null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td>");
#nullable restore
#line 60 "C:\Users\Chasen\source\repos\İhaleTakip\WebUI\İhaleTakip.WebUI.Site\Views\ElectricitySubscriber\Index.cshtml"
               Write(obj.CurrentBill.Amount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 61 "C:\Users\Chasen\source\repos\İhaleTakip\WebUI\İhaleTakip.WebUI.Site\Views\ElectricitySubscriber\Index.cshtml"
               Write(obj.CurrentBill.Debt);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 62 "C:\Users\Chasen\source\repos\İhaleTakip\WebUI\İhaleTakip.WebUI.Site\Views\ElectricitySubscriber\Index.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td></td>\r\n                <td></td>\r\n");
#nullable restore
#line 67 "C:\Users\Chasen\source\repos\İhaleTakip\WebUI\İhaleTakip.WebUI.Site\Views\ElectricitySubscriber\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 68 "C:\Users\Chasen\source\repos\İhaleTakip\WebUI\İhaleTakip.WebUI.Site\Views\ElectricitySubscriber\Index.cshtml"
             if (obj.CurrentUnitPriceDebt != null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td>");
#nullable restore
#line 70 "C:\Users\Chasen\source\repos\İhaleTakip\WebUI\İhaleTakip.WebUI.Site\Views\ElectricitySubscriber\Index.cshtml"
               Write(obj.CurrentUnitPriceDebt);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 71 "C:\Users\Chasen\source\repos\İhaleTakip\WebUI\İhaleTakip.WebUI.Site\Views\ElectricitySubscriber\Index.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td></td>\r\n");
#nullable restore
#line 75 "C:\Users\Chasen\source\repos\İhaleTakip\WebUI\İhaleTakip.WebUI.Site\Views\ElectricitySubscriber\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("            <td>");
#nullable restore
#line 76 "C:\Users\Chasen\source\repos\İhaleTakip\WebUI\İhaleTakip.WebUI.Site\Views\ElectricitySubscriber\Index.cshtml"
           Write(obj.Company.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 77 "C:\Users\Chasen\source\repos\İhaleTakip\WebUI\İhaleTakip.WebUI.Site\Views\ElectricitySubscriber\Index.cshtml"
           Write(obj.Subscriber.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 78 "C:\Users\Chasen\source\repos\İhaleTakip\WebUI\İhaleTakip.WebUI.Site\Views\ElectricitySubscriber\Index.cshtml"
           Write(obj.Subscriber.ExtraInformation);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>\r\n                <a class=\"btn btn-sm btn-warning text-white\"");
            BeginWriteAttribute("href", " href=\"", 3007, "\"", 3149, 1);
#nullable restore
#line 80 "C:\Users\Chasen\source\repos\İhaleTakip\WebUI\İhaleTakip.WebUI.Site\Views\ElectricitySubscriber\Index.cshtml"
WriteAttributeValue("", 3014, Url.Action("UpdateElectricitySubscriber", "ElectricitySubscriber", new {Id=obj.Subscriber.Id, Year=ViewBag.Year, Month=ViewBag.Month}), 3014, 135, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-pencil-square-o\" aria-hidden=\"true\"></i></a>\r\n                <a class=\"btn btn-sm btn-danger\"");
            BeginWriteAttribute("href", " href=\"", 3261, "\"", 3435, 1);
#nullable restore
#line 81 "C:\Users\Chasen\source\repos\İhaleTakip\WebUI\İhaleTakip.WebUI.Site\Views\ElectricitySubscriber\Index.cshtml"
WriteAttributeValue("", 3268, Url.Action("DeleteElectricitySubscriber", "ElectricitySubscriber", new {InstallationNumber=obj.Subscriber.InstallationNumber, Year=ViewBag.Year, Month=ViewBag.Month}), 3268, 167, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" onclick=\"return confirm(\'Silme İşlemini Onaylıyor Musun?\')\"><i class=\"fa fa-trash\" aria-hidden=\"true\"></i></a>\r\n            </td>\r\n            <td>\r\n");
#nullable restore
#line 84 "C:\Users\Chasen\source\repos\İhaleTakip\WebUI\İhaleTakip.WebUI.Site\Views\ElectricitySubscriber\Index.cshtml"
                 if (obj.CurrentBill != null)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <a class=\"btn btn-sm btn-primary text-white\"");
            BeginWriteAttribute("href", " href=\"", 3716, "\"", 3807, 1);
#nullable restore
#line 86 "C:\Users\Chasen\source\repos\İhaleTakip\WebUI\İhaleTakip.WebUI.Site\Views\ElectricitySubscriber\Index.cshtml"
WriteAttributeValue("", 3723, Url.Action("UpdateElectricityBill", "ElectricityBill", new {Id=obj.CurrentBill.Id}), 3723, 84, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-file-text\" aria-hidden=\"true\"></i></a>\r\n                    <a class=\"btn btn-sm btn-danger\"");
            BeginWriteAttribute("href", " href=\"", 3917, "\"", 4008, 1);
#nullable restore
#line 87 "C:\Users\Chasen\source\repos\İhaleTakip\WebUI\İhaleTakip.WebUI.Site\Views\ElectricitySubscriber\Index.cshtml"
WriteAttributeValue("", 3924, Url.Action("DeleteElectricityBill", "ElectricityBill", new {Id=obj.CurrentBill.Id}), 3924, 84, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" onclick=\"return confirm(\'Silme İşlemini Onaylıyor Musun?\')\"><i class=\"fa fa-trash\" aria-hidden=\"true\"></i></a>\r\n");
#nullable restore
#line 88 "C:\Users\Chasen\source\repos\İhaleTakip\WebUI\İhaleTakip.WebUI.Site\Views\ElectricitySubscriber\Index.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <a class=\"btn btn-sm btn-success text-white\"");
            BeginWriteAttribute("href", " href=\"", 4246, "\"", 4405, 1);
#nullable restore
#line 91 "C:\Users\Chasen\source\repos\İhaleTakip\WebUI\İhaleTakip.WebUI.Site\Views\ElectricitySubscriber\Index.cshtml"
WriteAttributeValue("", 4253, Url.Action("AddElectricityBill", "ElectricityBill", new {InstallationNumber=obj.Subscriber.InstallationNumber, Year=ViewBag.Year, Month=ViewBag.Month}), 4253, 152, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-plus-square-o\" aria-hidden=\"true\"></i></a>\r\n");
#nullable restore
#line 92 "C:\Users\Chasen\source\repos\İhaleTakip\WebUI\İhaleTakip.WebUI.Site\Views\ElectricitySubscriber\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </td>\r\n        </tr>\r\n");
#nullable restore
#line 95 "C:\Users\Chasen\source\repos\İhaleTakip\WebUI\İhaleTakip.WebUI.Site\Views\ElectricitySubscriber\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n<script>\r\n    function onDateChange(element) {\r\n        let year = parseInt(element.value.split(\"-\")[0]);\r\n        let month = parseInt(element.value.split(\"-\")[1]);\r\n        window.location = \'");
#nullable restore
#line 103 "C:\Users\Chasen\source\repos\İhaleTakip\WebUI\İhaleTakip.WebUI.Site\Views\ElectricitySubscriber\Index.cshtml"
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
