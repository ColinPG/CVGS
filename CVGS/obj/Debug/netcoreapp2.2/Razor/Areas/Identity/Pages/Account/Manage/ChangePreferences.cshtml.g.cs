#pragma checksum "C:\Users\Justin\Documents\GitHub\CVGS\CVGS\Areas\Identity\Pages\Account\Manage\ChangePreferences.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "051a138b4eb02dabe8164b3486395419939a94ee"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(CVGS.Areas.Identity.Pages.Account.Manage.Areas_Identity_Pages_Account_Manage_ChangePreferences), @"mvc.1.0.razor-page", @"/Areas/Identity/Pages/Account/Manage/ChangePreferences.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Areas/Identity/Pages/Account/Manage/ChangePreferences.cshtml", typeof(CVGS.Areas.Identity.Pages.Account.Manage.Areas_Identity_Pages_Account_Manage_ChangePreferences), null)]
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
#line 2 "C:\Users\Justin\Documents\GitHub\CVGS\CVGS\Areas\Identity\Pages\_ViewImports.cshtml"
using CVGS.Areas.Identity;

#line default
#line hidden
#line 3 "C:\Users\Justin\Documents\GitHub\CVGS\CVGS\Areas\Identity\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 1 "C:\Users\Justin\Documents\GitHub\CVGS\CVGS\Areas\Identity\Pages\Account\_ViewImports.cshtml"
using CVGS.Areas.Identity.Pages.Account;

#line default
#line hidden
#line 1 "C:\Users\Justin\Documents\GitHub\CVGS\CVGS\Areas\Identity\Pages\Account\Manage\_ViewImports.cshtml"
using CVGS.Areas.Identity.Pages.Account.Manage;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"051a138b4eb02dabe8164b3486395419939a94ee", @"/Areas/Identity/Pages/Account/Manage/ChangePreferences.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"94cde57a9f3df0c26abb41e24de7230a243a5456", @"/Areas/Identity/Pages/_ViewImports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"422ea8cb3dc27f1e8318c7e5cfc1d14b039574a3", @"/Areas/Identity/Pages/Account/_ViewImports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"be23a28f8d569fbee60a2c8f288cd34ee9cd8840", @"/Areas/Identity/Pages/Account/Manage/_ViewImports.cshtml")]
    public class Areas_Identity_Pages_Account_Manage_ChangePreferences : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "C:\Users\Justin\Documents\GitHub\CVGS\CVGS\Areas\Identity\Pages\Account\Manage\ChangePreferences.cshtml"
  
    ViewData["Title"] = "Preferences";
    ViewData["ActivePage"] = ManageNavPages.Preferences;


#line default
#line hidden
            BeginContext(186, 6, true);
            WriteLiteral("\r\n<h4>");
            EndContext();
            BeginContext(193, 17, false);
#line 9 "C:\Users\Justin\Documents\GitHub\CVGS\CVGS\Areas\Identity\Pages\Account\Manage\ChangePreferences.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(210, 10, true);
            WriteLiteral("</h4>\r\n}\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CVGS.Areas.Identity.Pages.Account.Manage.ChangePreferencesModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<CVGS.Areas.Identity.Pages.Account.Manage.ChangePreferencesModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<CVGS.Areas.Identity.Pages.Account.Manage.ChangePreferencesModel>)PageContext?.ViewData;
        public CVGS.Areas.Identity.Pages.Account.Manage.ChangePreferencesModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
