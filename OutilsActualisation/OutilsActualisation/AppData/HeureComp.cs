using System;
using System.Collections.Generic;

namespace OutilsActualisation.AppData
{
    public partial class HeureComp
    {
        public string Competence { get; set; }
        public int NoSession { get; set; }
        public int? GroupeCompetence { get; set; }
        public int? NbHeure { get; set; }
        public int? InstanceHeureCompetence { get; set; }
        public Competence CompetenceNavigation { get; set; }
        public GroupeCompetence GroupeCompetenceNavigation { get; set; }
        public InstanceHeureCompetence InstanceHeureCompetenceNavigation { get; set; }

    }
}
