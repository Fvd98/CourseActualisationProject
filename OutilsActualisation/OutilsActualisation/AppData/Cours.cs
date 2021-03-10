using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OutilsActualisation.AppData
{
    public partial class Cours
    {
        public Cours()
        {
            ChoixCoursCours = new HashSet<ChoixCoursCours>();
            ChoixCoursCoursFormationGenerale = new HashSet<ChoixCoursCoursFormationGenerale>();
            CoursCompetence = new HashSet<CoursCompetence>();
            CoursCompetenceEquivalance = new HashSet<CoursCompetenceEquivalance>();
            CoursCoursEquivalanceCoursEquivalantNavigation = new HashSet<CoursCoursEquivalance>();
            CoursCoursEquivalanceCoursNavigation = new HashSet<CoursCoursEquivalance>();
            CoursCoursPrealableCoursNavigation = new HashSet<CoursCoursPrealable>();
            CoursCoursPrealableCoursPrealableNavigation = new HashSet<CoursCoursPrealable>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Veuillez entrer un sigle.")]
        public string Sigle { get; set; }
        [Required(ErrorMessage = "Veuillez entrer un titre.")]
        public string Titre { get; set; }
        public int? NoSession { get; set; }
        [Required]
        public int? PondT { get; set; }
        [Required]
        public int? PondL { get; set; }
        [Required]
        public int? PondP { get; set; }
        public bool? IsOld { get; set; }
        public bool? IsGeneral { get; set; }
        public int? Actualisation { get; set; }

        public Actualisation ActualisationNavigation { get; set; }
        public ICollection<ChoixCoursCours> ChoixCoursCours { get; set; }
        public ICollection<ChoixCoursCoursFormationGenerale> ChoixCoursCoursFormationGenerale { get; set; }
        public ICollection<CoursCompetence> CoursCompetence { get; set; }
        public ICollection<CoursCompetenceEquivalance> CoursCompetenceEquivalance { get; set; }
        public ICollection<CoursCoursEquivalance> CoursCoursEquivalanceCoursEquivalantNavigation { get; set; }
        public ICollection<CoursCoursEquivalance> CoursCoursEquivalanceCoursNavigation { get; set; }
        public ICollection<CoursCoursPrealable> CoursCoursPrealableCoursNavigation { get; set; }
        public ICollection<CoursCoursPrealable> CoursCoursPrealableCoursPrealableNavigation { get; set; }
    }
}
