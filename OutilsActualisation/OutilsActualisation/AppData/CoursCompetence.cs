using System;
using System.Collections.Generic;

namespace OutilsActualisation.AppData
{
    public partial class CoursCompetence
    {
        public int Cours { get; set; }
        public string Competence { get; set; }
        public int? NbHeures { get; set; }

        public Competence CompetenceNavigation { get; set; }
        public Cours CoursNavigation { get; set; }
    }
}
