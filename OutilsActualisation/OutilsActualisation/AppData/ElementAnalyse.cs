using System;
using System.Collections.Generic;

namespace OutilsActualisation.AppData
{
    public partial class ElementAnalyse
    {
        public int Id { get; set; }
        public int Actualisation { get; set; }
        public int Element { get; set; }
        public int? NiveauTaxonomique { get; set; }

        public Actualisation ActualisationNavigation { get; set; }
        public Element ElementNavigation { get; set; }
        public NiveauTaxonomique NiveauTaxonomiqueNavigation { get; set; }
    }
}
