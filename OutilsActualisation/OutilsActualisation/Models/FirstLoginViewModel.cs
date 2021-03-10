using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OutilsActualisation.Models
{
    public class FirstLoginViewModel
    {
        [Display(Name = "Nouveau mot de passe")]
        [Required(ErrorMessage = " Veuillez entrer un mot de passe.")]
        public string NewPassword { get; set; }

        public string Salt { get; set; }
    }
}
