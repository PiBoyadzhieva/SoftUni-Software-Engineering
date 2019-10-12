CREATE PROC usp_GetTownsStartingWith(@string NVARCHAR(20))
AS
    BEGIN
        SELECT [Name]
        FROM Towns
        WHERE [Name] LIKE @string + '%';
    END;

--EXEC usp_GetTownsStartingWith 
 --    'b';