CREATE FUNCTION udf_ExamGradesToUpdate
(@studentId INT, 
 @grade     DECIMAL(3, 2)
)
RETURNS VARCHAR(100)
AS
     BEGIN
         IF(@grade > 6.00)
             BEGIN
                 RETURN 'Grade cannot be above 6.00!';
         END;

         DECLARE @Id char(1) =
         (
             SELECT TOP (1) StudentId
             FROM StudentsExams
             WHERE StudentId = @studentId
         );

         IF(@Id is null)
             BEGIN
                 RETURN 'The student with provided id does not exist in the school!';
         END;
         DECLARE @count INT=
         (
             SELECT COUNT(Grade)
             FROM StudentsExams
             WHERE StudentId = @studentId
                   AND Grade BETWEEN @grade AND @grade + 0.50
         );
         DECLARE @firstName NVARCHAR(30)=
         (
             SELECT FirstName
             FROM Students
             WHERE Id = @studentId
         );
         RETURN concat('You have to update ', @count, ' grades for the student ', @firstName);
     END;

SELECT dbo.udf_ExamGradesToUpdate(12, 5.50)
