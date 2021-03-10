using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OutilsActualisation.AppData;
using OutilsActualisation.Models;

namespace OutilsActualisation.Controllers
{
    public class DevisController : Controller
    {
        private OutilActualisationContext _context;
        public DevisController(OutilActualisationContext context)
        {
            this._context = context;
        }
        public IActionResult Etapes()
        {
            return PartialView();
        }

        #region ConditionAdmission
        [Authorize(Policy = "IsResponsable")]
        public IActionResult ConditionAdmission()
        {
            int devisId = GetActualisation().Devis ?? -1;
            List<ConditionAdmissionViewModel> conditions = new List<ConditionAdmissionViewModel>();
            this._context.ConditionAdmission.ToList().FindAll(c => c.Devis == devisId).ForEach(d => conditions.Add(d.ToViewModel()));
            return PartialView(conditions);
        }
        [HttpGet]
        public IActionResult ConditionAdmission_Create()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> ConditionAdmission_Create(ConditionAdmissionViewModel conditionView)
        {
            ConditionAdmission condition = conditionView.ToModel();
            condition.Devis = GetActualisation().Devis;
            this._context.ConditionAdmission.Add(condition);
            await this._context.SaveChangesAsync();
            return Ok("Cette condition d'admission a été ajoutée avec succès.");
        }
        [HttpGet]
        public IActionResult ConditionAdmission_Update(int id)
        {
            return PartialView((this._context.Find(typeof(ConditionAdmission), id) as ConditionAdmission).ToViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> ConditionAdmission_Update(ConditionAdmissionViewModel conditionView)
        {
            ConditionAdmission conditionAdmissionOld = this._context.Find(typeof(ConditionAdmission), conditionView.Id) as ConditionAdmission;
            conditionAdmissionOld.Contenu = conditionView.Contenu;
            this._context.ConditionAdmission.Update(conditionAdmissionOld);
            await this._context.SaveChangesAsync();
            return Ok("Cette condition d'admission a été modifiée avec succès.");
        }
        [HttpPost]
        public async Task<IActionResult> ConditionAdmission_Delete(int id)
        {
            ConditionAdmission condition = (this._context.Find(typeof(ConditionAdmission), id) as ConditionAdmission);
            this._context.ConditionAdmission.Remove(condition);
            await this._context.SaveChangesAsync();
            return Ok("Cette condition d'admission a été supprimée avec succès.");
        }
        #endregion ConditionAdmission

        #region AnalyseProfession
        public IActionResult AnalyseProfession()
        {
            List<PointGabarit> PGs = this._context.Gabarit.Where(G => G.Actualisation == GetActualisation().Id && G.TypeGabarit == 1 && G.Nom == "N").Include(G => G.PointGabarit).ThenInclude(PG => PG.InverseParentPointGabaritNavigation).First().PointGabarit.ToList();
            PGs.RemoveAll(PG => PG.ParentPointGabarit != null && PG.InverseParentPointGabaritNavigation.Count == 0);
            return PartialView(PGs);
        }

        [HttpPost]
        public async Task<IActionResult> Point_Update(PointGabarit point)
        {
            if (point.Contenu == null || new Regex(@"^(\d+(.\d+)*)*$").Match(point.Contenu).Success || this._context.PointGabarit.Where(PG => PG.Id == point.Id).Include(PG => PG.GabaritNavigation).First().GabaritNavigation.TypeGabarit != 2)
            {
                PointGabarit pointOld = this._context.Find(typeof(PointGabarit), point.Id) as PointGabarit;
                pointOld.Contenu = point.Contenu;
                this._context.Update(pointOld);
                await this._context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return BadRequest("L'enregistrement a échoué: les données doivent être des nombres.");
            }
            
        }
        #endregion AnalyseProfession

        #region UniteHeure
        public IActionResult UniteHeure()
        {
            GabaritComparaisonViewModel gabaritComparaisonViewModel = new GabaritComparaisonViewModel
            {
                ancienDevis = this._context.Gabarit.Where(G => G.Actualisation == GetActualisation().Id && G.TypeGabarit == 2 && G.Nom == "A").Include(G => G.PointGabarit).ThenInclude(PG => PG.InverseParentPointGabaritNavigation).First(),
                nouveauDevis = this._context.Gabarit.Where(G => G.Actualisation == GetActualisation().Id && G.TypeGabarit == 2 && G.Nom == "N").Include(G => G.PointGabarit).ThenInclude(PG => PG.InverseParentPointGabaritNavigation).First()
            };
            List<PointGabarit> PGs = gabaritComparaisonViewModel.ancienDevis.PointGabarit.ToList();
            PGs.RemoveAll(PG => PG.ParentPointGabarit != null && PG.InverseParentPointGabaritNavigation.Count == 0);
            gabaritComparaisonViewModel.ancienDevis.PointGabarit = PGs;
            List<PointGabarit> PGs2 = gabaritComparaisonViewModel.nouveauDevis.PointGabarit.ToList();
            PGs2.RemoveAll(PG => PG.ParentPointGabarit != null && PG.InverseParentPointGabaritNavigation.Count == 0);
            gabaritComparaisonViewModel.nouveauDevis.PointGabarit = PGs2;
            return PartialView(gabaritComparaisonViewModel);
        }
        #endregion UniteHeure

        #region Finalite
        public IActionResult Finalite()
        {           
            return PartialView(new GabaritComparaisonViewModel { ancienDevis = this._context.Gabarit.Where(G => G.Actualisation == GetActualisation().Id && G.TypeGabarit == 3 && G.Nom == "A").Include(G => G.PointGabarit).First(), nouveauDevis = this._context.Gabarit.Where(G => G.Actualisation == GetActualisation().Id && G.TypeGabarit == 3 && G.Nom == "N").Include(G => G.PointGabarit).First() } );
        }
        #endregion Finalite

        #region Competence
        public IActionResult Competence()
        {
            return PartialView(this._context.CompetenceAnalyse.Where(CA => CA.Actualisation == GetActualisation().Id).Include(CA => CA.CompetenceNavigation).ThenInclude(CA => CA.Element).ToList());
        }

        [HttpGet]
        public IActionResult Competence_Create()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> Competence_Create(Competence model)
        {
            if (ModelState.IsValid)
            {
                CompetenceAnalyse competenceAnalyse = this._context.CompetenceAnalyse.Where(CA => CA.Competence == model.Code && CA.Actualisation == GetActualisation().Id).FirstOrDefault();
                if (competenceAnalyse == null)
                {
                    if (this._context.Competence.Where(C => C.Code == model.Code).FirstOrDefault() == null)
                    {
                        if (model.ContextesRealisation != null)
                        {
                            model.ContextesRealisation = model.ContextesRealisation.Replace("\r\n", "<br/>");
                        }
                        model.Devis = this._context.Devis.Where(D => D.Id == GetActualisation().Devis).First().Id;
                        this._context.Add(model);
                        await this._context.SaveChangesAsync();
                        this._context.Add(new CompetenceAnalyse { Competence = model.Code, Actualisation = GetActualisation().Id, Reformulation = "", Contexte = "" });
                        await this._context.SaveChangesAsync();
                        return Ok("Cette compétence a été ajoutée avec succès.");
                    }
                    else
                    {
                        this._context.Add(new CompetenceAnalyse { Competence = model.Code, Actualisation = GetActualisation().Id, Reformulation = "", Contexte = "" });
                        foreach(Element e in this._context.Element.Where(E => E.Competence == model.Code).ToList())
                        {
                            this._context.Add(new ElementAnalyse { Actualisation = GetActualisation().Id, Element = e.Id });
                        }
                        await this._context.SaveChangesAsync();
                        return Ok("Cette compétence a été ajoutée avec succès.");
                    }
                }
                ModelState.AddModelError("Code", "Cette compétence existe déjà. Veuillez entrer un code différent.");
                return PartialView(model);
            }
            return PartialView(model);
        }

        [HttpGet]
        public IActionResult Competence_Update(string id)
        {
            Competence competence = this._context.Find(typeof(Competence), id) as Competence;
            if (competence.ContextesRealisation != null)
            {
                competence.ContextesRealisation = competence.ContextesRealisation.Replace("<br/>", "\r\n");
            }           
            return PartialView(competence);
        }

        [HttpPost]
        public async Task<IActionResult> Competence_Update(Competence model)
        {
            if (ModelState.IsValid)
            {
                Competence competenceOld = this._context.Competence.Where(C => C.Code == model.Code).First();
                if (model.ContextesRealisation != null)
                {
                    model.ContextesRealisation = model.ContextesRealisation.Replace("\r\n", "<br/>");
                }
                competenceOld.Enonce = model.Enonce;
                competenceOld.IsObligatoire = model.IsObligatoire;
                competenceOld.ContextesRealisation = model.ContextesRealisation;
                this._context.Update(competenceOld);
                await this._context.SaveChangesAsync();
                return Ok("Cette compétence a été modifiée avec succès.");
            }
            return PartialView(model);
        }

        [HttpPost]
        public async Task<IActionResult> Competence_Delete(string id)
        {
            CompetenceAnalyse analyseCompetence = this._context.CompetenceAnalyse.Where(CA => CA.Competence == id && CA.Actualisation == GetActualisation().Id).Include(CA => CA.CompetenceNavigation).ThenInclude(C => C.CoursCompetence).FirstOrDefault();
            if (analyseCompetence != null)
            {
                if (analyseCompetence.CompetenceNavigation.CoursCompetence.Count() == 0)
                {
                    this._context.ElementAnalyse.Include(EA => EA.ElementNavigation).Where(EA => EA.Actualisation == GetActualisation().Id && EA.ElementNavigation.Competence == id).ToList().ForEach(EA => this._context.Remove(EA));
                    this._context.Remove(analyseCompetence);
                    await this._context.SaveChangesAsync();
                    return Ok("Cette compétence a été retiré avec succès.");
                }
                return BadRequest("Cette compétence ne peut pas être supprimée car elle est utilisée par un cours d'une actualisation.");
            }
            return BadRequest("Cette compétence n'existe pas ou a déjà été retiré.");
        }

        [HttpGet]
        public IActionResult ElementCompetence_Create(string id)
        {
            return PartialView(new Element { Competence = id });
        }

        [HttpPost]
        public async Task<IActionResult> ElementCompetence_Create(Element model)
        {
            if (ModelState.IsValid)
            {
                if (model.CriterePerformance != null)
                {
                    model.CriterePerformance = model.CriterePerformance.Replace("\r\n", "<br/>");
                }
                this._context.Add(model);
                this._context.CompetenceAnalyse.Where(C => C.Competence == model.Competence).Select(C => C.Actualisation).ToList().ForEach(A => this._context.Add(new ElementAnalyse { Actualisation = A ?? -1, Element = model.Id }));
                await this._context.SaveChangesAsync();
                return Ok("Cet élément a été ajoutée avec succès.");
            }
            return PartialView(model);
        }

        [HttpGet]
        public IActionResult ElementCompetence_Update(int id)
        {
            Element element = this._context.Element.Where(E => E.Id == id).First();
            if (element.CriterePerformance != null)
            {
                element.CriterePerformance = element.CriterePerformance.Replace("<br/>", "\r\n");
            }           
            return PartialView(element);
        }

        [HttpPost]
        public async Task<IActionResult> ElementCompetence_Update(Element model)
        {
            if (ModelState.IsValid)
            {
                Element elementOld = this._context.Element.Where(E => E.Id == model.Id).First();
                if (model.CriterePerformance != null)
                {
                    model.CriterePerformance = model.CriterePerformance.Replace("\r\n", "<br/>");
                }
                elementOld.CriterePerformance = model.CriterePerformance;
                elementOld.Enonce = model.Enonce;
                this._context.Update(elementOld);
                await this._context.SaveChangesAsync();
                return Ok("Cet élément a été modifié avec succès.");
            }
            return PartialView(model);
        }

        [HttpPost]
        public async Task<IActionResult> ElementCompetence_Delete(int id)
        {
            Element element = this._context.Element.Where(E => E.Id == id).First();
            if (element != null)
            {
                this._context.ElementAnalyse.Where(EA => EA.Element == id).ToList().ForEach(EA => this._context.Remove(EA));
                this._context.Remove(element);
                await this._context.SaveChangesAsync();
                return Ok("Cet élément a été supprimé avec succès.");
            }
            return BadRequest("Cet élément n'existe pas ou a déjà été supprimé.");
        }
        #endregion Competence

        private Actualisation GetActualisation()
        {
            return this._context.Find(typeof(Actualisation), Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "IDActu").Value)) as Actualisation;
        }

        private bool charOK(char C)
        {
            return Char.IsNumber(C) || C == '.';
        }

    }
}