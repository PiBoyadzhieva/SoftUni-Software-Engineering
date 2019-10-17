SELECT p.[Name], 
       s.[Name]
FROM Planets AS p
     INNER JOIN Spaceports AS s ON s.PlanetId = p.Id
     INNER JOIN Journeys AS j ON j.DestinationSpaceportId = s.Id
WHERE j.Purpose = 'Educational'
ORDER BY s.[Name] DESC;
