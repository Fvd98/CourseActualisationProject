using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OutilsActualisation.Models
{
    public class ChangerMDPViewModel
    {
        [Required]
        public string Courriel { get; set; }

        [Display(Name = "Nouveau mot de passe")]
        [Required]
        public string Hash { get; set; }

        public string Salt { get; set; }

    }
}
