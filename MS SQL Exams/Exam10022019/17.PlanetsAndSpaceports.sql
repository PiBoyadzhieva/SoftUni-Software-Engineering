SELECT p.[Name], 
       COUNT(s.Id) AS [Count]
FROM Planets AS p
     LEFT OUTER JOIN Spaceports AS s ON s.PlanetId = p.Id
GROUP BY p.[Name]
ORDER BY [Count] DESC, 
         p.[Name];
