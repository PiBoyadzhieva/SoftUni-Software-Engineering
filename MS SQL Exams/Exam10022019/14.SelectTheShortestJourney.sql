SELECT top(1) j.Id, 
       p.[Name] AS [PlanetName], 
       s.[Name] AS [SpaceportName], 
       j.Purpose AS [JourneyPurpose]
FROM Journeys AS j
     INNER JOIN Spaceports AS s ON j.DestinationSpaceportId = s.Id
     INNER JOIN Planets AS p ON s.PlanetId = p.Id
ORDER BY DATEDIFF(MINUTE, j.JourneyStart, j.JourneyEnd);