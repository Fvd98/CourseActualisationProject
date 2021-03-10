using System;
using System.Collections.Generic;

namespace OutilsActualisation.AppData
{
    public partial class CoursElement
    {
        public string Cours { get; set; }
        public int Element { get; set; }

        public Cours CoursNavigation { get; set; }
        public Element ElementNavigation { get; set; }
    }
}
