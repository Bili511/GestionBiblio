CREATE TABLE Adresses(
	idAdresse INT PRIMARY KEY IDENTITY NOT NULL,
	[Numéro civique] INT NOT NULL,
	Rue VARCHAR(200) NOT NULL,
	Ville VARCHAR(200) NOT NULL,
	[Code postal] CHAR(6) NOT NULL CHECK([Code postal] LIKE '[A-Z][0-9][A-Z][0-9][A-Z][0-9]')
)
GO
CREATE TABLE Membres(
	idMembre INT PRIMARY KEY IDENTITY NOT NULL,
	idAdresse INT NOT NULL ,
	Nom VARCHAR(30) NOT NULL,
	[Prénom] VARCHAR(30) NOT NULL,
	[Date_naissance] DATE NOT NULL,
	[Courriel] VARCHAR(200),
	[Téléphone] BIGINT NOT NULL,
	CONSTRAINT fk_iAdresse FOREIGN KEY (idAdresse) REFERENCES Adresses(idAdresse)ON DELETE CASCADE,
	CONSTRAINT tel CHECK([Téléphone] LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]')
)
GO
CREATE TABLE Livres(
	idLivre INT PRIMARY KEY IDENTITY NOT NULL,
	ISBN VARCHAR(200) NOT NULL,
	Titre VARCHAR(200) NOT NULL,
	Auteur VARCHAR(200) NOT NULL,
	[Année Édition] INT NOT NULL,
	[Catégorie] VARCHAR(200) NOT NULL	
)
GO
CREATE TABLE Emprunts(
	idEmprunt INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	idMembre INT NOT NULL,
	idLivre INT  NOT NULL,
	Date_Emprunt DATE DEFAULT CONVERT(date, getdate()),
	Date_Retour DATE ,	
	CONSTRAINT diff_date CHECK(Emprunts.Date_Emprunt <= Emprunts.Date_Retour),
	CONSTRAINT fk_idMembre FOREIGN KEY(idMembre) REFERENCES Membres(idMembre) ON DELETE CASCADE,
	CONSTRAINT fk_idLivre FOREIGN KEY (idLivre) REFERENCES Livres(idLivre) ON DELETE CASCADE	
)
