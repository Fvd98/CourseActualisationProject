#pragma checksum "F:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\Actualisation\Accueil.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9be65be26a6ccf2b0ea320953d94cc1b43eb5e0b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Actualisation_Accueil), @"mvc.1.0.view", @"/Views/Actualisation/Accueil.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Actualisation/Accueil.cshtml", typeof(AspNetCore.Views_Actualisation_Accueil))]
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
#line 1 "F:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\_ViewImports.cshtml"
using OutilsActualisation;

#line default
#line hidden
#line 2 "F:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\_ViewImports.cshtml"
using OutilsActualisation.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9be65be26a6ccf2b0ea320953d94cc1b43eb5e0b", @"/Views/Actualisation/Accueil.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"81ab37d2a19db97e1812d2a0e685ff62998308c6", @"/Views/_ViewImports.cshtml")]
    public class Views_Actualisation_Accueil : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<OutilsActualisation.Models.MesActualisationsViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Actualisation_Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("float:right; margin-right:8px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Actualisation", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Actualisation", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(75, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "F:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\Actualisation\Accueil.cshtml"
  
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(131, 915, true);
            WriteLiteral(@"
<style>
    .flex-container {
        display: flex;
        flex-wrap: wrap;
    }

        .flex-container > a, .flex-container > a:visited {
            background-color: #dc9191;
            background-image: linear-gradient(to bottom left, rgb(255, 188, 118), rgb(187, 115, 165));
            padding: 6px 15px;
            border-radius: 3px;
            margin: 8px;
            line-height: 40px;
            font-size: 30px;
            flex-grow: 1;
            color: black;
            text-decoration: none;
            font-size: 24px;
        }

            .flex-container > a:hover {
                cursor: pointer;
                background-image: linear-gradient(to bottom left, rgb(255, 218, 148), rgb(217, 145, 195));
                color: black;
            }

    .dateCreation {
        font-size: 16px !important;
    }
</style>

<h2>Mes actualisations  ");
            EndContext();
#line 38 "F:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\Actualisation\Accueil.cshtml"
                         if (User.IsInRole("Admin")) {

#line default
#line hidden
            BeginContext(1076, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(1077, 201, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "43cda7a2fb2a4b959e1942ca100394e2", async() => {
                BeginContext(1177, 97, true);
                WriteLiteral("Démarrer une actualisation<span class=\"glyphicon glyphicon-plus\" style=\"margin-left:7px;\"></span>");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1278, 2, true);
            WriteLiteral("  ");
            EndContext();
#line 38 "F:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\Actualisation\Accueil.cshtml"
                                                                                                                                                                                                                                                                  }

#line default
#line hidden
            BeginContext(1281, 39, true);
            WriteLiteral("</h2>\r\n\r\n<div class=\"flex-container\">\r\n");
            EndContext();
#line 41 "F:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\Actualisation\Accueil.cshtml"
     if (Model.Count() != 0)
    {
        

#line default
#line hidden
#line 43 "F:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\Actualisation\Accueil.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
            BeginContext(1406, 12, true);
            WriteLiteral("            ");
            EndContext();
            BeginContext(1418, 307, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "72255bbcfcfd43e2ba436efda3aa3122", async() => {
                BeginContext(1516, 51, true);
                WriteLiteral("\r\n                <div>\r\n                    <span>");
                EndContext();
                BeginContext(1568, 8, false);
#line 47 "F:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\Actualisation\Accueil.cshtml"
                     Write(item.Nom);

#line default
#line hidden
                EndContext();
                BeginContext(1576, 62, true);
                WriteLiteral("</span><br />\r\n                    <span class=\"dateCreation\">");
                EndContext();
                BeginContext(1639, 37, false);
#line 48 "F:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\Actualisation\Accueil.cshtml"
                                          Write(item.DateCreation.ToShortDateString());

#line default
#line hidden
                EndContext();
                BeginContext(1676, 45, true);
                WriteLiteral("</span>\r\n                </div>\r\n            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-idActualisation", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 45 "F:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\Actualisation\Accueil.cshtml"
                                                                                        WriteLiteral(item.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["idActualisation"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-idActualisation", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["idActualisation"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1725, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 51 "F:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\Actualisation\Accueil.cshtml"
        }

#line default
#line hidden
#line 51 "F:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\Actualisation\Accueil.cshtml"
         
    }
    else
    {

#line default
#line hidden
            BeginContext(1762, 139, true);
            WriteLiteral("            <h2 style=\"margin-top:75px;text-align:center; width:100%\">Vous ne participez à aucune actualisation présentement...</h2>     \r\n");
            EndContext();
#line 56 "F:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\Actualisation\Accueil.cshtml"
    }

#line default
#line hidden
            BeginContext(1908, 14, true);
            WriteLiteral("\r\n</div>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<OutilsActualisation.Models.MesActualisationsViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
