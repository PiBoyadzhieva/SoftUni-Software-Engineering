USE SoftUni;

--Problem 1
SELECT TOP (5) e.EmployeeID, 
               e.JobTitle, 
               e.AddressID, 
               a.AddressText
FROM Employees AS e
     INNER JOIN Addresses AS a ON e.AddressID = a.AddressID
ORDER BY e.AddressID;


--Problem 2
SELECT TOP (50) e.FirstName, 
                e.LastName, 
                t.[Name] As Town, 
                a.AddressText
FROM Employees AS e
     INNER JOIN Addresses AS a ON e.AddressID = a.AddressID
     INNER JOIN Towns AS t ON a.TownID = t.TownID
ORDER BY e.FirstName, 
         e.LastName;

--Problem 3
SELECT e.EmployeeID, 
       FirstName, 
       e.LastName, 
       d.[Name] AS DepartmentName
FROM Employees AS e
     INNER JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE d.DepartmentID = 3
ORDER BY e.EmployeeID;

--Problem 4
SELECT TOP (5) e.EmployeeID, 
               e.FirstName, 
               e.Salary, 
               d.[Name] AS DepartmentName
FROM Employees AS e
     INNER JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
WHERE e.Salary > 15000
ORDER BY d.DepartmentID;

--Problem 5
SELECT TOP (3) e.EmployeeID, 
               e.FirstName
FROM Employees AS e
     LEFT JOIN EmployeesProjects AS p ON e.EmployeeID = p.EmployeeID
WHERE p.ProjectID IS NULL
ORDER BY e.EmployeeID;

--Problem 6
SELECT e.FirstName, 
       e.LastName, 
       e.HireDate, 
       d.[Name] AS DeptName
FROM Employees AS e
     INNER JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE e.HireDate > '1999-01-01'
      AND d.[Name] IN('Finance', 'Sales')
ORDER BY e.HireDate;

--Problem 7
SELECT TOP (5) e.EmployeeID, 
               e.FirstName, 
               p.[Name] AS ProjectName
FROM Employees AS e
     INNER JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
     INNER JOIN Projects AS p ON ep.ProjectID = p.ProjectID
WHERE p.StartDate > '2002-08-13'
      AND p.EndDate IS NULL
ORDER BY EmployeeID;

--Problem 8
SELECT e.EmployeeID, 
       e.FirstName,
       CASE
           WHEN p.StartDate >= '2005-01-01'
           THEN NULL
           ELSE p.[Name]
       END AS [ProjectName]
FROM Employees AS e
     INNER JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
     INNER JOIN Projects AS p ON ep.ProjectID = p.ProjectID
WHERE e.EmployeeID = 24;

--Second way
SELECT e.EmployeeID, 
       e.FirstName, 
       IIF(p.StartDate >= '2005-01-01', NULL, p.[Name]) as [ProjectName]
FROM Employees AS e
     INNER JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
     INNER JOIN Projects AS p ON ep.ProjectID = p.ProjectID
WHERE e.EmployeeID = 24;


--Problem 9
SELECT empl.EmployeeID, 
       empl.FirstName, 
       empl.ManagerID, 
       mng.FirstName AS [ManagerName]
FROM Employees AS empl
     INNER JOIN Employees AS mng ON mng.EmployeeID = empl.ManagerID
WHERE mng.EmployeeID IN(3, 7)
ORDER BY empl.EmployeeID;

--Problem 10
SELECT TOP (50) empl.EmployeeID, 
                concat(empl.FirstName, ' ', empl.LastName) AS EmployeeName, 
                concat(mng.FirstName, ' ', mng.LastName) AS ManagerName, 
                d.[Name] AS DepartmentName
FROM Employees AS empl
     INNER JOIN Employees AS mng ON empl.ManagerID = mng.EmployeeID
     INNER JOIN Departments AS d ON empl.DepartmentID = d.DepartmentID
ORDER BY empl.EmployeeID;

--Problem 11
SELECT MIN(temp.AvgSalary) AS MinAverageSalary
FROM
(
    SELECT AVG(Salary) AS AvgSalary
    FROM Employees
    GROUP BY DepartmentID
) AS temp;


USE [Geography];

--Problem 12
SELECT c.CountryCode, 
       m.MountainRange, 
       p.PeakName, 
       p.Elevation
FROM Countries AS c
     INNER JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
     INNER JOIN Mountains AS m ON mc.MountainId = m.Id
     INNER JOIN Peaks AS p ON p.MountainId = m.Id
WHERE c.CountryCode = 'BG'
      AND p.Elevation > 2835
ORDER BY p.Elevation DESC;

--Problem 13
SELECT c.CountryCode, 
       COUNT(m.MountainRange) AS MountainRanges
FROM Countries AS c
     INNER JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
     INNER JOIN Mountains AS m ON mc.MountainId = m.Id
WHERE c.CountryCode IN('US', 'RU', 'BG')
GROUP BY c.CountryCode;

--Problem 14
SELECT TOP (5) c.CountryName, 
               r.RiverName
FROM Countries AS c
     LEFT JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
     LEFT JOIN Rivers AS r ON cr.RiverId = r.Id
WHERE c.ContinentCode = 'AF'
ORDER BY c.CountryName;

--Problem 15 
SELECT k.ContinentCode, 
       k.CurrencyCode, 
       k.CurrencyUsage
FROM
(
    SELECT c.ContinentCode, 
           c.CurrencyCode, 
           COUNT(CurrencyCode) AS CurrencyUsage, 
           DENSE_RANK() OVER(PARTITION BY c.ContinentCode
           ORDER BY COUNT(CurrencyCode) DESC) AS [CurrencyRank]
    FROM Countries AS c
    GROUP BY c.ContinentCode, 
             c.CurrencyCode
    HAVING COUNT(c.CurrencyCode) > 1
) AS k
WHERE k.CurrencyRank = 1
ORDER BY k.ContinentCode;


--Problem 16
SELECT COUNT(*) AS [Count]
FROM Countries AS c
     LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
WHERE mc.MountainId IS NULL;

--Problem 17
SELECT TOP (5) CountryName, 
               MAX(p.Elevation) AS [HighestPeakElevation], 
               MAX(r.[Length]) AS [LongestRiverLength]
FROM Countries AS c
     LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
     LEFT JOIN Mountains AS m ON mc.MountainId = m.Id
     LEFT JOIN Peaks AS p ON m.Id = p.MountainId
     LEFT JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
     LEFT JOIN Rivers AS r ON cr.RiverId = r.Id
GROUP BY c.CountryName
ORDER BY HighestPeakElevation DESC, 
         LongestRiverLength DESC, 
         c.CountryName;

--Problem 18 ???
SELECT TOP (5) k.CountryName, 
               k.[Highest Peak Name], 
               k.[Highest Peak Elevation], 
               k.Mountain
FROM
(
    SELECT c.CountryName, 
           ISNULL(p.PeakName, '(no highest peak)') AS [Highest Peak Name], 
           ISNULL(p.Elevation, 0) AS [Highest Peak Elevation], 
           ISNULL(m.MountainRange, '(no mountain)') AS [Mountain], 
           DENSE_RANK() OVER(PARTITION BY c.CountryName
           ORDER BY p.Elevation DESC) AS [ElevationRank]
    FROM Countries AS c
         LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
         LEFT JOIN Mountains AS m ON mc.MountainId = m.Id
         LEFT JOIN Peaks AS p ON m.Id = p.MountainId
) AS k
WHERE k.ElevationRank = 1
ORDER BY k.CountryName, 
         k.[Highest Peak Name];