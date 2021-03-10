using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OutilsActualisation.AppData
{
    public partial class ChoixCours
    {
        public ChoixCours()
        {
            ChoixCoursCours = new HashSet<ChoixCoursCours>();
            ChoixCoursCoursFormationGenerale = new HashSet<ChoixCoursCoursFormationGenerale>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Veuillez entrer un nom.")]
        public string Nom { get; set; }
        public int? NbAchoisir { get; set; }
        public int? Actualisation { get; set; }

        public Actualisation ActualisationNavigation { get; set; }
        public ICollection<ChoixCoursCours> ChoixCoursCours { get; set; }
        public ICollection<ChoixCoursCoursFormationGenerale> ChoixCoursCoursFormationGenerale { get; set; }
    }
}
