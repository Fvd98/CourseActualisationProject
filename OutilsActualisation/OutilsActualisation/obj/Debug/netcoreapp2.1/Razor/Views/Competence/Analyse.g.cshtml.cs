#pragma checksum "F:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\Competence\Analyse.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2dfa34d666c4d98ef61fe58e6a3c8cd05e44044b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Competence_Analyse), @"mvc.1.0.view", @"/Views/Competence/Analyse.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Competence/Analyse.cshtml", typeof(AspNetCore.Views_Competence_Analyse))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2dfa34d666c4d98ef61fe58e6a3c8cd05e44044b", @"/Views/Competence/Analyse.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"81ab37d2a19db97e1812d2a0e685ff62998308c6", @"/Views/_ViewImports.cshtml")]
    public class Views_Competence_Analyse : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<OutilsActualisation.AppData.CompetenceAnalyse>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "F:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\Competence\Analyse.cshtml"
  
    int Increment = 0;
    string IsObl = "Obl.";
    string IsOpt = "Opt.";

#line default
#line hidden
            BeginContext(154, 420, true);
            WriteLiteral(@"
<!--Content-->
<div style=""height: calc(100vh - (1vh + 11.25vw + 111px));max-height: calc(100vh - (5vh + 11.25vw)); overflow-y:auto;"">
    <h2 style=""margin-top:0px;"">Analyse des compétences</h2>
    <p>
        Cette étape sert à analyser les compétences entrées dans l'étape précédente en leur attribuant un niveau taxonomique, une reformalution et un contexte, ainsi que des attitudes et méthodes.
    </p>

");
            EndContext();
#line 15 "F:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\Competence\Analyse.cshtml"
     if (Model.Count() != 0)
    {
        

#line default
#line hidden
#line 18 "F:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\Competence\Analyse.cshtml"
         foreach (var CompetenceAnalyse in Model.ToList())
        {

#line default
#line hidden
            BeginContext(732, 162, true);
            WriteLiteral("            <div class=\"btn btn-dark btn-success\" style=\"width:100%; padding:6px; position:relative;\" type=\"button\" data-toggle=\"collapse\" data-target=\"#collapse_");
            EndContext();
            BeginContext(895, 9, false);
#line 20 "F:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\Competence\Analyse.cshtml"
                                                                                                                                                             Write(Increment);

#line default
#line hidden
            EndContext();
            BeginContext(904, 1, true);
            WriteLiteral("\"");
            EndContext();
            BeginWriteAttribute("aria-controls", " aria-controls=\"", 905, "\"", 940, 2);
            WriteAttributeValue("", 921, "collapse_", 921, 9, true);
#line 20 "F:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\Competence\Analyse.cshtml"
WriteAttributeValue("", 930, Increment, 930, 10, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(941, 228, true);
            WriteLiteral(">\r\n                <span style=\"width:100px; float:left; text-align:left;\">\r\n                    <span class=\"badge badge-light\" style=\"color:black; border-radius:3px; vertical-align:central;margin-top:2px; font-weight:bold;\">\r\n");
            EndContext();
#line 23 "F:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\Competence\Analyse.cshtml"
                         if (CompetenceAnalyse.CompetenceNavigation.IsObligatoire ?? true)
                        {

#line default
#line hidden
            BeginContext(1287, 5, false);
#line 24 "F:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\Competence\Analyse.cshtml"
                    Write(IsObl);

#line default
#line hidden
            EndContext();
#line 24 "F:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\Competence\Analyse.cshtml"
                               }
                    else
                    {

#line default
#line hidden
            BeginContext(1343, 5, false);
#line 26 "F:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\Competence\Analyse.cshtml"
                Write(IsOpt);

#line default
#line hidden
            EndContext();
#line 26 "F:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\Competence\Analyse.cshtml"
                           }

#line default
#line hidden
            BeginContext(1351, 172, true);
            WriteLiteral("                    </span>\r\n                    <span class=\"badge badge-light\" style=\"width: 45px;color:black; border-radius:3px; vertical-align:central;margin-top:2px;\">");
            EndContext();
            BeginContext(1524, 43, false);
#line 28 "F:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\Competence\Analyse.cshtml"
                                                                                                                                          Write(CompetenceAnalyse.CompetenceNavigation.Code);

#line default
#line hidden
            EndContext();
            BeginContext(1567, 181, true);
            WriteLiteral("</span>\r\n                </span>\r\n\r\n                <span style=\"font-weight:bold; width: calc(100% - 100px); overflow:hidden; display:inline-block; float: left; font-size:1.05em;\">");
            EndContext();
            BeginContext(1749, 45, false);
#line 31 "F:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\Competence\Analyse.cshtml"
                                                                                                                                            Write(CompetenceAnalyse.CompetenceNavigation.Enonce);

#line default
#line hidden
            EndContext();
            BeginContext(1794, 282, true);
            WriteLiteral(@"</span>
                <div style=""width:100px; height:100%;position:absolute; right:-6px; top:0; font-size:10px; padding:2px 5px; float:right; margin-right:6px; background-image:linear-gradient(to right, rgba(52, 58, 64,0) , rgba(52, 58, 64,1) 80%);""></div>
            </div>
");
            EndContext();
            BeginContext(2078, 33, true);
            WriteLiteral("            <div class=\"collapse\"");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 2111, "\"", 2135, 2);
            WriteAttributeValue("", 2116, "collapse_", 2116, 9, true);
#line 35 "F:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\Competence\Analyse.cshtml"
WriteAttributeValue("", 2125, Increment, 2125, 10, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2136, 392, true);
            WriteLiteral(@">
                <div style=""background-color:rgba(255, 255, 255, 0.54); margin:0 2px 2px 2px; padding: 0 15px 15px 15px;  border-radius: 0 0 4px 4px;"">
                    <div style=""background-color: white;padding: 8px;border-radius: 0 0 4px 4px;margin-bottom: 15px;border: 0.5px solid #343a40;border-top: 0;"">
                        <strong>Contextes de réalisation :<br /></strong> ");
            EndContext();
            BeginContext(2529, 69, false);
#line 38 "F:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\Competence\Analyse.cshtml"
                                                                     Write(Html.Raw(CompetenceAnalyse.CompetenceNavigation.ContextesRealisation));

#line default
#line hidden
            EndContext();
            BeginContext(2598, 289, true);
            WriteLiteral(@"
                    </div>
                    <div class=""container"" style=""width:inherit; padding:0px;"">
                        <ul class=""nav nav-tabs"" style=""display:flex;"">
                            <li style=""flex-grow:1; text-align:center; cursor:pointer; font-weight:bold;""");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 2887, "\"", 3025, 7);
            WriteAttributeValue("", 2897, "AjaxFill(\'/Competence/Analyse_Taxonomie?id=", 2897, 43, true);
#line 42 "F:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\Competence\Analyse.cshtml"
WriteAttributeValue("", 2940, CompetenceAnalyse.CompetenceNavigation.Code, 2940, 44, false);

#line default
#line hidden
            WriteAttributeValue("", 2984, "\',", 2984, 2, true);
            WriteAttributeValue(" ", 2986, "\'#menu_", 2987, 8, true);
#line 42 "F:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\Competence\Analyse.cshtml"
WriteAttributeValue("", 2994, CompetenceAnalyse.Id, 2994, 21, false);

#line default
#line hidden
            WriteAttributeValue("", 3015, "\',", 3015, 2, true);
            WriteAttributeValue(" ", 3017, "false);", 3018, 8, true);
            EndWriteAttribute();
            BeginContext(3026, 184, true);
            WriteLiteral(" class=\"active\"><a data-toggle=\"tab\" style=\"color:black;\">Taxonomies</a></li>\r\n                            <li style=\"flex-grow:1; text-align:center; cursor:pointer; font-weight:bold;\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 3210, "\"", 3329, 7);
            WriteAttributeValue("", 3220, "AjaxFill(\'/Competence/Analyse_Reformulation?id=", 3220, 47, true);
#line 43 "F:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\Competence\Analyse.cshtml"
WriteAttributeValue("", 3267, CompetenceAnalyse.Id, 3267, 21, false);

#line default
#line hidden
            WriteAttributeValue("", 3288, "\',", 3288, 2, true);
            WriteAttributeValue(" ", 3290, "\'#menu_", 3291, 8, true);
#line 43 "F:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\Competence\Analyse.cshtml"
WriteAttributeValue("", 3298, CompetenceAnalyse.Id, 3298, 21, false);

#line default
#line hidden
            WriteAttributeValue("", 3319, "\',", 3319, 2, true);
            WriteAttributeValue(" ", 3321, "false);", 3322, 8, true);
            EndWriteAttribute();
            BeginContext(3330, 184, true);
            WriteLiteral("><a data-toggle=\"tab\" style=\"color:black;\">Reformulation et contexte</a></li>\r\n                            <li style=\"flex-grow:1; text-align:center; cursor:pointer; font-weight:bold;\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 3514, "\"", 3645, 7);
            WriteAttributeValue("", 3524, "AjaxFill(\'/Competence/Analyse_CompetenceAttitudeMethode?id=", 3524, 59, true);
#line 44 "F:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\Competence\Analyse.cshtml"
WriteAttributeValue("", 3583, CompetenceAnalyse.Id, 3583, 21, false);

#line default
#line hidden
            WriteAttributeValue("", 3604, "\',", 3604, 2, true);
            WriteAttributeValue(" ", 3606, "\'#menu_", 3607, 8, true);
#line 44 "F:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\Competence\Analyse.cshtml"
WriteAttributeValue("", 3614, CompetenceAnalyse.Id, 3614, 21, false);

#line default
#line hidden
            WriteAttributeValue("", 3635, "\',", 3635, 2, true);
            WriteAttributeValue(" ", 3637, "false);", 3638, 8, true);
            EndWriteAttribute();
            BeginContext(3646, 314, true);
            WriteLiteral(@"><a data-toggle=""tab"" style=""color:black; margin-right:0;"">Attitudes et méthodes</a></li>
                        </ul>

                        <div class=""tab-content"" style=""background-color:white; border:1px solid #ddd; border-top:0;  padding:15px; word-break:break-word;"">
                            <div");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 3960, "\"", 3991, 2);
            WriteAttributeValue("", 3965, "menu_", 3965, 5, true);
#line 48 "F:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\Competence\Analyse.cshtml"
WriteAttributeValue("", 3970, CompetenceAnalyse.Id, 3970, 21, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3992, 231, true);
            WriteLiteral(" class=\"tab-pane fade in active\" style=\"\">\r\n\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n            <div style=\"height:7px;\"></div>\r\n");
            EndContext();
#line 56 "F:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\Competence\Analyse.cshtml"
            Increment++;

#line default
#line hidden
            BeginContext(4249, 81, true);
            WriteLiteral("            <script>\r\n                AjaxFill(\'/Competence/Analyse_Taxonomie?id=");
            EndContext();
            BeginContext(4331, 43, false);
#line 58 "F:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\Competence\Analyse.cshtml"
                                                      Write(CompetenceAnalyse.CompetenceNavigation.Code);

#line default
#line hidden
            EndContext();
            BeginContext(4374, 10, true);
            WriteLiteral("\', \'#menu_");
            EndContext();
            BeginContext(4385, 20, false);
#line 58 "F:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\Competence\Analyse.cshtml"
                                                                                                            Write(CompetenceAnalyse.Id);

#line default
#line hidden
            EndContext();
            BeginContext(4405, 35, true);
            WriteLiteral("\', false);\r\n            </script>\r\n");
            EndContext();
#line 60 "F:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\Competence\Analyse.cshtml"
        }

#line default
#line hidden
#line 60 "F:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\Competence\Analyse.cshtml"
         
        
    }
    else
    {

#line default
#line hidden
            BeginContext(4485, 155, true);
            WriteLiteral("        <br />\r\n        <p style=\"font-weight:bold; font-size:20px; text-align:center;\">Aucune compétence pour cette actualisation...</p>\r\n        <br />\r\n");
            EndContext();
#line 68 "F:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\Competence\Analyse.cshtml"
    }

#line default
#line hidden
            BeginContext(4647, 124, true);
            WriteLiteral("</div>\r\n\r\n<script>\r\n    $(document).ready(function () {\r\n        $(\'[data-toggle=\"popover\"]\').popover();\r\n    });\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<OutilsActualisation.AppData.CompetenceAnalyse>> Html { get; private set; }
    }
}
#pragma warning restore 1591
