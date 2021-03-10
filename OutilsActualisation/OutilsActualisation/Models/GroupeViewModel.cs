using Microsoft.AspNetCore.Mvc.Rendering;
using OutilsActualisation.AppData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutilsActualisation.Models
{
    public class GroupeViewModel
    {
        public SelectList selectList { get; set; }
        public InstanceHeureCompetence instance { get; set; }
    }
}
