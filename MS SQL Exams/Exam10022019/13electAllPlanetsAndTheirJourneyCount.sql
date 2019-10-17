SELECT p.[Name] as [PlanetName], 
       COUNT(j.Id) AS [JourneysCount]
FROM Planets AS p
     INNER JOIN Spaceports AS s ON s.PlanetId = p.Id
     INNER JOIN Journeys AS j ON j.DestinationSpaceportId = s.Id
GROUP BY p.[Name]
ORDER BY JourneysCount DESC, PlanetName;