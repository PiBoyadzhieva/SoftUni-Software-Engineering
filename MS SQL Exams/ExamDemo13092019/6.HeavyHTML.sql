SELECT Id, 
       [Name], 
       Size
FROM files
WHERE Size > 1000
      AND [name] LIKE '%html%'
ORDER BY size DESC, 
         Id, 
         [Name];
