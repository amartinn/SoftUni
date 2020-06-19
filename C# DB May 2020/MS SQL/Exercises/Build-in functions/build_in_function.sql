/* 1 */
SELECT FirstName,LastName from Employees
WHERE FirstName LIKE 'SA%'
/* 2 */
SELECT FirstName,LastName from Employees
WHERE LastName LIKE '%ei%'
/* 3 */
SELECT FirstName from Employees
WHERE DepartmentID IN (3,10) AND YEAR(HireDate) BETWEEN 1995 AND 2005
/* 4 */
SELECT FirstName,LastName from Employees
WHERE JobTitle NOT LIKE '%engineer%'
/* 5 */
SELECT [Name] FROM Towns 
WHERE LEN([Name]) = 5 OR LEN([Name]) = 6 
ORDER BY [Name] ASC
/* 6 */
SELECT TownID,[Name] FROM Towns
WHERE [Name] LIKE '[MKBE]%'
ORDER BY [Name] ASC
/* 7 */
SELECT TownID,[Name] FROM Towns
WHERE [Name] NOT LIKE '[RBD]%'
ORDER BY [Name] ASC
/* 8 */
CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT FirstName,LastName FROM Employees
WHERE YEAR(HireDate) >2000
/* 9 */
SELECT FirstName,LastName FROM Employees
WHERE LEN(LastName)=5
/* 10 */
SELECT EmployeeID,FirstName,LastName,Salary,DENSE_RANK() OVER(
PARTITION BY Salary ORDER BY EmployeeID ASC) AS [Rank] 
FROM Employees
WHERE Salary BETWEEN 10000 and 50000 
ORDER BY Salary DESC
/* 11 */
SELECT t.* FROM 
(SELECT EmployeeID,FirstName,LastName,Salary,DENSE_RANK() OVER(
PARTITION BY Salary ORDER BY EmployeeID ASC) AS [Rank] 
FROM Employees
WHERE Salary BETWEEN 10000 and 50000) t
WHERE t.Rank = 2
ORDER BY Salary DESC
/* 12 */
USE [Geography]

SELECT CountryName AS [Country Name] ,IsoCode AS [ISO CODE] FROM Countries
WHERE CountryName LIKE '%A%A%A%'
ORDER BY IsoCode ASC
/* 13 */
SELECT p.PeakName,r.RiverName, LOWER(p.PeakName + SUBSTRING(r.RiverName,2,LEN(r.RiverName)-1)) AS Mix
FROM Peaks AS p
JOIN Rivers AS r 
ON RIGHT(p.PeakName,1) = LEFT(r.RiverName,1)
ORDER BY Mix
/* 14 */
USE Diablo
SELECT TOP (50) [Name],FORMAT([Start],'yyyy-MM-dd') AS [Start] FROM Games
WHERE DATEPART(YEAR,[Start]) IN (2011,2012)
ORDER BY [Start],[Name] 
/* 15 */
SELECT [Username],SUBSTRING(Email,CHARINDEX('@',Email,1)+1,LEN(Email)) as [Email Provider]  FROM Users
ORDER BY [Email Provider] ASC, [Username] ASC
/* 16 */
SELECT Username,IpAddress FROM Users
WHERE IpAddress LIKE '___.1%.%.___'
ORDER BY Username
/* 17 */
SELECT[Name] AS Game,
[Part of the day] = 
	CASE
		WHEN DATEPART(HOUR,[Start]) BETWEEN 0 AND 11 THEN 'Morning'
		WHEN DATEPART(HOUR,[Start]) BETWEEN 12 AND 17 THEN 'Afternoon'
		ELSE 'Evening'
	END,
[Duration] = 
	CASE
		WHEN Duration  <=3 THEN 'Extra Short'
		WHEN Duration BETWEEN 4 AND 6 THEN 'Short'
		WHEN Duration > 6 THEN 'Long'
		ELSE 'Extra Long'
	END
FROM Games
ORDER BY [Name], Duration
/* 18 */

CREATE TABLE Orders
(	Id INT PRIMARY KEY IDENTITY NOT NULL,
	ProductName NVARCHAR(30) NOT NULL,
	OrderDate DATETIME NOT NULL
)
INSERT INTO Orders VALUES
('Butter'	,'2016-09-19 00:00:00.000'),
('Milk'	,'2016-09-30 00:00:00.000'),
('Cheese'	,'2016-09-04 00:00:00.000'),
('Bread'	,'2015-12-20 00:00:00.000'),
('Tomatoes','2015-12-30 00:00:00.000')

SELECT ProductName,OrderDate,DATEADD(DAY,3,OrderDate) AS [Pay Due],
DATEADD(MONTH,1,ORDERDATE) AS [Deliver Due] FROM Orders