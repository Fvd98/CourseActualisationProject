using System;
using System.Collections.Generic;

namespace OutilsActualisation.AppData
{
    public partial class CoursCompetenceEquivalance
    {
        public int Cours { get; set; }
        public string Competence1 { get; set; }
        public string Competence2 { get; set; }

        public Competence Competence1Navigation { get; set; }
        public Competence Competence2Navigation { get; set; }
        public Cours CoursNavigation { get; set; }
    }
}
