CREATE PROC usp_ChangeJourneyPurpose
(@JourneyId  INT, 
 @NewPurpose VARCHAR(11)
)
AS
    BEGIN TRANSACTION;
        DECLARE @targetId INT=
        (
            SELECT Id
            FROM Journeys
            WHERE Id = @JourneyId
        );

        IF(@targetId IS NULL)
            BEGIN
                ROLLBACK;
                RAISERROR('The journey does not exist!', 16, 1);
                RETURN;
        END;

        DECLARE @targetPurpose VARCHAR(11)=
        (
            SELECT Purpose
            FROM Journeys
            WHERE Id = @JourneyId
        );

        IF(@targetPurpose = @NewPurpose)
            BEGIN
                ROLLBACK;
                RAISERROR('You cannot change the purpose!', 16, 1);
                RETURN;
        END;

        UPDATE Journeys
          SET 
              Purpose = @NewPurpose
        WHERE Id = @JourneyId;

        COMMIT;

EXEC usp_ChangeJourneyPurpose 1, 'Technical'
EXEC usp_ChangeJourneyPurpose 2, 'Educational'
EXEC usp_ChangeJourneyPurpose 196, 'Technical'
