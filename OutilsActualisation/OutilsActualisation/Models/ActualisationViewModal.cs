using Microsoft.AspNetCore.Mvc.Rendering;
using OutilsActualisation.AppData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OutilsActualisation.Models
{
    public class ActualisationViewModal
    {
        public int Id { get; set; }
        [Display(Name = "Nom*")]
        [Required(ErrorMessage = "Le nom est obligatoire")]
        public string Nom { get; set; }
        [Display(Name = "Totale ou partielle?")]
        [Required(ErrorMessage = "Veuillez remplir ce champs")]
        public bool? IsTotal { get; set; }
        [Display(Name = "Devis*")]
        [Required( ErrorMessage = "Le devis est obligatoire" )]
        public int? Devis { get; set; }
        [Display(Name = "Ancien devis (optionnel)")]
        public int? AncienDevis { get; set; }
        [Display(Name = "Ancienne actualisation (optionnel)")]
        public int? AncienneActualisation { get; set; }

        public SelectList selectListActualisations { get; set; }

        public Actualisation ToModel()
        {
            Actualisation actualisation = new Actualisation { DateCreation = DateTime.Now, Devis=this.Devis, EbaucheEsp = "", EbauchePs="", Nom=this.Nom,  };
            if (this.Id != default(int))
            {
                actualisation.Id = this.Id;
            }
            if (this.AncienneActualisation != null)
            {
                actualisation.AncienneActualisation = this.AncienneActualisation;
            }
            else if (this.AncienDevis != null)
            {
                actualisation.AncienDevis = this.AncienDevis;
            }
            return actualisation;
        }
    }
}
