using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OutilsActualisation.AppData;
using OutilsActualisation.Models;

namespace OutilsActualisation.Controllers
{
    public class CompetenceController : Controller
    {
        private OutilActualisationContext _context;
        public CompetenceController(OutilActualisationContext context)
        {
            this._context = context;
        }
        public IActionResult Etapes()
        {
            return PartialView();
        }

        #region Analyse

        public IActionResult Analyse()
        {
            return PartialView(this._context.CompetenceAnalyse.Where(CA => CA.Actualisation == GetActualisation().Id).Include(CA => CA.CompetenceNavigation).ThenInclude(C => C.Element).ToList());
        }
        
        #region Taxonomie
        [HttpGet]
        public IActionResult Analyse_Taxonomie(string id)
        {
            List<int> elementsCompetence = this._context.Competence.Where(C => C.Code == id).Include(C => C.Element).First().Element.ToList().Select(E => E.Id).ToList();
            AnalyseTaxonomieViewModel viewModel = new AnalyseTaxonomieViewModel { competenceAnalyse = this._context.CompetenceAnalyse.Where(CA => CA.Actualisation == GetActualisation().Id && CA.Competence == id).FirstOrDefault(), elementAnalyses = this._context.ElementAnalyse.Include(EA => EA.ElementNavigation).Where(EA => elementsCompetence.Contains(EA.ElementNavigation.Id) && EA.Actualisation == GetActualisation().Id).ToList() };
            if(GetActualisation().ModeleTaxonomique == null)
            {
                viewModel.modelesDisponibles = new SelectList(this._context.ModeleTaxonomique.Where(MT => MT.IsAvailable ?? false).ToList(), "Nom", "Nom");
            }
            else
            {
                viewModel.modeleTaxonomique = this._context.ModeleTaxonomique.Where(MT => MT.Nom == GetActualisation().ModeleTaxonomique).Include(MT => MT.NiveauTaxonomique).First();
            }
            return PartialView(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> SetModeleTaxonomique(string id)
        {
            try
            {
                Actualisation actualisation = GetActualisation();
                actualisation.ModeleTaxonomique = id;
                this._context.Update(actualisation);
                await this._context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Oups! Une erreur est survenue.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Analyse_Taxonomie(TaxonomieViewModel model)
        {
            switch(model.isCompetence)
            {
                case true:
                    CompetenceAnalyse competenceOld = this._context.CompetenceAnalyse.Where(CA => CA.Id == model.id).FirstOrDefault();
                    if(competenceOld != null)
                    {
                        competenceOld.NiveauTaxonomique = model.idNiveauTaxonomique;
                        this._context.CompetenceAnalyse.Update(competenceOld);
                        await this._context.SaveChangesAsync();
                        return Ok();
                    }
                    return BadRequest("Oups! Une erreur est survenue.");
                case false:
                    ElementAnalyse elementOld = this._context.ElementAnalyse.Where(EA => EA.Id == model.id).FirstOrDefault();
                    if (elementOld != null)
                    {
                        elementOld.NiveauTaxonomique = model.idNiveauTaxonomique;                      
                        this._context.ElementAnalyse.Update(elementOld);
                        await this._context.SaveChangesAsync();
                        return Ok();
                    }
                    return BadRequest("Oups! Une erreur est survenue.");
            }
            return BadRequest();
        }
        #endregion Taxonomie

        #region Reformulation
        [HttpGet]
        public IActionResult Analyse_Reformulation(int id)
        {
            return PartialView(this._context.CompetenceAnalyse.Where(CA => CA.Id == id).First());
        }

        [HttpPost]
        public async Task<IActionResult> Analyse_Reformulation(CompetenceAnalyse model)
        {
            CompetenceAnalyse competenceOld = this._context.CompetenceAnalyse.Where(CA => CA.Id == model.Id).FirstOrDefault();
            if (competenceOld != null)
            {
                competenceOld.Reformulation = model.Reformulation ?? "";
                competenceOld.Contexte = model.Contexte ?? "";
                this._context.CompetenceAnalyse.Update(competenceOld);
                await this._context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest("Oups! Une erreur est survenue.");
        }
        #endregion Reformulation

        #region AttitudeMethode
        // Retourne la liste des attitudes ET des des méthodes de la compétence
        [HttpGet]
        public IActionResult Analyse_CompetenceAttitudeMethode(int id)
        {
            return PartialView(this._context.CompetenceAnalyse.Where(CA => CA.Id == id).Include(CA => CA.CompetenceAnalyseAttitudeMethode).ThenInclude(CAAM => CAAM.AttitudeMethodeNavigation).First());
        }

        // Retourne la liste des attitudes OU des méthodes de l'actualisation
        [HttpGet]
        public IActionResult Analyse_CompetenceAttitudeMethode_Update(int id, string type)
        {
            CheckListViewModel<AttitudeMethode, CompetenceAnalyse> checkListViewModel = new CheckListViewModel<AttitudeMethode, CompetenceAnalyse> { Items = new List<CheckListItem<AttitudeMethode>>(), Parent = this._context.CompetenceAnalyse.Where(C => C.Id == id).First() };
            List<AttitudeMethode> AMs = this._context.Actualisation.Where(A => A.Id == Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "IDActu").Value)).Include(A => A.AttitudeMethode).ThenInclude(AM => AM.CompetenceAnalyseAttitudeMethode).First().AttitudeMethode.ToList();
            foreach(AttitudeMethode C in AMs.Where(AM => AM.Am == type))
            {
                checkListViewModel.Items.Add(new CheckListItem<AttitudeMethode> { Item = C, Checked = C.CompetenceAnalyseAttitudeMethode.ToList().Exists(CAAM => CAAM.CompetenceAnalyse == id) });
            }
            this.ViewBag.Type = type == "A" ? "attitudes" : "méthodes";
            return PartialView(checkListViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Analyse_CompetenceAttitudeMethode_Update(int idAM, int idCA, bool ajouter)
        {
            string AorM = this._context.AttitudeMethode.Where(AM => AM.Id == idAM).First().Am == "A" ? "attitude" : "méthode";
            if (ajouter)
            {
                this._context.Add(new CompetenceAnalyseAttitudeMethode { CompetenceAnalyse = idCA, AttitudeMethode = idAM });
                await this._context.SaveChangesAsync();
                return Ok(String.Format("Cette {0} a été ajoutée à la compétence avec succès.", AorM));
            }
            else
            {
                this._context.Remove(this._context.CompetenceAnalyseAttitudeMethode.Where(CAAM => CAAM.AttitudeMethode == idAM && CAAM.CompetenceAnalyse == idCA).First());
                await this._context.SaveChangesAsync();
                return Ok(String.Format("Cette {0} a été retirée de la compétence avec succès.",AorM));
            }
        }

        [HttpGet]
        public IActionResult Analyse_AttitudeMethode_Create(string AM, int idCA)
        {
            ViewBag.idCA = idCA;
            return PartialView(new AttitudeMethode { Actualisation = GetActualisation().Id, Am = AM });
        }

        [HttpPost]
        public async Task<IActionResult> Analyse_AttitudeMethode_Create(AttitudeMethode model)
        {
            string AorM = model.Am == "A" ? "attitude" : "méthode";
            if (ModelState.IsValid)
            {
                this._context.Add(model);
                await this._context.SaveChangesAsync();
                return Ok(String.Format("Cette {0} a été ajoutée à l'actualisation avec succès.", AorM));
            }
            return PartialView(model);
        }

        [HttpGet]
        public IActionResult Analyse_AttitudeMethode_Update(int id, int idCA)
        {
            ViewBag.idCA = idCA;
            return PartialView(this._context.AttitudeMethode.Where(AM => AM.Id == id).First());
        }

        [HttpPost]
        public async Task<IActionResult> Analyse_AttitudeMethode_Update(AttitudeMethode model)
        {
            string AorM = model.Am == "A" ? "attitude" : "méthode";
            if (ModelState.IsValid)
            {
                AttitudeMethode amOld = this._context.AttitudeMethode.Where(AM => AM.Id == model.Id).First();
                amOld.Categorie = model.Categorie;
                amOld.Enonce = model.Enonce;
                this._context.Update(amOld);
                await this._context.SaveChangesAsync();
                return Ok(String.Format("Cette {0} a été modifié avec succès.", AorM));
            }
            return PartialView(model);
            
        }

        [HttpPost]
        public async Task<IActionResult> Analyse_AttitudeMethode_Delete(int id)
        {
            AttitudeMethode amOld = this._context.AttitudeMethode.Where(AM => AM.Id == id).Include(AM => AM.CompetenceAnalyseAttitudeMethode).FirstOrDefault();
            if (amOld != null)
            {
                if (amOld.CompetenceAnalyseAttitudeMethode.Count() == 0)
                {
                    this._context.Remove(amOld);
                    await this._context.SaveChangesAsync();
                    return Ok(String.Format("Cette {0} a été supprimée avec succès.", amOld.Am == "A" ? "attitude" : "méthode"));
                }
                return BadRequest(String.Format("Cette {0} ne peut pas être supprimé car elle est utilisée par l'actualisation.", amOld.Am == "A" ? "attitude" : "méthode"));
            }
            return BadRequest(String.Format("Cette {0} n'existe pas ou a déjà été supprimée.", amOld.Am == "A" ? "attitude" : "méthode"));
        }
        #endregion AttitudeMethode

        #endregion Analyse

        #region Famille et séquence
        public IActionResult FamilleSequence()
        {
            return PartialView();
        }

        #region Famille
        public IActionResult Famille()
        {
            return PartialView(this._context.FamilleCompetence.Where(FC => FC.Actualisation == GetActualisation().Id).Include(FC => FC.FamilleCompetenceCompetence).ThenInclude(FCC => FCC.CompetenceNavigation).ToList());
        }

        [HttpGet]
        public IActionResult Famille_Create()
        {
            this.ViewBag.IDActu = GetActualisation().Id;
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> Famille_Create(FamilleCompetence model)
        {
            if (ModelState.IsValid)
            {
                model.Actualisation = GetActualisation().Id;
                this._context.Add(model);
                await this._context.SaveChangesAsync();
                return Ok("Cette famille de compétence a été ajouté avec succès.");
            }
            return PartialView(model);
        }

        [HttpGet]
        public IActionResult Famille_Update(int id)
        {
            return PartialView(this._context.Find(typeof(FamilleCompetence), id) as FamilleCompetence);
        }

        [HttpPost]
        public async Task<IActionResult> Famille_Update(FamilleCompetence model)
        {
            if (ModelState.IsValid)
            {
                FamilleCompetence familleOld = this._context.FamilleCompetence.Where(F => F.Id == model.Id).First();
                familleOld.Nom = model.Nom;
                familleOld.Couleur = model.Couleur;
                this._context.Update(familleOld);
                await this._context.SaveChangesAsync();
                return Ok("Cette famille a été modifiée avec succès.");
            }
            return PartialView(model);
        }

        [HttpPost]
        public async Task<IActionResult> Famille_Delete(int id)
        {
            FamilleCompetence famille = this._context.FamilleCompetence.Where(F => F.Id == id).Include(F => F.FamilleCompetenceCompetence).FirstOrDefault();
            if (famille != null)
            {
                if (famille.FamilleCompetenceCompetence.Count() == 0)
                {
                    this._context.Remove(famille);
                    await this._context.SaveChangesAsync();
                    return Ok("Cette famille a été supprimée avec succès.");
                }
                return BadRequest("Cette famille ne peut pas être supprimée car elle contient des compétences.");
            }
            return BadRequest("Cette famille n'existe pas ou a déjà été supprimée.");
        }

        [HttpGet]
        public IActionResult Famille_Competence(int id)
        {
            CheckListViewModel<Competence, FamilleCompetence> checkListViewModel = new CheckListViewModel<Competence, FamilleCompetence> { Items = new List<CheckListItem<Competence>>(), Parent = this._context.FamilleCompetence.Where(FC => FC.Id == id).First() };
            List<Competence> CompetenceF = this._context.CompetenceAnalyse.Where(CA => CA.Actualisation == GetActualisation().Id).Include(CA => CA.CompetenceNavigation).Select(CA => CA.CompetenceNavigation).Include(C => C.FamilleCompetenceCompetence).ToList();
            foreach (Competence C in CompetenceF)
            {
                checkListViewModel.Items.Add(new CheckListItem<Competence> { Item = C, Checked = C.FamilleCompetenceCompetence.ToList().Exists(FCC => FCC.FamilleCompetence == id) });
            }
            return PartialView(checkListViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Famille_Competence(string idCompetence, int idFamille, bool ajouter)
        {
            if (ajouter)
            {
                this._context.Add(new FamilleCompetenceCompetence { Competence = idCompetence, FamilleCompetence = idFamille });
                await this._context.SaveChangesAsync();
                return Ok("Cette compétence a été ajoutée à la famille avec succès.");
            }
            else
            {
                this._context.Remove(this._context.FamilleCompetenceCompetence.Where(FCC => FCC.Competence == idCompetence && FCC.FamilleCompetence == idFamille).First());
                await this._context.SaveChangesAsync();
                return Ok("Cette compétence a été retirée de la famille avec succès.");
            }
        }
        #endregion Famille

        #region Séquence
        public IActionResult Sequence()
        {
            return PartialView(this._context.SequenceCompetence.Where(FC => FC.Actualisation == GetActualisation().Id).Include(FC => FC.SequenceCompetenceCompetence).ThenInclude(FCC => FCC.CompetenceNavigation).ToList());
        }

        [HttpGet]
        public IActionResult Sequence_Create()
        {
            this.ViewBag.IDActu = GetActualisation().Id;
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> Sequence_Create(SequenceCompetence model)
        {
            if (ModelState.IsValid)
            {
                model.Actualisation = GetActualisation().Id;
                this._context.Add(model);
                await this._context.SaveChangesAsync();
                return Ok("Cette séquence de compétence a été ajouté avec succès.");
            }
            return PartialView(model);
        }

        [HttpGet]
        public IActionResult Sequence_Update(int id)
        {
            return PartialView(this._context.Find(typeof(SequenceCompetence), id) as SequenceCompetence);
        }

        [HttpPost]
        public async Task<IActionResult> Sequence_Update(SequenceCompetence model)
        {
            if (ModelState.IsValid)
            {
                SequenceCompetence sequenceeOld = this._context.SequenceCompetence.Where(F => F.Id == model.Id).First();
                sequenceeOld.Nom = model.Nom;
                this._context.Update(sequenceeOld);
                await this._context.SaveChangesAsync();
                return Ok("Cette séquence a été modifiée avec succès.");
            }
            return PartialView(model);
        }

        [HttpPost]
        public async Task<IActionResult> Sequence_Delete(int id)
        {
            SequenceCompetence sequence = this._context.SequenceCompetence.Where(F => F.Id == id).Include(F => F.SequenceCompetenceCompetence).FirstOrDefault();
            if (sequence != null)
            {
                if (sequence.SequenceCompetenceCompetence.Count() == 0)
                {
                    this._context.Remove(sequence);
                    await this._context.SaveChangesAsync();
                    return Ok("Cette séquence a été supprimée avec succès.");
                }
                return BadRequest("Cette séquence ne peut pas être supprimée car elle contient des compétences.");
            }
            return BadRequest("Cette séquence n'existe pas ou a déjà été supprimée.");
        }

        public async Task<IActionResult> Sequence_Competence_Swap(int idSequence, string idC1, string idC2)
        {
            SequenceCompetenceCompetence comp1 = this._context.SequenceCompetenceCompetence.Where(S => S.SequenceCompetence==idSequence && S.Competence == idC1).First();
            SequenceCompetenceCompetence comp2 = this._context.SequenceCompetenceCompetence.Where(S => S.SequenceCompetence==idSequence && S.Competence == idC2).First();
            int ordreTemp = comp1.Ordre ?? -1;
            comp1.Ordre = comp2.Ordre;
            comp2.Ordre = ordreTemp;
            this._context.Update(comp1);
            this._context.Update(comp2);
            await this._context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public IActionResult Sequence_Competence(int id)
        {
            CheckListViewModel<Competence, SequenceCompetence> checkListViewModel = new CheckListViewModel<Competence, SequenceCompetence> { Items = new List<CheckListItem<Competence>>(), Parent = this._context.SequenceCompetence.Where(FC => FC.Id == id).First() };
            List<Competence> CompetenceF = this._context.CompetenceAnalyse.Where(CA => CA.Actualisation == GetActualisation().Id).Include(CA => CA.CompetenceNavigation).Select(CA => CA.CompetenceNavigation).Include(C => C.SequenceCompetenceCompetence).ToList();
            foreach (Competence C in CompetenceF)
            {
                checkListViewModel.Items.Add(new CheckListItem<Competence> { Item = C, Checked = C.SequenceCompetenceCompetence.ToList().Exists(FCC => FCC.SequenceCompetence == id) });
            }
            return PartialView(checkListViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Sequence_Competence(string idCompetence, int idSequence, bool ajouter)
        {
            if (ajouter)
            {
                SequenceCompetence sequence = this._context.SequenceCompetence.Where(SC => SC.Id == idSequence).Include(SC => SC.SequenceCompetenceCompetence).FirstOrDefault();
                int maxOrdre = sequence != null ?sequence.SequenceCompetenceCompetence.ToList().Max(SCC => SCC.Ordre) ?? 0:0;
                this._context.Add(new SequenceCompetenceCompetence { Competence = idCompetence, SequenceCompetence = idSequence, Ordre =  maxOrdre+1 });

                await this._context.SaveChangesAsync();
                return Ok("Cette compétence a été ajoutée à la séquence avec succès.");
            }
            else
            {
                this._context.Remove(this._context.SequenceCompetenceCompetence.Where(FCC => FCC.Competence == idCompetence && FCC.SequenceCompetence == idSequence).First());
                await this._context.SaveChangesAsync();
                return Ok("Cette compétence a été retirée de la séquence avec succès.");
            }
        }
        #endregion Séquence

        #endregion Famille et séquence

        #region ProfilFormation
        public IActionResult ProfilFormation()
        {
            return PartialView(this._context.ProfilFormation.Where(PF => PF.Actualisation == GetActualisation().Id).Include(PF => PF.CompetenceProfilFormation).ThenInclude(CPF => CPF.CompetenceNavigation).ToList());
        }

        [HttpGet]
        public IActionResult ProfilFormation_Create()
        {
            this.ViewBag.IDActu = GetActualisation().Id;
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> ProfilFormation_Create(ProfilFormation model)
        {
            if (ModelState.IsValid)
            {
                model.Actualisation = GetActualisation().Id;
                this._context.Add(model);
                await this._context.SaveChangesAsync();
                foreach (Competence c in this._context.CompetenceAnalyse.Where(CA => CA.Actualisation == GetActualisation().Id).Include(CA => CA.CompetenceNavigation).Select(CA => CA.CompetenceNavigation).Where(C => C.IsObligatoire ?? true).ToList())
                {
                    model.CompetenceProfilFormation.Add(new CompetenceProfilFormation { Competence = c.Code });
                }
                this._context.Update(model);
                this._context.Add(new InstanceHeureCompetence { DateCreation = DateTime.Now.Date, Actualisation = GetActualisation().Id, IsOfficiel = true, ProfilFormation = model.Id, Nom = model.Nom + " (Officielle)", DateModification = DateTime.Now.Date });
                await this._context.SaveChangesAsync();
                return Ok("Ce profil de formation a été ajouté avec succès.");
            }
            return PartialView(model);
        }

        [HttpGet]
        public IActionResult ProfilFormation_Update(int id)
        {
            return PartialView(this._context.Find(typeof(ProfilFormation), id) as ProfilFormation);
        }

        [HttpPost]
        public async Task<IActionResult> ProfilFormation_Update(ProfilFormation model)
        {
            if (ModelState.IsValid)
            {
                ProfilFormation profilOld = this._context.ProfilFormation.Where(P => P.Id == model.Id).First();
                profilOld.Nom = model.Nom;
                this._context.Update(profilOld);
                await this._context.SaveChangesAsync();
                InstanceHeureCompetence instanceOld = this._context.InstanceHeureCompetence.Where(I => I.ProfilFormation == model.Id).First();
                instanceOld.Nom = model.Nom;
                await this._context.SaveChangesAsync();
                return Ok("Ce profil a été modifié avec succès.");
            }
            return PartialView(model);
        }

        [HttpPost]
        public async Task<IActionResult> ProfilFormation_Delete(int id)
        {
            ProfilFormation profil = this._context.ProfilFormation.Where(P => P.Id == id).Include(P => P.CompetenceProfilFormation).Include(P => P.InstanceHeureCompetence).FirstOrDefault();
            if (profil != null)
            {
                if (profil.CompetenceProfilFormation.Count() != 0)
                {
                    foreach (CompetenceProfilFormation CPF in profil.CompetenceProfilFormation)
                    {
                        this._context.Remove(CPF);
                    }
                }
                await this._context.SaveChangesAsync();
                this._context.Remove(profil);
                await this._context.SaveChangesAsync();
                return Ok("Ce profil a été supprimé avec succès.");
            }
            return BadRequest("Ce profil n'existe pas ou a déjà été supprimé.");
        }

        [HttpGet]
        public IActionResult ProfilFormation_Competence(int id)
        {
            CheckListViewModel<Competence, ProfilFormation> checkListViewModel = new CheckListViewModel<Competence, ProfilFormation> { Items = new List<CheckListItem<Competence>>(), Parent = this._context.ProfilFormation.Where(PF => PF.Id == id).First() };
            List<Competence> CompetencePF = this._context.CompetenceAnalyse.Where(CA => CA.Actualisation == GetActualisation().Id).Include(CA => CA.CompetenceNavigation).Select(CA => CA.CompetenceNavigation).Include(C => C.CompetenceProfilFormation).ToList();
            foreach (Competence C in CompetencePF)
            {
                checkListViewModel.Items.Add(new CheckListItem<Competence> { Item = C, Checked = C.CompetenceProfilFormation.ToList().Exists(CPF => CPF.ProfilFormation == id) });
            }
            return PartialView(checkListViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ProfilFormation_Competence(string idCompetence, int idProfil, bool ajouter)
        {
            if (ajouter)
            {
                this._context.Add(new CompetenceProfilFormation { Competence = idCompetence, ProfilFormation = idProfil });
                await this._context.SaveChangesAsync();
                return Ok("Cette compétence a été ajoutée au profil avec succès.");
            }
            else
            {
                CompetenceProfilFormation competenceProfilFormation = this._context.CompetenceProfilFormation.Where(CPF => CPF.Competence == idCompetence && CPF.ProfilFormation == idProfil).Include(P => P.CompetenceNavigation).First();
                if(!competenceProfilFormation.CompetenceNavigation.IsObligatoire ?? true)
                {
                     this._context.Remove(competenceProfilFormation);
                    await this._context.SaveChangesAsync();
                    return Ok("Cette compétence a été retirée du profil avec succès.");
                }
                return BadRequest("Vous ne pouvez pas retirer une compétence obligatoire du profil.");
            }
        }

        #endregion ProfilFormation

        #region RepartitionHeure
        [HttpGet]
        public IActionResult RepartitionHeure()
        {
            return PartialView(this._context.ProfilFormation.Where(PF => PF.Actualisation == GetActualisation().Id).ToList());
        }

        [HttpGet]
        public IActionResult RepartitionHeure_Instances(int id)
        {
            SelectList selectListItems = new SelectList(this._context.ProfilFormation.Where(PF => PF.Id == id).Include(PF => PF.InstanceHeureCompetence).First().InstanceHeureCompetence.ToList(), "Id", "Nom");
            this.ViewBag.Profil = id;
            return PartialView(selectListItems);
        }

        [HttpGet]
        public IActionResult RepartitionHeure_Instance(int id)
        {
            this.ViewBag.HeureMin = this._context.Gabarit.Where(G => G.Actualisation == GetActualisation().Id && G.TypeGabarit == 2).Include(G => G.PointGabarit).First().PointGabarit.Where(PG => PG.Enonce == "Nombre total minimal d'heures").First().Contenu;
            this.ViewBag.HeureMax = this._context.Gabarit.Where(G => G.Actualisation == GetActualisation().Id && G.TypeGabarit == 2).Include(G => G.PointGabarit).First().PointGabarit.Where(PG => PG.Enonce == "Nombre total maximal d'heures").First().Contenu;
            return PartialView(this._context.InstanceHeureCompetence.Where(IHC => IHC.Id == id).Include(IHC =>IHC.ProfilFormationNavigation).ThenInclude(PF => PF.CompetenceProfilFormation).ThenInclude(CPF => CPF.CompetenceNavigation).Include(IHC => IHC.HeureComp).First());
        }

        [HttpPost]
        public async Task<IActionResult> RepartitionHeure(HeureComp model, bool? nouveau)
        {
            switch (nouveau ?? false)
            {
                case true:
                    this._context.Add(model);
                    await this._context.SaveChangesAsync();
                    return Ok();
                case false:
                    HeureComp heurecompOld = this._context.HeureComp.Where(HC => HC.InstanceHeureCompetence == model.InstanceHeureCompetence && HC.NoSession == model.NoSession && HC.Competence == model.Competence).First();
                    if (model.NbHeure != null)
                    {
                        heurecompOld.NbHeure = model.NbHeure;
                        this._context.Update(heurecompOld);
                    }
                    else
                    {
                        this._context.Remove(heurecompOld);
                    }
                    await this._context.SaveChangesAsync();
                    return Ok();
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> RepartitionHeure_Instance_Create(int id)
        {
            string compteur = String.Format(" ({0})",this._context.InstanceHeureCompetence.ToList().Where(I => I.Actualisation == GetActualisation().Id && I.Utilisateur == User.Claims.Where(C => C.Type == ClaimTypes.Email).First().Value).Count());
            this._context.Add(new InstanceHeureCompetence { Actualisation = GetActualisation().Id, DateCreation = DateTime.Now.Date, DateModification = DateTime.Now.Date, IsOfficiel = false, ProfilFormation = id, Utilisateur = User.Claims.Where(C => C.Type == ClaimTypes.Email).First().Value, Nom = this._context.ProfilFormation.Where(PF => PF.Id == id).First().Nom + " - " + User.Identity.Name + (compteur != " (0)" ? compteur:"") });
            await this._context.SaveChangesAsync();
            return Ok("Votre instance de répartiton des heures a été créée.");
        }

        [HttpPost]
        public async Task<IActionResult> RepartitionHeure_Instance_Delete(int id)
        {
            InstanceHeureCompetence instance = this._context.InstanceHeureCompetence.Where(I => I.Id == id).First();
            if (!instance.IsOfficiel ?? true)
            {
                if (instance.Utilisateur == User.Claims.Where(C => C.Type == ClaimTypes.Email).First().Value)
                {
                    this._context.Remove(instance);
                    await this._context.SaveChangesAsync();
                    return Ok("Votre instance a été supprimée avec succès.");
                }
                return BadRequest("Vous ne pouvez pas supprimer l'instance d'une autre personne.");
            }
            return BadRequest("L'instance oficielle ne peut pas être supprimée.");
        }
        #endregion RepartitionHeure

        #region Groupe
        public IActionResult GroupeCompetence()
        {
            return PartialView(this._context.ProfilFormation.Where(PF => PF.Actualisation == GetActualisation().Id).ToList());
        }

        [HttpGet]
        public IActionResult GroupeCompetence_Profil(int id)
        {
            InstanceHeureCompetence instanceHeureCompetence = this._context.InstanceHeureCompetence.Where(I => I.ProfilFormation == id && I.IsOfficiel == true).Include(IHC => IHC.GroupeCompetence).Include(IHC => IHC.ProfilFormationNavigation).ThenInclude(PF => PF.CompetenceProfilFormation).ThenInclude(CPF => CPF.CompetenceNavigation).Include(IHC => IHC.HeureComp).ThenInclude(HC => HC.GroupeCompetenceNavigation).First();
            SelectList selectListItems = new SelectList(instanceHeureCompetence.GroupeCompetence, "Id", "Nom");
            this.ViewBag.Profil = id;
            return PartialView(new GroupeViewModel { selectList = selectListItems, instance = instanceHeureCompetence } );
        }

        [HttpPost]
        public async Task<IActionResult> GroupeCompetence_Profil(HeureComp model)
        {
            HeureComp heurecompOld = this._context.HeureComp.Where(HC => HC.InstanceHeureCompetence == model.InstanceHeureCompetence && HC.NoSession == model.NoSession && HC.Competence == model.Competence).First();
            heurecompOld.GroupeCompetence = model.GroupeCompetence;
            this._context.Update(heurecompOld);
            await this._context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public IActionResult GroupeCompetence_Create(int idInstance, int idProfil)
        {
            this.ViewBag.Profil = idProfil;
            return PartialView(new GroupeCompetence { InstanceHeureCompetence = idInstance });
        }

        [HttpPost]
        public async Task<IActionResult> GroupeCompetence_Create(GroupeCompetence model)
        {
            if (ModelState.IsValid)
            {
                this._context.Add(model);
                await this._context.SaveChangesAsync();
                return Ok("Le groupe de compétences a été ajouté avec succès.");
            }
            return PartialView(model);
        }

        [HttpGet]
        public IActionResult GroupeCompetence_Update(int idGroupe, int idProfil)
        {
            this.ViewBag.Profil = idProfil;
            return PartialView(this._context.GroupeCompetence.Where(GC => GC.Id == idGroupe).First());
        }

        [HttpPost]
        public async Task<IActionResult> GroupeCompetence_Update(GroupeCompetence model)
        {
            if (ModelState.IsValid)
            {
                GroupeCompetence groupeOld = this._context.GroupeCompetence.Where(GC => GC.Id == model.Id).First();
                groupeOld.Nom = model.Nom;
                groupeOld.Couleur = model.Couleur;
                this._context.Update(groupeOld);
                await this._context.SaveChangesAsync();
                return Ok("Ce groupe de compétences a été modifiée avec succès.");
            }
            return PartialView(model);
        }

        [HttpPost]
        public async Task<IActionResult> GroupeCompetence_Delete(int id)
        {
            GroupeCompetence groupe = this._context.GroupeCompetence.Where(GC => GC.Id == id).Include(GC => GC.HeureComp).FirstOrDefault();
            if (groupe != null)
            {
                if(groupe.HeureComp.Count != 0)
                {
                  foreach(HeureComp HC in groupe.HeureComp)
                    {
                        HC.GroupeCompetence = null;
                        this._context.Update(HC);
                    }
                    await this._context.SaveChangesAsync();
                }
                this._context.Remove(groupe);
                await this._context.SaveChangesAsync();
                return Ok("Ce groupe de compétences a été supprimée avec succès.");
            }
            return BadRequest("Ce groupe de compétences n'existe pas ou a déjà été retiré.");
        }
        #endregion Groupe

        #region Ebauche
        public IActionResult Ebauche()
        {
            return PartialView(GetActualisation());
        }
        [HttpPost]
        public async Task<IActionResult> Ebauche_Update(Actualisation actualisation)
        {
            Actualisation actualisationOld = GetActualisation();
            actualisationOld.EbauchePs = actualisation.EbauchePs ?? "";
            actualisationOld.EbaucheEsp = actualisation.EbaucheEsp ?? "";
            this._context.Update(actualisationOld);
            await this._context.SaveChangesAsync();
            return Ok();
        }
        #endregion Ebauche

        private Actualisation GetActualisation()
        {
            return this._context.Find(typeof(Actualisation), Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "IDActu").Value)) as Actualisation;
        }
    }
}