SELECT f.Id, 
       f.[Name], 
       concat(f.Size, 'KB') as [Size]
FROM Files AS f
     LEFT JOIN Files AS p ON f.Id = p.ParentId
WHERE p.Id IS NULL
ORDER BY f.Id, 
         f.[Name], 
         f.Size DESC;
