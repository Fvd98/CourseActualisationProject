using System;
using System.Collections.Generic;

namespace OutilsActualisation.AppData
{
    public partial class SequenceCompetenceCompetence
    {
        public int SequenceCompetence { get; set; }
        public string Competence { get; set; }
        public int? Ordre { get; set; }

        public Competence CompetenceNavigation { get; set; }
        public SequenceCompetence SequenceCompetenceNavigation { get; set; }
    }
}
