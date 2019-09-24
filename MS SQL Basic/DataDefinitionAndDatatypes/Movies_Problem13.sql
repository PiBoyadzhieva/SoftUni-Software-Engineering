CREATE DATABASE Movies;
USE Movies;

CREATE TABLE Directors
(Id           INT
 PRIMARY KEY IDENTITY, 
 DirectorName NVARCHAR(30)
 UNIQUE NOT NULL, 
 Notes        NVARCHAR(MAX)
);

CREATE TABLE Genres
(Id        INT
 PRIMARY KEY IDENTITY, 
 GenreName NVARCHAR(30)
 UNIQUE NOT NULL, 
 Notes     NVARCHAR(MAX)
);

CREATE TABLE Categories
(Id           INT
 PRIMARY KEY IDENTITY, 
 CategoryName NVARCHAR(30)
 UNIQUE NOT NULL, 
 Notes        NVARCHAR(MAX)
);

CREATE TABLE Movies
(Id            INT
 PRIMARY KEY IDENTITY, 
 Title         NVARCHAR(50)
 UNIQUE NOT NULL, 
 DirectorId    INT FOREIGN KEY REFERENCES Directors(Id), 
 CopyrightYear DATE NOT NULL, 
 [Length]      DECIMAL(3, 2) NOT NULL, 
 GenreId       INT FOREIGN KEY REFERENCES Genres(Id), 
 CategoryId    INT FOREIGN KEY REFERENCES Categories(Id), 
 Raiting       DECIMAL(2, 1), 
 Notes         NVARCHAR(MAX)
);

INSERT INTO Directors(DirectorName, Notes)
VALUES		('Pesho', NULL),
		('Gosho', NULL),
		('Ivan', NULL),
		('Mariq', 'Hi!'),
		('Mitko', 'How are you?')

INSERT INTO Genres(GenreName, Notes)
VALUES		('Romantic', NULL),
		('Drama', NULL),
		('Action', NULL),
		('Historical', NULL),
		('Comedy', NULL)

INSERT INTO Categories(CategoryName, Notes)
VALUES		('Category1', NULL),
		('Category2', NULL),
		('Category3', NULL),
		('Category4', NULL),
		('Category5', NULL)

INSERT INTO Movies
			(Title, DirectorId, CopyrightYear, [Length], GenreId, CategoryId, Raiting, Notes)
VALUES
			('First', 1, '1982', '2.30', 3, 1, 9.5, NULL),
			('Second', 2, '2008', '1.35', 2, 2, 6.8, NULL),
			('Third', 3, '2010', '1.59', 1, 3, 5.2, NULL),
			('Fourth', 4, '2011', '2.11', 5, 4, 7.8, NULL),
			('Fifth', 5, '2012', '2.15', 4, 5, 8.4, NULL)

SELECT *
FROM Movies;