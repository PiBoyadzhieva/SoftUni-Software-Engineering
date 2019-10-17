SELECT c.Id, 
       concat(c.FirstName, ' ', c.LastName) AS [FullName]
FROM Colonists AS c
     INNER JOIN TravelCards AS tc ON tc.ColonistId = c.Id
WHERE tc.JobDuringJourney = 'Pilot'
ORDER BY c.Id;