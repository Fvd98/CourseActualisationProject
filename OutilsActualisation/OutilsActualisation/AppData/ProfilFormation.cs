using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OutilsActualisation.AppData
{
    public partial class ProfilFormation
    {
        public ProfilFormation()
        {
            CompetenceProfilFormation = new HashSet<CompetenceProfilFormation>();
            InstanceHeureCompetence = new HashSet<InstanceHeureCompetence>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Veuillez entrer un nom.")]
        public string Nom { get; set; }
        public int? Actualisation { get; set; }

        public Actualisation ActualisationNavigation { get; set; }
        public ICollection<CompetenceProfilFormation> CompetenceProfilFormation { get; set; }
        public ICollection<InstanceHeureCompetence> InstanceHeureCompetence { get; set; }
    }
}
