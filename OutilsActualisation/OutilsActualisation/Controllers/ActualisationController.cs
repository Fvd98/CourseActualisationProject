using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OutilsActualisation.AppData;
using OutilsActualisation.Autorisation;
using OutilsActualisation.Models;
using Microsoft.Exchange.WebServices.Autodiscover;
using Microsoft.Exchange.WebServices.Data;
using System.Net.Mail;

namespace OutilsActualisation.Controllers
{
    public class ActualisationController : Controller
    {
        private OutilActualisationContext _context;
        public ActualisationController(OutilActualisationContext context)
        {
            this._context = context;
        }

        [Authorize]
        public IActionResult Accueil()
        {
            // récupère la liste des actualisations de l'usager
            List<MesActualisationsViewModel> actualisations;
            if (User.IsInRole("Admin"))
            {
                actualisations = this._context.Actualisation.Where(A => A.FormationGenerale != null).Select(A => A.ToMesViewModel()).ToList();
            }
            else
            {
                actualisations = new List<MesActualisationsViewModel>();
                this._context.UtilisateurActualisation.Where(UA => UA.Utilisateur == User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value).Include(UA => UA.ActualisationNavigation).ToList().ForEach(UA => actualisations.Add(UA.ActualisationNavigation.ToMesViewModel()));
            }
            return View(actualisations);
        }

        #region Actualisation
        [Authorize]
        public async Task<IActionResult> Actualisation(int idActualisation)
        {
            this.HttpContext.Session.Clear();
            string RoleDb;
            if (User.IsInRole("Admin"))
            {
                RoleDb = "R";
            }
            else
            {
                RoleDb = this._context.UtilisateurActualisation.Where(UA => UA.Utilisateur == User.Claims.FirstOrDefault(c=>c.Type == ClaimTypes.Email).Value && UA.Actualisation == idActualisation).Single().Rm ?? "AucunRole";
            }
            if (RoleDb != "AucunRole")
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                var identity = User.Identity as ClaimsIdentity;
                if (identity.HasClaim(C => C.Type == "IDActu"))
                {
                    identity.RemoveClaim(identity.FindFirst("IDActu"));
                }
                if (identity.HasClaim(C => C.Type == "RoleActu"))
                {
                    identity.RemoveClaim(identity.FindFirst("RoleActu"));
                }
                identity.AddClaim(new Claim("IDActu", idActualisation.ToString()));
                identity.AddClaim(new Claim("RoleActu", RoleDb));
                await HttpContext.SignInAsync(new ClaimsPrincipal(identity));
                return View();
            }
            else
            {
                return RedirectToAction("Error","Public",new { ErrorMessage = "Accès refusé" });
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Actualisation_Create()
        {
            return View(new ActualisationViewModal { selectListActualisations = new SelectList(this._context.Actualisation.Where(A => A.FormationGenerale != null).ToList(), "Id", "Nom") });
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Actualisation_Create(ActualisationViewModal model)
        {
            if (ModelState.IsValid)
            {
                Actualisation actualisation = model.ToModel();
                actualisation.FormationGenerale = this._context.Actualisation.Where(A => A.FormationGenerale == null && A.DateCreation == this._context.Actualisation.Where(a => a.FormationGenerale == null).Max(a => a.DateCreation)).First().Id;
                this._context.Actualisation.Add(actualisation);
                await this._context.SaveChangesAsync();
                if (((!model.IsTotal) ?? false) && actualisation.AncienneActualisation != null)
                {
                    //Todo : dupliquer l'ancienne actualisation et l'associer à celle créer ci-dessus (compétence, cours, etc...)
                }
                Gabarit AnalyseProfession = this._context.Gabarit.Where(G => G.IsDefault == true && G.TypeGabarit == 1).Include(G => G.PointGabarit).ThenInclude(PG => PG.ParentPointGabaritNavigation).FirstOrDefault();
                Gabarit UniteHeure = this._context.Gabarit.Where(G => G.IsDefault == true && G.TypeGabarit == 2).Include(G => G.PointGabarit).ThenInclude(PG => PG.ParentPointGabaritNavigation).FirstOrDefault();
                Gabarit Finalite = this._context.Gabarit.Where(G => G.IsDefault == true && G.TypeGabarit == 3).Include(G => G.PointGabarit).ThenInclude(PG => PG.ParentPointGabaritNavigation).FirstOrDefault();
                if (AnalyseProfession != null && UniteHeure != null && Finalite != null)
                {
                    if (!await AnalyseProfession.Duplicate("N", actualisation.Id, this._context) || !await UniteHeure.Duplicate("A", actualisation.Id, this._context) || !await UniteHeure.Duplicate("N", actualisation.Id, this._context) || !await Finalite.Duplicate("A", actualisation.Id, this._context) || !await Finalite.Duplicate("N", actualisation.Id, this._context))
                    {
                        return BadRequest("Échec de la création des gabarits.");
                    } 
                    HttpContext.Session.SetInt32("IDActu", actualisation.Id);
                    return RedirectToAction(nameof(Actualisation_Membre));
                }
                return BadRequest("Aucun gabarit par défaut n'est sélectionné, contactez un administrateur pour qu'il règle le problème.");
            }
            return View(model);
        }

        [HttpGet]
        [Authorize(Policy = "IsResponsable")]
        public IActionResult Actualisation_Membre(bool? FromActu)
        {
            int idActu = FromActu ?? false ? Convert.ToInt32(User.Claims.FirstOrDefault(C => C.Type == "IDActu").Value) : this.HttpContext.Session.GetInt32("IDActu") ?? -1;
            List<UtilisateurActualisation> responsables = this._context.UtilisateurActualisation.Where(UA => UA.Actualisation == idActu && UA.Rm == "R").Include(UA => UA.UtilisateurNavigation).ToList();
            return View(new Actualisation_MembreViewModel { Responsables = responsables, Membres = this._context.UtilisateurActualisation.Where(UA => UA.Actualisation == GetActualisation() && UA.Rm == "M").Include(UA => UA.UtilisateurNavigation).ToList() });
        }

        [HttpGet]
        [Authorize(Policy = "IsResponsable")]
        public IActionResult Actualisation_Membre_Ajouter(string Role)
        {
            this.HttpContext.Session.SetString("RoleCreate", Role);
            return PartialView(new UtilisateurActualisation { Rm = Role });
        }

        [HttpPost]
        [Authorize(Policy = "IsResponsable")]
        public async Task<IActionResult> Actualisation_Membre_Ajouter(UtilisateurActualisation model)
        {
            model.Actualisation = GetActualisation() ?? -1;
            if(model.Actualisation != -1)
            {
                if(ModelState.IsValid)
                {
                    if (!this._context.UtilisateurActualisation.ToList().Exists(UA => UA.Utilisateur.ToLower() == model.Utilisateur.ToLower() && UA.Actualisation == model.Actualisation))
                    {
                        if (this._context.Utilisateur.ToList().Exists(U => U.Courriel.ToLower() == model.Utilisateur.ToLower()))
                        {
                            model.Utilisateur = model.Utilisateur.ToLower();
                            this._context.UtilisateurActualisation.Add(model);
                            await this._context.SaveChangesAsync();
                            return Ok("L'utilisateur a été ajouté avec succès.");
                        }
                        return Ok("X");  
                    }
                    return BadRequest("Cet utilisateur a déjà été ajouté à l'actualisation.");
                }
                return PartialView(model);
            }
            return BadRequest("Oups! Une erreur est survenue.");    
        }

        [HttpPost]
        [Authorize(Policy = "IsResponsable")]
        public async Task<IActionResult> Actualisation_Membre_Retirer(string id)
        {
            try
            {
                this._context.Remove(this._context.UtilisateurActualisation.Where(UA => UA.Utilisateur.ToLower() == id.ToLower() && UA.Actualisation == GetActualisation()).First());
                await this._context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Oups! une erreur s'est produite...");
            }
            
        }

        [HttpGet]
        [Authorize(Policy = "IsResponsable")]
        public IActionResult Membre_Create(string id)
        {
            ViewBag.Role = this.HttpContext.Session.GetString("RoleCreate");
            return PartialView(new Utilisateur { Courriel = id });
        }

        [HttpPost]
        [Authorize(Policy = "IsResponsable")]
        public async Task<IActionResult> Membre_Create(Utilisateur model)
        {
            model.IsActive = false;
            model.IsAdmin = false;
            if (ModelState.IsValid)
            {
                if (this._context.Utilisateur.ToList().Exists(U => U.Courriel == model.Courriel))
                {
                    return BadRequest("Cet utilisateur existe déjà!");
                }
                model.MotDePasse = AdminController.GenerateMDP();
                try
                {
                    ExchangeService myservice = new ExchangeService(ExchangeVersion.Exchange2010_SP1);
                    myservice.Credentials = new WebCredentials(this._context._config.GetSection("Courriel").Value, this._context._config.GetSection("MotDePasse").Value);
                    string serviceUrl = "https://outlook.office365.com/ews/exchange.asmx";
                    myservice.Url = new Uri(serviceUrl);
                    EmailMessage emailMessage = new EmailMessage(myservice);
                    emailMessage.Subject = "Invitation à l'outil d'actualisation de programmes";
                    emailMessage.Body = new MessageBody(String.Format("Un compte a été créé à votre nom pour l'outil d'actualisation de programmes du Cégep de l'Outaouais. Voici vos informations de connexion:\n\nCourriel: {0}\nMot de passe temporaire: {1}", model.Courriel, model.MotDePasse));
                    emailMessage.ToRecipients.Add(model.Courriel);
                    emailMessage.Send();

                    model.Salt = Salt_Hasher.GetSalt();
                    model.MotDePasse = Salt_Hasher.GetHash(model.MotDePasse + model.Salt);
                    this._context.Add(model);
                    this._context.Add(new UtilisateurActualisation { Actualisation = GetActualisation()??-1, Rm = this.HttpContext.Session.GetString("RoleCreate"), Utilisateur = model.Courriel });
                    await this._context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    return BadRequest("Échec lors de l'envoi du courriel.");
                }
                return Ok("Le courriel a été envoyé avec succès.");
            }
            return PartialView(model);
        }
        #endregion Actualisation
        #region Devis
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Devis_Create(string Name, string ID)
        {
            ViewBag.Name = Name;
            ViewBag.ID = ID;
            return PartialView();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Devis_Create(DevisViewModel model)
        {
            if (model.DevisFile == null || model.DevisFile.Length == 0 || model.DevisFile.ContentType != "application/pdf")
            {
                return BadRequest();
            }
            this._context.Devis.Add(model.Devis);
            await this._context.SaveChangesAsync();
            string[] extensions = model.DevisFile.FileName.Split(".");
            using (var stream = new FileStream(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/devis", model.Devis.Id.ToString() + "." + extensions[extensions.Length - 1]), FileMode.Create))
            {
                await model.DevisFile.CopyToAsync(stream);
            }
            this._context.Devis.Update(model.Devis);
            await this._context.SaveChangesAsync();
            return Ok(model.Devis.Id);
        }
        #endregion Devis

        private int? GetActualisation()
        {
            int? idActu = this.HttpContext.Session.GetInt32("IDActu");
            if (idActu == null)
            {
                Claim ActuClaim;
                if ((ActuClaim = User.Claims.Where(C => C.Type == "IDActu").FirstOrDefault()) == null)
                {
                    return null;
                }
                return Convert.ToInt32(ActuClaim.Value);
            }
            return idActu;
        }
    }


}