USE Geography;

SELECT M.MountainRange, 
       P.PeakName, 
       P.Elevation
FROM Mountains as M
     INNER JOIN Peaks as P ON M.Id = P.MountainId
WHERE M.MountainRange = 'Rila'
ORDER BY P.Elevation DESC;