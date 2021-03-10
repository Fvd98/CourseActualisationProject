using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OutilsActualisation.AppData;
using OutilsActualisation.Models;

namespace OutilsActualisation.Controllers
{
    public class PublicController : Controller
    {
        private OutilActualisationContext _context;
        public PublicController(OutilActualisationContext context)
        {
            this._context = context;
        }

        public IActionResult Accueil()
        {
            return View();
        }

        public IActionResult Error(string ErrorMessage, string IsView)
        {
            ViewBag.IsView = IsView;
            return PartialView(model: ErrorMessage);
        }
    }
}