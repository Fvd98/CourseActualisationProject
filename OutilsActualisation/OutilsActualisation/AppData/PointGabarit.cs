using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OutilsActualisation.AppData
{
    public partial class PointGabarit
    {
        public PointGabarit()
        {
            InverseParentPointGabaritNavigation = new HashSet<PointGabarit>();
        }

        public int Id { get; set; }
        public int? Ordre { get; set; }
        [Display(Name = "Énoncé du point")]
        [Required(ErrorMessage = "Veuillez entrer un énoncé.")]
        public string Enonce { get; set; }
        public string Contenu { get; set; }
        public int? Gabarit { get; set; }
        public int? ParentPointGabarit { get; set; }

        public Gabarit GabaritNavigation { get; set; }
        public PointGabarit ParentPointGabaritNavigation { get; set; }
        public ICollection<PointGabarit> InverseParentPointGabaritNavigation { get; set; }

        public PointGabarit Duplicate(int idGabarit, int? idPointParent, OutilActualisationContext _context)
        {
            PointGabarit newPointGabarit = new PointGabarit { Contenu = this.Contenu, Enonce = this.Enonce, Gabarit = idGabarit, Ordre = this.Ordre };
            if (idPointParent != null)
            {
                newPointGabarit.ParentPointGabarit = idPointParent;
            }
            return newPointGabarit;
        }
    }
}
