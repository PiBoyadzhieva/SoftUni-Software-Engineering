--Problem 1
CREATE DATABASE Minions;
GO
USE Minions;

--Problem 2
CREATE TABLE Minions
(Id     INT NOT NULL, 
 [Name] NVARCHAR(50) NOT NULL, 
 Age    INT NOT NULL
);

CREATE TABLE Towns
(id     INT NOT NULL, 
 [name] NVARCHAR(50) NOT NULL
);

ALTER TABLE Minions DROP COLUMN Age;
ALTER TABLE Minions
ADD Age INT;

ALTER TABLE Minions
ADD CONSTRAINT PK_Id PRIMARY KEY(Id);

ALTER TABLE Towns
ADD CONSTRAINT Town_Id PRIMARY KEY(Id);

--Problem 3
ALTER TABLE Minions
ADD TownId INT;

ALTER TABLE Minions
ADD CONSTRAINT FK_MinionTownId FOREIGN KEY(TownId) REFERENCES Towns(Id);

--Another way
--ALTER TABLE Minions
--ADD TownId INT FOREIGN KEY REFERENCES Towns(Id);

--Problem 4
INSERT INTO Towns
(Id, 
 [Name]
)
VALUES
(1, 
 'Sofia'
),
(2, 
 'Plovdiv'
),
(3, 
 'Varna'
);

SELECT *
FROM Towns;

INSERT INTO Minions
(Id, 
 [Name], 
 Age, 
 TownId
)
VALUES
(1, 
 'Kevin', 
 22, 
 1
),
(2, 
 'Bob', 
 15, 
 3
),
(3, 
 'Steward', 
 NULL, 
 2
);

SELECT [Id], 
       [Name], 
       [Age], 
       [TownId]
FROM Minions;


-- Remove and add PK
--ALTER TABLE Minions DROP CONSTRAINT PK_Id;
--ALTER TABLE Minions
--ADD CONSTRAINT PK_Id PRIMARY KEY(Id);

--Problem 5
TRUNCATE TABLE Minions;

--Problem 6
DROP TABLE Minions;
DROP TABLE Towns;