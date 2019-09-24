CREATE DATABASE Hotel;
USE Hotel;

CREATE TABLE Employees
(Id        INT
 PRIMARY KEY IDENTITY, 
 FirstName NVARCHAR(30) NOT NULL, 
 LastName  NVARCHAR(30) NOT NULL, 
 Title     NVARCHAR(30), 
 Notes     NVARCHAR(MAX)
);

CREATE TABLE Customers
(AccountNumber   INT
 PRIMARY KEY, 
 FirstName       NVARCHAR(30) NOT NULL, 
 LastName        NVARCHAR(30) NOT NULL, 
 PhoneNumber     VARCHAR(15)
 UNIQUE NOT NULL, 
 EmergencyName   NVARCHAR(30), 
 EmergencyNumber VARCHAR(15), 
 Notes           NVARCHAR(MAX)
);

CREATE TABLE RoomStatus
(RoomStatus VARCHAR(10)
 PRIMARY KEY, 
 Notes      NVARCHAR(MAX)
);

Create TABLE RoomTypes 
(RoomType VARCHAR(10)
 PRIMARY KEY, 
 Notes      NVARCHAR(MAX)
);

CREATE TABLE BedTypes  
(BedType VARCHAR(10)
 PRIMARY KEY, 
 Notes      NVARCHAR(MAX)
);

CREATE TABLE Rooms
(RoomNumber INT
 PRIMARY KEY, 
 RoomType   VARCHAR(10) FOREIGN KEY REFERENCES RoomTypes(RoomType), 
 BedType    VARCHAR(10) FOREIGN KEY REFERENCES BedTypes(BedType), 
 Rate       DECIMAL(2, 1), 
 RoomStatus VARCHAR(10) FOREIGN KEY REFERENCES RoomStatus(RoomStatus), 
 Notes      NVARCHAR(MAX)
);

CREATE TABLE Payments
(Id                INT
 PRIMARY KEY IDENTITY, 
 EmployeeId        INT FOREIGN KEY REFERENCES Employees(Id), 
 PaymentDate       DATE NOT NULL, 
 AccountNumber     INT FOREIGN KEY REFERENCES Customers(AccountNumber), 
 FirstDateOccupied DATE NOT NULL, 
 LastDateOccupied  DATE NOT NULL, 
 TotalDays         INT NOT NULL, 
 AmountCharged     DECIMAL(10, 2) NOT NULL, 
 TaxRate           DECIMAL(7, 2), 
 TaxAmount         DECIMAL(10, 2) NOT NULL, 
 PaymentTotal      DECIMAL(10, 2) NOT NULL, 
 Notes             NVARCHAR(MAX)
);

CREATE TABLE Occupancies
(Id            INT
 PRIMARY KEY IDENTITY, 
 EmployeeId    INT FOREIGN KEY REFERENCES Employees(Id), 
 DateOccupied  DATE NOT NULL, 
 AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber), 
 RoomNumber    INT FOREIGN KEY REFERENCES Rooms(RoomNumber), 
 RateApplied   DECIMAL(3, 2), 
 PhoneCharge   DECIMAL(15, 2), 
 Notes         NVARCHAR(MAX)
);

INSERT INTO Employees
	    (FirstName, LastName, Title, Notes)
VALUES	    
	    ('Marin', 'Marinov', 'employee1', NULL),
	    ('Ivan', 'Ivanov', 'employee2', NULL),
	    ('Pesho', 'Peshev', 'employee3', NULL)

INSERT INTO Customers
	    (AccountNumber, FirstName, LastName, PhoneNumber,
	    EmergencyName, EmergencyNumber, Notes)
VALUES	    
	    (123, 'Sasho', 'Sashov', 123456, NULL, NULL, NULL),
	    (456, 'Ivan', 'Vankov', 654321, NULL, NULL, NULL),
	    (789, 'Gosho', 'Goshov', 223341, NULL, NULL, NULL)

INSERT INTO RoomStatus(RoomStatus, Notes)
VALUES	('12', NULL),
	    ('23', NULL),
	    ('34', NULL)

INSERT INTO RoomTypes(RoomType, Notes)
VALUES	('Single', NULL),
	    ('Double', NULL),
	    ('Apartment', NULL)

INSERT INTO BedTypes(BedType, Notes)
VALUES	('Type1', NULL),
	    ('Type2', NULL),
	    ('Type3', NULL)

INSERT INTO Rooms
	    (RoomNumber, Rate, Notes)
VALUES     
	    (103, 7, NULL),
	    (205, 8.50, NULL),
	    (111, 9.00, NULL)

INSERT INTO Payments
            (PaymentDate, 
            FirstDateOccupied, LastDateOccupied, 
            TotalDays, AmountCharged, TaxRate, 
            TaxAmount, PaymentTotal, Notes)
VALUES            
            ('2015-05-10', '2015-05-08', '2015-05-10', 2, 200, 8, 1.5, 300.00, NULL),
            ('2015-05-11', '2015-05-09', '2015-05-11', 2, 200, 8, 1.5, 300.00, NULL),
            ('2015-05-12', '2015-05-09', '2015-05-12', 3, 300, 8, 1.5, 450.00, NULL)

INSERT INTO Occupancies
	    (EmployeeId, DateOccupied, RateApplied, PhoneCharge, Notes)
VALUES    
	    (1, '2015-05-08', NULL, NULL, NULL),
	    (3, '2015-05-10', NULL, NULL, NULL),
	    (2, '2015-05-06', NULL, NULL, NULL)

SELECT *
FROM Occupancies;
SELECT *
FROM Payments;

--Problem 23
UPDATE Payments
SET TaxRate -= TaxRate*0.03;

SELECT TaxRate
FROM Payments;

--Problem 24
TRUNCATE TABLE Occupancies;