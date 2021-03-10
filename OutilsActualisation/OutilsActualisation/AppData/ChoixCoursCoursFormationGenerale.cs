using System;
using System.Collections.Generic;

namespace OutilsActualisation.AppData
{
    public partial class ChoixCoursCoursFormationGenerale
    {
        public int Id { get; set; }
        public int? ChoixCours { get; set; }
        public int? Actualisation { get; set; }
        public int? Cours { get; set; }

        public Actualisation ActualisationNavigation { get; set; }
        public ChoixCours ChoixCoursNavigation { get; set; }
        public Cours CoursNavigation { get; set; }
    }
}
