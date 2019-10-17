CREATE PROC usp_ExcludeFromSchool(@StudentId INT)
AS
    BEGIN

        IF(NOT EXISTS
        (
            SELECT *
            FROM Students AS s
            WHERE s.Id = @studentId
        ))
            BEGIN
                RAISERROR('This school has no student with the provided id!', 16, 1);
                RETURN;
        END;

        DELETE FROM StudentsSubjects
        WHERE StudentId = @StudentId;

        DELETE FROM StudentsTeachers
        WHERE StudentId = @StudentId;

        DELETE FROM StudentsExams
        WHERE StudentId = @StudentId;

        DELETE FROM Students
        WHERE Id = @StudentId;
    END;