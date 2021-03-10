using System;
using System.Collections.Generic;

namespace OutilsActualisation.AppData
{
    public partial class CompetenceAnalyseAttitudeMethode
    {
        public int CompetenceAnalyse { get; set; }
        public int AttitudeMethode { get; set; }

        public AttitudeMethode AttitudeMethodeNavigation { get; set; }
        public CompetenceAnalyse CompetenceAnalyseNavigation { get; set; }
    }
}
