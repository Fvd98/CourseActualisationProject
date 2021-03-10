using System;
using System.Collections.Generic;

namespace OutilsActualisation.AppData
{
    public partial class TypeRapport
    {
        public TypeRapport()
        {
            Rapport = new HashSet<Rapport>();
        }

        public int Id { get; set; }
        public string Nom { get; set; }

        public ICollection<Rapport> Rapport { get; set; }
    }
}
