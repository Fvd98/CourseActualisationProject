#pragma checksum "K:\ProjetFinal - V0.1.4\OutilsActualisation\OutilsActualisation\Views\Cours\Etapes.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b069b1d5bbc6ac84dc1029b2b289008841c3472e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cours_Etapes), @"mvc.1.0.view", @"/Views/Cours/Etapes.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Cours/Etapes.cshtml", typeof(AspNetCore.Views_Cours_Etapes))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b069b1d5bbc6ac84dc1029b2b289008841c3472e", @"/Views/Cours/Etapes.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"81ab37d2a19db97e1812d2a0e685ff62998308c6", @"/Views/_ViewImports.cshtml")]
    public class Views_Cours_Etapes : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 961, true);
            WriteLiteral(@"<div style=""width:15vw; position:absolute; left:0; top: calc(8.5vw + 2vh); margin-top: 20px;"">
    <div onclick=""AjaxFill('/Cours/Creation', '#ContentContainer', false); ChangeSelect('smallstep','selected', $(event.target));"" class=""smallstep selected"">Création des cours</div>
    <div onclick=""AjaxFill('/Cours/Choix', '#ContentContainer', false); ChangeSelect('smallstep','selected', $(event.target));"" class=""smallstep"">Choix de cours</div>
    <div onclick=""AjaxFill('/Cours/FormationGenerale', '#ContentContainer', false); ChangeSelect('smallstep','selected', $(event.target));"" class=""smallstep"">Formation Générale</div>
    <div onclick=""AjaxFill('/Cours/RepartitionHeure', '#ContentContainer', false); ChangeSelect('smallstep','selected', $(event.target));"" class=""smallstep"">Répartition des heures</div>
</div>
<div id=""ContentContainer"" style=""margin-left: 15vw; position:relative; height: calc(100vh - (1vh + 11.25vw + 111px));"">
    
</div>");
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
