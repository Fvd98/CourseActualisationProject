using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OutilsActualisation.AppData;

namespace OutilsActualisation.Models
{
    public class Actualisation_MembreViewModel
    {
        public List<UtilisateurActualisation> Responsables { get; set; }
        public List<UtilisateurActualisation> Membres { get; set; }
    }
}
