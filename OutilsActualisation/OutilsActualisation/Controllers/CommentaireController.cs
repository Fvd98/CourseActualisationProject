using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OutilsActualisation.AppData;

namespace OutilsActualisation.Controllers
{
    public class CommentaireController : Controller
    {
        private OutilActualisationContext _context;
        public CommentaireController(OutilActualisationContext context)
        {
            this._context = context;
        }
    }
}