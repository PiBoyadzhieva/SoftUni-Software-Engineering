CREATE TABLE NotificationEmails
(Id        INT
 PRIMARY KEY IDENTITY, 
 Recipient INT, 
 [Subject] VARCHAR(100), 
 Body      VARCHAR(100)
);

GO

CREATE TRIGGER tr_CreateNewEmail ON Logs
FOR INSERT
AS
     BEGIN
         DECLARE @recipient INT;
         DECLARE @subject VARCHAR(200);
         DECLARE @oldSum MONEY;
         DECLARE @newSum MONEY;
         DECLARE @body VARCHAR(200);

         SET @recipient =
         (
             SELECT i.AccountId
             FROM inserted AS i
         );

         SET @subject = 'Balance change for account: ' + CAST(@recipient AS VARCHAR(100));

         SET @oldSum =
         (
             SELECT i.OldSum
             FROM inserted AS i
         );

         SET @newSum =
         (
             SELECT i.NewSum
             FROM inserted AS i
         );

         SET @body = 'On ' + CAST(GETDATE() AS VARCHAR(20)) + ' your balance was changed from ' + 
					 CAST(@oldSum AS VARCHAR(30)) + ' to ' + CAST(@newSum AS VARCHAR(30));
         
		 INSERT INTO NotificationEmails
         (Recipient, 
          [Subject], 
          Body
         )
         VALUES
         (@recipient, 
          @subject, 
          @body
         );
     END;