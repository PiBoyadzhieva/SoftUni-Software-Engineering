SELECT TOP (10) concat(e.FirstName, ' ', e.LastName) AS [Full Name], 
                SUM(oi.Quantity * i.Price) AS [Total Price], 
                SUM(oi.Quantity) AS [Items]
FROM Employees AS e
     INNER JOIN Orders AS o ON o.EmployeeId = e.Id
     INNER JOIN OrderItems AS oi ON oi.OrderId = o.Id
     INNER JOIN Items AS i ON oi.ItemId = i.Id
WHERE o.[DateTime] < '2018-06-15'
GROUP BY e.FirstName, 
         e.LastName
ORDER BY [Total Price] DESC, 
         [Items] DESC;
