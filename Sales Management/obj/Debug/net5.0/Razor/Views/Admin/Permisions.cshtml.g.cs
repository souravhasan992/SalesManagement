#pragma checksum "D:\IDB\ASP.NET Core\Sales To Upload into Github\Sales Management MyTry\Sales Management\Sales Management\Views\Admin\Permisions.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fb9dd84358c003a9f40e1db6ae2323e3ead5e036"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_Permisions), @"mvc.1.0.view", @"/Views/Admin/Permisions.cshtml")]
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
#line 1 "D:\IDB\ASP.NET Core\Sales To Upload into Github\Sales Management MyTry\Sales Management\Sales Management\Views\_ViewImports.cshtml"
using Sales_Management;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\IDB\ASP.NET Core\Sales To Upload into Github\Sales Management MyTry\Sales Management\Sales Management\Views\_ViewImports.cshtml"
using Sales_Management.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fb9dd84358c003a9f40e1db6ae2323e3ead5e036", @"/Views/Admin/Permisions.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1c44e00fcf07b355c0002b764861587f3132d6c7", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Admin_Permisions : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Sales_Management.Data.Models.UserLogin>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Permision", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\IDB\ASP.NET Core\Sales To Upload into Github\Sales Management MyTry\Sales Management\Sales Management\Views\Admin\Permisions.cshtml"
  
    ViewData["Title"] = "Permisions";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Permisions</h2>\r\n\r\n<p>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fb9dd84358c003a9f40e1db6ae2323e3ead5e0364028", async() => {
                WriteLiteral("Create New");
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
            WriteLiteral("\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 17 "D:\IDB\ASP.NET Core\Sales To Upload into Github\Sales Management MyTry\Sales Management\Sales Management\Views\Admin\Permisions.cshtml"
           Write(Html.DisplayNameFor(model => model.UserName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 20 "D:\IDB\ASP.NET Core\Sales To Upload into Github\Sales Management MyTry\Sales Management\Sales Management\Views\Admin\Permisions.cshtml"
           Write(Html.DisplayNameFor(model => model.UserPass));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 23 "D:\IDB\ASP.NET Core\Sales To Upload into Github\Sales Management MyTry\Sales Management\Sales Management\Views\Admin\Permisions.cshtml"
           Write(Html.DisplayNameFor(model => model.UserType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 29 "D:\IDB\ASP.NET Core\Sales To Upload into Github\Sales Management MyTry\Sales Management\Sales Management\Views\Admin\Permisions.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 33 "D:\IDB\ASP.NET Core\Sales To Upload into Github\Sales Management MyTry\Sales Management\Sales Management\Views\Admin\Permisions.cshtml"
               Write(Html.DisplayFor(modelItem => item.UserName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 36 "D:\IDB\ASP.NET Core\Sales To Upload into Github\Sales Management MyTry\Sales Management\Sales Management\Views\Admin\Permisions.cshtml"
               Write(Html.DisplayFor(modelItem => item.UserPass));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 39 "D:\IDB\ASP.NET Core\Sales To Upload into Github\Sales Management MyTry\Sales Management\Sales Management\Views\Admin\Permisions.cshtml"
               Write(Html.DisplayFor(modelItem => item.UserType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n");
            WriteLiteral("            </tr>\r\n");
#nullable restore
#line 47 "D:\IDB\ASP.NET Core\Sales To Upload into Github\Sales Management MyTry\Sales Management\Sales Management\Views\Admin\Permisions.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Sales_Management.Data.Models.UserLogin>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591