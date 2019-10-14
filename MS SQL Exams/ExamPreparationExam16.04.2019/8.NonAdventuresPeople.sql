SELECT p.FirstName AS [First Name], 
       p.LastName AS [Last Name], 
       p.Age
FROM Passengers AS p
     LEFT OUTER JOIN Tickets AS t ON t.PassengerId = p.Id
WHERE t.Id IS NULL
ORDER BY p.Age DESC, 
         p.FirstName, 
         p.LastName;