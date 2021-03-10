using System;
using System.Collections.Generic;

namespace OutilsActualisation.AppData
{
    public partial class FamilleCompetence
    {
        public FamilleCompetence()
        {
            FamilleCompetenceCompetence = new HashSet<FamilleCompetenceCompetence>();
        }

        public int Id { get; set; }
        public string Nom { get; set; }
        public string Couleur { get; set; }
        public int? Actualisation { get; set; }

        public Actualisation ActualisationNavigation { get; set; }
        public ICollection<FamilleCompetenceCompetence> FamilleCompetenceCompetence { get; set; }
    }
}
