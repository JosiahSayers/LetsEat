#pragma checksum "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\Admin\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "568de6ed07cd9af15cc39efad4927f8cf7eb3802"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_Index), @"mvc.1.0.view", @"/Views/Admin/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Admin/Index.cshtml", typeof(AspNetCore.Views_Admin_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"568de6ed07cd9af15cc39efad4927f8cf7eb3802", @"/Views/Admin/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f4509b75b3263b9d11b65382f13c6cd984b8d5d0", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<LetsEat.Models.WebsiteRequest>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CompleteWebsiteRequest", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-sm btn-outline-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DenyWebsiteRequest", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-sm btn-outline-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(51, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\Admin\Index.cshtml"
  
    ViewData["Title"] = "Website Requests";

#line default
#line hidden
            BeginContext(105, 115, true);
            WriteLiteral("\r\n<h1>Website Requests</h1>\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(221, 38, false);
#line 13 "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\Admin\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Id));

#line default
#line hidden
            EndContext();
            BeginContext(259, 283, true);
            WriteLiteral(@"
            </th>
            <th>
                Website
            </th>
            <th>
                Full URL
            </th>
            <th>
                User
            </th>
            <th>Change Status</th>
        </tr>
    </thead>
    <tbody>
");
            EndContext();
#line 28 "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\Admin\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
            BeginContext(574, 48, true);
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(623, 37, false);
#line 31 "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\Admin\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Id));

#line default
#line hidden
            EndContext();
            BeginContext(660, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(716, 42, false);
#line 34 "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\Admin\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.BaseURL));

#line default
#line hidden
            EndContext();
            BeginContext(758, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(814, 42, false);
#line 37 "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\Admin\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.FullURL));

#line default
#line hidden
            EndContext();
            BeginContext(856, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(912, 51, false);
#line 40 "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\Admin\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.User.DisplayName));

#line default
#line hidden
            EndContext();
            BeginContext(963, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1018, 122, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "568de6ed07cd9af15cc39efad4927f8cf7eb38027923", async() => {
                BeginContext(1122, 14, true);
                WriteLiteral("Mark Completed");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-wrid", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 43 "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\Admin\Index.cshtml"
                                                           WriteLiteral(item.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["wrid"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-wrid", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["wrid"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1140, 18, true);
            WriteLiteral("\r\n                ");
            EndContext();
            BeginContext(1158, 115, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "568de6ed07cd9af15cc39efad4927f8cf7eb380210390", async() => {
                BeginContext(1257, 12, true);
                WriteLiteral("Deny Request");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-wrid", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 44 "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\Admin\Index.cshtml"
                                                       WriteLiteral(item.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["wrid"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-wrid", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["wrid"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1273, 36, true);
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
            EndContext();
#line 47 "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\Admin\Index.cshtml"
}

#line default
#line hidden
            BeginContext(1312, 22, true);
            WriteLiteral("    </tbody>\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<LetsEat.Models.WebsiteRequest>> Html { get; private set; }
    }
}
#pragma warning restore 1591
