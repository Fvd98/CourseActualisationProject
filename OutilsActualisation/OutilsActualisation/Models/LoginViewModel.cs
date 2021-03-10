using OutilsActualisation.AppData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OutilsActualisation.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Veuillez entrer votre courriel.")]
        [EmailAddress(ErrorMessage = "Le courriel entré ne suit pas le format d'un courriel.")]
        public string Courriel { get; set; }
        [Required(ErrorMessage = "Veuillez entrer votre mot de passe.")]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public string MotDePasse { get; set; }
        [Display(Name = "Se rappeler de moi?")]
        public bool RememberMe { get; set; }
        public string Salt { get; set; }
    }
}
