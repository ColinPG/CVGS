#pragma checksum "C:\Users\colin\source\repos\CVGS\CVGS\Views\Game\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "42969a34db084b7d2d9d13928f2e226afebf8c22"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Game_Delete), @"mvc.1.0.view", @"/Views/Game/Delete.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Game/Delete.cshtml", typeof(AspNetCore.Views_Game_Delete))]
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
#line 1 "C:\Users\colin\source\repos\CVGS\CVGS\Views\_ViewImports.cshtml"
using CVGS;

#line default
#line hidden
#line 2 "C:\Users\colin\source\repos\CVGS\CVGS\Views\_ViewImports.cshtml"
using CVGS.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"42969a34db084b7d2d9d13928f2e226afebf8c22", @"/Views/Game/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"50662a4b06b34ddc6a7692a13ac4f749ea9cc64c", @"/Views/_ViewImports.cshtml")]
    public class Views_Game_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CVGS.Models.Game>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(25, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\colin\source\repos\CVGS\CVGS\Views\Game\Delete.cshtml"
  
    ViewData["Title"] = "Delete Game";

#line default
#line hidden
            BeginContext(74, 6, true);
            WriteLiteral("\r\n<h1>");
            EndContext();
            BeginContext(81, 17, false);
#line 7 "C:\Users\colin\source\repos\CVGS\CVGS\Views\Game\Delete.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(98, 160, true);
            WriteLiteral("</h1>\r\n\r\n<h3>Are you sure you want to delete this?</h3>\r\n<div>\r\n    <h4>Game</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class=\"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(259, 47, false);
#line 15 "C:\Users\colin\source\repos\CVGS\CVGS\Views\Game\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.EnglishName));

#line default
#line hidden
            EndContext();
            BeginContext(306, 61, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(368, 43, false);
#line 18 "C:\Users\colin\source\repos\CVGS\CVGS\Views\Game\Delete.cshtml"
       Write(Html.DisplayFor(model => model.EnglishName));

#line default
#line hidden
            EndContext();
            BeginContext(411, 17, true);
            WriteLiteral("\r\n        </dd>\r\n");
            EndContext();
            BeginContext(2200, 43, true);
            WriteLiteral("        <dt class=\"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(2244, 54, false);
#line 69 "C:\Users\colin\source\repos\CVGS\CVGS\Views\Game\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.EnglishPlayerCount));

#line default
#line hidden
            EndContext();
            BeginContext(2298, 61, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(2360, 50, false);
#line 72 "C:\Users\colin\source\repos\CVGS\CVGS\Views\Game\Delete.cshtml"
       Write(Html.DisplayFor(model => model.EnglishPlayerCount));

#line default
#line hidden
            EndContext();
            BeginContext(2410, 60, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(2471, 50, false);
#line 75 "C:\Users\colin\source\repos\CVGS\CVGS\Views\Game\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.EsrbRatingCode));

#line default
#line hidden
            EndContext();
            BeginContext(2521, 61, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(2583, 61, false);
#line 78 "C:\Users\colin\source\repos\CVGS\CVGS\Views\Game\Delete.cshtml"
       Write(Html.DisplayFor(model => model.EsrbRatingCodeNavigation.Code));

#line default
#line hidden
            EndContext();
            BeginContext(2644, 60, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(2705, 50, false);
#line 81 "C:\Users\colin\source\repos\CVGS\CVGS\Views\Game\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.GameCategoryId));

#line default
#line hidden
            EndContext();
            BeginContext(2755, 61, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(2817, 60, false);
#line 84 "C:\Users\colin\source\repos\CVGS\CVGS\Views\Game\Delete.cshtml"
       Write(Html.DisplayFor(model => model.GameCategory.EnglishCategory));

#line default
#line hidden
            EndContext();
            BeginContext(2877, 60, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(2938, 55, false);
#line 87 "C:\Users\colin\source\repos\CVGS\CVGS\Views\Game\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.GamePerspectiveCode));

#line default
#line hidden
            EndContext();
            BeginContext(2993, 61, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(3055, 66, false);
#line 90 "C:\Users\colin\source\repos\CVGS\CVGS\Views\Game\Delete.cshtml"
       Write(Html.DisplayFor(model => model.GamePerspectiveCodeNavigation.Code));

#line default
#line hidden
            EndContext();
            BeginContext(3121, 60, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(3182, 50, false);
#line 93 "C:\Users\colin\source\repos\CVGS\CVGS\Views\Game\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.GameStatusCode));

#line default
#line hidden
            EndContext();
            BeginContext(3232, 61, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(3294, 61, false);
#line 96 "C:\Users\colin\source\repos\CVGS\CVGS\Views\Game\Delete.cshtml"
       Write(Html.DisplayFor(model => model.GameStatusCodeNavigation.Code));

#line default
#line hidden
            EndContext();
            BeginContext(3355, 60, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(3416, 53, false);
#line 99 "C:\Users\colin\source\repos\CVGS\CVGS\Views\Game\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.GameSubCategoryId));

#line default
#line hidden
            EndContext();
            BeginContext(3469, 61, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(3531, 63, false);
#line 102 "C:\Users\colin\source\repos\CVGS\CVGS\Views\Game\Delete.cshtml"
       Write(Html.DisplayFor(model => model.GameSubCategory.EnglishCategory));

#line default
#line hidden
            EndContext();
            BeginContext(3594, 60, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(3655, 54, false);
#line 105 "C:\Users\colin\source\repos\CVGS\CVGS\Views\Game\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.EnglishDescription));

#line default
#line hidden
            EndContext();
            BeginContext(3709, 61, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(3771, 50, false);
#line 108 "C:\Users\colin\source\repos\CVGS\CVGS\Views\Game\Delete.cshtml"
       Write(Html.DisplayFor(model => model.EnglishDescription));

#line default
#line hidden
            EndContext();
            BeginContext(3821, 60, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(3882, 49, false);
#line 111 "C:\Users\colin\source\repos\CVGS\CVGS\Views\Game\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.EnglishDetail));

#line default
#line hidden
            EndContext();
            BeginContext(3931, 69, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            <ul><li>");
            EndContext();
            BeginContext(4001, 45, false);
#line 114 "C:\Users\colin\source\repos\CVGS\CVGS\Views\Game\Delete.cshtml"
               Write(Html.DisplayFor(model => model.EnglishDetail));

#line default
#line hidden
            EndContext();
            BeginContext(4046, 48, true);
            WriteLiteral("</li></ul>\r\n        </dd>\r\n    </dl>\r\n    \r\n    ");
            EndContext();
            BeginContext(4094, 220, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "42969a34db084b7d2d9d13928f2e226afebf8c2212779", async() => {
                BeginContext(4120, 10, true);
                WriteLiteral("\r\n        ");
                EndContext();
                BeginContext(4130, 38, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "42969a34db084b7d2d9d13928f2e226afebf8c2213172", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#line 119 "C:\Users\colin\source\repos\CVGS\CVGS\Views\Game\Delete.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Guid);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(4168, 95, true);
                WriteLiteral("\r\n        <input id=\"delete\" type=\"submit\" value=\"Delete\" class=\"btn btn-danger\" /> |\r\n        ");
                EndContext();
                BeginContext(4263, 38, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "42969a34db084b7d2d9d13928f2e226afebf8c2215078", async() => {
                    BeginContext(4285, 12, true);
                    WriteLiteral("Back to List");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(4301, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4314, 10, true);
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CVGS.Models.Game> Html { get; private set; }
    }
}
#pragma warning restore 1591