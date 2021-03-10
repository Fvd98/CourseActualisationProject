#pragma checksum "K:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\Competence\Sequence_Competence.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "aaa465cc347a867ffcde928ce2f8528ca37bdc14"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Competence_Sequence_Competence), @"mvc.1.0.view", @"/Views/Competence/Sequence_Competence.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Competence/Sequence_Competence.cshtml", typeof(AspNetCore.Views_Competence_Sequence_Competence))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"aaa465cc347a867ffcde928ce2f8528ca37bdc14", @"/Views/Competence/Sequence_Competence.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"81ab37d2a19db97e1812d2a0e685ff62998308c6", @"/Views/_ViewImports.cshtml")]
    public class Views_Competence_Sequence_Competence : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CheckListViewModel<OutilsActualisation.AppData.Competence, OutilsActualisation.AppData.SequenceCompetence>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "K:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\Competence\Sequence_Competence.cshtml"
  
    string Checked = "checked";

#line default
#line hidden
            BeginContext(155, 191, true);
            WriteLiteral("\r\n<div class=\"modal-header\">\r\n    <button type=\"button\" class=\"close\" data-dismiss=\"modal\">&times;</button>\r\n    <h4 class=\"modal-title\">Selectionnez les compétences pour la séquence <strong>");
            EndContext();
            BeginContext(347, 16, false);
#line 8 "K:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\Competence\Sequence_Competence.cshtml"
                                                                             Write(Model.Parent.Nom);

#line default
#line hidden
            EndContext();
            BeginContext(363, 52, true);
            WriteLiteral("</strong></h4>\r\n</div>\r\n\r\n<div class=\"modal-body\">\r\n");
            EndContext();
#line 12 "K:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\Competence\Sequence_Competence.cshtml"
     if (Model.Items.Count() != 0)
    {

#line default
#line hidden
            BeginContext(458, 358, true);
            WriteLiteral(@"        <table class=""ombre"">
            <thead>
                <tr>
                    <th>
                        Compétence
                    </th>
                    <th style=""text-align: center!important;"">
                        Sélectionnée
                    </th>
                </tr>
            </thead>
            <tbody>
");
            EndContext();
#line 26 "K:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\Competence\Sequence_Competence.cshtml"
                 foreach (var item in Model.Items.OrderBy(I => I.Item.Code))
                {

#line default
#line hidden
            BeginContext(913, 119, true);
            WriteLiteral("                    <tr>\r\n                        <td style=\"text-align:left!important;\">\r\n                            ");
            EndContext();
            BeginContext(1033, 46, false);
#line 30 "K:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\Competence\Sequence_Competence.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Item.Enonce));

#line default
#line hidden
            EndContext();
            BeginContext(1079, 192, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td style=\"text-align: center!important;\">\r\n                            <a data-ajax-url=\"/Competence/Sequence_Competence?idCompetence=");
            EndContext();
            BeginContext(1272, 14, false);
#line 33 "K:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\Competence\Sequence_Competence.cshtml"
                                                                                      Write(item.Item.Code);

#line default
#line hidden
            EndContext();
            BeginContext(1286, 12, true);
            WriteLiteral("&idSequence=");
            EndContext();
            BeginContext(1299, 15, false);
#line 33 "K:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\Competence\Sequence_Competence.cshtml"
                                                                                                                 Write(Model.Parent.Id);

#line default
#line hidden
            EndContext();
            BeginContext(1314, 9, true);
            WriteLiteral("&Ajouter=");
            EndContext();
            BeginContext(1325, 13, false);
#line 33 "K:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\Competence\Sequence_Competence.cshtml"
                                                                                                                                           Write(!item.Checked);

#line default
#line hidden
            EndContext();
            BeginContext(1339, 107, true);
            WriteLiteral("\" data-ajax=\"true\" data-ajax-method=\"POST\" data-ajax-success=\"AjaxFill(\'/Competence/Sequence_Competence?id=");
            EndContext();
            BeginContext(1447, 15, false);
#line 33 "K:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\Competence\Sequence_Competence.cshtml"
                                                                                                                                                                                                                                                                     Write(Model.Parent.Id);

#line default
#line hidden
            EndContext();
            BeginContext(1462, 283, true);
            WriteLiteral(@"', '#ModalContainer', false);AjaxFill('/Competence/Sequence', '#menu', false);"" data-ajax-failure=""Alert('error', xhr.responseText)"">
                                <input onclick=""this.disabled=true;this.style.cursor = 'progress'"" style=""height:20px; width:20px;"" type=""checkbox"" ");
            EndContext();
#line 34 "K:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\Competence\Sequence_Competence.cshtml"
                                                                                                                                                     if (item.Checked) { 

#line default
#line hidden
            BeginContext(1767, 7, false);
#line 34 "K:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\Competence\Sequence_Competence.cshtml"
                                                                                                                                                                    Write(Checked);

#line default
#line hidden
            EndContext();
#line 34 "K:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\Competence\Sequence_Competence.cshtml"
                                                                                                                                                                                  }

#line default
#line hidden
            BeginContext(1776, 97, true);
            WriteLiteral(" />\r\n                            </a>\r\n                        </td>\r\n                    </tr>\r\n");
            EndContext();
#line 38 "K:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\Competence\Sequence_Competence.cshtml"
                }

#line default
#line hidden
            BeginContext(1892, 40, true);
            WriteLiteral("            </tbody>\r\n        </table>\r\n");
            EndContext();
#line 41 "K:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\Competence\Sequence_Competence.cshtml"
    }
    else
    {

#line default
#line hidden
            BeginContext(1956, 118, true);
            WriteLiteral("        <p style=\"font-weight:bold; font-size:20px; text-align:center;\">Aucune compétence pour cette séquence...</p>\r\n");
            EndContext();
#line 45 "K:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\Competence\Sequence_Competence.cshtml"
    }

#line default
#line hidden
            BeginContext(2081, 14, true);
            WriteLiteral("</div>\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CheckListViewModel<OutilsActualisation.AppData.Competence, OutilsActualisation.AppData.SequenceCompetence>> Html { get; private set; }
    }
}
#pragma warning restore 1591