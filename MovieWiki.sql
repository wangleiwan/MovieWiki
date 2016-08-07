--USE MovieWiki;
--GO

DROP TABLE WikiArticleEditHistory;
DROP TABLE ArticleSection;
DROP TABLE WikiArticle;
DROP TABLE UserAccount;
--DROP DATABASE MovieWiki;

--CREATE DATABASE MovieWiki;

CREATE TABLE UserAccount
  (
     AccountId  INT IDENTITY(1, 1),
     Username   VARCHAR(50) NOT NULL,
     [Password] VARCHAR(50) NOT NULL,
     CONSTRAINT UserAccount_AccountId_pk 
		PRIMARY KEY (AccountId),
     CONSTRAINT UserAccount_Username_uq	
		UNIQUE (Username)
  );

CREATE TABLE WikiArticle
  (
     ArticleId     INT IDENTITY(1, 1),
     Author        INT,
     ArticleType   VARCHAR(20) NOT NULL,
     Title         VARCHAR(50) NOT NULL,
     [Description] TEXT NOT NULL,
     CONSTRAINT WikiArticle_ArticleId_pk 
		PRIMARY KEY (ArticleId),
     CONSTRAINT WikiArticle_Author_fk 
		FOREIGN KEY (Author) 
		REFERENCES UserAccount (AccountId),
     CONSTRAINT WikiArticle_Title_uq 
		UNIQUE (Title)
  );

CREATE TABLE ArticleSection
  (
     SectionId     INT IDENTITY(1, 1),
     ArticleId     INT,
     SectionType   VARCHAR(20) NOT NULL,
     Caption       VARCHAR(50) NOT NULL,
     [Description] TEXT NOT NULL,
     CONSTRAINT ArticleSection_SectionId_pk 
		PRIMARY KEY (SectionId),
     CONSTRAINT ArticleSection_ArticleId_fk 
		FOREIGN KEY (ArticleId) 
		REFERENCES WikiArticle (ArticleId)
  );

CREATE TABLE WikiArticleEditHistory
  (
     EditId        INT IDENTITY(1, 1),
     ArticleId     INT,
     AccountId     INT,
     EditTimestamp DATETIME NOT NULL,
     CONSTRAINT WikiArticleEditHistory_EditId_pk 
		PRIMARY KEY (EditId),
     CONSTRAINT WikiArticleEditHistory_ArticleId_fk 
		FOREIGN KEY (ArticleId)
		REFERENCES WikiArticle (ArticleId),
     CONSTRAINT WikiArticleEditHistory_AccountId_fk 
		FOREIGN KEY (AccountId)
		REFERENCES UserAccount (AccountId)
  ); 

INSERT INTO UserAccount
VALUES ('Nick', 'pw');

SELECT * FROM UserAccount;