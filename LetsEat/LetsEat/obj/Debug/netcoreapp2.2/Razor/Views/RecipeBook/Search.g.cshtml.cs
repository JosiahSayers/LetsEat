#pragma checksum "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\RecipeBook\Search.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ac77833bb542bb35083fec80182b358dec37051b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_RecipeBook_Search), @"mvc.1.0.view", @"/Views/RecipeBook/Search.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/RecipeBook/Search.cshtml", typeof(AspNetCore.Views_RecipeBook_Search))]
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
#line 3 "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\_ViewImports.cshtml"
using LetsEat.Models.Forms;

#line default
#line hidden
#line 4 "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\_ViewImports.cshtml"
using LetsEat.Models.FamilyController;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ac77833bb542bb35083fec80182b358dec37051b", @"/Views/RecipeBook/Search.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f4509b75b3263b9d11b65382f13c6cd984b8d5d0", @"/Views/_ViewImports.cshtml")]
    public class Views_RecipeBook_Search : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<LetsEat.Models.Recipe>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Search", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(43, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\RecipeBook\Search.cshtml"
  
    ViewData["Title"] = "Search";

#line default
#line hidden
            BeginContext(87, 21, true);
            WriteLiteral("\r\n<h2>Search</h2>\r\n\r\n");
            EndContext();
            BeginContext(108, 69, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ac77833bb542bb35083fec80182b358dec37051b4305", async() => {
                BeginContext(134, 36, true);
                WriteLiteral("\r\n    <input asp-all-route-data=\"\"\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(177, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
#line 13 "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\RecipeBook\Search.cshtml"
 if (Model != null)
{

#line default
#line hidden
            BeginContext(205, 104, true);
            WriteLiteral("    <table class=\"table\">\r\n        <thead>\r\n            <tr>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(310, 38, false);
#line 19 "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\RecipeBook\Search.cshtml"
               Write(Html.DisplayNameFor(model => model.ID));

#line default
#line hidden
            EndContext();
            BeginContext(348, 67, true);
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(416, 40, false);
#line 22 "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\RecipeBook\Search.cshtml"
               Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
            EndContext();
            BeginContext(456, 67, true);
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(524, 47, false);
#line 25 "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\RecipeBook\Search.cshtml"
               Write(Html.DisplayNameFor(model => model.Description));

#line default
#line hidden
            EndContext();
            BeginContext(571, 67, true);
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(639, 47, false);
#line 28 "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\RecipeBook\Search.cshtml"
               Write(Html.DisplayNameFor(model => model.PrepMinutes));

#line default
#line hidden
            EndContext();
            BeginContext(686, 67, true);
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(754, 47, false);
#line 31 "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\RecipeBook\Search.cshtml"
               Write(Html.DisplayNameFor(model => model.CookMinutes));

#line default
#line hidden
            EndContext();
            BeginContext(801, 67, true);
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(869, 42, false);
#line 34 "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\RecipeBook\Search.cshtml"
               Write(Html.DisplayNameFor(model => model.Source));

#line default
#line hidden
            EndContext();
            BeginContext(911, 67, true);
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(979, 45, false);
#line 37 "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\RecipeBook\Search.cshtml"
               Write(Html.DisplayNameFor(model => model.DateAdded));

#line default
#line hidden
            EndContext();
            BeginContext(1024, 67, true);
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(1092, 48, false);
#line 40 "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\RecipeBook\Search.cshtml"
               Write(Html.DisplayNameFor(model => model.UserWhoAdded));

#line default
#line hidden
            EndContext();
            BeginContext(1140, 67, true);
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(1208, 44, false);
#line 43 "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\RecipeBook\Search.cshtml"
               Write(Html.DisplayNameFor(model => model.FamilyID));

#line default
#line hidden
            EndContext();
            BeginContext(1252, 67, true);
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(1320, 44, false);
#line 46 "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\RecipeBook\Search.cshtml"
               Write(Html.DisplayNameFor(model => model.PrepTime));

#line default
#line hidden
            EndContext();
            BeginContext(1364, 67, true);
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(1432, 44, false);
#line 49 "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\RecipeBook\Search.cshtml"
               Write(Html.DisplayNameFor(model => model.CookTime));

#line default
#line hidden
            EndContext();
            BeginContext(1476, 67, true);
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(1544, 52, false);
#line 52 "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\RecipeBook\Search.cshtml"
               Write(Html.DisplayNameFor(model => model.TotalTimeMinutes));

#line default
#line hidden
            EndContext();
            BeginContext(1596, 67, true);
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(1664, 45, false);
#line 55 "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\RecipeBook\Search.cshtml"
               Write(Html.DisplayNameFor(model => model.TotalTime));

#line default
#line hidden
            EndContext();
            BeginContext(1709, 106, true);
            WriteLiteral("\r\n                </th>\r\n                <th></th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
            EndContext();
#line 61 "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\RecipeBook\Search.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
            BeginContext(1872, 72, true);
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(1945, 37, false);
#line 65 "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\RecipeBook\Search.cshtml"
                   Write(Html.DisplayFor(modelItem => item.ID));

#line default
#line hidden
            EndContext();
            BeginContext(1982, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(2062, 39, false);
#line 68 "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\RecipeBook\Search.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
            EndContext();
            BeginContext(2101, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(2181, 46, false);
#line 71 "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\RecipeBook\Search.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Description));

#line default
#line hidden
            EndContext();
            BeginContext(2227, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(2307, 46, false);
#line 74 "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\RecipeBook\Search.cshtml"
                   Write(Html.DisplayFor(modelItem => item.PrepMinutes));

#line default
#line hidden
            EndContext();
            BeginContext(2353, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(2433, 46, false);
#line 77 "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\RecipeBook\Search.cshtml"
                   Write(Html.DisplayFor(modelItem => item.CookMinutes));

#line default
#line hidden
            EndContext();
            BeginContext(2479, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(2559, 41, false);
#line 80 "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\RecipeBook\Search.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Source));

#line default
#line hidden
            EndContext();
            BeginContext(2600, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(2680, 44, false);
#line 83 "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\RecipeBook\Search.cshtml"
                   Write(Html.DisplayFor(modelItem => item.DateAdded));

#line default
#line hidden
            EndContext();
            BeginContext(2724, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(2804, 47, false);
#line 86 "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\RecipeBook\Search.cshtml"
                   Write(Html.DisplayFor(modelItem => item.UserWhoAdded));

#line default
#line hidden
            EndContext();
            BeginContext(2851, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(2931, 43, false);
#line 89 "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\RecipeBook\Search.cshtml"
                   Write(Html.DisplayFor(modelItem => item.FamilyID));

#line default
#line hidden
            EndContext();
            BeginContext(2974, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(3054, 43, false);
#line 92 "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\RecipeBook\Search.cshtml"
                   Write(Html.DisplayFor(modelItem => item.PrepTime));

#line default
#line hidden
            EndContext();
            BeginContext(3097, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(3177, 43, false);
#line 95 "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\RecipeBook\Search.cshtml"
                   Write(Html.DisplayFor(modelItem => item.CookTime));

#line default
#line hidden
            EndContext();
            BeginContext(3220, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(3300, 51, false);
#line 98 "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\RecipeBook\Search.cshtml"
                   Write(Html.DisplayFor(modelItem => item.TotalTimeMinutes));

#line default
#line hidden
            EndContext();
            BeginContext(3351, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(3431, 44, false);
#line 101 "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\RecipeBook\Search.cshtml"
                   Write(Html.DisplayFor(modelItem => item.TotalTime));

#line default
#line hidden
            EndContext();
            BeginContext(3475, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(3555, 65, false);
#line 104 "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\RecipeBook\Search.cshtml"
                   Write(Html.ActionLink("Edit", "Edit", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
            EndContext();
            BeginContext(3620, 28, true);
            WriteLiteral(" |\r\n                        ");
            EndContext();
            BeginContext(3649, 71, false);
#line 105 "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\RecipeBook\Search.cshtml"
                   Write(Html.ActionLink("Details", "Details", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
            EndContext();
            BeginContext(3720, 28, true);
            WriteLiteral(" |\r\n                        ");
            EndContext();
            BeginContext(3749, 69, false);
#line 106 "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\RecipeBook\Search.cshtml"
                   Write(Html.ActionLink("Delete", "Delete", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
            EndContext();
            BeginContext(3818, 52, true);
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
            EndContext();
#line 109 "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\RecipeBook\Search.cshtml"
            }

#line default
#line hidden
            BeginContext(3885, 32, true);
            WriteLiteral("        </tbody>\r\n    </table>\r\n");
            EndContext();
#line 112 "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\RecipeBook\Search.cshtml"
}

#line default
#line hidden
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
