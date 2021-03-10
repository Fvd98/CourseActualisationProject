using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OutilsActualisation.AppData
{
    public partial class Gabarit
    {
        public Gabarit()
        {
            PointGabarit = new HashSet<PointGabarit>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Le nom est obligatoire.")]
        public string Nom { get; set; }
        [Display(Name = "Date de création")]
        public DateTime? DateCreation { get; set; }
        [Display(Name = "Par défaut")]
        public bool? IsDefault { get; set; }
        public int? GabaritParent { get; set; }
        public int? Actualisation { get; set; }
        public int? TypeGabarit { get; set; }

        public Actualisation ActualisationNavigation { get; set; }
        public Gabarit GabaritParentNavigation { get; set; }
        public TypeGabarit TypeGabaritNavigation { get; set; }
        public ICollection<Gabarit> InverseGabaritParentNavigation { get; set; }
        public ICollection<PointGabarit> PointGabarit { get; set; }

        public async Task<bool> Duplicate(string Nom, int idActu, OutilActualisationContext _context)
        {
            try
            {
                Gabarit newGabarit = new Gabarit { Actualisation = idActu, DateCreation = DateTime.Now, GabaritParent = this.Id, IsDefault = false, Nom = Nom, TypeGabarit = this.TypeGabarit };
                _context.Add(newGabarit);
                await _context.SaveChangesAsync();
                foreach (PointGabarit P in this.PointGabarit.Where(PG => PG.ParentPointGabarit == null).ToList())
                {
                    PointGabarit newPoint = P.Duplicate(newGabarit.Id, null, _context);
                    _context.Add(newPoint);
                    foreach (PointGabarit enfantP in P.InverseParentPointGabaritNavigation.ToList())
                    {
                        _context.Add(enfantP.Duplicate(newGabarit.Id, newPoint.Id, _context));
                    }
                    
                }
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
