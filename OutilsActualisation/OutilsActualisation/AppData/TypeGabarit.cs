using System;
using System.Collections.Generic;

namespace OutilsActualisation.AppData
{
    public partial class TypeGabarit
    {
        public TypeGabarit()
        {
            Gabarit = new HashSet<Gabarit>();
        }

        public int Id { get; set; }
        public string Nom { get; set; }

        public ICollection<Gabarit> Gabarit { get; set; }
    }
}
