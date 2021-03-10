using Microsoft.AspNetCore.Http;
using OutilsActualisation.AppData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OutilsActualisation.Models
{
    public class DevisViewModel
    {
        public Devis Devis { get; set; }
        [Display(Name = "Devis (format PDF)")]
        public IFormFile DevisFile { get; set; }
    }
}
