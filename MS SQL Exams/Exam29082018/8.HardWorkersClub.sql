SELECT FirstName, 
       LastName, 
       AVG(DATEDIFF(HOUR, s.CheckIn, s.CheckOut)) AS [Work hours]
FROM Employees AS e
     INNER JOIN Shifts AS s ON s.EmployeeId = e.Id
GROUP BY e.FirstName, 
         e.LastName, 
         e.Id
HAVING AVG(DATEDIFF(HOUR, s.CheckIn, s.CheckOut)) > 7
ORDER BY [Work hours] DESC, 
         e.Id;



