using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OutilsActualisation.AppData
{
    public partial class UtilisateurActualisation
    {
        public int Actualisation { get; set; }
        [Display(Name = "Courriel de l'utilisateur")]
        [Required(ErrorMessage = "Veuillez entrer un courriel.")]
        public string Utilisateur { get; set; }
        public string Rm { get; set; }
        public Actualisation ActualisationNavigation { get; set; }
        public Utilisateur UtilisateurNavigation { get; set; }
    }
}
