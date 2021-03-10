CREATE DATABASE OutilActualisation
GO

USE OutilActualisation
GO

-----------Tier 1
CREATE TABLE TypeRapport(
	ID int IDENTITY(1,1) PRIMARY KEY, 
	Nom varchar(50)
)
GO
CREATE TABLE TypeGabarit(
	ID int IDENTITY(1,1) PRIMARY KEY, 
	Nom varchar(50)
)
GO
CREATE TABLE ModeleTaxonomique( 
	Nom varchar(50) PRIMARY KEY,
	DateCreation datetime,
	isAvailable bit
)
GO
CREATE TABLE Devis( 
	ID int IDENTITY(1,1) PRIMARY KEY,
	CodeProgramme varchar(50),
	DatePublication datetime
)
GO
CREATE TABLE Utilisateur( 
	Courriel varchar(75) PRIMARY KEY,
	MotDePasse text,
	Salt text,
	Titre varchar(50),
	Nom varchar(50),
	Prenom varchar(50),
	IsAdmin bit,
	IsActive bit
)
GO
-----------Tier 2
CREATE TABLE NiveauTaxonomique( 
	ID int IDENTITY(1,1) PRIMARY KEY,
	Ordre varchar(50),
	Terme varchar(50),
	ModeleTaxonomique varchar(50) FOREIGN KEY REFERENCES ModeleTaxonomique(Nom) ON DELETE CASCADE
)
GO
CREATE TABLE ConditionAdmission( 
	ID int IDENTITY(1,1) PRIMARY KEY,
	Ordre int,
	Contenu text,
	Devis int FOREIGN KEY REFERENCES Devis(ID)
)
GO
CREATE TABLE Actualisation( 
	ID int IDENTITY(1,1) PRIMARY KEY,
	Nom varchar(75),
	DateCreation datetime,
	EbaucheESP text,
	EbauchePS text,
	Devis int FOREIGN KEY REFERENCES Devis(ID) NULL,
	AncienDevis int FOREIGN KEY REFERENCES Devis(ID) NULL,
	AncienneActualisation int FOREIGN KEY REFERENCES Actualisation(ID) NULL,
	FormationGenerale int FOREIGN KEY REFERENCES Actualisation(ID) NULL,
	ModeleTaxonomique varchar(50) FOREIGN KEY REFERENCES ModeleTaxonomique(Nom) NULL
)
GO
CREATE TABLE Competence( 
	Code varchar(50) PRIMARY KEY,
	Enonce text,
	Devis int FOREIGN KEY REFERENCES Devis(ID) NULL,
	ContextesRealisation text,
	IsObligatoire bit
)
GO
CREATE TABLE Gabarit( 
	ID int IDENTITY(1,1) PRIMARY KEY,
	Nom varchar(50),
	DateCreation datetime,
	isDefault bit,
	GabaritParent int FOREIGN KEY REFERENCES Gabarit(ID) NULL,
	Actualisation int FOREIGN KEY REFERENCES Actualisation(ID) NULL,
	TypeGabarit int FOREIGN KEY REFERENCES TypeGabarit(ID)
)
GO
CREATE TABLE AttitudeMethode( 
	ID int IDENTITY(1,1) PRIMARY KEY,
	AM char,
	Categorie varchar(50),
	Enonce varchar(100),
	Actualisation int FOREIGN KEY REFERENCES Actualisation(ID)
)
GO

CREATE TABLE Rapport( 
	DateCreation datetime,
	Actualisation int FOREIGN KEY REFERENCES Actualisation(ID),
	TypeRapport int FOREIGN KEY REFERENCES TypeRapport(ID),
	PRIMARY KEY(DateCreation,Actualisation,TypeRapport),
	LienRapport text
)
GO
CREATE TABLE UtilisateurActualisation( 
	Actualisation int FOREIGN KEY REFERENCES Actualisation(ID),
	Utilisateur varchar(75) FOREIGN KEY REFERENCES Utilisateur(Courriel),
	PRIMARY KEY(Actualisation,Utilisateur),
	RM char
)
GO
CREATE TABLE Commentaire( 
	ID int IDENTITY(1,1) PRIMARY KEY,
	DateCreation datetime,
	Vue varchar(50),
	Contenu varchar(300),
	Utilisateur varchar(75) FOREIGN KEY REFERENCES Utilisateur(Courriel) ON DELETE CASCADE,
	Actualisation int FOREIGN KEY REFERENCES Actualisation(ID)
)
GO
-----------Tier 3
CREATE TABLE ProfilFormation(
	ID int IDENTITY(1,1) PRIMARY KEY, 
	Nom varchar(50),
	Actualisation int FOREIGN KEY REFERENCES Actualisation(ID)
)
GO
CREATE TABLE FamilleCompetence(
	ID int IDENTITY(1,1) PRIMARY KEY, 
	Nom varchar(50),
	Couleur varchar(50),
	Actualisation int FOREIGN KEY REFERENCES Actualisation(ID)
)
GO
CREATE TABLE SequenceCompetence(
	ID int IDENTITY(1,1) PRIMARY KEY, 
	Nom varchar(50),
	Actualisation int FOREIGN KEY REFERENCES Actualisation(ID)
)
GO
CREATE TABLE Cours(
	ID int IDENTITY(1,1) PRIMARY KEY, 
	Sigle varchar(50),
	Titre text,
	NoSession int NULL,
	PondT int NULL,
	PondL int NULL,
	PondP int NULL,
	IsOld bit,
	IsGeneral bit,
	Actualisation int FOREIGN KEY REFERENCES Actualisation(ID)
)
GO
CREATE TABLE ChoixCours(
	ID int IDENTITY(1,1) PRIMARY KEY, 
	Nom varchar(50),
	NbAChoisir int NULL,
	Actualisation int FOREIGN KEY REFERENCES Actualisation(ID)
)
GO
CREATE TABLE PointGabarit(
	ID int IDENTITY(1,1) PRIMARY KEY, 
	Ordre int,
	Enonce varchar(75),
	Contenu text,
	Gabarit int FOREIGN KEY REFERENCES Gabarit(ID) ON DELETE CASCADE,
	ParentPointGabarit int FOREIGN KEY REFERENCES PointGabarit(ID) NULL
)
GO
CREATE TABLE Element(
	ID int IDENTITY(1,1) PRIMARY KEY, 
	Ordre int,
	Enonce text,
	CriterePerformance text,
	Competence varchar(50) FOREIGN KEY REFERENCES Competence(Code)
)
GO

-- Drop table
CREATE TABLE InstanceHeureCompetence(
	ID int IDENTITY(1,1) PRIMARY KEY, 
	Nom varchar(75),
	DateCreation datetime,
	DateModification datetime NULL,
	IsOfficiel bit,
	Actualisation int FOREIGN KEY REFERENCES Actualisation(ID),
	Utilisateur varchar(75) FOREIGN KEY REFERENCES Utilisateur(Courriel) NULL,
	ProfilFormation int FOREIGN KEY REFERENCES ProfilFormation(ID) ON DELETE CASCADE
)
GO
CREATE TABLE CompetenceAnalyse( 	
	ID int IDENTITY(1,1) PRIMARY KEY, 
	Reformulation text,
	Contexte text,
	NbHeureApp int NULL,
	Actualisation int FOREIGN KEY REFERENCES Actualisation(ID),
	Competence varchar(50) FOREIGN KEY REFERENCES Competence(Code) ON DELETE CASCADE,
	NiveauTaxonomique int FOREIGN KEY REFERENCES NiveauTaxonomique(ID) NULL
)
GO

CREATE TABLE ElementAnalyse( 
	ID int IDENTITY(1,1) PRIMARY KEY,
	Actualisation int FOREIGN KEY REFERENCES Actualisation(ID),
	Element int FOREIGN KEY REFERENCES Element(ID),
	NiveauTaxonomique int FOREIGN KEY REFERENCES NiveauTaxonomique(ID) NULL
)
GO
CREATE TABLE CompetenceProfilFormation( 
	Competence varchar(50) FOREIGN KEY REFERENCES Competence(Code),
	ProfilFormation int FOREIGN KEY REFERENCES ProfilFormation(ID),
	PRIMARY KEY(Competence,ProfilFormation)
)
GO
-----------Tier 4

--drop
CREATE TABLE GroupeCompetence(
	ID int IDENTITY(1,1) PRIMARY KEY, 
	Nom varchar(50),
	Couleur varchar(50),
	InstanceHeureCompetence int FOREIGN KEY REFERENCES InstanceHeureCompetence(ID) ON DELETE CASCADE
)
GO

CREATE TABLE CompetenceAnalyseAttitudeMethode( 
	CompetenceAnalyse int FOREIGN KEY REFERENCES CompetenceAnalyse(ID),
	AttitudeMethode int FOREIGN KEY REFERENCES AttitudeMethode(ID),
	PRIMARY KEY(CompetenceAnalyse,AttitudeMethode)
)
GO
CREATE TABLE FamilleCompetenceCompetence( 
	FamilleCompetence int FOREIGN KEY REFERENCES FamilleCompetence(ID),
	Competence varchar(50) FOREIGN KEY REFERENCES Competence(Code),
	PRIMARY KEY(FamilleCompetence,Competence)
)
GO
-- DROP LA TABLE et la refaire
CREATE TABLE SequenceCompetenceCompetence( 
	SequenceCompetence int FOREIGN KEY REFERENCES SequenceCompetence(ID),
	Competence varchar(50) FOREIGN KEY REFERENCES Competence(Code),
	Ordre int,
	PRIMARY KEY(SequenceCompetence,Competence)
)
GO
-- DROP LA TABLE et la refaire
CREATE TABLE CoursCompetence( 
	Cours int FOREIGN KEY REFERENCES Cours(ID) ON DELETE CASCADE,
	Competence varchar(50) FOREIGN KEY REFERENCES Competence(Code),
	NbHeures int,
	PRIMARY KEY(Cours,Competence)
)
GO
CREATE TABLE CoursCoursPrealable( 
	Cours int FOREIGN KEY REFERENCES Cours(ID),
	CoursPrealable int FOREIGN KEY REFERENCES Cours(ID),
	PRIMARY KEY(Cours,CoursPrealable),
	APC char
)
GO
CREATE TABLE CoursCoursEquivalance( 
	Cours int FOREIGN KEY REFERENCES Cours(ID),
	CoursEquivalant int FOREIGN KEY REFERENCES Cours(ID),
	PRIMARY KEY(Cours,CoursEquivalant)
)
GO
CREATE TABLE ChoixCoursCours( 
	ChoixCours int FOREIGN KEY REFERENCES ChoixCours(ID) ON DELETE CASCADE,
	Cours int FOREIGN KEY REFERENCES Cours(ID),
	PRIMARY KEY(ChoixCours,Cours)
)
GO
CREATE TABLE ChoixCoursCoursFormationGenerale(
	Id int IDENTITY(1,1) PRIMARY KEY, 
	ChoixCours int FOREIGN KEY REFERENCES ChoixCours(ID),
	Actualisation int FOREIGN KEY REFERENCES Actualisation(ID) NULL,
	Cours int FOREIGN KEY REFERENCES Cours(ID) NULL
)
GO

CREATE TABLE CoursCompetenceEquivalance( 
	Cours int FOREIGN KEY REFERENCES Cours(ID),
	Competence1 varchar(50) FOREIGN KEY REFERENCES Competence(Code),
	Competence2 varchar(50) FOREIGN KEY REFERENCES Competence(Code),
	PRIMARY KEY(Cours,Competence1,Competence2)
)
GO
-----------Tier 5
-- DROP TABLE et la refaire
CREATE TABLE HeureComp( 	
	Competence varchar(50) FOREIGN KEY REFERENCES Competence(Code),
	NoSession int,
	PRIMARY KEY(Competence,NoSession,InstanceHeureCompetence),
	GroupeCompetence int FOREIGN KEY REFERENCES GroupeCompetence(ID) NULL,
	InstanceHeureCompetence int FOREIGN KEY REFERENCES InstanceHeureCompetence(ID) ON DELETE CASCADE,
	NbHeure int
)
GO


-----------Insertion de données

INSERT INTO Utilisateur VALUES('testmvc98@outlook.com', '152435674883855559c030cdafec96d9a99e635a7d6bc31eca90e7d1293cd8d2', 'acvasdasdafadsada','Testeur', 'Groulx', 'Marika', 1, 1)
GO

INSERT INTO Devis VALUES('420.B0', GETDATE())
GO

INSERT INTO TypeGabarit VALUES('Analyse de la profession'),('Unités et heures'),('Finalités')
GO

-- Gabarits par défaut
INSERT INTO Gabarit VALUES('Finalités par défaut', CONVERT(datetime, '19-11-2018', 105), 1, NULL, NULL, 3)
GO

INSERT INTO Gabarit VALUES('Unités et heures par défaut', CONVERT(datetime, '22-11-2018', 105), 1, NULL, NULL, 2)
GO

INSERT INTO Gabarit VALUES('Analyse de la profession par défaut', CONVERT(datetime, '22-11-2018', 105), 1, NULL, NULL, 1)
GO

-- Points pour Analyse de la profession
INSERT INTO PointGabarit VALUES (1, 'Définition de la profession', '', 3, NULL),
								(2, 'Caractéristiques des entreprises et de l''emploi', '', 3, NULL),
								(3, 'Types d''emploi offert', '', 3, NULL),
								(4, 'Santé et sécurité', '', 3, NULL),
								(5, 'Conditions de travail', '', 3, 4),
								(6, 'Statut d''emploi', '', 3, 4),
								(7, 'Horaire de travail typique', '', 3, 4),
								(8, 'Rénumération type', '', 3, 4),
								(9, 'Facteurs de stress', '', 3, 4),
								(10, 'Organisation du travail', '', 3, NULL),
								(11, 'Collaboration', '', 3, 10),
								(12, 'Niveau de responsabilité', '', 3, 10),
								(13, 'Autres', '', 3, 10),
								(14, 'Conditions d''entrée sur le marché', '', 3, NULL),
								(15, 'Qualités et aptitudes', '', 3, 14),
								(16, 'Qualification', '', 3, 14),
								(17, 'Cheminement de carrière', '', 3, 14),
								(18, 'Changements à venir', '', 3, NULL),
								(19, 'Analyse des tâches', '', 3, NULL),
								(20, 'Opérations', '', 3, 19),
								(21, 'Conditions', '', 3, 19),
								(22, 'Exigences de réalisation', '', 3, 19),
								(23, 'Fonctions de travail', '', 3, NULL),
								(24, 'Occurence, importance, temps de travail, difficultés des tâches, etc.', '', 3, 23),
								(25, 'Connaissances requises', '', 3, NULL),
								(26, 'Habiletés requises', '', 3, NULL),
								(27, 'Cognitives', '', 3, 26),
								(28, 'Motrices', '', 3, 26),
								(29, 'Kinesthésiques', '', 3, 26),
								(30, 'Perceptives', '', 3, 26),
								(31, 'Comportements socioaffectifs', '', 3, NULL),
								(32, 'Communication interpersonnelle', '', 3, 31),
								(33, 'Éthique professionnelle', '', 3, 31),
								(34, 'Santé et sécurité', '', 3, 31)
GO

-- Points pour Unités et heures
INSERT INTO PointGabarit VALUES (1, 'Date de publication', '', 2, NULL),
								(2, 'Totaux du programme', '', 2, NULL),
								(3, 'Nombre minimal d''unités', '', 2, 36),
								(4, 'Nombre maximal d''unités', '', 2, 36),
								(5, 'Nombre minimal d''heures', '', 2, 36),
								(6, 'Nombre maximal d''heures', '', 2, 36),
								(7, 'Formation générale', '', 2, NULL),
								(8, 'Nombre d''unités', '', 2, 41),
								(9, 'Nombre d''heures', '', 2, 41),
								(10, 'Formation spécifique', '', 2, NULL),
								(11, 'Nombre total minimal d''unités', '', 2, 44),
								(12, 'Nombre total maximal d''unités', '', 2, 44),
								(13, 'Nombre d''unités obligatoires', '', 2, 44),
								(14, 'Nombre minimal d''unités optionnelles', '', 2, 44),
								(15, 'Nombre maximal d''unités optionnelles', '', 2, 44),
								(16, 'Nombre total minimal d''heures', '', 2, 44),
								(17, 'Nombre total maximal d''heures', '', 2, 44),
								(18, 'Nombre de compétences obligatoires', '', 2, 44),
								(19, 'Nombre de compétences optionnelles', '', 2, 44)
GO

-- Points pour Finalités
INSERT INTO PointGabarit VALUES (1, 'Visées de la formation spécifique', '', 1, NULL),
								(2, 'Intentions éducatives', '', 1, NULL),
								(3, 'Finalilité du programme d''études', '', 1, NULL),
								(4, 'Conditions à l''entrée dans le programme', '', 1, NULL),
								(5, 'Visées de la formation spécifique', '', 1, NULL)
GO

INSERT INTO ModeleTaxonomique VALUES('Taxonomie de Bloom', GETDATE(), 1)
GO

INSERT INTO NiveauTaxonomique VALUES(1, 'Mémoriser', 'Taxonomie de Bloom'),(2, 'Comprendre', 'Taxonomie de Bloom'),(3, 'Appliquer', 'Taxonomie de Bloom'),(4, 'Analyser', 'Taxonomie de Bloom'),(5, 'Évaluer', 'Taxonomie de Bloom'),(6, 'Créer', 'Taxonomie de Bloom')
GO

INSERT INTO Actualisation VALUES('Formation générale 1990', GETDATE(), '', '', NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO Actualisation VALUES('Techniques de l''informatique', GETDATE(), '', '', 1, NULL, NULL, 1, NULL)
GO

INSERT INTO UtilisateurActualisation VALUES( 2,'testmvc98@outlook.com', 'R')
GO

-- Gabarits pour actualisation 2
INSERT INTO Gabarit VALUES('A', CONVERT(datetime, '19-11-2018', 105), 0, 1, 2, 3)
GO

INSERT INTO Gabarit VALUES('N', CONVERT(datetime, '19-11-2018', 105), 0, 1, 2, 3)
GO

INSERT INTO Gabarit VALUES('A', CONVERT(datetime, '19-11-2018', 105), 0, 2, 2, 2)
GO

INSERT INTO Gabarit VALUES('N', CONVERT(datetime, '19-11-2018', 105), 0, 2, 2, 2)
GO

INSERT INTO Gabarit VALUES('N', CONVERT(datetime, '19-11-2018', 105), 0, 3, 2, 1)
GO

-- Points pour actualisation 2 finalités ancien devis
INSERT INTO PointGabarit VALUES (1, 'Visées de la formation spécifique', '', 4, NULL),
								(2, 'Intentions éducatives', '', 4, NULL),
								(3, 'Finalilité du programme d''études', '', 4, NULL),
								(4, 'Conditions à l''entrée dans le programme', '', 4, NULL),
								(5, 'Visées de la formation spécifique', '', 4, NULL)
GO

-- Points pour actualisation 2 finalités nouveau devis
INSERT INTO PointGabarit VALUES (1, 'Visées de la formation spécifique', '', 5, NULL),
								(2, 'Intentions éducatives', '', 5, NULL),
								(3, 'Finalilité du programme d''études', '', 5, NULL),
								(4, 'Conditions à l''entrée dans le programme', '', 5, NULL),
								(5, 'Visées de la formation spécifique', '', 5, NULL)
GO

-- Points pour actualisation 2 unités et heures ancien devis
INSERT INTO PointGabarit VALUES (1, 'Date de publication', '', 6, NULL),
								(2, 'Totaux du programme', '', 6, NULL),
								(3, 'Nombre minimal d''unités', '', 6, 70),
								(4, 'Nombre maximal d''unités', '', 6, 70),
								(5, 'Nombre minimal d''heures', '', 6, 70),
								(6, 'Nombre maximal d''heures', '', 6, 70),
								(7, 'Formation générale', '', 6, NULL),
								(8, 'Nombre d''unités', '', 6, 75),
								(9, 'Nombre d''heures', '', 6, 75),
								(10, 'Formation spécifique', '', 6, NULL),
								(11, 'Nombre total minimal d''unités', '', 6, 78),
								(12, 'Nombre total maximal d''unités', '', 6, 78),
								(13, 'Nombre d''unités obligatoires', '', 6, 78),
								(14, 'Nombre minimal d''unités optionnelles', '', 6, 78),
								(15, 'Nombre maximal d''unités optionnelles', '', 6, 78),
								(16, 'Nombre total minimal d''heures', '', 6, 78),
								(17, 'Nombre total maximal d''heures', '', 6, 78),
								(18, 'Nombre de compétences obligatoires', '', 6, 78),
								(19, 'Nombre de compétences optionnelles', '', 6, 78)
GO

-- Points pour actualisation 2 unités et heures nouveau devis
INSERT INTO PointGabarit VALUES (1, 'Date de publication', '', 7, NULL),
								(2, 'Totaux du programme', '', 7, NULL),
								(3, 'Nombre minimal d''unités', '', 7, 89),
								(4, 'Nombre maximal d''unités', '', 7, 89),
								(5, 'Nombre minimal d''heures', '', 7, 89),
								(6, 'Nombre maximal d''heures', '', 7, 89),
								(7, 'Formation générale', '', 7, NULL),
								(8, 'Nombre d''unités', '', 7, 94),
								(9, 'Nombre d''heures', '', 7, 94),
								(10, 'Formation spécifique', '', 7, NULL),
								(11, 'Nombre total minimal d''unités', '', 7, 97),
								(12, 'Nombre total maximal d''unités', '', 7, 97),
								(13, 'Nombre d''unités obligatoires', '', 7, 97),
								(14, 'Nombre minimal d''unités optionnelles', '', 7, 97),
								(15, 'Nombre maximal d''unités optionnelles', '', 7, 97),
								(16, 'Nombre total minimal d''heures', '', 7, 97),
								(17, 'Nombre total maximal d''heures', '', 7, 97),
								(18, 'Nombre de compétences obligatoires', '', 7, 97),
								(19, 'Nombre de compétences optionnelles', '', 7, 97)
GO

-- Points pour actualisation 2 analyse profession ancien devis
INSERT INTO PointGabarit VALUES (1, 'Définition de la profession', '', 8, NULL),
								(2, 'Caractéristiques des entreprises et de l''emploi', '', 8, NULL),
								(3, 'Types d''emploi offert', '', 8, NULL),
								(4, 'Santé et sécurité', '', 8, NULL),
								(5, 'Conditions de travail', '', 8, 110),
								(6, 'Statut d''emploi', '', 8, 110),
								(7, 'Horaire de travail typique', '', 8, 110),
								(8, 'Rénumération type', '', 8, 110),

								(9, 'Facteurs de stress', '', 8, 110),
								(10, 'Organisation du travail', '', 8, NULL),
								(11, 'Collaboration', '', 8, 116),
								(12, 'Niveau de responsabilité', '', 8, 116),
								(13, 'Autres', '', 8, 116),
								(14, 'Conditions d''entrée sur le marché', '', 8, NULL),
								(15, 'Qualités et aptitudes', '', 8, 120),
								(16, 'Qualification', '', 8, 120),
								(17, 'Cheminement de carrière', '', 8, 120),
								(18, 'Changements à venir', '', 8, NULL),
								(19, 'Analyse des tâches', '', 8, NULL),
								(20, 'Opérations', '', 8, 125),
								(21, 'Conditions', '', 8, 125),
								(22, 'Exigences de réalisation', '', 8, 125),
								(23, 'Fonctions de travail', '', 8, NULL),
								(24, 'Occurence, importance, temps de travail, difficultés des tâches, etc.', '', 8, 129),
								(25, 'Connaissances requises', '', 8, NULL),
								(26, 'Habiletés requises', '', 8, NULL),
								(27, 'Cognitives', '', 8, 132),
								(28, 'Motrices', '', 8, 132),
								(29, 'Kinesthésiques', '', 8, 132),
								(30, 'Perceptives', '', 8, 132),
								(31, 'Comportements socioaffectifs', '', 8, NULL),
								(32, 'Communication interpersonnelle', '', 8, 137),
								(33, 'Éthique professionnelle', '', 8, 137),
								(34, 'Santé et sécurité', '', 8, 137)
GO


delete from PointGabarit where Enonce = 'Date de publication'
go