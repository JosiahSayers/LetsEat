#pragma checksum "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\RecipeBook\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "27a09ec713ca8c52428d535f4e25e21a184a15f0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_RecipeBook_Index), @"mvc.1.0.view", @"/Views/RecipeBook/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/RecipeBook/Index.cshtml", typeof(AspNetCore.Views_RecipeBook_Index))]
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
#line 1 "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\_ViewImports.cshtml"
using LetsEat;

#line default
#line hidden
#line 2 "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\_ViewImports.cshtml"
using LetsEat.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"27a09ec713ca8c52428d535f4e25e21a184a15f0", @"/Views/RecipeBook/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6584e4f8aea6744065c2fd1214fe898fcc763b53", @"/Views/_ViewImports.cshtml")]
    public class Views_RecipeBook_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<LetsEat.Models.Recipe>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(43, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\RecipeBook\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(86, 29, true);
            WriteLiteral("\r\n<h1>Index</h1>\r\n\r\n<p>\r\n    ");
            EndContext();
            BeginContext(115, 37, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "27a09ec713ca8c52428d535f4e25e21a184a15f03839", async() => {
                BeginContext(138, 10, true);
                WriteLiteral("Create New");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(152, 92, true);
            WriteLiteral("\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(245, 38, false);
#line 16 "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\RecipeBook\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.ID));

#line default
#line hidden
            EndContext();
            BeginContext(283, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(339, 40, false);
#line 19 "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\RecipeBook\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
            EndContext();
            BeginContext(379, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(435, 47, false);
#line 22 "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\RecipeBook\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Description));

#line default
#line hidden
            EndContext();
            BeginContext(482, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(538, 47, false);
#line 25 "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\RecipeBook\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.PrepMinutes));

#line default
#line hidden
            EndContext();
            BeginContext(585, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(641, 47, false);
#line 28 "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\RecipeBook\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.CookMinutes));

#line default
#line hidden
            EndContext();
            BeginContext(688, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(744, 42, false);
#line 31 "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\RecipeBook\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Source));

#line default
#line hidden
            EndContext();
            BeginContext(786, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(842, 45, false);
#line 34 "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\RecipeBook\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.DateAdded));

#line default
#line hidden
            EndContext();
            BeginContext(887, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(943, 44, false);
#line 37 "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\RecipeBook\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.FamilyID));

#line default
#line hidden
            EndContext();
            BeginContext(987, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(1043, 44, false);
#line 40 "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\RecipeBook\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.PrepTime));

#line default
#line hidden
            EndContext();
            BeginContext(1087, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(1143, 44, false);
#line 43 "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\RecipeBook\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.CookTime));

#line default
#line hidden
            EndContext();
            BeginContext(1187, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(1243, 52, false);
#line 46 "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\RecipeBook\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.TotalTimeMinutes));

#line default
#line hidden
            EndContext();
            BeginContext(1295, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(1351, 45, false);
#line 49 "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\RecipeBook\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.TotalTime));

#line default
#line hidden
            EndContext();
            BeginContext(1396, 86, true);
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 55 "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\RecipeBook\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
            BeginContext(1514, 48, true);
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1563, 37, false);
#line 58 "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\RecipeBook\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.ID));

#line default
#line hidden
            EndContext();
            BeginContext(1600, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1656, 39, false);
#line 61 "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\RecipeBook\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
            EndContext();
            BeginContext(1695, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1751, 46, false);
#line 64 "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\RecipeBook\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Description));

#line default
#line hidden
            EndContext();
            BeginContext(1797, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1853, 46, false);
#line 67 "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\RecipeBook\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.PrepMinutes));

#line default
#line hidden
            EndContext();
            BeginContext(1899, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1955, 46, false);
#line 70 "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\RecipeBook\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.CookMinutes));

#line default
#line hidden
            EndContext();
            BeginContext(2001, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(2057, 41, false);
#line 73 "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\RecipeBook\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Source));

#line default
#line hidden
            EndContext();
            BeginContext(2098, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(2154, 44, false);
#line 76 "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\RecipeBook\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.DateAdded));

#line default
#line hidden
            EndContext();
            BeginContext(2198, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(2254, 43, false);
#line 79 "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\RecipeBook\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.FamilyID));

#line default
#line hidden
            EndContext();
            BeginContext(2297, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(2353, 43, false);
#line 82 "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\RecipeBook\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.PrepTime));

#line default
#line hidden
            EndContext();
            BeginContext(2396, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(2452, 43, false);
#line 85 "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\RecipeBook\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.CookTime));

#line default
#line hidden
            EndContext();
            BeginContext(2495, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(2551, 51, false);
#line 88 "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\RecipeBook\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.TotalTimeMinutes));

#line default
#line hidden
            EndContext();
            BeginContext(2602, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(2658, 44, false);
#line 91 "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\RecipeBook\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.TotalTime));

#line default
#line hidden
            EndContext();
            BeginContext(2702, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(2758, 65, false);
#line 94 "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\RecipeBook\Index.cshtml"
           Write(Html.ActionLink("Edit", "Edit", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
            EndContext();
            BeginContext(2823, 20, true);
            WriteLiteral(" |\r\n                ");
            EndContext();
            BeginContext(2844, 71, false);
#line 95 "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\RecipeBook\Index.cshtml"
           Write(Html.ActionLink("Details", "Details", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
            EndContext();
            BeginContext(2915, 20, true);
            WriteLiteral(" |\r\n                ");
            EndContext();
            BeginContext(2936, 69, false);
#line 96 "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\RecipeBook\Index.cshtml"
           Write(Html.ActionLink("Delete", "Delete", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
            EndContext();
            BeginContext(3005, 36, true);
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
            EndContext();
#line 99 "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\RecipeBook\Index.cshtml"
}

#line default
#line hidden
            BeginContext(3044, 24, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<LetsEat.Models.Recipe>> Html { get; private set; }
    }
}
#pragma warning restore 1591
