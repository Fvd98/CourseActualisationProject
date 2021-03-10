using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OutilsActualisation.AppData
{
    public partial class Utilisateur
    {
        public Utilisateur()
        {
            Commentaire = new HashSet<Commentaire>();
            InstanceHeureCompetence = new HashSet<InstanceHeureCompetence>();
            UtilisateurActualisation = new HashSet<UtilisateurActualisation>();
        }
        [Required(ErrorMessage = "Veuillez entrer un courriel.")]
        [EmailAddress]
        public string Courriel { get; set; }
        [Display(Name = "Mot de passe")]
        public string MotDePasse { get; set; }
        public string Salt { get; set; }
        [Required(ErrorMessage = "Veuillez entrer un titre.")]
        public string Titre { get; set; }
        [Required(ErrorMessage = "Veuillez entrer un nom.")]
        public string Nom { get; set; }
        [Display(Name = "Prénom")]
        [Required(ErrorMessage = "Veuillez entrer un prénom.")]
        public string Prenom { get; set; }
        [Display(Name = "Administrateur")]
        public bool? IsAdmin { get; set; }
        [Display(Name = "Activé")]
        public bool? IsActive { get; set; }
        public ICollection<Commentaire> Commentaire { get; set; }
        public ICollection<InstanceHeureCompetence> InstanceHeureCompetence { get; set; }
        public ICollection<UtilisateurActualisation> UtilisateurActualisation { get; set; }
    }
}
