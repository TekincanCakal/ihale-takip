#pragma checksum "C:\Users\yukse\Documents\GitHub\ihale-takip\WebUI\İhaleTakip.WebUI.Site\Views\Electricity\ElectricityUnitPrice\Admin\AddElectricityUnitPrice.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "13ad4c0ee3c2e810ef2e70d93b1d0a7f9cec91c9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Electricity_ElectricityUnitPrice_Admin_AddElectricityUnitPrice), @"mvc.1.0.view", @"/Views/Electricity/ElectricityUnitPrice/Admin/AddElectricityUnitPrice.cshtml")]
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
#nullable restore
#line 1 "C:\Users\yukse\Documents\GitHub\ihale-takip\WebUI\İhaleTakip.WebUI.Site\Views\Electricity\ElectricityUnitPrice\Admin\AddElectricityUnitPrice.cshtml"
using İhaleTakip.Model;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"13ad4c0ee3c2e810ef2e70d93b1d0a7f9cec91c9", @"/Views/Electricity/ElectricityUnitPrice/Admin/AddElectricityUnitPrice.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"386bedd329dfc2110bc5199d87da40c236d575f1", @"/Views/_ViewImports.cshtml")]
    public class Views_Electricity_ElectricityUnitPrice_Admin_AddElectricityUnitPrice : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ElectricityUnitPrice>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/ElectricityUnitPrice/AddElectricityUnitPrice"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-4\"></div>\r\n    <div class=\"col-4\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "13ad4c0ee3c2e810ef2e70d93b1d0a7f9cec91c95568", async() => {
                WriteLiteral(@"
            <div class=""mb-3 text-center border-bottom"">
                <h3>Birim Fiyat Kaydı</h3>
            </div>
            <div class=""mb-3"">
                <label class=""form-label"">Ad</label>
                <select class=""form-select"" name=""SubscriptionTypeId"" required>
");
#nullable restore
#line 14 "C:\Users\yukse\Documents\GitHub\ihale-takip\WebUI\İhaleTakip.WebUI.Site\Views\Electricity\ElectricityUnitPrice\Admin\AddElectricityUnitPrice.cshtml"
                     foreach (ElectricitySubscriptionType electricitySubscriptionType in ViewBag.SubscriptionTypes)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "13ad4c0ee3c2e810ef2e70d93b1d0a7f9cec91c96552", async() => {
#nullable restore
#line 16 "C:\Users\yukse\Documents\GitHub\ihale-takip\WebUI\İhaleTakip.WebUI.Site\Views\Electricity\ElectricityUnitPrice\Admin\AddElectricityUnitPrice.cshtml"
                                                                   Write(electricitySubscriptionType.Name);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 16 "C:\Users\yukse\Documents\GitHub\ihale-takip\WebUI\İhaleTakip.WebUI.Site\Views\Electricity\ElectricityUnitPrice\Admin\AddElectricityUnitPrice.cshtml"
                           WriteLiteral(electricitySubscriptionType.Id);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 17 "C:\Users\yukse\Documents\GitHub\ihale-takip\WebUI\İhaleTakip.WebUI.Site\Views\Electricity\ElectricityUnitPrice\Admin\AddElectricityUnitPrice.cshtml"
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                </select>
            </div>
            <div class=""mb-3"">
                <label class=""form-label"">Dönem</label>
                <input class=""form-control"" name=""Period"" type=""month"" required />
            </div>
            <div class=""mb-3"">
                <label class=""form-label"">Tek Zamanlı Enerji Bedeli</label>
                <input class=""form-control comma-numbers"" name=""OneTimeEnergyCost"" required />
            </div>
            <div class=""mb-3"">
                <label class=""form-label"">Dağıtım Bedeli</label>
                <input class=""form-control comma-numbers"" name=""DistributionCost"" required />
            </div>
            <div class=""mb-3"">
                <button class=""btn btn-primary w-100"">Ekle</button>
            </div>
        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n    <div class=\"col-4\"></div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ElectricityUnitPrice> Html { get; private set; }
    }
}
#pragma warning restore 1591
