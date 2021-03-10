using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OutilsActualisation.AppData
{
    public partial class GroupeCompetence
    {
        public GroupeCompetence()
        {
            HeureComp = new HashSet<HeureComp>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Veuillez entrer un nom.")]
        public string Nom { get; set; }
        [Required(ErrorMessage = "Veuillez choisir une couleur.")]
        public string Couleur { get; set; }
        public int? InstanceHeureCompetence { get; set; }

        public InstanceHeureCompetence InstanceHeureCompetenceNavigation { get; set; }
        public ICollection<HeureComp> HeureComp { get; set; }
    }
}
