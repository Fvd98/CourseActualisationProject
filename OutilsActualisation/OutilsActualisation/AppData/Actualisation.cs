using OutilsActualisation.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OutilsActualisation.AppData
{
    public partial class Actualisation
    {
        public Actualisation()
        {
            AttitudeMethode = new HashSet<AttitudeMethode>();
            ChoixCours = new HashSet<ChoixCours>();
            ChoixCoursCoursFormationGenerale = new HashSet<ChoixCoursCoursFormationGenerale>();
            Commentaire = new HashSet<Commentaire>();
            CompetenceAnalyse = new HashSet<CompetenceAnalyse>();
            Cours = new HashSet<Cours>();
            ElementAnalyse = new HashSet<ElementAnalyse>();
            FamilleCompetence = new HashSet<FamilleCompetence>();
            Gabarit = new HashSet<Gabarit>();
            InstanceHeureCompetence = new HashSet<InstanceHeureCompetence>();
            InverseAncienneActualisationNavigation = new HashSet<Actualisation>();
            InverseFormationGeneraleNavigation = new HashSet<Actualisation>();
            ProfilFormation = new HashSet<ProfilFormation>();
            Rapport = new HashSet<Rapport>();
            SequenceCompetence = new HashSet<SequenceCompetence>();
            UtilisateurActualisation = new HashSet<UtilisateurActualisation>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Le nom est requis.")]
        public string Nom { get; set; }
        public DateTime? DateCreation { get; set; }
        public string EbaucheEsp { get; set; }
        public string EbauchePs { get; set; }
        public int? Devis { get; set; }
        public int? AncienDevis { get; set; }
        public int? AncienneActualisation { get; set; }
        public int? FormationGenerale { get; set; }
        public string ModeleTaxonomique { get; set; }

        public Devis AncienDevisNavigation { get; set; }
        public Actualisation AncienneActualisationNavigation { get; set; }
        public Devis DevisNavigation { get; set; }
        public Actualisation FormationGeneraleNavigation { get; set; }
        public ModeleTaxonomique ModeleTaxonomiqueNavigation { get; set; }
        public ICollection<AttitudeMethode> AttitudeMethode { get; set; }
        public ICollection<ChoixCours> ChoixCours { get; set; }
        public ICollection<ChoixCoursCoursFormationGenerale> ChoixCoursCoursFormationGenerale { get; set; }
        public ICollection<Commentaire> Commentaire { get; set; }
        public ICollection<CompetenceAnalyse> CompetenceAnalyse { get; set; }
        public ICollection<Cours> Cours { get; set; }
        public ICollection<ElementAnalyse> ElementAnalyse { get; set; }
        public ICollection<FamilleCompetence> FamilleCompetence { get; set; }
        public ICollection<Gabarit> Gabarit { get; set; }
        public ICollection<InstanceHeureCompetence> InstanceHeureCompetence { get; set; }
        public ICollection<Actualisation> InverseAncienneActualisationNavigation { get; set; }
        public ICollection<Actualisation> InverseFormationGeneraleNavigation { get; set; }
        public ICollection<ProfilFormation> ProfilFormation { get; set; }
        public ICollection<Rapport> Rapport { get; set; }
        public ICollection<SequenceCompetence> SequenceCompetence { get; set; }
        public ICollection<UtilisateurActualisation> UtilisateurActualisation { get; set; }

        public ActualisationViewModal ToViewModel()
        {
            return new ActualisationViewModal { Id = this.Id, Nom = this.Nom };
        }
        public MesActualisationsViewModel ToMesViewModel()
        {
            return new MesActualisationsViewModel { Id = this.Id, Nom = this.Nom, DateCreation = this.DateCreation ?? default(DateTime) };
        }
    }
}
