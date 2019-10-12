CREATE PROC usp_TransferMoney
(@senderId   INT, 
 @receiverId INT, 
 @amount     DECIMAL(15, 4)
)
AS
    BEGIN TRANSACTION;
        EXEC dbo.usp_WithdrawMoney 
             @senderId, 
             @amount;
        EXEC dbo.usp_DepositMoney 
             @receiverId, 
             @amount;
        COMMIT;