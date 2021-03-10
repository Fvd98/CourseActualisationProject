using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OutilsActualisation.AppData
{
    public partial class Competence
    {
        public Competence()
        {
            CompetenceAnalyse = new HashSet<CompetenceAnalyse>();
            CompetenceProfilFormation = new HashSet<CompetenceProfilFormation>();
            CoursCompetence = new HashSet<CoursCompetence>();
            CoursCompetenceEquivalanceCompetence1Navigation = new HashSet<CoursCompetenceEquivalance>();
            CoursCompetenceEquivalanceCompetence2Navigation = new HashSet<CoursCompetenceEquivalance>();
            Element = new HashSet<Element>();
            FamilleCompetenceCompetence = new HashSet<FamilleCompetenceCompetence>();
            HeureComp = new HashSet<HeureComp>();
            SequenceCompetenceCompetence = new HashSet<SequenceCompetenceCompetence>();
        }
        [Required(ErrorMessage = "Veuillez entrer un code.")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Veuillez entrer un énoncé.")]
        [Display(Name = "Énoncé")]
        public string Enonce { get; set; }
        public int? Devis { get; set; }
        [Display(Name = "Contexte de réalisation")]
        public string ContextesRealisation { get; set; }
        [Display(Name = "Est obligatoire")]
        public bool? IsObligatoire { get; set; }

        public Devis DevisNavigation { get; set; }
        public ICollection<CompetenceAnalyse> CompetenceAnalyse { get; set; }
        public ICollection<CompetenceProfilFormation> CompetenceProfilFormation { get; set; }
        public ICollection<CoursCompetence> CoursCompetence { get; set; }
        public ICollection<CoursCompetenceEquivalance> CoursCompetenceEquivalanceCompetence1Navigation { get; set; }
        public ICollection<CoursCompetenceEquivalance> CoursCompetenceEquivalanceCompetence2Navigation { get; set; }
        public ICollection<Element> Element { get; set; }
        public ICollection<FamilleCompetenceCompetence> FamilleCompetenceCompetence { get; set; }
        public ICollection<HeureComp> HeureComp { get; set; }
        public ICollection<SequenceCompetenceCompetence> SequenceCompetenceCompetence { get; set; }
    }
}
