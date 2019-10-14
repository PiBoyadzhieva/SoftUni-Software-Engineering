  SELECT concat(p.FirstName, ' ', p.LastName) AS [Full Name], 
         pl.[Name] AS [Plane Name], 
         concat(f.Origin, ' - ', f.Destination) AS [Trip], 
         lt.[Type] AS [Luggage Type]
	FROM Passengers AS p
	     INNER JOIN Tickets AS t ON t.PassengerId = p.Id
	     INNER JOIN Flights AS f ON t.FlightId = f.Id
	     INNER JOIN Planes AS pl ON f.PlaneId = pl.Id
	     INNER JOIN Luggages AS l ON t.LuggageId = l.Id
	     INNER JOIN LuggageTypes AS lt ON l.LuggageTypeId = lt.Id
ORDER BY [Full Name], 
         [Plane Name], 
         f.Origin, 
         f.Destination, 
         [Luggage Type];
