using Microsoft.AspNetCore.Mvc.Rendering;
using OutilsActualisation.AppData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutilsActualisation.Models
{
    public class AnalyseTaxonomieViewModel
    {
        public CompetenceAnalyse competenceAnalyse { get; set; }

        public List<ElementAnalyse> elementAnalyses { get; set; }

        public ModeleTaxonomique modeleTaxonomique { get; set; }

        public SelectList modelesDisponibles { get; set; }
    }
}
