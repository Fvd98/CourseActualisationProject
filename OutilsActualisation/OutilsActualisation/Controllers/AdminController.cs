using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using OutilsActualisation.AppData;
using OutilsActualisation.Autorisation;
using OutilsActualisation.Models;
using Microsoft.Exchange.WebServices.Autodiscover;
using Microsoft.Exchange.WebServices.Data;
using System.Net.Mail;
using System.Security.Claims;

namespace OutilsActualisation.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private OutilActualisationContext _context;
        public AdminController(OutilActualisationContext context)
        {
            this._context = context;
        }

        #region Gabarits
        public IActionResult Gabarit()
        {         
            return View(new GabaritsViewModel { gabarits = this._context.Gabarit.Include(G => G.GabaritParentNavigation).Where(G => G.GabaritParentNavigation == null && G.TypeGabarit != 2).Include(G => G.TypeGabaritNavigation).Include(G => G.InverseGabaritParentNavigation).ToList(), typeGabarit = this._context.TypeGabarit.Where(TG => TG.Id != 2).ToList() });
        }

        [HttpGet]
        public IActionResult Gabarit_Create(int TypeID)
        {
            ViewBag.Type = TypeID;
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> Gabarit_Create(Gabarit model)
        {
            if(ModelState.IsValid)
            {
                Gabarit gabaritDefault = this._context.Gabarit.FirstOrDefault(G => G.IsDefault == true && G.TypeGabarit == model.TypeGabarit);
                if ((model.IsDefault ?? false) && gabaritDefault != null)
                {
                    gabaritDefault.IsDefault = false;
                    this._context.Update(gabaritDefault);
                    await this._context.SaveChangesAsync();
                }
                model.DateCreation = DateTime.Now.Date;
                this._context.Add(model);
                await this._context.SaveChangesAsync();
                return Ok("Ce gabarit a été ajouté avec succès.");
            }
            return PartialView(model);
        }

        [HttpGet]
        public IActionResult Gabarit_Update(int id)
        {
            return PartialView(this._context.Find(typeof(Gabarit), id) as Gabarit);
        }

        [HttpPost]
        public async Task<IActionResult> Gabarit_Update(Gabarit model)
        {
            if (ModelState.IsValid)
            {
                Gabarit gabaritDefault = this._context.Gabarit.FirstOrDefault(G => G.IsDefault == true && G.TypeGabarit == model.TypeGabarit);
                if (gabaritDefault != null && (model.IsDefault ?? false))
                {
                    gabaritDefault.IsDefault = false;
                    this._context.Update(gabaritDefault);
                    await this._context.SaveChangesAsync();
                }
                Gabarit gabaritOld = this._context.Find(typeof(Gabarit), model.Id) as Gabarit;
                gabaritOld.IsDefault = model.IsDefault;
                gabaritOld.Nom = model.Nom;
                this._context.Update(gabaritOld);
                await this._context.SaveChangesAsync();
                return Ok("Ce gabarit a été modifié avec succès.");
            }
            return PartialView(model);
        }

        [HttpPost]
        public async Task<IActionResult> Gabarit_Delete(int id)
        {
            Gabarit gabarit = this._context.Gabarit.Where(G => G.Id == id).Include(G => G.InverseGabaritParentNavigation).FirstOrDefault();
            if (gabarit != null)
            {
                if (gabarit.InverseGabaritParentNavigation.Count() == 0 && gabarit.GabaritParent == null)
                {
                    this._context.Remove(gabarit);
                    await this._context.SaveChangesAsync();
                    return Ok("Ce gabarit a été supprimé avec succès.");
                }
                return BadRequest("Ce gabarit ne peut pas être supprimé car il est utilisé par une actualisation.");
            }
            return BadRequest("Ce gabarit n'existe pas ou a déjà été supprimé.");
        }

        public IActionResult PointGabarit(int id)
        {
            HttpContext.Session.SetString("idGab", id.ToString());
            ViewBag.GabId = id;
            Gabarit gabarit = this._context.Gabarit.Where(G => G.Id == id).Include(G => G.PointGabarit).ThenInclude(G => G.InverseParentPointGabaritNavigation).Include(G => G.InverseGabaritParentNavigation).First();
            List<PointGabarit> PGs = gabarit.PointGabarit.ToList();
            PGs.RemoveAll(PG => PG.ParentPointGabarit != null);
            gabarit.PointGabarit = PGs;
            return PartialView(gabarit);
        }

        [HttpGet]
        public IActionResult PointGabarit_Create(int? id)
        {
            if (this._context.Gabarit.Where(G => G.Id == Convert.ToInt32(this.HttpContext.Session.GetString("idGab"))).Include(G => G.InverseGabaritParentNavigation).First().InverseGabaritParentNavigation.Count() == 0)
            {
                ViewBag.GabID = Convert.ToInt32(this.HttpContext.Session.GetString("idGab"));
                return PartialView(new PointGabarit { ParentPointGabarit = id });
            }
            return BadRequest("Ce gabarit ne peut pas avoir de nouveaux points car il est utlisé par une actualisation.");
        }

        [HttpPost]
        public async Task<IActionResult> PointGabarit_Create(PointGabarit model)
        {
            if (ModelState.IsValid)
            {
                model.Contenu = "";
                this._context.Add(model);
                await this._context.SaveChangesAsync();
                return Ok("Ce point de gabarit a été ajouté avec succès.");
            }
            return PartialView(model);
        }

        [HttpGet]
        public IActionResult PointGabarit_Update(int id)
        {
            PointGabarit pointGabaritOld = this._context.PointGabarit.Where(PG => PG.Id == id).Include(PG => PG.GabaritNavigation).ThenInclude(G => G.InverseGabaritParentNavigation).First();
            if (pointGabaritOld.GabaritNavigation.InverseGabaritParentNavigation.Count() == 0)
            {
                return PartialView(pointGabaritOld);
            }
            return BadRequest("Ce point de gabarit ne peut pas être modifié car il est utlisé par une actualisation.");
        }

        [HttpPost]
        public async Task<IActionResult> PointGabarit_Update(PointGabarit model)
        {
            if (ModelState.IsValid)
            {
                PointGabarit pointGabaritOld = this._context.PointGabarit.Where(PG => PG.Id == model.Id).Include(PG => PG.GabaritNavigation).First();
                if (pointGabaritOld.GabaritNavigation.GabaritParent == null)
                {
                    pointGabaritOld.Enonce = model.Enonce;
                    pointGabaritOld.Ordre = model.Ordre;
                    this._context.Update(pointGabaritOld);
                    await this._context.SaveChangesAsync();
                    return Ok("Ce point de gabarit a été modifié avec succès.");
                }
                return BadRequest("Ce point de gabarit ne peut pas être modifié car il est utilisé par une actualisation."); 
            }
            return PartialView(model);
        }

        [HttpPost]
        public async Task<IActionResult> PointGabarit_Delete(int id)
        {
            PointGabarit pointGabarit = this._context.PointGabarit.Where(PG => PG.Id == id).Include(PG => PG.InverseParentPointGabaritNavigation).Include(PG => PG.GabaritNavigation).ThenInclude(G => G.InverseGabaritParentNavigation).FirstOrDefault();
            if (pointGabarit != null)
            {
                if (pointGabarit.GabaritNavigation.GabaritParent == null)
                {
                    if (pointGabarit.GabaritNavigation.InverseGabaritParentNavigation.Count() == 0)
                    {
                        if (pointGabarit.InverseParentPointGabaritNavigation.Count != 0)
                        {
                            foreach (PointGabarit PEnfant in pointGabarit.InverseParentPointGabaritNavigation)
                            {
                                this._context.Remove(PEnfant);
                            }
                        }
                        this._context.Remove(pointGabarit);
                        await this._context.SaveChangesAsync();
                        return Ok("Ce point de gabarit a été supprimé avec succès.");
                    }
                    return BadRequest("Ce point de gabarit ne peut pas être supprimé car il est utilisé par une actualisation.");
                }
                return BadRequest("Ce point de gabarit ne peut pas être supprimé.");
            }
            return BadRequest("Ce point de gabarit n'existe pas ou a déjà été supprimé."); 
        }

        #endregion Gabarits

        #region Utilisateurs
        [HttpGet]
        public IActionResult Utilisateur()
        {
            return View(this._context.Utilisateur.ToList());
        }

        [HttpGet]
        public IActionResult Utilisateur_Create()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> Utilisateur_Create(Utilisateur model)
        {
            model.IsActive = false;
            if (ModelState.IsValid)
            {
                if (this._context.Utilisateur.ToList().Exists(U => U.Courriel == model.Courriel))
                {
                    return BadRequest("Cet utilisateur existe déjà. Veuillez entrer un courriel différent.");
                }
                model.MotDePasse = GenerateMDP();

                try
                {
                    ExchangeService myservice = new ExchangeService(ExchangeVersion.Exchange2010_SP1);
                    myservice.Credentials = new WebCredentials("Projet_SRDP@cegepoutaouais.qc.ca", "Le$Etudiant$Projet");
                    string serviceUrl = "https://outlook.office365.com/ews/exchange.asmx";
                    myservice.Url = new Uri(serviceUrl);
                    EmailMessage emailMessage = new EmailMessage(myservice);
                    emailMessage.Subject = "Invitation à l'outil d'actualisation de programmes";
                    emailMessage.Body = new MessageBody(String.Format("Un compte a été créé à votre nom pour l'outil d'actualisation de programmes du Cégep de l'Outaouais.<br/><br/>Voici vos informations de connexion:<br/><br/>Courriel: <strong>{0}</strong><br/>Mot de passe temporaire: <strong>{1}</strong>", model.Courriel, model.MotDePasse));
                    emailMessage.ToRecipients.Add(model.Courriel);
                    emailMessage.Send();
                }
                catch (Exception ex)
                {
                    return BadRequest(String.Format("Échec lors de l'envoi du courriel: {0}", ex.Message));
                }
                model.Salt = Salt_Hasher.GetSalt();
                model.MotDePasse = Salt_Hasher.GetHash(model.MotDePasse + model.Salt);
                this._context.Add(model);
                await this._context.SaveChangesAsync();
                return Ok("Le courriel a été envoyé avec succès.");
            }
            return PartialView(model);
        }

        [HttpGet]
        public IActionResult Utilisateur_Update(string id)
        {
            return PartialView(this._context.Find(typeof(Utilisateur), id) as Utilisateur);
        }

        [HttpPost]
        public async Task<IActionResult> Utilisateur_Update(Utilisateur model)
        {
            if (ModelState.IsValid)
            {
                Utilisateur utilisateurOld = this._context.Find(typeof(Utilisateur), model.Courriel) as Utilisateur;
                utilisateurOld.IsActive = model.IsActive;
                utilisateurOld.IsAdmin = model.IsAdmin;
                utilisateurOld.Nom = model.Nom;
                utilisateurOld.Prenom = model.Prenom;
                utilisateurOld.Titre = model.Titre;
                this._context.Update(utilisateurOld);
                await this._context.SaveChangesAsync();
                return Ok("Cet utilisateur a été modifié avec succès.");
            }
            return PartialView(model);
        }

        [HttpGet]
        public IActionResult Utilisateur_ChangerMDP(string id)
        {
            string Salt = Salt_Hasher.GetSalt();
            HttpContext.Session.SetString("TempSalt", Salt);
            return PartialView(new ChangerMDPViewModel { Salt = Salt, Courriel = id });
        }

        [HttpPost]
        public async Task<IActionResult> Utilisateur_ChangerMDP(ChangerMDPViewModel model)
        {
            if (ModelState.IsValid)
            {
                Utilisateur OldUser = this._context.Utilisateur.Where(U => U.Courriel == model.Courriel).FirstOrDefault();
                if (OldUser != null)
                {
                    OldUser.Salt = HttpContext.Session.GetString("TempSalt");
                    OldUser.MotDePasse = model.Hash;
                    this._context.Update(OldUser);
                    await this._context.SaveChangesAsync();
                    return RedirectToAction(nameof(Utilisateur));
                }
                return BadRequest();
            }
            return PartialView(model);
        }

        [HttpPost]
        public async Task<IActionResult> Utilisateur_Delete(string id)
        {
            Utilisateur utilisateur = this._context.Utilisateur.Where(U => U.Courriel == id).FirstOrDefault();
            if (utilisateur != null)
            {
                if (utilisateur.Courriel != User.Claims.Where(C => C.Type == ClaimTypes.Email).First().Value)
                {
                    this._context.Remove(utilisateur);
                    await this._context.SaveChangesAsync();
                    return Ok("Cet utilisateur et ses commentaires ont été supprimés avec succès.");
                }
                return BadRequest("Vous ne pouvez pas vous supprimer...");
            }
            return BadRequest("Cet utilisateur n'existe pas ou a déjà été supprimé.");
        }
        #endregion Utilisateurs

        #region Taxonomies
        public IActionResult Taxonomie()
        {
            List<ModeleTaxonomique> liste = this._context.ModeleTaxonomique.Include(MT => MT.NiveauTaxonomique).ToList();
            return View(liste);
        }

        [HttpGet]
        public IActionResult Taxonomie_Create()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> Taxonomie_Create(ModeleTaxonomique model)
        {
            if (ModelState.IsValid)
            {
                model.DateCreation = DateTime.Now.Date;
                this._context.Add(model);
                await this._context.SaveChangesAsync();
                return Ok("Ce modèle taxonomique a été ajouté avec succès.");
            }
            return PartialView(model);
        }

        [HttpGet]
        public IActionResult Taxonomie_Update(string id)
        {
            return PartialView(this._context.Find(typeof(ModeleTaxonomique), id) as ModeleTaxonomique);
        }

        [HttpPost]
        public async Task<IActionResult> Taxonomie_Update(ModeleTaxonomique model)
        {
            if (ModelState.IsValid)
            {
                ModeleTaxonomique modeleOld = this._context.Find(typeof(ModeleTaxonomique), model.Nom) as ModeleTaxonomique;
                modeleOld.IsAvailable = model.IsAvailable;
                this._context.Update(modeleOld);
                await this._context.SaveChangesAsync();
                return Ok("Ce modèle taxonomique a été modifié avec succès.");
            }
            return PartialView(model);
        }

        [HttpPost]
        public async Task<IActionResult> Taxonomie_Delete(string id)
        {
            ModeleTaxonomique modele = this._context.ModeleTaxonomique.Where(MT => MT.Nom == id).Include(MT => MT.Actualisation).FirstOrDefault();
            if (modele != null)
            {
                if (modele.Actualisation.Count() == 0)
                {
                    this._context.Remove(modele);
                    await this._context.SaveChangesAsync();
                    return Ok("Ce modèle taxonomique a été supprimé avec succès.");
                }
                return BadRequest("Ce modèle taxonomique ne peut pas être supprimé car il est utilisé par une actualisation.");
            }
            return BadRequest("Ce modèle taxonomique n'existe pas ou a déjà été supprimé.");
        }

        public IActionResult NiveauTaxonomique(string id)
        {     
            this.HttpContext.Session.SetString("ModID", id);
            ViewBag.ModID = id;
            return PartialView(this._context.ModeleTaxonomique.Where(MT => MT.Nom == id).Include(MT => MT.NiveauTaxonomique).First());
        }

        [HttpGet]
        public IActionResult NiveauTaxonomique_Create()
        {
            this.ViewBag.ModID = this.HttpContext.Session.GetString("ModID");
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> NiveauTaxonomique_Create(NiveauTaxonomique model)
        {
            if (ModelState.IsValid)
            {
                model.ModeleTaxonomique = this.HttpContext.Session.GetString("ModID");
                this._context.Add(model);
                await this._context.SaveChangesAsync();
                return Ok("Ce niveau taxonomique a été ajouté avec succès.");
            }
            return PartialView(model);
        }

        [HttpGet]
        public IActionResult NiveauTaxonomique_Update(int id)
        {
            NiveauTaxonomique niveauTaxonomiqueOld = this._context.NiveauTaxonomique.Where(NT => NT.Id == id).Include(NT => NT.ModeleTaxonomiqueNavigation).ThenInclude(MT => MT.Actualisation).First();
            if (niveauTaxonomiqueOld.ModeleTaxonomiqueNavigation.Actualisation.Count() == 0)
            {
                return PartialView(niveauTaxonomiqueOld);
            }
            return BadRequest("Ce niveau taxonomique est présentement utilisé par une actualisation et ne peut donc pas être modifié.");
        }

        [HttpPost]
        public async Task<IActionResult> NiveauTaxonomique_Update(NiveauTaxonomique model)
        {
            if (ModelState.IsValid)
            {
                NiveauTaxonomique niveauTaxonomiqueOld = this._context.NiveauTaxonomique.Where(NT => NT.Id == model.Id).Include(NT => NT.ModeleTaxonomiqueNavigation).ThenInclude(MT => MT.Actualisation).First();
                if (niveauTaxonomiqueOld.ModeleTaxonomiqueNavigation.Actualisation.Count() == 0)
                {
                    niveauTaxonomiqueOld.Ordre = model.Ordre;
                    niveauTaxonomiqueOld.Terme = model.Terme;
                    this._context.Update(niveauTaxonomiqueOld);
                    await this._context.SaveChangesAsync();
                    return Ok("Ce niveau taxonomique a été modifié avec succès.");
                }
                return BadRequest();
            }
            return PartialView(model);
        }

        [HttpPost]
        public async Task<IActionResult> NiveauTaxonomique_Delete(int id)
        {
            NiveauTaxonomique niveauTaxonomique = this._context.NiveauTaxonomique.Where(NT => NT.Id == id).Include(NT => NT.ModeleTaxonomiqueNavigation).ThenInclude(MT => MT.Actualisation).FirstOrDefault();
            if (niveauTaxonomique != null)
            {
                if (niveauTaxonomique.ModeleTaxonomiqueNavigation.Actualisation.Count() == 0)
                {
                    this._context.Remove(niveauTaxonomique);
                    await this._context.SaveChangesAsync();
                    return Ok("Ce niveau taxonomique a été supprimé avec succès.");
                }
                return BadRequest("Ce niveau taxonomique ne peut pas être supprimé car il est utilisé par une actualisation.");
            }
            return BadRequest("Ce niveau taxonomique n'existe pas ou a déjà été supprimé.");
        }
        #endregion Taxonomies

        #region FormationsGenerales

            #region FormationsGenerales
        [HttpGet]
        public IActionResult FormationGenerale_Liste()
        {
            return View(this._context.Actualisation.Where(A => A.FormationGenerale == null).ToList());
        }

        [HttpGet]
        public IActionResult FormationGenerale_Create()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> FormationGenerale_Create(Actualisation model)
        {
            if (ModelState.IsValid)
            {
                model.DateCreation = DateTime.Now.Date;
                this._context.Add(model);
                await this._context.SaveChangesAsync();
                return Ok("Cette formation générale a été ajoutée avec succès.");
            }
            return PartialView(model);
        }

        [HttpPost]
        public async Task<IActionResult> FormationGenerale_Delete(int id)
        {
            Actualisation actualisation = this._context.Actualisation.Where(A => A.Id == id).Include(A => A.InverseFormationGeneraleNavigation).FirstOrDefault();
            if (actualisation != null)
            {
                if (actualisation.InverseFormationGeneraleNavigation.Count() == 0)
                {
                    this._context.Remove(actualisation);
                    await this._context.SaveChangesAsync();
                    return Ok("Cette formation générale a été supprimée avec succès.");
                }
                return BadRequest("Cette formation générale ne peut pas être supprimée car elle est utilisée par une actualisation.");
            }
            return BadRequest("Cette formation générale n'existe pas ou a déjà été supprimée.");
        }

        [HttpGet]
        public IActionResult FormationGenerale(int id)
        {
            this.HttpContext.Session.SetString("idFG", id.ToString());
            return View(this._context.Find(typeof(Actualisation), id) as Actualisation);
        }
        #endregion FormationGenerale

            #region Competences
        [HttpGet]
        public IActionResult FormationGenerale_Competence()
        {
            return PartialView(this._context.CompetenceAnalyse.Where(CA => CA.Actualisation == Convert.ToInt32(this.HttpContext.Session.GetString("idFG"))).Include(CA => CA.CompetenceNavigation).ToList());
        }

        [HttpGet]
        public IActionResult FormationGenerale_Competence_Create()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> FormationGenerale_Competence_Create(Competence model)
        {
            if (ModelState.IsValid)
            {
                if (this._context.Competence.Where(C => C.Code == model.Code).FirstOrDefault() == null)
                {
                    model.IsObligatoire = true;
                    model.ContextesRealisation = "";
                    this._context.Add(model);
                    await this._context.SaveChangesAsync();
                    this._context.Add(new CompetenceAnalyse { Competence = model.Code, Actualisation = Convert.ToInt32(this.HttpContext.Session.GetString("idFG")), Reformulation = "", Contexte = "" });
                    await this._context.SaveChangesAsync();
                    return Ok("Cette compétence a été ajoutée avec succès.");
                }
                ModelState.AddModelError("Code", "Cette compétence existe déjà. Veuillez entrer un code différent.");
                return PartialView(model); 
            }
            return PartialView(model);
        }

        [HttpGet]
        public IActionResult FormationGenerale_Competence_Update(string id)
        {
            return PartialView(this._context.Find(typeof(Competence), id) as Competence);
        }

        [HttpPost]
        public async Task<IActionResult> FormationGenerale_Competence_Update(Competence model)
        {
            if (ModelState.IsValid)
            {
                Competence competenceOld = this._context.Competence.Where(C => C.Code == model.Code).First();
                competenceOld.Enonce = model.Enonce;
                this._context.Update(competenceOld);
                await this._context.SaveChangesAsync();
                return Ok("Cette compétence a été modifiée avec succès.");
            }
            return PartialView(model);   
        }

        [HttpPost]
        public async Task<IActionResult> FormationGenerale_Competence_Delete(string id)
        {
            Competence competence = this._context.Competence.Where(C => C.Code == id).Include(C => C.CoursCompetence).FirstOrDefault();
            if (competence != null)
            {
                if (competence.CoursCompetence.Count() == 0)
                {
                    this._context.Remove(competence);
                    await this._context.SaveChangesAsync();
                    return Ok("Cette compétence a été supprimée avec succès.");
                }
                return BadRequest("Cette compétence ne peut pas être supprimée car elle est utilisée par un cours de la formation générale.");
            }
            return BadRequest("Cette compétence n'existe pas ou a déjà été supprimé.");
        }

        #endregion Competences

            #region Cours
        [HttpGet]
        public IActionResult FormationGenerale_Cours()
        {
            return PartialView(this._context.Cours.Where(C => C.Actualisation == Convert.ToInt32(this.HttpContext.Session.GetString("idFG"))).Include(C => C.CoursCompetence).ThenInclude(CC => CC.CompetenceNavigation).ToList());
        }

        [HttpGet]
        public IActionResult FormationGenerale_Cours_Create()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> FormationGenerale_Cours_Create(Cours model)
        {
            model.IsGeneral = true;
            model.IsOld = false;
            model.Actualisation = Convert.ToInt32(this.HttpContext.Session.GetString("idFG"));
            if (ModelState.IsValid)
            {
                this._context.Add(model);
                await this._context.SaveChangesAsync();
                return Ok("Ce cours a été ajouté avec succès.");
            }
            return PartialView(model);
        }

        [HttpGet]
        public IActionResult FormationGenerale_Cours_Update(int id)
        {
            return PartialView(this._context.Find(typeof(Cours), id) as Cours);
        }

        [HttpPost]
        public async Task<IActionResult> FormationGenerale_Cours_Update(Cours model)
        {
            if (ModelState.IsValid)
            {
                Cours coursOld = this._context.Cours.Where(C => C.Id == model.Id).First();
                coursOld.Titre = model.Titre;
                coursOld.PondL = model.PondL;
                coursOld.PondP = model.PondP;
                coursOld.PondT = model.PondT;
                this._context.Update(coursOld);
                await this._context.SaveChangesAsync();
                return Ok("Ce cours a été modifié avec succès.");
            }
            return PartialView(model); 
        }

        [HttpPost]
        public async Task<IActionResult> FormationGenerale_Cours_Delete(int id)
        {
            Cours cours = this._context.Cours.Where(C => C.Id == id).Include(C => C.ChoixCoursCours).FirstOrDefault();
            if (cours != null)
            {
                if (cours.ChoixCoursCours.Count() == 0)
                {
                    this._context.Remove(cours);
                    await this._context.SaveChangesAsync();
                    return Ok("Ce cours a été supprimé avec succès.");
                }
                return BadRequest("Ce cours ne peut pas être supprimé car il est utilisé par un choix de cours de la formation générale.");
            }
            return BadRequest("Ce cours n'existe pas ou a déjà été supprimé.");
        }

        [HttpGet]
        public IActionResult FormationGenerale_Cours_Competence(int id)
        {
            CheckListViewModel<Competence, Cours> checkListViewModel = new CheckListViewModel<Competence, Cours> { Items = new List<CheckListItem<Competence>>(), Parent = this._context.Cours.Where(C => C.Id == id).First() };
            List<Competence> CompetenceFG = this._context.CompetenceAnalyse.Where(CA => CA.Actualisation == Convert.ToInt32(this.HttpContext.Session.GetString("idFG"))).Include(CA => CA.CompetenceNavigation).Select(CA => CA.CompetenceNavigation).Include(C => C.CoursCompetence).ToList();
            foreach (Competence C in CompetenceFG)
            {
                checkListViewModel.Items.Add(new CheckListItem<Competence> { Item = C, Checked = C.CoursCompetence.ToList().Exists(CC => CC.Cours == id) });
            }
            return PartialView(checkListViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> FormationGenerale_Cours_Competence(string idCompetence, int idCours, bool ajouter)
        {
            if (ajouter)
            {
                this._context.Add(new CoursCompetence { Competence = idCompetence, Cours = idCours });
                await this._context.SaveChangesAsync();
                return Ok("Cette compétence a été ajoutée au cours avec succès.");
            }
            else
            {
                this._context.Remove(this._context.CoursCompetence.Where(CC => CC.Competence == idCompetence && CC.Cours == idCours).First());
                await this._context.SaveChangesAsync();
                return Ok("Cette compétence a été retirée du cours avec succès.");
            }
        }
        #endregion Cours

            #region ChoixCours
        [HttpGet]
        public IActionResult FormationGenerale_ChoixCours()
        {
            return PartialView(this._context.ChoixCours.Where(C => C.Actualisation == Convert.ToInt32(this.HttpContext.Session.GetString("idFG"))).Include(CC => CC.ChoixCoursCours).ThenInclude(CCC => CCC.CoursNavigation).ToList());
        }

        [HttpGet]
        public IActionResult FormationGenerale_ChoixCours_Create()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> FormationGenerale_ChoixCours_Create(ChoixCours model)
        {
            model.NbAchoisir = 1;
            model.Actualisation = Convert.ToInt32(this.HttpContext.Session.GetString("idFG"));
            if (ModelState.IsValid)
            {
                this._context.Add(model);
                await this._context.SaveChangesAsync();
                return Ok("Ce choix de cours a été ajouté avec succès.");
            }
            return PartialView(model);
        }

        [HttpGet]
        public IActionResult FormationGenerale_ChoixCours_Update(int id)
        {
            return PartialView(this._context.Find(typeof(ChoixCours), id) as ChoixCours);
        }

        [HttpPost]
        public async Task<IActionResult> FormationGenerale_ChoixCours_Update(ChoixCours model)
        {
            if (ModelState.IsValid)
            {
                ChoixCours choixcoursOld = this._context.ChoixCours.Where(CC => CC.Id == model.Id).First();
                choixcoursOld.Nom = model.Nom;
                this._context.Update(choixcoursOld);
                await this._context.SaveChangesAsync();
                return Ok("Ce choix de cours a été modifié avec succès.");
            }
            return PartialView(model);
        }

        [HttpPost]
        public async Task<IActionResult> FormationGenerale_ChoixCours_Delete(int id)
        {
           
            ChoixCours choixcours = this._context.ChoixCours.Where(CC => CC.Id == id).Include(CC => CC.ChoixCoursCoursFormationGenerale).FirstOrDefault();
            if (choixcours != null)
            {
                if (choixcours.ChoixCoursCoursFormationGenerale.Count() == 0)
                {
                    this._context.Remove(choixcours);
                    await this._context.SaveChangesAsync();
                    return Ok("Ce choix de cours a été supprimé avec succès.");
                }
                return BadRequest("Ce choix de cours ne peut pas être supprimé car il est utilisé par une actualisation.");
            }
            return BadRequest("Ce choix de cours n'existe pas ou a déjà été supprimé."); 
        }
            
        [HttpGet]
        public IActionResult FormationGenerale_ChoixCours_Cours(int id)
        {
            CheckListViewModel<Cours, ChoixCours> checkListViewModel = new CheckListViewModel<Cours, ChoixCours> { Items = new List<CheckListItem<Cours>>(), Parent = this._context.ChoixCours.Where(CC => CC.Id == id).First() };
            List<Cours> CoursFG = this._context.Cours.Where(C => C.Actualisation == Convert.ToInt32(this.HttpContext.Session.GetString("idFG"))).Include(C => C.ChoixCoursCours).ToList();
            foreach (Cours C in CoursFG)
            {
                checkListViewModel.Items.Add(new CheckListItem<Cours> { Item = C, Checked = C.ChoixCoursCours.ToList().Exists(CCC => CCC.ChoixCours == id) });
            }
            return PartialView(checkListViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> FormationGenerale_ChoixCours_Cours(int idCours, int idChoixCours, bool ajouter)
        {
            if (ajouter)
            {
                this._context.Add(new ChoixCoursCours { Cours= idCours, ChoixCours = idChoixCours });
                await this._context.SaveChangesAsync();
                return Ok("Ce cours a été ajouté au choix de cours avec succès.");
            }
            else
            {
                this._context.Remove(this._context.ChoixCoursCours.Where(CCC => CCC.Cours == idCours && CCC.ChoixCours == idChoixCours).First());
                await this._context.SaveChangesAsync();
                return Ok("Ce cours a été retiré du choix de cours avec succès.");
            }         
        }
            #endregion ChoixCours

        #endregion FormationsGenerales

        public static string GenerateMDP()
        {
            StringBuilder MDPAleatoire = new StringBuilder("");
            int LongeurMDP = new Random().Next(6, 9);
            for (int i = 1; i <= LongeurMDP; i++)
            {
                switch (new Random().Next(1, 4))
                {
                    case 1:
                        MDPAleatoire.Append((char)new Random().Next(65, 91));
                        break;
                    case 2:
                        MDPAleatoire.Append((char)new Random().Next(97, 123));
                        break;
                    case 3:

                        MDPAleatoire.Append((char)new Random().Next(48, 58));
                        break;
                }
            }
            return MDPAleatoire.ToString();
        }
    }
}