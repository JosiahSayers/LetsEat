#pragma checksum "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\RecipeBook\WebsiteRequestAdded.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "22cf0e02632fed37a25f168420c2be593f5c5fc5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_RecipeBook_WebsiteRequestAdded), @"mvc.1.0.view", @"/Views/RecipeBook/WebsiteRequestAdded.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/RecipeBook/WebsiteRequestAdded.cshtml", typeof(AspNetCore.Views_RecipeBook_WebsiteRequestAdded))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"22cf0e02632fed37a25f168420c2be593f5c5fc5", @"/Views/RecipeBook/WebsiteRequestAdded.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"542d869c03f2067f752c24fe4c4d660418393418", @"/Views/_ViewImports.cshtml")]
    public class Views_RecipeBook_WebsiteRequestAdded : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebsiteRequest>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\RecipeBook\WebsiteRequestAdded.cshtml"
  
    ViewData["Title"] = "WebsiteRequestAdded";

#line default
#line hidden
            BeginContext(78, 105, true);
            WriteLiteral("\r\n<h1>Website Request Added</h1>\r\n\r\n<p>Unfortunately Let\'s Eat does not currently support importing from ");
            EndContext();
            BeginContext(184, 13, false);
#line 8 "C:\Users\Josiah\Documents\Code\Lets-Eat\LetsEat\LetsEat\Views\RecipeBook\WebsiteRequestAdded.cshtml"
                                                                Write(Model.BaseURL);

#line default
#line hidden
            EndContext();
            BeginContext(197, 83, true);
            WriteLiteral(". A request has been sent to the administrator to add support for this website.</p>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebsiteRequest> Html { get; private set; }
    }
}
#pragma warning restore 1591
