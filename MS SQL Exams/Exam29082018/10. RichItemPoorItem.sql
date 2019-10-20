SELECT TOP (10) oi.OrderId, 
                MAX(Price) AS [ExpensivePrice], 
                MIN(Price) AS [CheapPrice]
FROM OrderItems AS oi
     INNER JOIN Items AS i ON oi.ItemId = i.Id
GROUP BY oi.OrderId
ORDER BY ExpensivePrice DESC, 
         oi.OrderId;