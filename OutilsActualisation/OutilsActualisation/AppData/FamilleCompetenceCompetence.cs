using System;
using System.Collections.Generic;

namespace OutilsActualisation.AppData
{
    public partial class FamilleCompetenceCompetence
    {
        public int FamilleCompetence { get; set; }
        public string Competence { get; set; }

        public Competence CompetenceNavigation { get; set; }
        public FamilleCompetence FamilleCompetenceNavigation { get; set; }
    }
}
