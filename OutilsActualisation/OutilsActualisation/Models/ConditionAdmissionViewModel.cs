using OutilsActualisation.AppData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutilsActualisation.Models
{
    public class ConditionAdmissionViewModel
    {
        public int Id { get; set; }

        public int Ordre { get; set; }

        public string Contenu { get; set; }

        public ConditionAdmission ToModel()
        {
            return new ConditionAdmission { Ordre = this.Ordre, Contenu = this.Contenu };
        }
    }
}
