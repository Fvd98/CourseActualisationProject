using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace OutilsActualisation.AppData
{
    public partial class OutilActualisationContext : DbContext
    {
        public IConfiguration _config;
        public OutilActualisationContext()
        {
        }

        public OutilActualisationContext(IConfiguration config, DbContextOptions<OutilActualisationContext> options)

            : base(options)
        {
            this._config = config;
        }

        public virtual DbSet<Actualisation> Actualisation { get; set; }
        public virtual DbSet<AttitudeMethode> AttitudeMethode { get; set; }
        public virtual DbSet<ChoixCours> ChoixCours { get; set; }
        public virtual DbSet<ChoixCoursCours> ChoixCoursCours { get; set; }
        public virtual DbSet<ChoixCoursCoursFormationGenerale> ChoixCoursCoursFormationGenerale { get; set; }
        public virtual DbSet<Commentaire> Commentaire { get; set; }
        public virtual DbSet<Competence> Competence { get; set; }
        public virtual DbSet<CompetenceAnalyse> CompetenceAnalyse { get; set; }
        public virtual DbSet<CompetenceAnalyseAttitudeMethode> CompetenceAnalyseAttitudeMethode { get; set; }
        public virtual DbSet<CompetenceProfilFormation> CompetenceProfilFormation { get; set; }
        public virtual DbSet<ConditionAdmission> ConditionAdmission { get; set; }
        public virtual DbSet<Cours> Cours { get; set; }
        public virtual DbSet<CoursCompetence> CoursCompetence { get; set; }
        public virtual DbSet<CoursCompetenceEquivalance> CoursCompetenceEquivalance { get; set; }
        public virtual DbSet<CoursCoursEquivalance> CoursCoursEquivalance { get; set; }
        public virtual DbSet<CoursCoursPrealable> CoursCoursPrealable { get; set; }
        public virtual DbSet<Devis> Devis { get; set; }
        public virtual DbSet<Element> Element { get; set; }
        public virtual DbSet<ElementAnalyse> ElementAnalyse { get; set; }
        public virtual DbSet<FamilleCompetence> FamilleCompetence { get; set; }
        public virtual DbSet<FamilleCompetenceCompetence> FamilleCompetenceCompetence { get; set; }
        public virtual DbSet<Gabarit> Gabarit { get; set; }
        public virtual DbSet<GroupeCompetence> GroupeCompetence { get; set; }
        public virtual DbSet<HeureComp> HeureComp { get; set; }
        public virtual DbSet<InstanceHeureCompetence> InstanceHeureCompetence { get; set; }
        public virtual DbSet<ModeleTaxonomique> ModeleTaxonomique { get; set; }
        public virtual DbSet<NiveauTaxonomique> NiveauTaxonomique { get; set; }
        public virtual DbSet<PointGabarit> PointGabarit { get; set; }
        public virtual DbSet<ProfilFormation> ProfilFormation { get; set; }
        public virtual DbSet<Rapport> Rapport { get; set; }
        public virtual DbSet<SequenceCompetence> SequenceCompetence { get; set; }
        public virtual DbSet<SequenceCompetenceCompetence> SequenceCompetenceCompetence { get; set; }
        public virtual DbSet<TypeGabarit> TypeGabarit { get; set; }
        public virtual DbSet<TypeRapport> TypeRapport { get; set; }
        public virtual DbSet<Utilisateur> Utilisateur { get; set; }
        public virtual DbSet<UtilisateurActualisation> UtilisateurActualisation { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(this._config.GetConnectionString("DefaultConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actualisation>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DateCreation).HasColumnType("datetime");

                entity.Property(e => e.EbaucheEsp)
                    .HasColumnName("EbaucheESP")
                    .HasColumnType("text");

                entity.Property(e => e.EbauchePs)
                    .HasColumnName("EbauchePS")
                    .HasColumnType("text");

                entity.Property(e => e.ModeleTaxonomique)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nom)
                    .HasMaxLength(75)
                    .IsUnicode(false);

                entity.HasOne(d => d.AncienDevisNavigation)
                    .WithMany(p => p.ActualisationAncienDevisNavigation)
                    .HasForeignKey(d => d.AncienDevis)
                    .HasConstraintName("FK__Actualisa__Ancie__47DBAE45");

                entity.HasOne(d => d.AncienneActualisationNavigation)
                    .WithMany(p => p.InverseAncienneActualisationNavigation)
                    .HasForeignKey(d => d.AncienneActualisation)
                    .HasConstraintName("FK__Actualisa__Ancie__48CFD27E");

                entity.HasOne(d => d.DevisNavigation)
                    .WithMany(p => p.ActualisationDevisNavigation)
                    .HasForeignKey(d => d.Devis)
                    .HasConstraintName("FK__Actualisa__Devis__46E78A0C");

                entity.HasOne(d => d.FormationGeneraleNavigation)
                    .WithMany(p => p.InverseFormationGeneraleNavigation)
                    .HasForeignKey(d => d.FormationGenerale)
                    .HasConstraintName("FK__Actualisa__Forma__49C3F6B7");

                entity.HasOne(d => d.ModeleTaxonomiqueNavigation)
                    .WithMany(p => p.Actualisation)
                    .HasForeignKey(d => d.ModeleTaxonomique)
                    .HasConstraintName("FK__Actualisa__Model__4AB81AF0");
            });

            modelBuilder.Entity<AttitudeMethode>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Am)
                    .HasColumnName("AM")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Categorie)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Enonce)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.ActualisationNavigation)
                    .WithMany(p => p.AttitudeMethode)
                    .HasForeignKey(d => d.Actualisation)
                    .HasConstraintName("FK__AttitudeM__Actua__5535A963");
            });

            modelBuilder.Entity<ChoixCours>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.NbAchoisir).HasColumnName("NbAChoisir");

                entity.Property(e => e.Nom)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.ActualisationNavigation)
                    .WithMany(p => p.ChoixCours)
                    .HasForeignKey(d => d.Actualisation)
                    .HasConstraintName("FK__ChoixCour__Actua__6EF57B66");
            });

            modelBuilder.Entity<ChoixCoursCours>(entity =>
            {
                entity.HasKey(e => new { e.ChoixCours, e.Cours });

                entity.HasOne(d => d.ChoixCoursNavigation)
                    .WithMany(p => p.ChoixCoursCours)
                    .HasForeignKey(d => d.ChoixCours)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ChoixCour__Choix__245D67DE");

                entity.HasOne(d => d.CoursNavigation)
                    .WithMany(p => p.ChoixCoursCours)
                    .HasForeignKey(d => d.Cours)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ChoixCour__Cours__25518C17");
            });

            modelBuilder.Entity<ChoixCoursCoursFormationGenerale>(entity =>
            {
                entity.HasOne(d => d.ActualisationNavigation)
                    .WithMany(p => p.ChoixCoursCoursFormationGenerale)
                    .HasForeignKey(d => d.Actualisation)
                    .HasConstraintName("FK__ChoixCour__Actua__29221CFB");

                entity.HasOne(d => d.ChoixCoursNavigation)
                    .WithMany(p => p.ChoixCoursCoursFormationGenerale)
                    .HasForeignKey(d => d.ChoixCours)
                    .HasConstraintName("FK__ChoixCour__Choix__282DF8C2");

                entity.HasOne(d => d.CoursNavigation)
                    .WithMany(p => p.ChoixCoursCoursFormationGenerale)
                    .HasForeignKey(d => d.Cours)
                    .HasConstraintName("FK__ChoixCour__Cours__2A164134");
            });

            modelBuilder.Entity<Commentaire>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Contenu)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.DateCreation).HasColumnType("datetime");

                entity.Property(e => e.Utilisateur)
                    .HasMaxLength(75)
                    .IsUnicode(false);

                entity.Property(e => e.Vue)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.ActualisationNavigation)
                    .WithMany(p => p.Commentaire)
                    .HasForeignKey(d => d.Actualisation)
                    .HasConstraintName("FK__Commentai__Actua__60A75C0F");

                entity.HasOne(d => d.UtilisateurNavigation)
                    .WithMany(p => p.Commentaire)
                    .HasForeignKey(d => d.Utilisateur)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Commentai__Utili__5FB337D6");
            });

            modelBuilder.Entity<Competence>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.ContextesRealisation).HasColumnType("text");

                entity.Property(e => e.Enonce).HasColumnType("text");

                entity.HasOne(d => d.DevisNavigation)
                    .WithMany(p => p.Competence)
                    .HasForeignKey(d => d.Devis)
                    .HasConstraintName("FK__Competenc__Devis__4D94879B");
            });

            modelBuilder.Entity<CompetenceAnalyse>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Competence)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Contexte).HasColumnType("text");

                entity.Property(e => e.Reformulation).HasColumnType("text");

                entity.HasOne(d => d.ActualisationNavigation)
                    .WithMany(p => p.CompetenceAnalyse)
                    .HasForeignKey(d => d.Actualisation)
                    .HasConstraintName("FK__Competenc__Actua__7D439ABD");

                entity.HasOne(d => d.CompetenceNavigation)
                    .WithMany(p => p.CompetenceAnalyse)
                    .HasForeignKey(d => d.Competence)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Competenc__Compe__7E37BEF6");

                entity.HasOne(d => d.NiveauTaxonomiqueNavigation)
                    .WithMany(p => p.CompetenceAnalyse)
                    .HasForeignKey(d => d.NiveauTaxonomique)
                    .HasConstraintName("FK__Competenc__Nivea__7F2BE32F");
            });

            modelBuilder.Entity<CompetenceAnalyseAttitudeMethode>(entity =>
            {
                entity.HasKey(e => new { e.CompetenceAnalyse, e.AttitudeMethode });

                entity.HasOne(d => d.AttitudeMethodeNavigation)
                    .WithMany(p => p.CompetenceAnalyseAttitudeMethode)
                    .HasForeignKey(d => d.AttitudeMethode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Competenc__Attit__0E6E26BF");

                entity.HasOne(d => d.CompetenceAnalyseNavigation)
                    .WithMany(p => p.CompetenceAnalyseAttitudeMethode)
                    .HasForeignKey(d => d.CompetenceAnalyse)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Competenc__Compe__0D7A0286");
            });

            modelBuilder.Entity<CompetenceProfilFormation>(entity =>
            {
                entity.HasKey(e => new { e.Competence, e.ProfilFormation });

                entity.Property(e => e.Competence)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.CompetenceNavigation)
                    .WithMany(p => p.CompetenceProfilFormation)
                    .HasForeignKey(d => d.Competence)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Competenc__Compe__06CD04F7");

                entity.HasOne(d => d.ProfilFormationNavigation)
                    .WithMany(p => p.CompetenceProfilFormation)
                    .HasForeignKey(d => d.ProfilFormation)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Competenc__Profi__07C12930");
            });

            modelBuilder.Entity<ConditionAdmission>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Contenu).HasColumnType("text");

                entity.HasOne(d => d.DevisNavigation)
                    .WithMany(p => p.ConditionAdmission)
                    .HasForeignKey(d => d.Devis)
                    .HasConstraintName("FK__Condition__Devis__440B1D61");
            });

            modelBuilder.Entity<Cours>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Sigle)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Titre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.ActualisationNavigation)
                    .WithMany(p => p.Cours)
                    .HasForeignKey(d => d.Actualisation)
                    .HasConstraintName("FK__Cours__Actualisa__6C190EBB");
            });

            modelBuilder.Entity<CoursCompetence>(entity =>
            {
                entity.HasKey(e => new { e.Cours, e.Competence });

                entity.Property(e => e.Competence).HasColumnType("text");

                entity.HasOne(d => d.CompetenceNavigation)
                    .WithMany(p => p.CoursCompetence)
                    .HasForeignKey(d => d.Competence)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CoursComp__Compe__19DFD96B");

                entity.HasOne(d => d.CoursNavigation)
                    .WithMany(p => p.CoursCompetence)
                    .HasForeignKey(d => d.Cours)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__CoursComp__Cours__18EBB532");
            });

            modelBuilder.Entity<CoursCompetenceEquivalance>(entity =>
            {
                entity.HasKey(e => new { e.Cours, e.Competence1, e.Competence2 });

                entity.Property(e => e.Competence1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Competence2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Competence1Navigation)
                    .WithMany(p => p.CoursCompetenceEquivalanceCompetence1Navigation)
                    .HasForeignKey(d => d.Competence1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CoursComp__Compe__2DE6D218");

                entity.HasOne(d => d.Competence2Navigation)
                    .WithMany(p => p.CoursCompetenceEquivalanceCompetence2Navigation)
                    .HasForeignKey(d => d.Competence2)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CoursComp__Compe__2EDAF651");

                entity.HasOne(d => d.CoursNavigation)
                    .WithMany(p => p.CoursCompetenceEquivalance)
                    .HasForeignKey(d => d.Cours)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CoursComp__Cours__2CF2ADDF");
            });

            modelBuilder.Entity<CoursCoursEquivalance>(entity =>
            {
                entity.HasKey(e => new { e.Cours, e.CoursEquivalant });

                entity.HasOne(d => d.CoursNavigation)
                    .WithMany(p => p.CoursCoursEquivalanceCoursNavigation)
                    .HasForeignKey(d => d.Cours)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CoursCour__Cours__208CD6FA");

                entity.HasOne(d => d.CoursEquivalantNavigation)
                    .WithMany(p => p.CoursCoursEquivalanceCoursEquivalantNavigation)
                    .HasForeignKey(d => d.CoursEquivalant)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CoursCour__Cours__2180FB33");
            });

            modelBuilder.Entity<CoursCoursPrealable>(entity =>
            {
                entity.HasKey(e => new { e.Cours, e.CoursPrealable });

                entity.Property(e => e.Apc)
                    .HasColumnName("APC")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.HasOne(d => d.CoursNavigation)
                    .WithMany(p => p.CoursCoursPrealableCoursNavigation)
                    .HasForeignKey(d => d.Cours)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CoursCour__Cours__1CBC4616");

                entity.HasOne(d => d.CoursPrealableNavigation)
                    .WithMany(p => p.CoursCoursPrealableCoursPrealableNavigation)
                    .HasForeignKey(d => d.CoursPrealable)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CoursCour__Cours__1DB06A4F");
            });

            modelBuilder.Entity<Devis>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CodeProgramme)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DatePublication).HasColumnType("datetime");
            });

            modelBuilder.Entity<Element>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Competence)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CriterePerformance).HasColumnType("text");

                entity.Property(e => e.Enonce).HasColumnType("text");

                entity.HasOne(d => d.CompetenceNavigation)
                    .WithMany(p => p.Element)
                    .HasForeignKey(d => d.Competence)
                    .HasConstraintName("FK__Element__Compete__75A278F5");
            });

            modelBuilder.Entity<ElementAnalyse>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.HasOne(d => d.ActualisationNavigation)
                    .WithMany(p => p.ElementAnalyse)
                    .HasForeignKey(d => d.Actualisation)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ElementAn__Actua__02084FDA");

                entity.HasOne(d => d.ElementNavigation)
                    .WithMany(p => p.ElementAnalyse)
                    .HasForeignKey(d => d.Element)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ElementAn__Eleme__02FC7413");

                entity.HasOne(d => d.NiveauTaxonomiqueNavigation)
                    .WithMany(p => p.ElementAnalyse)
                    .HasForeignKey(d => d.NiveauTaxonomique)
                    .HasConstraintName("FK__ElementAn__Nivea__03F0984C");
            });

            modelBuilder.Entity<FamilleCompetence>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Couleur)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nom)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.ActualisationNavigation)
                    .WithMany(p => p.FamilleCompetence)
                    .HasForeignKey(d => d.Actualisation)
                    .HasConstraintName("FK__FamilleCo__Actua__66603565");
            });

            modelBuilder.Entity<FamilleCompetenceCompetence>(entity =>
            {
                entity.HasKey(e => new { e.FamilleCompetence, e.Competence });

                entity.Property(e => e.Competence)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.CompetenceNavigation)
                    .WithMany(p => p.FamilleCompetenceCompetence)
                    .HasForeignKey(d => d.Competence)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FamilleCo__Compe__123EB7A3");

                entity.HasOne(d => d.FamilleCompetenceNavigation)
                    .WithMany(p => p.FamilleCompetenceCompetence)
                    .HasForeignKey(d => d.FamilleCompetence)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FamilleCo__Famil__114A936A");
            });

            modelBuilder.Entity<Gabarit>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DateCreation).HasColumnType("datetime");

                entity.Property(e => e.IsDefault).HasColumnName("isDefault");

                entity.Property(e => e.Nom)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.ActualisationNavigation)
                    .WithMany(p => p.Gabarit)
                    .HasForeignKey(d => d.Actualisation)
                    .HasConstraintName("FK__Gabarit__Actuali__5165187F");

                entity.HasOne(d => d.GabaritParentNavigation)
                    .WithMany(p => p.InverseGabaritParentNavigation)
                    .HasForeignKey(d => d.GabaritParent)
                    .HasConstraintName("FK__Gabarit__Gabarit__5070F446");

                entity.HasOne(d => d.TypeGabaritNavigation)
                    .WithMany(p => p.Gabarit)
                    .HasForeignKey(d => d.TypeGabarit)
                    .HasConstraintName("FK__Gabarit__TypeGab__52593CB8");
            });

            modelBuilder.Entity<GroupeCompetence>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Couleur)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nom)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.InstanceHeureCompetenceNavigation)
                    .WithMany(p => p.GroupeCompetence)
                    .HasForeignKey(d => d.InstanceHeureCompetence)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__GroupeCom__Insta__0A9D95DB");
            });

            modelBuilder.Entity<HeureComp>(entity =>
            {
                entity.HasKey(e => new { e.Competence, e.NoSession, e.InstanceHeureCompetence });

                entity.Property(e => e.Competence)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.CompetenceNavigation)
                    .WithMany(p => p.HeureComp)
                    .HasForeignKey(d => d.Competence)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__HeureComp__Compe__31B762FC");

                entity.HasOne(d => d.GroupeCompetenceNavigation)
                    .WithMany(p => p.HeureComp)
                    .HasForeignKey(d => d.GroupeCompetence)
                    .HasConstraintName("FK__HeureComp__Group__32AB8735");

                entity.HasOne(d => d.InstanceHeureCompetenceNavigation)
                   .WithMany(p => p.HeureComp)
                   .HasForeignKey(d => d.InstanceHeureCompetence)
                   .OnDelete(DeleteBehavior.Cascade)
                   .HasConstraintName("FK__HeureComp__Insta__236943A5");
            });

            modelBuilder.Entity<InstanceHeureCompetence>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DateCreation).HasColumnType("datetime");

                entity.Property(e => e.DateModification).HasColumnType("datetime");

                entity.Property(e => e.Nom)
                    .HasMaxLength(75)
                    .IsUnicode(false);

                entity.Property(e => e.Utilisateur)
                    .HasMaxLength(75)
                    .IsUnicode(false);

                entity.HasOne(d => d.ActualisationNavigation)
                    .WithMany(p => p.InstanceHeureCompetence)
                    .HasForeignKey(d => d.Actualisation)
                    .HasConstraintName("FK__InstanceH__Actua__787EE5A0");

                entity.HasOne(d => d.ProfilFormationNavigation)
                    .WithMany(p => p.InstanceHeureCompetence)
                    .HasForeignKey(d => d.ProfilFormation)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__InstanceH__Profi__7A672E12");

                entity.HasOne(d => d.UtilisateurNavigation)
                    .WithMany(p => p.InstanceHeureCompetence)
                    .HasForeignKey(d => d.Utilisateur)
                    .HasConstraintName("FK__InstanceH__Utili__797309D9");
            });

            modelBuilder.Entity<ModeleTaxonomique>(entity =>
            {
                entity.HasKey(e => e.Nom);

                entity.Property(e => e.Nom)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.DateCreation).HasColumnType("datetime");

                entity.Property(e => e.IsAvailable).HasColumnName("isAvailable");
            });

            modelBuilder.Entity<NiveauTaxonomique>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ModeleTaxonomique)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ordre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Terme)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.ModeleTaxonomiqueNavigation)
                    .WithMany(p => p.NiveauTaxonomique)
                    .HasForeignKey(d => d.ModeleTaxonomique)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__NiveauTax__Model__412EB0B6");
            });

            modelBuilder.Entity<PointGabarit>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Contenu).HasColumnType("text");

                entity.Property(e => e.Enonce)
                    .HasMaxLength(75)
                    .IsUnicode(false);

                entity.HasOne(d => d.GabaritNavigation)
                    .WithMany(p => p.PointGabarit)
                    .HasForeignKey(d => d.Gabarit)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__PointGaba__Gabar__71D1E811");

                entity.HasOne(d => d.ParentPointGabaritNavigation)
                    .WithMany(p => p.InverseParentPointGabaritNavigation)
                    .HasForeignKey(d => d.ParentPointGabarit)
                    .HasConstraintName("FK__PointGaba__Paren__72C60C4A");
            });

            modelBuilder.Entity<ProfilFormation>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Nom)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.ActualisationNavigation)
                    .WithMany(p => p.ProfilFormation)
                    .HasForeignKey(d => d.Actualisation)
                    .HasConstraintName("FK__ProfilFor__Actua__6383C8BA");
            });

            modelBuilder.Entity<Rapport>(entity =>
            {
                entity.HasKey(e => new { e.DateCreation, e.Actualisation, e.TypeRapport });

                entity.Property(e => e.DateCreation).HasColumnType("datetime");

                entity.Property(e => e.LienRapport).HasColumnType("text");

                entity.HasOne(d => d.ActualisationNavigation)
                    .WithMany(p => p.Rapport)
                    .HasForeignKey(d => d.Actualisation)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Rapport__Actuali__5812160E");

                entity.HasOne(d => d.TypeRapportNavigation)
                    .WithMany(p => p.Rapport)
                    .HasForeignKey(d => d.TypeRapport)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Rapport__TypeRap__59063A47");
            });

            modelBuilder.Entity<SequenceCompetence>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Nom)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.ActualisationNavigation)
                    .WithMany(p => p.SequenceCompetence)
                    .HasForeignKey(d => d.Actualisation)
                    .HasConstraintName("FK__SequenceC__Actua__693CA210");
            });

            modelBuilder.Entity<SequenceCompetenceCompetence>(entity =>
            {
                entity.HasKey(e => new { e.SequenceCompetence, e.Competence });

                entity.Property(e => e.Competence)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.CompetenceNavigation)
                    .WithMany(p => p.SequenceCompetenceCompetence)
                    .HasForeignKey(d => d.Competence)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SequenceC__Compe__160F4887");

                entity.HasOne(d => d.SequenceCompetenceNavigation)
                    .WithMany(p => p.SequenceCompetenceCompetence)
                    .HasForeignKey(d => d.SequenceCompetence)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SequenceC__Seque__151B244E");
            });

            modelBuilder.Entity<TypeGabarit>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Nom)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TypeRapport>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Nom)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Utilisateur>(entity =>
            {
                entity.HasKey(e => e.Courriel);

                entity.Property(e => e.Courriel)
                    .HasMaxLength(75)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.MotDePasse)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nom)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Prenom)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Titre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UtilisateurActualisation>(entity =>
            {
                entity.HasKey(e => new { e.Actualisation, e.Utilisateur });

                entity.Property(e => e.Utilisateur)
                    .HasMaxLength(75)
                    .IsUnicode(false);

                entity.Property(e => e.Rm)
                    .HasColumnName("RM")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.HasOne(d => d.ActualisationNavigation)
                    .WithMany(p => p.UtilisateurActualisation)
                    .HasForeignKey(d => d.Actualisation)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Utilisate__Actua__5BE2A6F2");

                entity.HasOne(d => d.UtilisateurNavigation)
                    .WithMany(p => p.UtilisateurActualisation)
                    .HasForeignKey(d => d.Utilisateur)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Utilisate__Utili__5CD6CB2B");
            });
        }
    }
}
