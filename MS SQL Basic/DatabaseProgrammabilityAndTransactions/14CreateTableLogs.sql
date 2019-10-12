CREATE TABLE Logs
(LogId     INT
 PRIMARY KEY IDENTITY, 
 AccountId INT, 
 OldSum    MONEY, 
 NewSum    MONEY
);

GO

CREATE TRIGGER tr_AccountChanges ON accounts
FOR UPDATE
AS
     BEGIN
         DECLARE @accountId INT;
         DECLARE @oldSum MONEY;
         DECLARE @newSum MONEY;
         SET @accountId =
         (
             SELECT i.Id
             FROM inserted AS i
         );
         SET @oldSum =
         (
             SELECT d.Balance
             FROM deleted AS d
         );
         SET @newSum =
         (
             SELECT i.Balance
             FROM inserted AS i
         );
         INSERT INTO Logs
         (AccountId, 
          OldSum, 
          NewSum
         )
         VALUES
         (@accountId, 
          @oldSum, 
          @newSum
         );
     END;