#pragma checksum "K:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\Competence\ProfilFormation_Competence.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0dbf16175f41e73171cdb54ba2810deefaf2b8c7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Competence_ProfilFormation_Competence), @"mvc.1.0.view", @"/Views/Competence/ProfilFormation_Competence.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Competence/ProfilFormation_Competence.cshtml", typeof(AspNetCore.Views_Competence_ProfilFormation_Competence))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0dbf16175f41e73171cdb54ba2810deefaf2b8c7", @"/Views/Competence/ProfilFormation_Competence.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"81ab37d2a19db97e1812d2a0e685ff62998308c6", @"/Views/_ViewImports.cshtml")]
    public class Views_Competence_ProfilFormation_Competence : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CheckListViewModel<OutilsActualisation.AppData.Competence, OutilsActualisation.AppData.ProfilFormation>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "K:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\Competence\ProfilFormation_Competence.cshtml"
  
    string Checked = "checked";

#line default
#line hidden
            BeginContext(152, 189, true);
            WriteLiteral("\r\n<div class=\"modal-header\">\r\n    <button type=\"button\" class=\"close\" data-dismiss=\"modal\">&times;</button>\r\n    <h4 class=\"modal-title\">Selectionnez les compétences pour le profil <strong>");
            EndContext();
            BeginContext(342, 16, false);
#line 8 "K:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\Competence\ProfilFormation_Competence.cshtml"
                                                                           Write(Model.Parent.Nom);

#line default
#line hidden
            EndContext();
            BeginContext(358, 52, true);
            WriteLiteral("</strong></h4>\r\n</div>\r\n\r\n<div class=\"modal-body\">\r\n");
            EndContext();
#line 12 "K:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\Competence\ProfilFormation_Competence.cshtml"
     if (Model.Items.Count() != 0)
    {

#line default
#line hidden
            BeginContext(453, 358, true);
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
#line 26 "K:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\Competence\ProfilFormation_Competence.cshtml"
                 foreach (var item in Model.Items.OrderBy(I => I.Item.Code).OrderBy(I => I.Item.IsObligatoire))
                {

#line default
#line hidden
            BeginContext(943, 119, true);
            WriteLiteral("                    <tr>\r\n                        <td style=\"text-align:left!important;\">\r\n                            ");
            EndContext();
            BeginContext(1063, 46, false);
#line 30 "K:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\Competence\ProfilFormation_Competence.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Item.Enonce));

#line default
#line hidden
            EndContext();
            BeginContext(1109, 199, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td style=\"text-align: center!important;\">\r\n                            <a data-ajax-url=\"/Competence/ProfilFormation_Competence?idCompetence=");
            EndContext();
            BeginContext(1309, 14, false);
#line 33 "K:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\Competence\ProfilFormation_Competence.cshtml"
                                                                                             Write(item.Item.Code);

#line default
#line hidden
            EndContext();
            BeginContext(1323, 10, true);
            WriteLiteral("&idProfil=");
            EndContext();
            BeginContext(1334, 15, false);
#line 33 "K:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\Competence\ProfilFormation_Competence.cshtml"
                                                                                                                      Write(Model.Parent.Id);

#line default
#line hidden
            EndContext();
            BeginContext(1349, 9, true);
            WriteLiteral("&Ajouter=");
            EndContext();
            BeginContext(1360, 13, false);
#line 33 "K:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\Competence\ProfilFormation_Competence.cshtml"
                                                                                                                                                Write(!item.Checked);

#line default
#line hidden
            EndContext();
            BeginContext(1374, 114, true);
            WriteLiteral("\" data-ajax=\"true\" data-ajax-method=\"POST\" data-ajax-success=\"AjaxFill(\'/Competence/ProfilFormation_Competence?id=");
            EndContext();
            BeginContext(1489, 15, false);
#line 33 "K:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\Competence\ProfilFormation_Competence.cshtml"
                                                                                                                                                                                                                                                                                 Write(Model.Parent.Id);

#line default
#line hidden
            EndContext();
            BeginContext(1504, 374, true);
            WriteLiteral(@"', '#ModalContainer', false);AjaxFill('/Competence/ProfilFormation', '#ContentContainer', false);"" data-ajax-failure=""Alert('error', xhr.responseText)"" style=""margin: auto;width: 20px;height: 20px;display: block;"">
                                <input onclick=""this.disabled=true;this.style.cursor = 'progress'"" style=""height:20px; width:20px; margin:0;"" type=""checkbox"" ");
            EndContext();
#line 34 "K:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\Competence\ProfilFormation_Competence.cshtml"
                                                                                                                                                               if (item.Checked) { 

#line default
#line hidden
            BeginContext(1900, 7, false);
#line 34 "K:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\Competence\ProfilFormation_Competence.cshtml"
                                                                                                                                                                              Write(Checked);

#line default
#line hidden
            EndContext();
#line 34 "K:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\Competence\ProfilFormation_Competence.cshtml"
                                                                                                                                                                                            }

#line default
#line hidden
            BeginContext(1909, 1, true);
            WriteLiteral(" ");
            EndContext();
#line 34 "K:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\Competence\ProfilFormation_Competence.cshtml"
                                                                                                                                                                                               if (item.Item.IsObligatoire ?? true) { 

#line default
#line hidden
            BeginContext(1951, 20, false);
#line 34 "K:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\Competence\ProfilFormation_Competence.cshtml"
                                                                                                                                                                                                                                 Write(Html.Raw("disabled"));

#line default
#line hidden
            EndContext();
#line 34 "K:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\Competence\ProfilFormation_Competence.cshtml"
                                                                                                                                                                                                                                                            }

#line default
#line hidden
            BeginContext(1973, 97, true);
            WriteLiteral(" />\r\n                            </a>\r\n                        </td>\r\n                    </tr>\r\n");
            EndContext();
#line 38 "K:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\Competence\ProfilFormation_Competence.cshtml"
                }

#line default
#line hidden
            BeginContext(2089, 40, true);
            WriteLiteral("            </tbody>\r\n        </table>\r\n");
            EndContext();
#line 41 "K:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\Competence\ProfilFormation_Competence.cshtml"
    }
    else
    {

#line default
#line hidden
            BeginContext(2153, 126, true);
            WriteLiteral("        <p style=\"font-weight:bold; font-size:20px; text-align:center;\">Aucune compétence pour ce profil de formation...</p>\r\n");
            EndContext();
#line 45 "K:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\Competence\ProfilFormation_Competence.cshtml"
    }

#line default
#line hidden
            BeginContext(2286, 14, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CheckListViewModel<OutilsActualisation.AppData.Competence, OutilsActualisation.AppData.ProfilFormation>> Html { get; private set; }
    }
}
#pragma warning restore 1591
