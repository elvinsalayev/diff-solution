#pragma checksum "C:\Users\HP\Desktop\development\back-end\project\diff-solution\Diff Solution\Diff.WebUI\Areas\Admin\Views\Users\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6a9f52a0c8301c443ed7003e972d34526f0dea2d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Users_Details), @"mvc.1.0.view", @"/Areas/Admin/Views/Users/Details.cshtml")]
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
#line 2 "C:\Users\HP\Desktop\development\back-end\project\diff-solution\Diff Solution\Diff.WebUI\Areas\Admin\Views\_ViewImports.cshtml"
using Diff.WebUI.Models.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\HP\Desktop\development\back-end\project\diff-solution\Diff Solution\Diff.WebUI\Areas\Admin\Views\_ViewImports.cshtml"
using Diff.WebUI.Models.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\HP\Desktop\development\back-end\project\diff-solution\Diff Solution\Diff.WebUI\Areas\Admin\Views\_ViewImports.cshtml"
using Diff.WebUI.AppCode.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\HP\Desktop\development\back-end\project\diff-solution\Diff Solution\Diff.WebUI\Areas\Admin\Views\_ViewImports.cshtml"
using Diff.WebUI.AppCode.Modules.BrandModule;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\HP\Desktop\development\back-end\project\diff-solution\Diff Solution\Diff.WebUI\Areas\Admin\Views\_ViewImports.cshtml"
using Diff.WebUI.AppCode.Modules.BlogpostModule;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\HP\Desktop\development\back-end\project\diff-solution\Diff Solution\Diff.WebUI\Areas\Admin\Views\_ViewImports.cshtml"
using Diff.WebUI.AppCode.Infrastructure;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\HP\Desktop\development\back-end\project\diff-solution\Diff Solution\Diff.WebUI\Areas\Admin\Views\_ViewImports.cshtml"
using Diff.WebUI.Models.Entities.Membership;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6a9f52a0c8301c443ed7003e972d34526f0dea2d", @"/Areas/Admin/Views/Users/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d1b567e9bf57a30092d4ef82979cf580dae0c512", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_Admin_Views_Users_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DiffUser>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "dashboard", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("col-sm-2 col-form-label"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info btn-icon"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/admin/assets/libs/toastr.js/toastr.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/admin/assets/libs/tab-control/tab-control.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/admin/assets/libs/tab-control/tab-control.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/admin/assets/libs/toastr.js/toastr.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\HP\Desktop\development\back-end\project\diff-solution\Diff Solution\Diff.WebUI\Areas\Admin\Views\Users\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"page-header\">\r\n    <div class=\"row align-items-end\">\r\n        <div class=\"col-lg-8\">\r\n            <div class=\"page-header-title\">\r\n                <div class=\"d-inline\">\r\n                    <h4>İstifadəçi</h4>\r\n");
            WriteLiteral(@"                </div>
            </div>
        </div>
        <div class=""col-lg-4"">
            <div class=""page-header-breadcrumb"">
                <ul class=""breadcrumb-title"">
                    <li class=""breadcrumb-item"" style=""float: left;"">
                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6a9f52a0c8301c443ed7003e972d34526f0dea2d9214", async() => {
                WriteLiteral(" <i class=\"feather icon-home\"></i> ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                    </li>
                    <li class=""breadcrumb-item"" style=""float: left;"">
                        <a href=""#!"">İstifadəçi</a>
                    </li>
                </ul>
            </div>
        </div>
    </div>
</div>
<div class=""page-body"">
    <div class=""card p-3"">
        <div class=""card-block"">
            <div>
                <div class=""form-group row"">
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6a9f52a0c8301c443ed7003e972d34526f0dea2d11048", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
#nullable restore
#line 37 "C:\Users\HP\Desktop\development\back-end\project\diff-solution\Diff Solution\Diff.WebUI\Areas\Admin\Views\Users\Details.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Name);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    <div class=\"col-sm-10\">\r\n                        <p class=\"form-control\">");
#nullable restore
#line 39 "C:\Users\HP\Desktop\development\back-end\project\diff-solution\Diff Solution\Diff.WebUI\Areas\Admin\Views\Users\Details.cshtml"
                                           Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    </div>\r\n                </div>\r\n                <div class=\"form-group row\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6a9f52a0c8301c443ed7003e972d34526f0dea2d13147", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
#nullable restore
#line 43 "C:\Users\HP\Desktop\development\back-end\project\diff-solution\Diff Solution\Diff.WebUI\Areas\Admin\Views\Users\Details.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Surname);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    <div class=\"col-sm-10\">\r\n                        <p class=\"form-control\">");
#nullable restore
#line 45 "C:\Users\HP\Desktop\development\back-end\project\diff-solution\Diff Solution\Diff.WebUI\Areas\Admin\Views\Users\Details.cshtml"
                                           Write(Model.Surname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    </div>\r\n                </div>\r\n                <div class=\"form-group row\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6a9f52a0c8301c443ed7003e972d34526f0dea2d15252", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
#nullable restore
#line 49 "C:\Users\HP\Desktop\development\back-end\project\diff-solution\Diff Solution\Diff.WebUI\Areas\Admin\Views\Users\Details.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.UserName);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    <div class=\"col-sm-10\">\r\n                        <p class=\"form-control\">");
#nullable restore
#line 51 "C:\Users\HP\Desktop\development\back-end\project\diff-solution\Diff Solution\Diff.WebUI\Areas\Admin\Views\Users\Details.cshtml"
                                           Write(Model.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    </div>\r\n                </div>\r\n                <div class=\"form-group row\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6a9f52a0c8301c443ed7003e972d34526f0dea2d17359", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
#nullable restore
#line 55 "C:\Users\HP\Desktop\development\back-end\project\diff-solution\Diff Solution\Diff.WebUI\Areas\Admin\Views\Users\Details.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Email);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    <div class=\"col-sm-10\">\r\n                        <p class=\"form-control\">");
#nullable restore
#line 57 "C:\Users\HP\Desktop\development\back-end\project\diff-solution\Diff Solution\Diff.WebUI\Areas\Admin\Views\Users\Details.cshtml"
                                           Write(Model.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                    </div>
                </div>
                <div class=""form-group row"">
                    <div class=""col-12"">
                        <div class=""tab-control"" role=""tabcontrol"">
                            <div class=""tab-page"" id=""roles"" aria-title=""Rollar"" selected>
                                <table class=""table table-striped"">
                                    <thead>
                                        <tr>
                                            <th class=""table-row-select"">

                                            </th>
                                            <th class=""text-left"">
                                                Name
                                            </th>
                                        </tr>
                                    </thead>
                                    <tbody>
");
#nullable restore
#line 76 "C:\Users\HP\Desktop\development\back-end\project\diff-solution\Diff Solution\Diff.WebUI\Areas\Admin\Views\Users\Details.cshtml"
                                         foreach (Tuple<int, string, bool> role in ViewBag.Roles)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <tr>\r\n                                                <td class=\"table-row-select\">\r\n                                                    <input type=\"checkbox\" ");
#nullable restore
#line 80 "C:\Users\HP\Desktop\development\back-end\project\diff-solution\Diff Solution\Diff.WebUI\Areas\Admin\Views\Users\Details.cshtml"
                                                                       Write(role.Item3 ? "checked" : "");

#line default
#line hidden
#nullable disable
            WriteLiteral(" data-role-id=\"");
#nullable restore
#line 80 "C:\Users\HP\Desktop\development\back-end\project\diff-solution\Diff Solution\Diff.WebUI\Areas\Admin\Views\Users\Details.cshtml"
                                                                                                                   Write(role.Item1);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-user-id=\"");
#nullable restore
#line 80 "C:\Users\HP\Desktop\development\back-end\project\diff-solution\Diff Solution\Diff.WebUI\Areas\Admin\Views\Users\Details.cshtml"
                                                                                                                                              Write(Model.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" />\r\n                                                </td>\r\n                                                <th>\r\n                                                    ");
#nullable restore
#line 83 "C:\Users\HP\Desktop\development\back-end\project\diff-solution\Diff Solution\Diff.WebUI\Areas\Admin\Views\Users\Details.cshtml"
                                               Write(role.Item2);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                </th>\r\n                                            </tr>\r\n");
#nullable restore
#line 86 "C:\Users\HP\Desktop\development\back-end\project\diff-solution\Diff Solution\Diff.WebUI\Areas\Admin\Views\Users\Details.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                    </tbody>
                                </table>
                            </div>
                            <div class=""tab-page"" id=""principals"" aria-title=""Səlahiyyətlər"">
                                <table class=""table table-striped"">
                                    <thead>
                                        <tr>
                                            <th class=""table-row-select"">

                                            </th>
                                            <th class=""text-left"">
                                                Name
                                            </th>
                                        </tr>
                                    </thead>
                                    <tbody>
");
#nullable restore
#line 103 "C:\Users\HP\Desktop\development\back-end\project\diff-solution\Diff Solution\Diff.WebUI\Areas\Admin\Views\Users\Details.cshtml"
                                         foreach (Tuple<string, bool> principal in ViewBag.Principals)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <tr>\r\n                                                <th class=\"table-row-select\">\r\n                                                    <input type=\"checkbox\" ");
#nullable restore
#line 107 "C:\Users\HP\Desktop\development\back-end\project\diff-solution\Diff Solution\Diff.WebUI\Areas\Admin\Views\Users\Details.cshtml"
                                                                       Write(principal.Item2 ? "checked" : "");

#line default
#line hidden
#nullable disable
            WriteLiteral(" data-user-id=\"");
#nullable restore
#line 107 "C:\Users\HP\Desktop\development\back-end\project\diff-solution\Diff Solution\Diff.WebUI\Areas\Admin\Views\Users\Details.cshtml"
                                                                                                                        Write(Model.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-principal-name=\"");
#nullable restore
#line 107 "C:\Users\HP\Desktop\development\back-end\project\diff-solution\Diff Solution\Diff.WebUI\Areas\Admin\Views\Users\Details.cshtml"
                                                                                                                                                        Write(principal.Item1);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" />\r\n                                                </th>\r\n                                                <th>\r\n                                                    ");
#nullable restore
#line 110 "C:\Users\HP\Desktop\development\back-end\project\diff-solution\Diff Solution\Diff.WebUI\Areas\Admin\Views\Users\Details.cshtml"
                                               Write(principal.Item1);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                </th>\r\n                                            </tr>\r\n");
#nullable restore
#line 113 "C:\Users\HP\Desktop\development\back-end\project\diff-solution\Diff Solution\Diff.WebUI\Areas\Admin\Views\Users\Details.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>

                <div class=""form-group row"">
                    <label class=""col-sm-2""></label>
                    <div class=""col-sm-10"">
                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6a9f52a0c8301c443ed7003e972d34526f0dea2d26764", async() => {
                WriteLiteral("<i class=\"icofont-arrow-left\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("css", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "6a9f52a0c8301c443ed7003e972d34526f0dea2d28251", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "6a9f52a0c8301c443ed7003e972d34526f0dea2d29430", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
            DefineSection("js", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6a9f52a0c8301c443ed7003e972d34526f0dea2d30725", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6a9f52a0c8301c443ed7003e972d34526f0dea2d31825", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
    <script>
        $(document).ready(function () {
            $('input[type=""checkbox""][data-role-id]').change(function (e) {
                let obj = $(e.currentTarget).data();
                obj.selected = $(e.currentTarget).is(':checked');


                 $.ajax({
                     url: `");
#nullable restore
#line 147 "C:\Users\HP\Desktop\development\back-end\project\diff-solution\Diff Solution\Diff.WebUI\Areas\Admin\Views\Users\Details.cshtml"
                      Write(Url.Action("SetRole"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"`,
                     type: 'POST',
                     data: obj,
                     contentType:'application/x-www-form-urlencoded',
                     dataType: 'json',
                     success: function (response) {
                         if (response.error == false) {
                             toastr.success(response.message, ""Uğurludur!"");
                             return;
                         }
                         toastr.error(""Xəta!"", response.message)

                         $(e.currentTarget).prop('checked', !obj.selected);
                     },
                     error: function (response) {
                         toastr[""error""](""Xəta"", ""Texniki xəta baş verdi,biraz sonra yenidən yoxlayın!"")
                     }
                 })
            });

            $('input[type=""checkbox""][data-principal-name]').change(function (e) {
                let obj = $(e.currentTarget).data();
                obj.selected = $(e.currentTarget).is(':ch");
                WriteLiteral("ecked\');\r\n\r\n\r\n                 $.ajax({\r\n                     url: `");
#nullable restore
#line 173 "C:\Users\HP\Desktop\development\back-end\project\diff-solution\Diff Solution\Diff.WebUI\Areas\Admin\Views\Users\Details.cshtml"
                      Write(Url.Action("SetPrincipal"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"`,
                     type: 'POST',
                     data: obj,
                     contentType:'application/x-www-form-urlencoded',
                     dataType: 'json',
                     success: function (response) {
                         if (response.error == false) {
                             toastr.success(response.message, ""Uğurludur!"");
                             return;
                         }
                         toastr.error(""Xəta!"", response.message)

                         $(e.currentTarget).prop('checked', !obj.selected);
                     },
                     error: function (response) {
                         toastr[""error""](""Xəta"", ""Texniki xəta baş verdi,biraz sonra yenidən yoxlayın!"")
                     }
                 })
            });
        });
    </script>
");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DiffUser> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
