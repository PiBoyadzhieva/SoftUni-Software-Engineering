CREATE PROC usp_EmployeesBySalaryLevel(@salaryLvl NVARCHAR(10))
AS
    BEGIN
        SELECT FirstName, 
               LastName
        FROM Employees AS e
        WHERE dbo.ufn_GetSalaryLevel(e.Salary) = @salaryLvl;
    END;

--EXEC usp_EmployeesBySalaryLevel 
--     'high';