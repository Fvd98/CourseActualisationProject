using System;
using System.Collections.Generic;

namespace OutilsActualisation.AppData
{
    public partial class Rapport
    {
        public DateTime DateCreation { get; set; }
        public int Actualisation { get; set; }
        public int TypeRapport { get; set; }
        public string LienRapport { get; set; }

        public Actualisation ActualisationNavigation { get; set; }
        public TypeRapport TypeRapportNavigation { get; set; }
    }
}
