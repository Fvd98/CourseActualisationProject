#pragma checksum "F:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\Cours\Choix.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2599d7b9544f47097783243eb832a38b12eb934c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cours_Choix), @"mvc.1.0.view", @"/Views/Cours/Choix.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Cours/Choix.cshtml", typeof(AspNetCore.Views_Cours_Choix))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2599d7b9544f47097783243eb832a38b12eb934c", @"/Views/Cours/Choix.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"81ab37d2a19db97e1812d2a0e685ff62998308c6", @"/Views/_ViewImports.cshtml")]
    public class Views_Cours_Choix : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 11736, true);
            WriteLiteral(@"<!--Content-->
<div style=""height: calc(100vh - (1vh + 11.25vw + 111px));max-height: calc(100vh - (5vh + 11.25vw)); overflow-y:auto;"">
    <h2 style=""margin-top:0px;"">Création de choix de cours <span style=""float:right;margin-right:5%;"" class=""btn btn-success"" data-toggle=""modal"" data-target=""#exampleModal"">Ajouter un choix de cours</span></h2>
    <p>
        Cette étape vous permet de créer, modifier et supprimer des choix de cours.
    </p>

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

        tr {
            background-color: #fff;
        }


        th {
            background-color: #343a40;
            color: white;
            text-align: center;
        }

        input[type=""radio""] {
            width: 1.5em;
            height: 1.5em;
        }
    </style>

        <div style=");
            WriteLiteral(@"""width:90%; margin:auto;"">
            <button class=""btn btn-dark btn-success"" style=""width:100%; padding:6px;"" type=""button"" data-toggle=""collapse"" data-target=""#collapseExample"" aria-expanded=""false"" aria-controls=""collapseExample"">
                Choix des cours de web design (2)
                <span style=""float:right; font-size:10px; padding:2px 5px; float:right;"" class=""btn btn-danger glyphicon glyphicon-trash""></span>
                <span style=""float:right; font-size:10px; padding:2px 5px; float:right; margin-right:6px;"" class=""btn btn-warning glyphicon glyphicon-pencil""></span>
            </button>
            <div class=""collapse"" id=""collapseExample"" style=""background-color:rgba(255, 255, 255, 0.54); margin:2px; padding: 10px;"">
                <div class=""card card-body"">
                    <table>
                        <tr>
                            <td>
                                <div style=""display:flex;"">
                                    <span class=""badge badge-l");
            WriteLiteral(@"ight"" style=""flex: none; display:inline-block;height:18px;background-color:#343a40;color:white; border-radius:3px; float:left; vertical-align:central;margin-top:2px; margin-right:6px;"">0000</span>
                                    <label style=""display:inline-block;text-align:left; flex-grow: 1;"">
                                        Documentation et multimédia
                                    </label>
                                </div>
                                <div style=""display:flex;"">
                                    <span class=""badge badge-dark"" style=""flex: none; display:inline-block;height:18px;background-color:#343a40;color:white; border-radius:3px; float:left; vertical-align:central;margin-top:2px; margin-right:6px;"">0012</span>
                                    <label style=""display:inline-block;text-align:left; flex-grow: 1;"">
                                        Programmation CSS et HTML
                                    </label>
                            ");
            WriteLiteral(@"    </div>
                                <div style=""display:flex;"">
                                    <span class=""badge badge-light"" style=""flex: none; display:inline-block;height:18px;background-color:#343a40;color:white; border-radius:3px; float:left; vertical-align:central;margin-top:2px; margin-right:6px;"">0035</span>
                                    <label style=""display:inline-block;text-align:left; flex-grow: 1;"">
                                        Bootstrap
                                    </label>
                                </div>
                            </td>
                        </tr>
                        <tr><td colspan=""2""><a style=""width:109px; margin-right:3px; float:right;"" data-toggle=""modal"" data-target=""#exampleModal2"" aria-controls=""exampleModal2"" class=""btn btn-warning""><span style=""margin-right:7px;"" class=""glyphicon glyphicon-pencil""></span>Modifier</a></td></tr>
                    </table>
                    
                </div>
       ");
            WriteLiteral(@"     </div>
        </div>
    </div>

    <!-- Modal Fam -->
    <div class=""modal fade"" id=""exampleModal2"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalLabel2"" aria-hidden=""true"">
        <div class=""modal-dialog"" role=""document"">
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <h4 class=""modal-title"" id=""exampleModalLabel2"" style=""display:inline-block;"">Choisissez les cours du choix :</h4>
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true"">&times;</span>
                    </button>
                </div>
                <div class=""modal-body"">

                    <table>
                        <tr>
                            <th style=""padding-right:85px;"">
                                <span class=""badge badge-light"" style=""flex: none; display:inline-block;height:18px;background-color:white;color:black; border-radius:3p");
            WriteLiteral(@"x; float:left; vertical-align:central;margin-top:2px; margin-right:6px;"">No</span>
                                Cours
                            </th>
                            <th>
                                Sélectionné
                            </th>
                        </tr>
                        <tr>
                            <td>
                                <div style=""display:flex;"">
                                    <span class=""badge badge-light"" style=""flex: none; display:inline-block;height:18px;background-color:#343a40;color:white; border-radius:3px; float:left; vertical-align:central;margin-top:2px; margin-right:6px;"">0000</span>
                                    <label style=""display:inline-block;text-align:left; flex-grow: 1;"">
                                        Cours 1
                                    </label>
                                </div>
                            </td>
                            <td style=""text-align:center;"">
");
            WriteLiteral(@"                                <input type=""checkbox"" style=""display:inline-block;"" checked>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style=""display:flex;"">
                                    <span class=""badge badge-light"" style=""flex: none; display:inline-block;height:18px;background-color:#343a40;color:white; border-radius:3px; float:left; vertical-align:central;margin-top:2px; margin-right:6px;"">00Q2</span>
                                    <label style=""display:inline-block;text-align:left; flex-grow: 1;"">
                                        Cours 2
                                    </label>
                                </div>
                            </td>
                            <td style=""text-align:center;"">
                                <input type=""checkbox"" style=""display:inline-block;"">
                            </td>
                    ");
            WriteLiteral(@"    </tr>
                        <tr>
                            <td>
                                <div style=""display:flex;"">
                                    <span class=""badge badge-light"" style=""flex: none; display:inline-block;height:18px;background-color:#343a40;color:white; border-radius:3px; float:left; vertical-align:central;margin-top:2px; margin-right:6px;"">00Q3</span>
                                    <label style=""display:inline-block;text-align:left; flex-grow: 1;"">
                                        Cours 3
                                    </label>
                                </div>
                            </td>
                            <td style=""text-align:center;"">
                                <input type=""checkbox"" style=""display:inline-block;"">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style=""display:flex;"">
              ");
            WriteLiteral(@"                      <span class=""badge badge-light"" style=""flex: none; display:inline-block;height:18px;background-color:#343a40;color:white; border-radius:3px; float:left; vertical-align:central;margin-top:2px; margin-right:6px;"">00Q3</span>
                                    <label style=""display:inline-block;text-align:left; flex-grow: 1;"">
                                        Cours 4
                                    </label>
                                </div>
                            </td>
                            <td style=""text-align:center;"">
                                <input type=""checkbox"" style=""display:inline-block;"">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style=""display:flex;"">
                                    <span class=""badge badge-light"" style=""flex: none; display:inline-block;height:18px;background-color:#343a40;color:white; border");
            WriteLiteral(@"-radius:3px; float:left; vertical-align:central;margin-top:2px; margin-right:6px;"">00Q3</span>
                                    <label style=""display:inline-block;text-align:left; flex-grow: 1;"">
                                        Cours 5
                                    </label>
                                </div>
                            </td>
                            <td style=""text-align:center;"">
                                <input type=""checkbox"" style=""display:inline-block;"">
                            </td>
                        </tr>
                    </table>

                </div>
                <div class=""modal-footer"">
                    <button type=""button"" class=""btn btn-primary"">Ajouter</button>
                </div>
            </div>
        </div>
    </div>


    <!-- Modal Attitude -->
    <div class=""modal fade"" id=""exampleModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
        <div class=");
            WriteLiteral(@"""modal-dialog"" role=""document"">
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <h4 class=""modal-title"" id=""exampleModalLabel"" style=""display:inline-block;"">Créer un choix de cours</h4>
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true"">&times;</span>
                    </button>
                </div>
                <div class=""modal-body"" style=""padding:20px 15%;"">

                    <div style=""display:flex; margin-top:7px;"">
                        <label style=""flex-grow: 0.5;width:30%; line-height:26px; padding-right:5px; text-align:right;"">Nom du choix de cours : </label>
                        <input type=""text"" style=""flex-grow: 1; width:15%;"" />
                    </div>
                    <div style=""display:flex; margin-top:7px;"">
                        <label style=""flex-grow: 0.5;width:30%; line-height:26px; padding-right:5px");
            WriteLiteral(@"; text-align:right;"">Nombre de cours à choisir : </label>
                        <input type=""number"" style=""flex-grow: 1; width:15%;"" />
                    </div>

                </div>
                <div class=""modal-footer"">
                    <button type=""button"" class=""btn btn-primary"" data-toggle=""modal"" data-target=""#exampleModal2"" aria-controls=""exampleModal2"">Créer</button>
                </div>
            </div>
        </div>
    </div>
");
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