#pragma checksum "C:\Users\Chasen\source\repos\İhaleTakip\WebUI\İhaleTakip.WebUI.Site\Views\Employee\Observer\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "97c674311a7f9c13b74d6de2130da23807ffd448"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Employee_Observer_Index), @"mvc.1.0.view", @"/Views/Employee/Observer/Index.cshtml")]
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
#nullable restore
#line 1 "C:\Users\Chasen\source\repos\İhaleTakip\WebUI\İhaleTakip.WebUI.Site\Views\Employee\Observer\Index.cshtml"
using İhaleTakip.Model;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"97c674311a7f9c13b74d6de2130da23807ffd448", @"/Views/Employee/Observer/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"386bedd329dfc2110bc5199d87da40c236d575f1", @"/Views/_ViewImports.cshtml")]
    public class Views_Employee_Observer_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div class=""row py-3"">
    <div class=""col"">
        <input class=""form-control"" id=""search"" type=""text"" placeholder=""Ara"" />
    </div>
</div>
<table id=""table""
       data-toggle=""table""
       data-search=""true""
       data-search-on-enter-key=""false""
       data-sort-order=""asc""
       data-pagination=""true""
       data-page-list=""[10, 25, 50, 100, all]""
       data-search-selector=""#search"">
    <thead>
        <tr>
            <th class=""text-center"" data-sortable=""true"">Ad</th>
            <th class=""text-center"">Soyad</th>
            <th class=""text-center"">Kullanıcı Adı</th>
            <th class=""text-center"">Şifre</th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 25 "C:\Users\Chasen\source\repos\İhaleTakip\WebUI\İhaleTakip.WebUI.Site\Views\Employee\Observer\Index.cshtml"
         foreach (Employee employee in ViewBag.Employees)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 28 "C:\Users\Chasen\source\repos\İhaleTakip\WebUI\İhaleTakip.WebUI.Site\Views\Employee\Observer\Index.cshtml"
               Write(employee.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 29 "C:\Users\Chasen\source\repos\İhaleTakip\WebUI\İhaleTakip.WebUI.Site\Views\Employee\Observer\Index.cshtml"
               Write(employee.Surname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 30 "C:\Users\Chasen\source\repos\İhaleTakip\WebUI\İhaleTakip.WebUI.Site\Views\Employee\Observer\Index.cshtml"
               Write(employee.Username);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 31 "C:\Users\Chasen\source\repos\İhaleTakip\WebUI\İhaleTakip.WebUI.Site\Views\Employee\Observer\Index.cshtml"
               Write(employee.Password);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n");
#nullable restore
#line 33 "C:\Users\Chasen\source\repos\İhaleTakip\WebUI\İhaleTakip.WebUI.Site\Views\Employee\Observer\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n");
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
