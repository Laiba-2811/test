#pragma checksum "C:\Users\MALIK MUNEEB\source\repos\BlogApplication_Mcsf19a002\Views\Home\PostView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bdc9536fb51c13ec9b3a9f03086004f0057d463c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_PostView), @"mvc.1.0.view", @"/Views/Home/PostView.cshtml")]
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
#line 1 "C:\Users\MALIK MUNEEB\source\repos\BlogApplication_Mcsf19a002\Views\Home\PostView.cshtml"
using BlogApplication_Mcsf19a002.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bdc9536fb51c13ec9b3a9f03086004f0057d463c", @"/Views/Home/PostView.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b853c2693020103458b52d8246f923ca3fd89014", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_PostView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Post>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 4 "C:\Users\MALIK MUNEEB\source\repos\BlogApplication_Mcsf19a002\Views\Home\PostView.cshtml"
   Layout = "~/Views/Shared/_Layout.cshtml"; 

#line default
#line hidden
#nullable disable
            WriteLiteral("<section class=\"container-fluid p-lg-2\">\n    <section class=\"container-fluid p-lg-2\">\n        <div class=\"text-center\">\n            <div class=\"p-3\">\n                <h2>");
#nullable restore
#line 9 "C:\Users\MALIK MUNEEB\source\repos\BlogApplication_Mcsf19a002\Views\Home\PostView.cshtml"
               Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\n            </div>\n            <div>\n                <p>");
#nullable restore
#line 12 "C:\Users\MALIK MUNEEB\source\repos\BlogApplication_Mcsf19a002\Views\Home\PostView.cshtml"
              Write(Model.Content);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n            </div>\n        </div>\n    </section>\n</section>\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Post> Html { get; private set; }
    }
}
#pragma warning restore 1591
