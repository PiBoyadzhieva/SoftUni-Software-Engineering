CREATE PROC usp_GetHoldersWithBalanceHigherThan(@number MONEY)
AS
    BEGIN
        SELECT ah.FirstName, 
               ah.LastName 
        FROM AccountHolders AS ah
             INNER JOIN Accounts AS a ON ah.Id = a.AccountHolderId
        GROUP BY ah.FirstName, 
                 ah.LastName
        HAVING SUM(a.Balance) > @number
        ORDER BY ah.FirstName, 
                 ah.LastName;
    END;
