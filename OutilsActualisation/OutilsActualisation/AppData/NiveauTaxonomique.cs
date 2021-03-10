using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OutilsActualisation.AppData
{
    public partial class NiveauTaxonomique
    {
        public NiveauTaxonomique()
        {
            CompetenceAnalyse = new HashSet<CompetenceAnalyse>();
            ElementAnalyse = new HashSet<ElementAnalyse>();
        }

        public int Id { get; set; }
        public string Ordre { get; set; }
        [Required(ErrorMessage = "Veuillez entrer un terme.")]
        public string Terme { get; set; }
        public string ModeleTaxonomique { get; set; }

        public ModeleTaxonomique ModeleTaxonomiqueNavigation { get; set; }
        public ICollection<CompetenceAnalyse> CompetenceAnalyse { get; set; }
        public ICollection<ElementAnalyse> ElementAnalyse { get; set; }
    }
}
