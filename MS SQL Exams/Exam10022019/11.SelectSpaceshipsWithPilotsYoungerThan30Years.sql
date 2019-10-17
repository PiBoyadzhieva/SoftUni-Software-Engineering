SELECT s.[Name], 
       s.Manufacturer
FROM Spaceships AS s
     INNER JOIN Journeys AS j ON j.SpaceshipId = s.Id
     INNER JOIN TravelCards AS t ON t.JourneyId = j.Id
     INNER JOIN Colonists AS c ON t.ColonistId = c.Id
WHERE t.JobDuringJourney = 'Pilot'
      AND DATEDIFF(YEAR, c.BirthDate, '2019-01-01') < 30
ORDER BY s.[Name];