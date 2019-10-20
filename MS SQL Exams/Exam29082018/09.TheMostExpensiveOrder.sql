SELECT TOP (1) oi.OrderId, 
               SUM(Price * Quantity) AS [TotalPrice]
FROM OrderItems AS oi
     INNER JOIN Items AS i ON oi.ItemId = i.Id
GROUP BY oi.OrderId
ORDER BY TotalPrice DESC;