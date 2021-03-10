using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OutilsActualisation.AppData;

namespace OutilsActualisation.Controllers
{
    public class CoursController : Controller
    {
        private OutilActualisationContext _context;
        public CoursController(OutilActualisationContext context)
        {
            this._context = context;
        }

        public IActionResult Etapes()
        {
            return PartialView();
        }

        public IActionResult Creation()
        {
            return PartialView();
        }

        public IActionResult Choix()
        {
            return PartialView();
        }

        public IActionResult FormationGenerale()
        {
            return PartialView();
        }

        public IActionResult RepartitionHeure()
        {
            return PartialView();
        }
    }
}