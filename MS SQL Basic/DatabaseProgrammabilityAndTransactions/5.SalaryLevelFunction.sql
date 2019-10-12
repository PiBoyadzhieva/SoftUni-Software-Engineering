create FUNCTION ufn_GetSalaryLevel
(@salary DECIMAL(18, 4))
RETURNS NVARCHAR(10)
AS
     BEGIN
         DECLARE @salaryLevel NVARCHAR(10);
         IF(@salary < 30000)
             BEGIN
                 SET @salaryLevel = 'Low';
			 END;
         ELSE IF(@salary <= 50000)
             BEGIN
                 SET @salaryLevel = 'Average';
             END;
         ELSE
             BEGIN
                 SET @salaryLevel = 'High';
             END;
         RETURN @salaryLevel;
     END;

--SELECT Salary, 
--       dbo.ufn_GetSalaryLevel(Salary) as [SalaryLevel]
--FROM [SoftUni].[dbo].[Employees]
