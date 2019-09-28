USE SoftUni;

--Problem 1
SELECT FirstName, 
       LastName
FROM Employees
WHERE FirstName LIKE 'SA%';

--Problem 2
SELECT FirstName, 
       LastName
FROM Employees
WHERE LastName LIKE '%ei%';

--Problem 3
SELECT FirstName
FROM Employees
WHERE DepartmentID IN(3, 10)
AND DATEPART(year, HireDate) BETWEEN 1995 AND 2005;

--Problem 4
SELECT FirstName, 
       LastName
FROM Employees
WHERE JobTitle NOT LIKE '%engineer%';

--Problem 5
SELECT [Name]
FROM Towns
WHERE LEN([Name]) IN(5, 6)
ORDER BY [Name];

--Problem 6
SELECT TownID, [Name]
FROM Towns
WHERE [Name] LIKE '[MKBE]%'
ORDER BY [Name];

--second way
SELECT TownID, [Name]
FROM Towns
WHERE LEFT([Name], 1) IN('M', 'K', 'B', 'E')
ORDER BY [Name];

--Problem 7
SELECT TownID, [Name]
FROM Towns
WHERE [Name] NOT LIKE '[RBD]%'
ORDER BY [Name];

--Problem 8
CREATE VIEW V_EmployeesHiredAfter2000
AS
     SELECT FirstName, 
            LastName
     FROM Employees
     WHERE DATEPART(year, HireDate) > 2000;

--SELECT *
--FROM V_EmployeesHiredAfter2000;

--Problem 9
SELECT FirstName, 
       LastName
FROM Employees
WHERE LEN(LastName) = 5;

--Problem 10
SELECT EmployeeID, 
       FirstName, 
       LastName, 
       Salary, 
       DENSE_RANK() OVER(PARTITION BY salary
       ORDER BY EmployeeId) AS [Rank]
FROM Employees
WHERE Salary BETWEEN 10000 AND 50000
ORDER BY Salary DESC;

--Problem 11
SELECT *
FROM
(
    SELECT EmployeeID, FirstName, LastName, Salary, 
           DENSE_RANK() OVER(PARTITION BY salary
           ORDER BY EmployeeId) AS [Rank]
    FROM Employees
    WHERE Salary BETWEEN 10000 AND 50000
) AS [Temp]
WHERE Temp.[Rank] = 2
ORDER BY Salary DESC;

USE [Geography];

--Problem 12
SELECT CountryName, 
       IsoCode
FROM Countries
WHERE CountryName LIKE '%A%A%A%'
ORDER BY IsoCode;

--Problem 13

SELECT p.PeakName, 
       r.RiverName, 
       LOWER(CONCAT(LEFT(p.PeakName, LEN(p.PeakName) - 1), r.RiverName)) AS [Mix]
FROM Peaks AS p, 
     Rivers AS r
WHERE RIGHT(p.PeakName, 1) = LEFT(r.RiverName, 1)
ORDER BY Mix;

--second way
SELECT p.PeakName, 
       r.RiverName, 
       LOWER(CONCAT(LEFT(p.PeakName, LEN(p.PeakName) - 1), r.RiverName)) AS [Mix]
FROM Peaks AS p
     JOIN Rivers AS r ON RIGHT(p.PeakName, 1) = LEFT(r.RiverName, 1)
ORDER BY Mix;

USE Diablo

--Problem 14
SELECT TOP (50) [Name], 
                Format([Start], 'yyyy-MM-dd') AS [Start]
FROM Games
WHERE DATEPART(YEAR, [Start]) IN(2011, 2012)
ORDER BY [Start], 
         [Name];

--Problem 15
SELECT Username, 
       SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email)) AS [Email Provider]
FROM Users
ORDER BY [Email Provider], 
         Username;

--Problem 16
SELECT [Username], 
       IpAddress
FROM Users
WHERE IpAddress LIKE '___.1_%._%.___'
ORDER BY [Username];


--Problem 17
SELECT [Name] AS [Game],
       CASE
           WHEN DATEPART(HOUR, [Start]) BETWEEN 0 AND 11
           THEN 'Morning'
           WHEN DATEPART(HOUR, [Start]) BETWEEN 12 AND 17
           THEN 'Afternoon'
           ELSE 'Evening'
       END AS 'Part of the Day',
       CASE
           WHEN Duration <= 3
           THEN 'Extra Short'
           WHEN Duration BETWEEN 4 AND 6
           THEN 'Short'
           WHEN Duration > 6
           THEN 'Long'
           WHEN Duration IS NULL
           THEN 'Extra Long'
       END AS 'Duration'
FROM games
ORDER BY Game, 
         Duration, 
         [Part of the Day];


USE Orders

--Problem 18
SELECT ProductName, 
       OrderDate, 
       DATEADD(DAY, 3, OrderDate) AS [Pay Due],
	   DATEADD(MONTH, 1, OrderDate) AS [Deliver Due]
FROM orders;

--Problem 19
CREATE TABLE People
(Id        INT
 PRIMARY KEY IDENTITY, 
 [Name]    VARCHAR(30) NOT NULL, 
 Birthdate DATETIME NOT NULL
);

INSERT INTO People
([Name], Birthdate)
VALUES  ('Victor', '2000-12-07'),
		('Steven', '1992-09-10'),
		('Stephen', '1910-09-19'),
		('John', '2010-01-06');

SELECT [Name], 
       DATEDIFF(YEAR, Birthdate, GETDATE()) AS [Age in Years], 
       DATEDIFF(MONTH, Birthdate, GETDATE()) AS [Age in Months], 
       DATEDIFF(DAY, Birthdate, GETDATE()) AS [Age in Days], 
       DATEDIFF(MINUTE, Birthdate, GETDATE()) AS [Age in Minutes]
FROM People;