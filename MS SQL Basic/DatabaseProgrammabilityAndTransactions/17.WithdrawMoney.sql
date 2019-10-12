CREATE PROC usp_WithdrawMoney
(@accountId   INT, 
 @moneyAmount DECIMAL(15, 4)
)
AS
    BEGIN TRANSACTION;
        DECLARE @targetAccountId INT=
        (
            SELECT a.Id
            FROM Accounts AS a
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
        IF(@moneyAmount >
        (
            SELECT Balance
            FROM Accounts AS a
            WHERE a.Id = @targetAccountId
        ))
            BEGIN
                ROLLBACK;
                RAISERROR('You do not have enough amount of money in your account', 16, 1);
                RETURN;
        END;
        UPDATE Accounts
          SET 
              balance-=@moneyAmount
        WHERE Id = @accountId;
        COMMIT;