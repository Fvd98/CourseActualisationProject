#pragma checksum "K:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\Admin\FormationGenerale.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ea8c7d48eed7d7f2cc51e148fb7da74bd54e6905"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_FormationGenerale), @"mvc.1.0.view", @"/Views/Admin/FormationGenerale.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Admin/FormationGenerale.cshtml", typeof(AspNetCore.Views_Admin_FormationGenerale))]
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
#line 1 "K:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\_ViewImports.cshtml"
using OutilsActualisation;

#line default
#line hidden
#line 2 "K:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\_ViewImports.cshtml"
using OutilsActualisation.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ea8c7d48eed7d7f2cc51e148fb7da74bd54e6905", @"/Views/Admin/FormationGenerale.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"81ab37d2a19db97e1812d2a0e685ff62998308c6", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_FormationGenerale : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<OutilsActualisation.AppData.Actualisation>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(50, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "K:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\Admin\FormationGenerale.cshtml"
  
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(106, 121, true);
            WriteLiteral("<style>\r\n    table,th,td{\r\n        border:none!important;\r\n    }\r\n</style>\r\n<h2>Détails de la formation générale <strong>");
            EndContext();
            BeginContext(228, 9, false);
#line 11 "K:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\Admin\FormationGenerale.cshtml"
                                        Write(Model.Nom);

#line default
#line hidden
            EndContext();
            BeginContext(237, 1197, true);
            WriteLiteral(@"</strong></h2>

<div class=""card card-body"" style=""padding-top:10px;"">

    <div class=""container"" style=""width:inherit;"">
        <ul class=""nav nav-tabs"" style=""display:flex;"">
            <li style=""flex-grow:1; text-align:center; cursor:pointer; font-weight:bold;"" onclick=""AjaxFill('/Admin/FormationGenerale_Competence', '#menu', false);"" class=""active""><a data-toggle=""tab"" style=""color:black;"">Compétences</a></li>
            <li style=""flex-grow:1; text-align:center; cursor:pointer; font-weight:bold;"" onclick=""AjaxFill('/Admin/FormationGenerale_Cours', '#menu', false);""><a data-toggle=""tab"" style=""color:black;"">Cours</a></li>
            <li style=""flex-grow:1; text-align:center; cursor:pointer; font-weight:bold;"" onclick=""AjaxFill('/Admin/FormationGenerale_ChoixCours', '#menu', false);""><a data-toggle=""tab"" style=""color:black; margin-right:0;"">Choix de cours</a></li>
        </ul>

        <div class=""tab-content"" style=""background-color:white; border:1px solid #ddd; border-top:0;  padding:15");
            WriteLiteral("px; word-break:break-word;\">\r\n            <div id=\"menu\" class=\"tab-pane fade in active\" style=\"padding:1% 5%;\">\r\n \r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(1452, 105, true);
                WriteLiteral("\r\n    <script>\r\n        AjaxFill(\'/Admin/FormationGenerale_Competence\', \'#menu\', false);\r\n    </script>\r\n");
                EndContext();
            }
            );
            BeginContext(1560, 4, true);
            WriteLiteral("\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<OutilsActualisation.AppData.Actualisation> Html { get; private set; }
    }
}
#pragma warning restore 1591