using System;
using System.Collections.Generic;

namespace OutilsActualisation.AppData
{
    public partial class CoursCoursEquivalance
    {
        public int Cours { get; set; }
        public int CoursEquivalant { get; set; }

        public Cours CoursEquivalantNavigation { get; set; }
        public Cours CoursNavigation { get; set; }
    }
}
