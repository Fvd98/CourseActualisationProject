using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OutilsActualisation.AppData
{
    public partial class Element
    {
        public Element()
        {
            ElementAnalyse = new HashSet<ElementAnalyse>();
        }

        public int Id { get; set; }
        public int? Ordre { get; set; }
        [Display(Name = "Éconcé")]
        [Required(ErrorMessage = "Veuillez entrer un énoncé.")]
        public string Enonce { get; set; }
        [Display(Name = "Critères de performance (optionnel)")]
        public string CriterePerformance { get; set; }
        public string Competence { get; set; }

        public Competence CompetenceNavigation { get; set; }
        public ICollection<ElementAnalyse> ElementAnalyse { get; set; }
    }
}
