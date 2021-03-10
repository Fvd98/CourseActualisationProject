using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OutilsActualisation.AppData;
using OutilsActualisation.Autorisation;
using OutilsActualisation.Models;

namespace OutilsActualisation.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger _logger;
        OutilActualisationContext _context;
        public LoginController(ILogger<LoginController> logger, OutilActualisationContext context)
        {
            this._context = context;
            _logger = logger;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            // Supprimer l'ancien jeton de l'ancien utilisateur s'il existe
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            ViewData["ReturnUrl"] = returnUrl ?? "/Actualisation/Accueil";

            if (Request.Cookies.ContainsKey("RememberMeActua") && Request.Cookies.ContainsKey("CourrielActua"))
            {
                ViewBag.RememberMeActua = Request.Cookies["RememberMeActua"];
                ViewBag.CourrielActua = Request.Cookies["CourrielActua"];
            }
            return View();
        }

        [AllowAnonymous]
        public IActionResult PreLogin(string Courriel)
        {
            if (Courriel != null)
            {
                Utilisateur utilisateur = this._context.Utilisateur.Where(U => U.Courriel.ToLower() == Courriel.ToLower()).FirstOrDefault();
                if (utilisateur != null)
                {
                    return Ok(utilisateur.Salt);
                }
                return Ok("");
            }
            return BadRequest();              
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                //Vérification de l'utilisateur dans la base de données
                var result = await this._context.Utilisateur.FindAsync(model.Courriel);
                if (result != null && result.MotDePasse == model.MotDePasse)
                {
                    var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                    identity.AddClaim(new Claim(ClaimTypes.Name, result.Prenom));
                    identity.AddClaim(new Claim(ClaimTypes.Email, result.Courriel));
                    identity.AddClaim(new Claim(ClaimTypes.Role, result.IsAdmin ?? false ? "Admin" : "User"));
                    //Création du jeton
                    await HttpContext.SignInAsync(new ClaimsPrincipal(identity));
                    if (model.RememberMe)
                    {
                        this.Response.Cookies.Append("RememberMeActua", model.RememberMe.ToString());
                        this.Response.Cookies.Append("CourrielActua", model.Courriel);
                    }
                    else
                    {
                        this.Response.Cookies.Append("RememberMeActua", "", new CookieOptions { Expires = DateTime.Now.AddDays(-1) });
                        this.Response.Cookies.Append("CourrielActua", "", new CookieOptions { Expires = DateTime.Now.AddDays(-1) });
                    }
                    _logger.LogInformation("User logged in.");
                    if (!result.IsActive ?? true)
                    {
                        return RedirectToAction("FirstLogin", new { returnUrl });
                    }
                    return LocalRedirect(returnUrl);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Courriel ou mot de passe invalide!");
                    return View("Login", model);
                }
            }
            return View("Login", model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            _logger.LogInformation("User logged out.");
            return RedirectToAction(nameof(PublicController.Accueil), nameof(PublicController).Replace("Controller", ""));
        }
        [AllowAnonymous]
        public IActionResult AccessDenied(string returnUrl = null)
        {
            ViewData["Url"] = returnUrl;
            return View();
        }

        [HttpGet]
        [Authorize]
        public IActionResult FirstLogin(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl ?? "/Actualisation/Accueil";
            return View(new FirstLoginViewModel { Salt = this._context.Utilisateur.Where(U => U.Courriel.ToLower() == User.Claims.Where(C => C.Type == ClaimTypes.Email).First().Value.ToLower()).First().Salt } );
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> FirstLogin(FirstLoginViewModel model ,string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                Utilisateur utilisateurOld = this._context.Utilisateur.Where(U => U.Courriel.ToLower() == User.Claims.Where(C => C.Type == ClaimTypes.Email).First().Value.ToLower()).First();
                utilisateurOld.MotDePasse = model.NewPassword;
                utilisateurOld.IsActive = true;
                this._context.Update(utilisateurOld);
                await this._context.SaveChangesAsync();
                return LocalRedirect(returnUrl);
            }
            return View(model); 
        }
    }
}
