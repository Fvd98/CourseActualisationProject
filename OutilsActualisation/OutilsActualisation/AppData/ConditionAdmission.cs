using OutilsActualisation.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OutilsActualisation.AppData
{
    public partial class ConditionAdmission
    {
        public int Id { get; set; }
        public int? Ordre { get; set; }
        [Required(ErrorMessage = "Veuillez entrer un contenu.")]
        public string Contenu { get; set; }
        public int? Devis { get; set; }

        public Devis DevisNavigation { get; set; }

        public ConditionAdmissionViewModel ToViewModel()
        {
            return new ConditionAdmissionViewModel { Id = this.Id, Ordre = this.Ordre ?? 0, Contenu = this.Contenu };
        }
    }
}
