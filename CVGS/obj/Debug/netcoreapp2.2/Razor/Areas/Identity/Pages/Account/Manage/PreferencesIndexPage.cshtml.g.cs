#pragma checksum "C:\Users\colin\source\repos\CVGS\CVGS\Areas\Identity\Pages\Account\Manage\PreferencesIndexPage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4896d0a1df3855057cefea1a32bd263c19ed9222"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(CVGS.Areas.Identity.Pages.Account.Manage.Areas_Identity_Pages_Account_Manage_PreferencesIndexPage), @"mvc.1.0.razor-page", @"/Areas/Identity/Pages/Account/Manage/PreferencesIndexPage.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Areas/Identity/Pages/Account/Manage/PreferencesIndexPage.cshtml", typeof(CVGS.Areas.Identity.Pages.Account.Manage.Areas_Identity_Pages_Account_Manage_PreferencesIndexPage), null)]
namespace CVGS.Areas.Identity.Pages.Account.Manage
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 2 "C:\Users\colin\source\repos\CVGS\CVGS\Areas\Identity\Pages\_ViewImports.cshtml"
using CVGS.Areas.Identity;

#line default
#line hidden
#line 3 "C:\Users\colin\source\repos\CVGS\CVGS\Areas\Identity\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 1 "C:\Users\colin\source\repos\CVGS\CVGS\Areas\Identity\Pages\Account\_ViewImports.cshtml"
using CVGS.Areas.Identity.Pages.Account;

#line default
#line hidden
#line 1 "C:\Users\colin\source\repos\CVGS\CVGS\Areas\Identity\Pages\Account\Manage\_ViewImports.cshtml"
using CVGS.Areas.Identity.Pages.Account.Manage;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4896d0a1df3855057cefea1a32bd263c19ed9222", @"/Areas/Identity/Pages/Account/Manage/PreferencesIndexPage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"94cde57a9f3df0c26abb41e24de7230a243a5456", @"/Areas/Identity/Pages/_ViewImports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"422ea8cb3dc27f1e8318c7e5cfc1d14b039574a3", @"/Areas/Identity/Pages/Account/_ViewImports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"be23a28f8d569fbee60a2c8f288cd34ee9cd8840", @"/Areas/Identity/Pages/Account/Manage/_ViewImports.cshtml")]
    public class Areas_Identity_Pages_Account_Manage_PreferencesIndexPage : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_StatusMessage", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("change-preferences"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "./ChangePreferences", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_ValidationScriptsPartial", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "C:\Users\colin\source\repos\CVGS\CVGS\Areas\Identity\Pages\Account\Manage\PreferencesIndexPage.cshtml"
  
    ViewData["Title"] = "Preferences";
    ViewData["ActivePage"] = ManageNavPages.Preferences;


#line default
#line hidden
            BeginContext(189, 6, true);
            WriteLiteral("\r\n<h4>");
            EndContext();
            BeginContext(196, 17, false);
#line 9 "C:\Users\colin\source\repos\CVGS\CVGS\Areas\Identity\Pages\Account\Manage\PreferencesIndexPage.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(213, 7, true);
            WriteLiteral("</h4>\r\n");
            EndContext();
            BeginContext(220, 53, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "4896d0a1df3855057cefea1a32bd263c19ed92226323", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#line 10 "C:\Users\colin\source\repos\CVGS\CVGS\Areas\Identity\Pages\Account\Manage\PreferencesIndexPage.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.StatusMessage);

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("for", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(273, 128, true);
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-md-6\">\r\n        <div>\r\n            <label>Platform Preference</label>\r\n            <h6>");
            EndContext();
            BeginContext(402, 30, false);
#line 15 "C:\Users\colin\source\repos\CVGS\CVGS\Areas\Identity\Pages\Account\Manage\PreferencesIndexPage.cshtml"
           Write(ViewData["platformPreference"]);

#line default
#line hidden
            EndContext();
            BeginContext(432, 102, true);
            WriteLiteral("</h6>\r\n        </div>\r\n        <div>\r\n            <label>Category Preference</label>\r\n            <h1>");
            EndContext();
            BeginContext(535, 30, false);
#line 19 "C:\Users\colin\source\repos\CVGS\CVGS\Areas\Identity\Pages\Account\Manage\PreferencesIndexPage.cshtml"
           Write(ViewData["categoryPreference"]);

#line default
#line hidden
            EndContext();
            BeginContext(565, 105, true);
            WriteLiteral("</h1>\r\n        </div>\r\n        <div>\r\n            <label>Subcategory Preference</label>\r\n            <h1>");
            EndContext();
            BeginContext(671, 32, false);
#line 23 "C:\Users\colin\source\repos\CVGS\CVGS\Areas\Identity\Pages\Account\Manage\PreferencesIndexPage.cshtml"
           Write(ViewData["subcatgoryPreference"]);

#line default
#line hidden
            EndContext();
            BeginContext(703, 43, true);
            WriteLiteral("</h1>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
            EndContext();
            BeginContext(746, 147, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4896d0a1df3855057cefea1a32bd263c19ed92229607", async() => {
                BeginContext(871, 18, true);
                WriteLiteral("Change Preferences");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "class", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 756, "nav-link", 756, 8, true);
#line 27 "C:\Users\colin\source\repos\CVGS\CVGS\Areas\Identity\Pages\Account\Manage\PreferencesIndexPage.cshtml"
AddHtmlAttributeValue(" ", 764, ManageNavPages.PersonalDataNavClass(ViewContext), 765, 49, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(893, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(915, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(921, 44, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "4896d0a1df3855057cefea1a32bd263c19ed922211804", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(965, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CVGS.Areas.Identity.Pages.Account.Manage.PreferencesIndexPageModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<CVGS.Areas.Identity.Pages.Account.Manage.PreferencesIndexPageModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<CVGS.Areas.Identity.Pages.Account.Manage.PreferencesIndexPageModel>)PageContext?.ViewData;
        public CVGS.Areas.Identity.Pages.Account.Manage.PreferencesIndexPageModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591