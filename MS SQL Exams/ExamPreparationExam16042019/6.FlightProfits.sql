SELECT t.FlightId, 
       SUM(Price) AS [Price]
FROM Tickets as t
GROUP BY t.FlightId
ORDER BY SUM(t.Price) DESC, 
         t.FlightId;