#pragma checksum "E:\c#\project\Project\Web\Views\Post\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "de487730e597a9fef30d51ceaf1a5dffe2f95838"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Web.Pages.Post.Views_Post_Index), @"mvc.1.0.view", @"/Views/Post/Index.cshtml")]
namespace Web.Pages.Post
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
#line 1 "E:\c#\project\Project\Web\Views\_ViewImports.cshtml"
using Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\c#\project\Project\Web\Views\_ViewImports.cshtml"
using Web.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\c#\project\Project\Web\Views\_ViewImports.cshtml"
using Web.Pages;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\c#\project\Project\Web\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "E:\c#\project\Project\Web\Views\_ViewImports.cshtml"
using Infrastructure.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"de487730e597a9fef30d51ceaf1a5dffe2f95838", @"/Views/Post/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a3460af757439f323512dc1516f00676ef00018b", @"/Views/_ViewImports.cshtml")]
    public class Views_Post_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Web.ViewModels.PostsViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "E:\c#\project\Project\Web\Views\Post\Index.cshtml"
   
    ViewData["Title"] = "Posts";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<table class=\"table table-dark\">\r\n    ");
#nullable restore
#line 7 "E:\c#\project\Project\Web\Views\Post\Index.cshtml"
Write(Html.ActionLink("Create new post", "create", "Post", null, new { @class = "btn btn-success float-right mb-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <thead>\r\n        <tr>\r\n            <th scope=\"col\">Name</th>\r\n            <th scope=\"col\">Description</th>\r\n            <th scope=\"col\">Action</th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 16 "E:\c#\project\Project\Web\Views\Post\Index.cshtml"
         foreach (var post in Model.Posts)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 19 "E:\c#\project\Project\Web\Views\Post\Index.cshtml"
               Write(post.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 20 "E:\c#\project\Project\Web\Views\Post\Index.cshtml"
               Write(post.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>\r\n                    ");
#nullable restore
#line 22 "E:\c#\project\Project\Web\Views\Post\Index.cshtml"
               Write(Html.ActionLink("View", "Single", "Post", new { Id = post.Id }, new { @class = "btn btn-info" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 23 "E:\c#\project\Project\Web\Views\Post\Index.cshtml"
               Write(Html.ActionLink("Edit", "Edit", "Post", new { Id = post.Id }, new { @class = "btn btn-warning" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <div>\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "de487730e597a9fef30d51ceaf1a5dffe2f958386630", async() => {
                WriteLiteral("\r\n                            <input type=\"hidden\" name=\"id\"");
                BeginWriteAttribute("value", " value=\"", 1017, "\"", 1033, 1);
#nullable restore
#line 26 "E:\c#\project\Project\Web\Views\Post\Index.cshtml"
WriteAttributeValue("", 1025, post.Id, 1025, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                            ");
#nullable restore
#line 27 "E:\c#\project\Project\Web\Views\Post\Index.cshtml"
                       Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                            <!-- Button trigger modal -->
                            <button type=""button"" class=""btn btn-danger mt-2"" data-toggle=""modal"" data-target=""#exampleModal"">
                                Delete
                            </button>

                            <!-- Modal -->
                            <div class=""modal fade text-dark"" id=""exampleModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
                                <div class=""modal-dialog"" role=""document"">
                                    <div class=""modal-content"">
                                        <div class=""modal-header"">
                                            <h5 class=""modal-title"" id=""exampleModalLabel"">Modal title</h5>
                                            <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                                                <span aria-hidden=""true"">&times;</span>
                ");
                WriteLiteral(@"                            </button>
                                        </div>
                                        <div class=""modal-body "">
                                            are you shure to want delete
                                        </div>
                                        <div class=""modal-footer"">
                                            <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Close</button>
                                            <button type=""submit"" class=""btn btn-danger"">Delete</button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </div>\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 57 "E:\c#\project\Project\Web\Views\Post\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Web.ViewModels.PostsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591