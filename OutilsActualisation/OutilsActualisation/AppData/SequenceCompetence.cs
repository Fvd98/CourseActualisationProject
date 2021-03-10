using System;
using System.Collections.Generic;

namespace OutilsActualisation.AppData
{
    public partial class SequenceCompetence
    {
        public SequenceCompetence()
        {
            SequenceCompetenceCompetence = new HashSet<SequenceCompetenceCompetence>();
        }

        public int Id { get; set; }
        public string Nom { get; set; }
        public int? Actualisation { get; set; }

        public Actualisation ActualisationNavigation { get; set; }
        public ICollection<SequenceCompetenceCompetence> SequenceCompetenceCompetence { get; set; }
    }
}
