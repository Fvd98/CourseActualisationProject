using System;
using System.Collections.Generic;

namespace OutilsActualisation.AppData
{
    public partial class CompetenceProfilFormation
    {
        public string Competence { get; set; }
        public int ProfilFormation { get; set; }

        public Competence CompetenceNavigation { get; set; }
        public ProfilFormation ProfilFormationNavigation { get; set; }
    }
}
