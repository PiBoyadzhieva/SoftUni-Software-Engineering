SELECT JobDuringJourney, 
       temp.FullName, 
       temp.JobRank
FROM
(
    SELECT tc.JobDuringJourney AS [JobDuringJourney], 
           concat(c.FirstName, ' ', c.LastName) AS [FullName], 
           ROW_NUMBER() OVER(PARTITION BY JobDuringJourney
           ORDER BY DATEDIFF(MONTH, c.BirthDate, GETDATE()) DESC) AS [JobRank]
    FROM TravelCards AS tc
         INNER JOIN Colonists AS c ON tc.ColonistId = c.Id
) AS temp
WHERE temp.JobRank = 2;

