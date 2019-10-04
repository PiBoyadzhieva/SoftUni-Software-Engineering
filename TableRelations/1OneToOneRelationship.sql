CREATE TABLE Passports
(PassportID     INT
 PRIMARY KEY NOT NULL, 
 PassportNumber VARCHAR(30)
 UNIQUE NOT NULL
);

CREATE TABLE Persons
(PersonID   INT
 PRIMARY KEY IDENTITY, 
 FirstName  NVARCHAR(30) NOT NULL, 
 Salary     DECIMAL(15, 2) NOT NULL, 
 PassportID INT
 UNIQUE NOT NULL
        CONSTRAINT FK_Persons_PassportID FOREIGN KEY REFERENCES Passports(PassportID)
);

INSERT INTO Passports (PassportID, PassportNumber)
VALUES
(101, 'N34FG21B'), 
(102, 'K65LO4R7'), 
(103, 'ZE657QP2');

INSERT INTO Persons (FirstName, Salary, PassportID)
VALUES
('Roberto', 43300, 102),
('Tom', 56100, 103),
('Yana', 60200, 101)