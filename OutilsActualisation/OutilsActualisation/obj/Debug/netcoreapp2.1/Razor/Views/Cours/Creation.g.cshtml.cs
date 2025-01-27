#pragma checksum "F:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\Cours\Creation.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f75f37103b0b112c22117451bcbd299e44c03c83"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cours_Creation), @"mvc.1.0.view", @"/Views/Cours/Creation.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Cours/Creation.cshtml", typeof(AspNetCore.Views_Cours_Creation))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f75f37103b0b112c22117451bcbd299e44c03c83", @"/Views/Cours/Creation.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"81ab37d2a19db97e1812d2a0e685ff62998308c6", @"/Views/_ViewImports.cshtml")]
    public class Views_Cours_Creation : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 14460, true);
            WriteLiteral(@"<!--Content-->
<div style=""height: calc(100vh - (1vh + 11.25vw + 111px));max-height: calc(100vh - (5vh + 11.25vw)); overflow-y:auto;"">
    <style>
        table {
            font-family: arial, sans-serif;
            border-collapse: collapse;
            width: 100%;
        }

        td, th {
            text-align: left;
            padding: 8px;
        }

        th {
            background-color: #343a40;
            color: white;
            text-align: center;
            word-break: keep-all !important;
        }

        input[type=""radio""] {
            width: 1.5em;
            height: 1.5em;
        }
    </style>

    <h2 style=""margin-top:0px;"">Création de cours <span style=""float:right;margin-right:5%;"" class=""btn btn-success"" data-toggle=""modal"" data-target=""#exampleModal"">Ajouter un cours</span></h2>
    <p>
       Cette étape vous permet de créer, modifier et supprimer les cours qui feront partis du nouveau programme.
    </p>

        <button class=""btn b");
            WriteLiteral(@"tn-dark btn-success"" style=""width:100%; padding:6px;"" type=""button"" data-toggle=""collapse"" data-target=""#collapseExample"" aria-expanded=""false"" aria-controls=""collapseExample"">
            <span class=""badge badge-light"" style=""color:black; border-radius:3px; float:left; vertical-align:central;margin-top:2px; margin-right:6px;"">420-HU-302</span>
            Programmation I
            <span style=""float:right; font-size:10px; padding:2px 5px; float:right;"" class=""btn btn-danger glyphicon glyphicon-trash""></span>
        </button>
        <div class=""collapse"" id=""collapseExample"" style=""background-color:rgba(255, 255, 255, 0.54); margin:2px; padding: 10px;"">
            <div class=""card card-body"">

                <div class=""container"" style=""width:inherit"">
                    <ul class=""nav nav-tabs"" style=""display:flex;"">
                        <li style=""flex-grow:1; text-align:center;"" class=""active""><a data-toggle=""tab"" href=""#menu1"" style=""color:black;"">Informations générales</a></li>
   ");
            WriteLiteral(@"                     <li style=""flex-grow:1; text-align:center;""><a data-toggle=""tab"" href=""#menu2"" style=""color:black;"">Compétences</a></li>
                        <li style=""flex-grow:1; text-align:center;""><a data-toggle=""tab"" href=""#menu3"" style=""color:black;"">Équivalences et préalables</a></li>
                    </ul>

                    <div class=""tab-content"" style=""background-color:white; margin:0 3px 0 1px; padding:15px; word-break:break-word;"">

                        <div id=""menu1"" class=""tab-pane fade in active"">
                            <a style=""width:109px; margin-right:3px; float:right;"" class=""btn btn-warning""><span style=""margin-right:7px;"" class=""glyphicon glyphicon-pencil""></span>Modifier</a>
                            <table>
                                <tr style=""margin-top:7px;"">
                                    <td><label style=""width:100%; line-height:26px; padding-right:5px; text-align:right;"">Sigle : </label></td>
                                    <td>");
            WriteLiteral(@"
                                        <label type=""text"">420-HU-302</label>
                                    </td>
                                </tr>
                                <tr style=""margin-top:7px;"">
                                    <td><label style=""width:100%; line-height:26px; padding-right:5px; text-align:right;"">Titre : </label></td>
                                    <td>
                                        <label type=""text"">Programmation I</label>
                                    </td>
                                </tr>
                                <tr style=""margin-top:7px;"">
                                    <td><label style=""width:100%; line-height:26px; padding-right:5px; text-align:right;"">Session : </label></td>
                                    <td>
                                        <label type=""text"">1</label>
                                    </td>
                                </tr>
                                <tr style=""");
            WriteLiteral(@"margin-top:7px;"">
                                    <td><label style=""width:100%; line-height:26px; padding-right:5px; text-align:right;"">Pondérations : </label></td>
                                    <td>
                                        <span type=""text"" style=""font-weight:bold;"">3-3-3</span>
                                    </td>
                                </tr>
                            </table>

                        </div>

                        <div id=""menu2"" class=""tab-pane fade"">
                            <a style=""width:109px; margin-right:3px; float:right;"" class=""btn btn-warning""><span style=""margin-right:7px;"" class=""glyphicon glyphicon-pencil""></span>Modifier</a>
                            <div style=""width:100%;"">
                                <button class=""btn btn-dark btn-success"" style=""width:100%; padding:6px; margin-top:7px;"" type=""button"" data-toggle=""collapse"" data-target=""#collapseExample5"" aria-expanded=""false"" aria-controls=""collapseExample");
            WriteLiteral(@""">
                                    <span class=""badge badge-light"" style=""color:black; border-radius:3px; float:left; vertical-align:central;margin-top:2px; margin-right:6px;"">0000</span>
                                    Traiter l’information relative aux réalités du milieu du travail en informatique
                                </button>
                                <div class=""collapse"" id=""collapseExample5"" style=""background-color:rgba(255, 255, 255, 0.54); margin:2px; padding: 10px;"">
                                    <div class=""card card-body"">
                                        <div style=""display:flex;"">
                                            <span class=""badge badge-light"" style=""height:18px;background-color:#343a40;color:white; border-radius:3px; float:left; vertical-align:central;margin-top:2px; margin-right:6px;"">1</span>
                                            <label style=""text-align:left; flex-grow: 1;"">
                                                Reche");
            WriteLiteral(@"rcher de l’information sur les professions et les milieux de travail en informatique.
                                            </label>
                                        </div>
                                        <div style=""display:flex;"">
                                            <span class=""badge badge-light"" style=""height:18px;background-color:#343a40;color:white; border-radius:3px; float:left; vertical-align:central;margin-top:2px; margin-right:6px;"">2</span>
                                            <label style=""text-align:left; flex-grow: 1;"">
                                                Analyser l’information sur les entreprises et les établissements embauchant des techniciennes et techniciens en informatique.
                                            </label>
                                        </div>
                                        <div style=""display:flex;"">
                                            <span class=""badge badge-light"" style=""height:18px;b");
            WriteLiteral(@"ackground-color:#343a40;color:white; border-radius:3px; float:left; vertical-align:central;margin-top:2px; margin-right:6px;"">3</span>
                                            <label style=""text-align:left; flex-grow: 1;"">
                                                Analyser l’information sur la profession de technicienne et technicien en informatique.
                                            </label>
                                        </div>

                                    </div>
                                </div>
                            </div>

                            <div>
                                <button class=""btn btn-dark btn-success"" style=""width:100%; padding:6px; margin-top:7px;"" type=""button"" data-toggle=""collapse"" data-target=""#collapseExample2"" aria-expanded=""false"" aria-controls=""collapseExample2"">
                                    <span class=""badge badge-light"" style=""color:black; border-radius:3px; float:left; vertical-align:central;margin-t");
            WriteLiteral(@"op:2px; margin-right:6px;"">00Q2</span>
                                    Utiliser des langages de programmation
                                </button>
                                <div class=""collapse"" id=""collapseExample2"" style=""background-color:rgba(255, 255, 255, 0.54); margin:2px; padding: 10px;"">
                                    <div class=""card card-body"">
                                        <div style=""display:flex;"">
                                            <span class=""badge badge-light"" style=""height:18px;background-color:#343a40;color:white; border-radius:3px; float:left; vertical-align:central;margin-top:2px; margin-right:6px;"">1</span>
                                            <label style=""text-align:left; flex-grow: 1;"">
                                                Traiter des nombres à représenter dans la mémoire d’un ordinateur.
                                            </label>
                                        </div>
                               ");
            WriteLiteral(@"         <div style=""display:flex;"">
                                            <span class=""badge badge-light"" style=""height:18px;background-color:#343a40;color:white; border-radius:3px; float:left; vertical-align:central;margin-top:2px; margin-right:6px;"">2</span>
                                            <label style=""text-align:left; flex-grow: 1;"">
                                                Représenter des figures géométriques en deux dimensions sous la forme d’images numériques.
                                            </label>
                                        </div>
                                        <div style=""display:flex;"">
                                            <span class=""badge badge-light"" style=""height:18px;background-color:#343a40;color:white; border-radius:3px; float:left; vertical-align:central;margin-top:2px; margin-right:6px;"">3</span>
                                            <label style=""text-align:left; flex-grow: 1;"">
                           ");
            WriteLiteral(@"                     Modéliser des raisonnements logiques à plusieurs variables.
                                            </label>
                                        </div>
                                        <div style=""display:flex;"">
                                            <span class=""badge badge-light"" style=""height:18px;background-color:#343a40;color:white; border-radius:3px; float:left; vertical-align:central;margin-top:2px; margin-right:6px;"">4</span>
                                            <label style=""text-align:left; flex-grow: 1;"">
                                                Traiter des données quantitatives par les statistiques descriptives.
                                            </label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div id=""menu3"" class=""tab-pane fade"">
         ");
            WriteLiteral(@"                   <a style=""width:109px; margin-right:3px; float:right;"" class=""btn btn-warning""><span style=""margin-right:7px;"" class=""glyphicon glyphicon-pencil""></span>Modifier</a>
                            <table>
                                <tr style=""margin-top:7px;"">
                                    <td><label style=""width:100%; line-height:26px; padding-right:5px; text-align:right;"">Cours équivalent : </label></td>
                                    <td>
                                        <label type=""text"">Introduction à la programmation</label>
                                    </td>
                                </tr>
                                <tr style=""margin-top:7px;"">
                                    <td><label style=""width:100%; line-height:26px; padding-right:5px; text-align:right;"">Préalables : </label></td>
                                    <td>
                                        <label type=""text"">aucun</label>
                               ");
            WriteLiteral(@"     </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
        </div>
    </div>
</div>

<!-- Modal Methodes -->
<div class=""modal fade"" id=""exampleModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h4 class=""modal-title"" id=""exampleModalLabel"" style=""display:inline-block;"">Création d'un cours</h4>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">
                <table>
                    <tr>
                        <td>Sigle*: </td>
                        <td>
                            <input type=""text"" class=");
            WriteLiteral(@"""form-control"">
                        </td>
                    </tr>
                    <tr>
                        <td>Titre*: </td>
                        <td>
                            <input type=""text"" class=""form-control"">
                        </td>
                    </tr>
                    <tr>
                        <td>Session: </td>
                        <td>
                            <input type=""number"" class=""form-control"">
                        </td>
                    </tr>
                    <tr>
                        <td>Pondérations: </td>
                        <td>
                            <input type=""number"" style=""width:10%;""/>
                            <input type=""number""style=""width:10%;""/>
                            <input type=""number"" style=""width:10%;""/>
                        </td>
                    </tr>
                   
                </table>

            </div>
            <div class=""modal-footer"">
        ");
            WriteLiteral("        <button type=\"button\" class=\"btn btn-success\">Créer</button>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
