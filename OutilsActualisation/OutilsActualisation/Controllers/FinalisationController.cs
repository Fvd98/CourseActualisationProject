using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OutilsActualisation.AppData;

namespace OutilsActualisation.Controllers
{
    public class FinalisationController : Controller
    {
        private OutilActualisationContext _context;
        public FinalisationController(OutilActualisationContext context)
        {
            this._context = context;
        }

        public IActionResult Etapes()
        {
            return PartialView();
        }

        public IActionResult Rapport()
        {
            return PartialView();
        }
    }
}