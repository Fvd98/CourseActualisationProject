using OutilsActualisation.AppData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OutilsActualisation.Models
{
    public class GabaritComparaisonViewModel
    {
        [Display(Name = "Devis actuel")]
        public Gabarit ancienDevis { get; set; }
        [Display(Name = "Nouveau devis")]
        public Gabarit nouveauDevis { get; set; }
    }
}
