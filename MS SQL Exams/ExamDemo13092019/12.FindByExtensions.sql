CREATE PROC usp_FindByExtension(@extension VARCHAR(10))
AS
    BEGIN
        SELECT Id, 
               [Name], 
               concat(Size, 'KB') AS [Size]
        FROM Files
        WHERE [Name] LIKE '%' + @extension
        ORDER BY Id, 
                 [Name], 
                 Size DESC;
    END;

EXEC usp_FindByExtension 'txt'