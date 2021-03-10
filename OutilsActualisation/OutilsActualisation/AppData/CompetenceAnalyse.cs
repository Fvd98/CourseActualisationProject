using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OutilsActualisation.AppData
{
    public partial class CompetenceAnalyse
    {
        public CompetenceAnalyse()
        {
            CompetenceAnalyseAttitudeMethode = new HashSet<CompetenceAnalyseAttitudeMethode>();
        }

        public int Id { get; set; }
        [Display(Name = "Reformulation de la compétence")]
        public string Reformulation { get; set; }
        public string Contexte { get; set; }
        public int? NbHeureApp { get; set; }
        public int? Actualisation { get; set; }
        public string Competence { get; set; }
        public int? NiveauTaxonomique { get; set; }

        public Actualisation ActualisationNavigation { get; set; }
        public Competence CompetenceNavigation { get; set; }
        public NiveauTaxonomique NiveauTaxonomiqueNavigation { get; set; }
        public ICollection<CompetenceAnalyseAttitudeMethode> CompetenceAnalyseAttitudeMethode { get; set; }
    }
}
