--Problem 1
SELECT COUNT(Id)
FROM WizzardDeposits;

--Problem 2
SELECT MAX(MagicWandSize) AS [LongestMagicWand]
FROM WizzardDeposits;

--Problem 3
SELECT DepositGroup, 
       MAX(MagicWandSize) AS [LongestMagicWand]
FROM WizzardDeposits
GROUP BY DepositGroup;

--Problem 4
SELECT TOP (2) DepositGroup
FROM WizzardDeposits
GROUP BY DepositGroup
ORDER BY AVG(MagicWandSize);

--Problem 5
SELECT DepositGroup, 
       SUM(DepositAmount) AS [TotalSum]
FROM WizzardDeposits
GROUP BY DepositGroup;

--Problem 6
SELECT DepositGroup, 
       SUM(DepositAmount) AS [TotalSum]
FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup;

--Problem 7
SELECT DepositGroup, 
       SUM(DepositAmount) AS [TotalSum]
FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup
HAVING SUM(DepositAmount) < 150000
ORDER BY [TotalSum] DESC;

--Problem 8
SELECT DepositGroup, 
       MagicWandCreator, 
       MIN(DepositCharge) AS [MinDepositCharge]
FROM WizzardDeposits
GROUP BY DepositGroup, 
         MagicWandCreator
ORDER BY MagicWandCreator, 
         DepositGroup;

--Problem 9
SELECT wd.AgeGroup, 
       COUNT(wd.AgeGroup) AS [WizardCount]
FROM
(
    SELECT CASE
               WHEN Age BETWEEN 0 AND 10
               THEN '[0-10]'
               WHEN Age BETWEEN 11 AND 20
               THEN '[11-20]'
               WHEN Age BETWEEN 21 AND 30
               THEN '[21-30]'
               WHEN Age BETWEEN 31 AND 40
               THEN '[31-40]'
               WHEN Age BETWEEN 41 AND 50
               THEN '[41-50]'
               WHEN Age BETWEEN 51 AND 60
               THEN '[51-60]'
               ELSE '[61+]'
           END AS [AgeGroup]
    FROM WizzardDeposits
) AS [WD]
GROUP BY wd.AgeGroup;

--Problem 10
SELECT LEFT(FirstName, 1) AS [FirstLetter]
FROM WizzardDeposits
WHERE DepositGroup = 'Troll Chest'
GROUP BY LEFT(FirstName, 1)
ORDER BY FirstLetter;

--Problem 11
SELECT DepositGroup,IsDepositExpired,
       AVG(DepositInterest) AS AverageInterest
FROM WizzardDeposits
WHERE DepositStartDate > '01/01/1985'
GROUP BY DepositGroup, IsDepositExpired
ORDER BY DepositGroup DESC, IsDepositExpired;

--Problem 12
SELECT SUM(WD.[Difference]) AS [SumDifference]
FROM
(
    SELECT FirstName AS [Host Wizard], 
           DepositAmount AS [Host Wizard Deposit], 
           LEAD(FirstName) OVER(
           ORDER BY Id) AS [Guest Wizard], 
           LEAD(DepositAmount) OVER(
           ORDER BY Id) AS [Guest Wizard Deposit], 
           DepositAmount - LEAD(DepositAmount) OVER(
           ORDER BY Id) AS [Difference]
    FROM WizzardDeposits
) AS WD;

--Second way
SELECT SUM(Result.Diff)
FROM
(
    SELECT wd.DepositAmount -
    (
        SELECT w.DepositAmount
        FROM WizzardDeposits AS w
        WHERE w.Id = wd.Id + 1
    ) AS Diff
    FROM WizzardDeposits AS wd
) AS Result;

USE SoftUni;

--Problem 13
SELECT DepartmentID, 
       SUM(Salary) AS [TotalSalary]
FROM Employees
GROUP BY DepartmentID
ORDER BY DepartmentID;

--Problem 14
SELECT DepartmentID, 
       MIN(Salary) AS [MinimumSalary]
FROM Employees
WHERE DepartmentID IN(2, 5, 7)
AND HireDate > '01/01/2000'
GROUP BY DepartmentID;

--Problem 15
SELECT *
INTO NewEmployees
FROM Employees
WHERE Salary > 30000;

DELETE FROM NewEmployees
WHERE ManagerID = 42;

UPDATE NewEmployees
  SET 
      salary+=5000
WHERE DepartmentID = 1;

SELECT DepartmentId, 
       AVG(Salary)
FROM NewEmployees
GROUP BY DepartmentID;

--Problem 16
SELECT DepartmentID, 
       MAX(Salary) AS [MaxSalary]
FROM Employees
GROUP BY DepartmentID
HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000;

--Problem 17
SELECT COUNT(Salary) AS [Count]
FROM Employees
WHERE ManagerID IS NULL;

--Problem 18
SELECT D.DepartmentID, 
       D.Salary AS [ThirdHighestSalary]
FROM
(
    SELECT DepartmentID, 
           Salary, 
           DENSE_RANK() OVER(PARTITION BY DepartmentID
           ORDER BY Salary DESC) AS [Ranking]
    FROM Employees
    GROUP BY DepartmentID, 
             Salary
) AS D
WHERE D.Ranking = 3;

--second way
SELECT DISTINCT 
       D.DepartmentID, 
       D.Salary AS [ThirdHighestSalary]
FROM
(
    SELECT DepartmentID, 
           Salary, 
           DENSE_RANK() OVER(PARTITION BY DepartmentID
           ORDER BY Salary DESC) AS [Ranking]
    FROM Employees
) AS D
WHERE D.Ranking = 3;

--Problem 19
SELECT TOP (10) FirstName, 
                LastName, 
                DepartmentID
FROM Employees AS E1
WHERE Salary >
(
    SELECT AVG(Salary) AS [AvgSalary]
    FROM Employees AS E2
    WHERE E2.DepartmentID = E1.DepartmentID
    GROUP BY DepartmentID
)
ORDER BY E1.DepartmentID;


