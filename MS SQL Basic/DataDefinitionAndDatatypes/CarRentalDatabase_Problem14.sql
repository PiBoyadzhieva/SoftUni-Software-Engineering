CREATE DATABASE CarRental;
USE CarRental;

CREATE TABLE Categories
(Id           INT
 PRIMARY KEY IDENTITY, 
 CategoryName NVARCHAR(30)
 UNIQUE NOT NULL, 
 DailyRate    INT, 
 WeeklyRate   INT, 
 MonthlyRate  INT, 
 WeekendRate  INT
);

CREATE TABLE Cars
(Id           INT
 PRIMARY KEY IDENTITY, 
 PlateNumber  NVARCHAR(10)
 UNIQUE NOT NULL, 
 Manufacturer NVARCHAR(30) NOT NULL, 
 Model        NVARCHAR(20) NOT NULL, 
 CarYear      DATE NOT NULL, 
 CategoryId   INT FOREIGN KEY REFERENCES Categories(Id), 
 Doors        INT NOT NULL, 
 Picture      VARBINARY(MAX), 
 Condition    BIT, 
 Available    BIT NOT NULL
);

CREATE TABLE Employees
(Id        INT
 PRIMARY KEY IDENTITY, 
 FirstName NVARCHAR(30) NOT NULL, 
 LastName  NVARCHAR(30) NOT NULL, 
 Title     NVARCHAR(30), 
 Notes     NVARCHAR(MAX)
);

CREATE TABLE Customers
(Id                  INT
 PRIMARY KEY IDENTITY, 
 DriverLicenceNumber INT NOT NULL, 
 FullName            NVARCHAR(60) NOT NULL, 
 [Address]           NVARCHAR(100), 
 City                NVARCHAR(20), 
 ZIPCode             INT, 
 Notes               NVARCHAR(MAX)
);

CREATE TABLE RentalOrders
(id               INT
 PRIMARY KEY IDENTITY, 
 EmployeeId       INT FOREIGN KEY REFERENCES Employees(Id), 
 CustomerId       INT FOREIGN KEY REFERENCES Customers(Id), 
 CarId            INT FOREIGN KEY REFERENCES Cars(Id), 
 TankLevel        INT, 
 KilometrageStart INT NOT NULL, 
 KilometrageEnd   INT NOT NULL, 
 TotalKilometrage INT NOT NULL, 
 StartDate        DATETIME NOT NULL, 
 EndDate          DATETIME NOT NULL, 
 TotalDays        INT NOT NULL, 
 RateApplied      INT, 
 TaxRate          INT, 
 OrderStatus      NVARCHAR(30), 
 Notes            NVARCHAR(MAX)
);

INSERT INTO Categories 
			(CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
VALUES		
			('Category1', 4, 6, 12, 10),
			('Category2', 4, 8, 15, 9),
			('Category3', 2, 4, 16, 8)

INSERT INTO Cars
			(PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available)
VALUES
			('1234', 'Mercedes', 'S500', '2015', 1, 5, NULL, 1, 1),
			('1596', 'Audi', 'A8', '2016', 2, 5, NULL, 1, 1),
			('3654', 'Opel', 'Astra', '2017', 3, 3, NULL, 1, 0)

INSERT INTO Employees
			(FirstName, LastName, Title, Notes)
VALUES 
			('Gosho', 'Goshev', NULL, NULL),
			('Pesho', 'Peshev', NULL, NULL),
			('Marin', 'Marinov', NULL, NULL)

INSERT INTO Customers
			(DriverLicenceNumber, FullName, [Address], City, ZIPCode, Notes)
VALUES 
			('12345', 'Ivan', NULL, NULL, NULL, NULL),
			('123456', 'Dragan', NULL, NULL, NULL, NULL),
			('1234567', 'Jordan', NULL, NULL, NULL, NULL)

INSERT INTO RentalOrders
			(EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, 
			TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, 
			OrderStatus, Notes)
VALUES
			(1, 1, 1, 50, 250, 260, 25450, '2016-06-12', '2016-06-15', 3, NULL, NULL, NULL, NULL),
			(2, 2, 2, 50, 360, 450, 36542, '2017-01-21', '2017-01-25', 4, NULL, NULL, NULL, NULL),
			(3, 3, 3, 50, 220, 320, 65014, '2018-06-22', '2018-06-23', 1, NULL, NULL, NULL, NULL)

SELECT *
FROM RentalOrders;