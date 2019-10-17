CREATE FUNCTION dbo.udf_GetColonistsCount
(@planetName VARCHAR(30)
)
RETURNS INT
AS
     BEGIN
         DECLARE @count INT;
         SET @count =
         (
             SELECT COUNT(tc.ColonistId) AS [Count]
             FROM Planets AS p
                  INNER JOIN Spaceports AS s ON s.PlanetId = p.Id
                  INNER JOIN Journeys AS j ON j.DestinationSpaceportId = s.Id
                  INNER JOIN TravelCards AS tc ON tc.JourneyId = j.Id
             WHERE p.[Name] = @planetName
         );
         RETURN @count;
     END;

SELECT dbo.udf_GetColonistsCount('Otroyphus');
