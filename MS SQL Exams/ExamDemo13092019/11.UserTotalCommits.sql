GO

CREATE FUNCTION udf_UserTotalCommits
(@username VARCHAR(30)
)
RETURNS INT
AS
     BEGIN
         DECLARE @count INT=
         (
             SELECT COUNT(c.Id)
             FROM Users AS u
                  INNER JOIN Commits AS c ON c.ContributorId = u.Id
             WHERE u.Username = @username
         );

		 return @count
     END;

GO

SELECT dbo.udf_UserTotalCommits('UnderSinduxrein')