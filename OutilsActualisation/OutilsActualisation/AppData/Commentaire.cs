using System;
using System.Collections.Generic;

namespace OutilsActualisation.AppData
{
    public partial class Commentaire
    {
        public int Id { get; set; }
        public DateTime? DateCreation { get; set; }
        public string Vue { get; set; }
        public string Contenu { get; set; }
        public string Utilisateur { get; set; }
        public int? Actualisation { get; set; }

        public Actualisation ActualisationNavigation { get; set; }
        public Utilisateur UtilisateurNavigation { get; set; }
    }
}
