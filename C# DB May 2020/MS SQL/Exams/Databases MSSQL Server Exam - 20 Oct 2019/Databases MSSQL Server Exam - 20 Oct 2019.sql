CREATE DATABASE [Service]
GO
USE [Service]
GO
/*1*/
CREATE TABLE Users
(
	Id INT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) UNIQUE NOT NULL,
	[Password] VARCHAR(50) NOT NULL,
	[Name] VARCHAR(50),
	Birthdate DATETIME,
	Age INT NOT NULL
	CHECK(Age BETWEEN 14 AND 110),
	Email VARCHAR(50) NOT NULL
)
CREATE TABLE Departments
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)
CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(25),
	LastName VARCHAR(25),
	Birthdate DATETIME,
	Age INT
	CHECK(Age BETWEEN 14 AND 110),
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id)
)

CREATE TABLE Categories 
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL
)
CREATE TABLE [Status] 
(
Id INT PRIMARY KEY IDENTITY,
[Label] VARCHAR(30) NOT NULL
)
CREATE TABLE Reports
(
Id INT PRIMARY KEY IDENTITY,
CategoryId INT NOT NULL FOREIGN KEY REFERENCES Categories(Id),
StatusId INT NOT NULL FOREIGN KEY REFERENCES [Status](Id),
OpenDate DATETIME NOT NULL,
CloseDate DATETIME,
[Description] VARCHAR(200) NOT NULL,
UserId INT NOT NULL FOREIGN KEY REFERENCES Users(Id),
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id)
)
/*2*/

INSERT  INTO Employees(FirstName,LastName,BirthDate,DepartmentId) VALUES 
('Marlo',	'O''Malley',	'9.21.1958',	1),
('Niki',	'Stanaghan',	'11.26.1969',	4),
('Ayrton',	'Senna',		'03.21.1960',	9),
('Ronnie',	'Peterson',		'02.14.1944',	9),
('Giovanna','Amati',		'07.20.1959',	5)

INSERT INTO Reports(CategoryId,StatusId,OpenDate,CloseDate,[Description],UserId,EmployeeId) VALUES
(1,	1,	'2017.04.13',		NULL,		'Stuck Road on Str.133',	6,	2),
(6,	3,	'2015.09.05',	'2015.12.06',	'Charity trail running',	3,	5),
(14,2,	'2015.09.07',		NULL,		'Falling bricks on Str.58',	5,	2),
(4,	3,	'2017.07.03',	'2017.07.06',	'Cut off streetlight on Str.11',	1,	1)

/*3*/
UPDATE Reports
SET CloseDate = GETDATE()
WHERE CloseDate IS NULL
/*4*/
DELETE FROM Reports
WHERE [StatusId] =4
/*5*/
SELECT * FROM 
(
	SELECT [Description],FORMAT(OpenDate,'dd-MM-yyyy') AS OpenDate FROM Reports
	WHERE EmployeeId IS NULL
) as formattedQuery
ORDER BY Convert(datetime,OpenDate,103),[Description]
/*6*/
SELECT r.[Description],c.[Name] AS CategoryName FROM Reports AS r
LEFT OUTER JOIN Categories AS c 
ON r.CategoryId=c.Id
ORDER BY r.[Description],c.[Name]
/*7*/
SELECT  TOP(5)  * FROM 
(
	SELECT c.[Name] AS CategoryName,COUNT(*) AS ReportsNumber FROM Reports AS r
	JOIN Categories AS c
	ON r.CategoryId=c.Id
	GROUP BY CategoryId,c.[Name]
) AS tempQuery
ORDER BY ReportsNumber DESC,CategoryName
/*8*/
SELECT u.Username,c.[Name] AS CategoryName FROM Reports AS r 
JOIN Users AS u
ON r.UserId = u.Id
JOIN Categories AS c
ON r.CategoryId=c.Id
WHERE FORMAT(u.Birthdate,'dd/MM') = FORMAT(r.OpenDate,'dd/MM')
ORDER BY u.Username,c.[Name]
/*9*/
SELECT 
	FirstName + ' ' + LastName AS FullName,
	(SELECT COUNT(DISTINCT UserId) FROM Reports WHERE EmployeeId=e.Id) AS [UserCount]
FROM Employees AS e
ORDER BY [UserCount] DESC,FullName 

SELECT
	FirstName + ' ' + LastName AS FullName,
	COUNT(DISTINCT UserId) AS [UserCount]
FROM Reports AS r
RIGHT JOIN Employees AS e ON e.Id =r.EmployeeId
GROUP BY EmployeeId,FirstName,LastName
ORDER BY UserCount DESC,FullName
/*10*/
SELECT 
	ISNULL(e.FirstName + ' ' + e.LastName ,'None') AS Employee,
	ISNULL(d.[Name],'None') AS Department,
	ISNULL(c.[Name],'None') AS Category,
	r.[Description],
	FORMAT(r.OpenDate,'dd.MM.yyyy') AS OpenDate,
	s.[Label] AS [Status],
	ISNULL(u.[Name] ,'None') AS [User] 
	FROM Reports AS r
	LEFT JOIN Employees AS e ON e.Id = r.EmployeeId
	LEFT JOIN Categories AS c ON c.Id=r.CategoryId
	LEFT JOIN Departments AS d ON d.Id=c.DepartmentId
	LEFT JOIN [Status] AS s ON s.Id = r.StatusId
	LEFT JOIN Users AS u ON u.Id = r.UserId
ORDER BY 
e.FirstName DESC,
e.LastName DESC,
d.[Name] ASC,
c.[Name] ASC,
r.[Description] ASC,
r.OpenDate ASC, 
s.[Label] ASC,
u.Username ASC

/*11*/
GO
CREATE FUNCTION udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME)
RETURNS INT
AS
BEGIN
IF(@StartDate IS NULL OR @EndDate IS NULL) 
BEGIN
return 0
END
return  DATEDIFF(HOUR,@StartDate,@EndDate)
END
GO
/*12*/

CREATE PROCEDURE usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT)
AS 
BEGIN
	DECLARE @EmployeeDepartmentId INT = (SELECT DepartmentId FROM Employees WHERE Id = @EmployeeId)
	DECLARE @ReportDepartmentId INT = (
				SELECT c.DepartmentId FROM Reports AS r
				JOIN Categories AS c ON r.CategoryId = c.Id
				WHERE r.Id = @ReportId) 

	IF(@EmployeeDepartmentId != @ReportDepartmentId) 
	THROW 50000,'Employee doesn''t belong to the appropriate department!',1
UPDATE Reports
SET EmployeeId = @EmployeeId
WHERE id = @ReportId
END
GO
