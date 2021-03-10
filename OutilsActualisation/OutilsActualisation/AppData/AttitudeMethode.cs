using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OutilsActualisation.AppData
{
    public partial class AttitudeMethode
    {
        public AttitudeMethode()
        {
            CompetenceAnalyseAttitudeMethode = new HashSet<CompetenceAnalyseAttitudeMethode>();
        }

        public int Id { get; set; }
        public string Am { get; set; }
        [Display(Name = "Catégorie")]
        [Required(ErrorMessage = "Veuillez entrer une catégorie.")]
        public string Categorie { get; set; }
        [Display(Name = "Énoncé")]
        [Required(ErrorMessage = "Veuillez entrer un énoncé.")]
        public string Enonce { get; set; }
        public int? Actualisation { get; set; }

        public Actualisation ActualisationNavigation { get; set; }
        public ICollection<CompetenceAnalyseAttitudeMethode> CompetenceAnalyseAttitudeMethode { get; set; }
    }
}
