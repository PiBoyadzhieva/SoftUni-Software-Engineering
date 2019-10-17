CREATE TABLE Planes
(Id      INT
 PRIMARY KEY IDENTITY, 
 [Name]  VARCHAR(30) NOT NULL, 
 Seats   INT NOT NULL, 
 [Range] INT NOT NULL
);

CREATE TABLE Flights
(Id            INT
 PRIMARY KEY IDENTITY, 
 DepartureTime DATETIME2, 
 ArrivalTime   DATETIME2, 
 Origin        VARCHAR(50) NOT NULL, 
 Destination   VARCHAR(50) NOT NULL, 
 PlaneId       INT NOT NULL
                   CONSTRAINT FK_Flights_PlaneId FOREIGN KEY REFERENCES Planes(Id)
);

CREATE TABLE Passengers
(Id         INT
 PRIMARY KEY IDENTITY, 
 FirstName  VARCHAR(30) NOT NULL, 
 LastName   VARCHAR(30) NOT NULL, 
 Age        INT NOT NULL, 
 [Address]    NVARCHAR(30) NOT NULL, 
 PassportId CHAR(11) NOT NULL
);

CREATE TABLE LuggageTypes
(Id     INT
 PRIMARY KEY IDENTITY, 
 [Type] VARCHAR(30) NOT NULL
);

CREATE TABLE Luggages
(Id            INT
 PRIMARY KEY IDENTITY, 
 LuggageTypeId INT NOT NULL
                   CONSTRAINT FK_Luggages_LuggageTypeId FOREIGN KEY REFERENCES LuggageTypes(Id), 
 PassengerId   INT NOT NULL
                   CONSTRAINT FK_Luggages_PassengersId FOREIGN KEY REFERENCES Passengers(Id)
);

CREATE TABLE Tickets
(Id          INT
 PRIMARY KEY IDENTITY, 
 PassengerId INT NOT NULL
                 CONSTRAINT FK_Tickets_PassengersId FOREIGN KEY REFERENCES Passengers(Id), 
 FlightId    INT NOT NULL
                 CONSTRAINT FK_Tickets_FlightsId FOREIGN KEY REFERENCES Flights(Id), 
 LuggageId   INT NOT NULL
                 CONSTRAINT FK_Tickets_LuggagesId FOREIGN KEY REFERENCES Luggages(Id), 
 Price       DECIMAL(15, 2) NOT NULL
);



