CREATE TABLE DeletedJourneys
(Id                     INT, 
 JourneyStart           DATETIME, 
 JourneyEnd             DATETIME, 
 Purpose                VARCHAR(11), 
 DestinationSpaceportId INT, 
 SpaceshipId            INT
);
GO
CREATE TRIGGER tr_DeletedJournes ON Journeys
FOR DELETE
AS
     BEGIN
         INSERT INTO DeletedJourneys
         (Id, 
          JourneyStart, 
          JourneyEnd, 
          Purpose, 
          DestinationSpaceportId, 
          SpaceshipId
         )
                SELECT d.Id, 
                       d.JourneyStart, 
                       d.JourneyEnd, 
                       d.Purpose, 
                       d.DestinationSpaceportId, 
                       d.SpaceshipId
                FROM deleted AS d;
     END;

DELETE FROM TravelCards
WHERE JourneyId =  1

DELETE FROM Journeys
WHERE Id =  1

