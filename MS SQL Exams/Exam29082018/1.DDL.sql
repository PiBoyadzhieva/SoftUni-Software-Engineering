CREATE DATABASE Supermarket;

USE Supermarket;

CREATE TABLE Categories
(Id     INT
 PRIMARY KEY IDENTITY, 
 [Name] NVARCHAR(30) NOT NULL
);

CREATE TABLE Items
(Id         INT
 PRIMARY KEY IDENTITY, 
 [Name]     NVARCHAR(30) NOT NULL, 
 Price      DECIMAL(18, 2) NOT NULL, 
 CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL
);

CREATE TABLE Employees
(Id        INT
 PRIMARY KEY IDENTITY, 
 FirstName NVARCHAR(50) NOT NULL, 
 LastName  NVARCHAR(50) NOT NULL, 
 Phone     CHAR(12) NOT NULL, 
 Salary    DECIMAL(18, 2) NOT NULL
);

CREATE TABLE Orders
(Id         INT
 PRIMARY KEY IDENTITY, 
 [DateTime] DATETIME NOT NULL, 
 EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL
);

CREATE TABLE OrderItems
(OrderId  INT FOREIGN KEY REFERENCES Orders(Id) NOT NULL, 
 ItemId   INT FOREIGN KEY REFERENCES Items(Id) NOT NULL, 
 CONSTRAINT PK_CompositeOrderIdItemId PRIMARY KEY(OrderId, ItemId), 
 Quantity INT NOT NULL
              CHECK(Quantity > 0)
);

CREATE TABLE Shifts
(Id         INT IDENTITY NOT NULL, 
 EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL, 
 CONSTRAINT PK_CompositeShiftsIdEmployeeId PRIMARY KEY(Id, EmployeeId), 
 CheckIn    DATETIME NOT NULL, 
 CheckOut   DATETIME NOT NULL, 
 CONSTRAINT CK_DiferenceBetweenCheckInAndCheckOut CHECK(checkOut > CheckIn)
);