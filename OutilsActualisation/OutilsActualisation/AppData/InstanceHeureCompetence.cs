using System;
using System.Collections.Generic;

namespace OutilsActualisation.AppData
{
    public partial class InstanceHeureCompetence
    {
        public InstanceHeureCompetence()
        {
            GroupeCompetence = new HashSet<GroupeCompetence>();
        }

        public int Id { get; set; }
        public string Nom { get; set; }
        public DateTime? DateCreation { get; set; }
        public DateTime? DateModification { get; set; }
        public bool? IsOfficiel { get; set; }
        public int? Actualisation { get; set; }
        public string Utilisateur { get; set; }
        public int? ProfilFormation { get; set; }

        public Actualisation ActualisationNavigation { get; set; }
        public ProfilFormation ProfilFormationNavigation { get; set; }
        public Utilisateur UtilisateurNavigation { get; set; }
        public ICollection<GroupeCompetence> GroupeCompetence { get; set; }
        public ICollection<HeureComp> HeureComp { get; set; }
    }
}
