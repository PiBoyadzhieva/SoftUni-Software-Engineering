CREATE PROC usp_DepositMoney
(@accountId   INT, 
 @moneyAmount DECIMAL(15, 4)
)
AS
    BEGIN TRANSACTION;
        DECLARE @targetAccountId INT=
        (
            SELECT a.Id
            FROM dbo.Accounts a
            WHERE a.Id = @AccountId
        );
        IF(@moneyAmount < 0
           OR @moneyAmount IS NULL)
            BEGIN
                ROLLBACK;
                RAISERROR('Invalid amount of money!', 16, 1);
                RETURN;
        END;
        IF(@targetAccountId IS NULL)
            BEGIN
                ROLLBACK;
                RAISERROR('Invalid account ID!', 16, 1);
                RETURN;
        END;
        UPDATE Accounts
          SET 
              balance+=@moneyAmount
		  WHERE Id = @accountId;
	COMMIT;