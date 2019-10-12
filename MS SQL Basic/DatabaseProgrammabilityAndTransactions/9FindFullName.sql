CREATE PROC usp_GetHoldersFullName
AS
    BEGIN
        SELECT concat(FirstName, ' ', LastName) AS [Full Name]
        FROM AccountHolders;
    END;

--EXEC usp_GetHoldersFullName;