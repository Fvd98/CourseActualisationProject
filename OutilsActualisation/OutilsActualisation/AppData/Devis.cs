using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OutilsActualisation.AppData
{
    public partial class Devis
    {
        public Devis()
        {
            ActualisationAncienDevisNavigation = new HashSet<Actualisation>();
            ActualisationDevisNavigation = new HashSet<Actualisation>();
            Competence = new HashSet<Competence>();
            ConditionAdmission = new HashSet<ConditionAdmission>();
        }

        public int Id { get; set; }
        [Display(Name = "Code du programme")]
        public string CodeProgramme { get; set; }
        public DateTime? DatePublication { get; set; }

        public ICollection<Actualisation> ActualisationAncienDevisNavigation { get; set; }
        public ICollection<Actualisation> ActualisationDevisNavigation { get; set; }
        public ICollection<Competence> Competence { get; set; }
        public ICollection<ConditionAdmission> ConditionAdmission { get; set; }
    }
}
