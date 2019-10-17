SELECT TOP (1) s.[Name], 
               sp.[Name]
FROM Spaceships AS s
     INNER JOIN Journeys AS j ON j.SpaceshipId = s.Id
     INNER JOIN Spaceports AS sp ON j.DestinationSpaceportId = sp.Id
ORDER BY s.LightSpeedRate DESC;