SELECT concat(e.FirstName, ' ', e.LastName) AS [Full Name], 
       datename(WEEKDAY, s.CheckIn) AS [Day of week]
FROM Employees AS e
     INNER JOIN Shifts AS s ON s.EmployeeId = e.Id
     LEFT JOIN Orders AS o ON o.EmployeeId = e.Id
WHERE DATEDIFF(hour, s.CheckIn, s.CheckOut) > 12
      AND o.Id IS NULL
ORDER BY e.Id;