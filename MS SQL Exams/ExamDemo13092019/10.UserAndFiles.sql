SELECT u.Username, 
       AVG(f.Size) as [Size]
FROM Commits AS c
     INNER JOIN Users AS u ON c.ContributorId = u.Id
     INNER JOIN Files AS f ON f.CommitId = c.Id
GROUP BY u.Username
order by Size desc, u.Username 