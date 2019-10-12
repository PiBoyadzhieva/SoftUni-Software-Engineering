GO
CREATE PROC usp_DeleteEmployeesFromDepartment(@departmentId INT)
AS
    BEGIN
        --Delete all working on projects by people that will be deleted
        DELETE FROM EmployeesProjects
        WHERE EmployeeID IN
        (
            --people that have to delete
            SELECT EmployeeID
            FROM Employees
            WHERE DepartmentID = @departmentId
        );

        --Set ManagerID to null on all the people which manager is being deleted
        UPDATE Employees
          SET 
              ManagerID = NULL
        WHERE ManagerID IN
        (
            --people that have to delete
            SELECT EmployeeID
            FROM Employees
            WHERE DepartmentID = @departmentId
        );

        --Set column ManagerID(Departments) to be nullable
        ALTER TABLE Departments ALTER COLUMN ManagerID INT;
        UPDATE Departments
          SET 
              ManagerID = NULL
        WHERE DepartmentID = @departmentId;
        DELETE FROM Employees
        WHERE DepartmentID = @departmentId;
        DELETE FROM Departments
        WHERE DepartmentID = @departmentId;
        SELECT COUNT(*)
        FROM Departments
        WHERE DepartmentID = @departmentId;
    END;
GO