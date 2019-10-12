GO
CREATE FUNCTION ufn_CashInUsersGames
(@gameName VARCHAR(MAX)
)
RETURNS @output TABLE(SumCash DECIMAL(18, 4))
AS
     BEGIN
         INSERT INTO @output
                SELECT
                (
                    SELECT SUM(Cash) AS [SumCash]
                    FROM
                    (
                        SELECT *, 
                               ROW_NUMBER() OVER(
                               ORDER BY Cash DESC) AS [RowNum]
                        FROM UsersGames
                        WHERE GameId IN
                        (
                            SELECT Id
                            FROM Games
                            WHERE [Name] = @gameName
                        )
                    ) AS [RowNumTable]
                    WHERE RowNum % 2 <> 0
                );
         RETURN;
     END;
GO

SELECT *
FROM dbo.ufn_CashInUsersGames('Love in a mist');