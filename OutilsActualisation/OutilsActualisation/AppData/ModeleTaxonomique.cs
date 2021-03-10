using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OutilsActualisation.AppData
{
    public partial class ModeleTaxonomique
    {
        public ModeleTaxonomique()
        {
            Actualisation = new HashSet<Actualisation>();
            NiveauTaxonomique = new HashSet<NiveauTaxonomique>();
        }
        [Required(ErrorMessage = "Veuillez entrer un nom.")]
        public string Nom { get; set; }
        public DateTime? DateCreation { get; set; }
        [Display(Name = "Disponible")]
        public bool? IsAvailable { get; set; }

        public ICollection<Actualisation> Actualisation { get; set; }
        public ICollection<NiveauTaxonomique> NiveauTaxonomique { get; set; }
    }
}
