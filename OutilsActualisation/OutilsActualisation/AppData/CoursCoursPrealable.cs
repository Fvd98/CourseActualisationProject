using System;
using System.Collections.Generic;

namespace OutilsActualisation.AppData
{
    public partial class CoursCoursPrealable
    {
        public int Cours { get; set; }
        public int CoursPrealable { get; set; }
        public string Apc { get; set; }

        public Cours CoursNavigation { get; set; }
        public Cours CoursPrealableNavigation { get; set; }
    }
}
