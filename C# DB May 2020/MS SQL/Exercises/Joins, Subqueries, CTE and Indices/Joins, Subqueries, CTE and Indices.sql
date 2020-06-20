USE SoftUni
/*1*/
SELECT TOP(5) e.EmployeeId, e.JobTitle,a.AddressID,a.AddressText
FROM Employees AS e
JOIN Addresses AS a
ON a.AddressID = e.AddressID
ORDER BY a.AddressID 
/*2*/
SELECT TOP(50) e.FirstName,e.LastName, t.[Name], a.AddressText
FROM Employees AS e
JOIN Addresses AS a
ON a.AddressID=e.AddressID
JOIN Towns AS t 
ON t.TownID = a.TownID
ORDER BY e.FirstName,e.LastName
/*3*/
SELECT e.EmployeeID, e.FirstName, e.LastName,d.[Name] as [DepartmentName] FROM Employees as e
JOIN Departments AS d 
ON d.DepartmentID=e.DepartmentID 
WHERE d.Name = 'Sales'
ORDER BY e.EmployeeID
/*4*/
SELECT TOP (5) e.EmployeeID, e.FirstName,e.Salary,d.[Name] as [DepartmentName] FROM Employees as e
JOIN Departments AS d 
ON d.DepartmentID=e.DepartmentID 
WHERE e.Salary > 15000
ORDER BY e.DepartmentID 
/*5*/
SELECT DISTINCT TOP (3) e.EmployeeID,e.FirstName FROM Employees AS E
JOIN EmployeesProjects AS ep
ON e.EmployeeID NOT IN(SELECT DISTINCT EmployeeID FROM EmployeesProjects)
ORDER BY e.EmployeeID
/*6*/
SELECT e.FirstName,e.LastName, e.HireDate,d.[Name] as DeptName FROM Employees AS e 
JOIN Departments AS d 
ON e.DepartmentID = d.DepartmentID
WHERE e.HireDate > '1.1.1999' AND d.[Name] IN ('Sales','Finance')
ORDER BY e.HireDate
/*7*/
SELECT TOP(5) e.EmployeeID,e.FirstName,p.[Name] AS ProjectName FROM Employees AS e
JOIN EmployeesProjects AS ep
ON e.EmployeeID=ep.EmployeeID
JOIN Projects AS p
ON p.ProjectID=ep.ProjectID
WHERE p.StartDate > '2002.08.13' AND p.EndDate IS NULL
ORDER BY e.EmployeeID
/*8*/
SELECT e.EmployeeID,e.FirstName,
CASE
	WHEN p.StartDate > '01.01.2005' THEN NULL
	ELSE p.[Name]
	END AS ProjectName
FROM Employees AS e
JOIN EmployeesProjects AS ep
ON e.EmployeeID=ep.EmployeeID
JOIN Projects AS p
ON p.ProjectID=ep.ProjectID
WHERE e.EmployeeID=24
ORDER BY e.EmployeeID
/*9*/
SELECT e.EmployeeID,e.FirstName,e.ManagerId,e2.FirstName AS ManagerName
FROM Employees AS e
JOIN Employees AS e2 
ON e2.EmployeeID=e.ManagerID AND e.ManagerID IN (3,7)
ORDER BY e.EmployeeID 
/*10*/
SELECT TOP(50) e.EmployeeID,e.FirstName + ' ' + e.LastName as EmployeeName,e2.FirstName + ' ' +  e2.LastName AS ManagerName,d.[Name] AS DepartmentName 
FROM Employees AS e
JOIN Employees AS e2 
ON e2.EmployeeID=e.ManagerID
JOIN Departments as d
ON d.DepartmentID=e.DepartmentID
ORDER BY e.EmployeeID 
/*11*/
SELECT MIN(AverageSalaryByDepartment) AS MinAverageSalary FROM
(SELECT AVG(Salary) AS AverageSalaryByDepartment FROM Employees
GROUP BY DepartmentID) AS AvgSalaries
/*12*/
USE Geography
GO 
SELECT c.CountryCode,m.MountainRange,p.PeakName,p.Elevation FROM Countries AS c
JOIN MountainsCountries AS mc
ON c.CountryCode = mc.CountryCode AND c.CountryCode LIKE 'BG'
JOIN Mountains AS m 
ON mc.MountainId = m.Id
JOIN Peaks as p 
ON p.MountainId = m.Id AND p.Elevation > 2835
ORDER BY p.Elevation DESC
/*13*/
SELECT c.CountryCode,COUNT(mc.MountainId) AS MountainRanges FROM Countries as c 
JOIN MountainsCountries AS mc
ON c.CountryCode = mc.CountryCode AND c.CountryName IN ('United States', 'Russia', 'Bulgaria')
GROUP BY c.CountryCode
/*14*/
SELECT TOP(5) c.CountryName, r.RiverName FROM Rivers as r
JOIN CountriesRivers as cr 
ON cr.RiverId=r.Id
RIGHT OUTER JOIN Countries as c
ON c.CountryCode = cr.CountryCode
WHERE c.ContinentCode='AF'
ORDER BY c.CountryName
