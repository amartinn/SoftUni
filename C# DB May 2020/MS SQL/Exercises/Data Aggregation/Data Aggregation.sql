/*1*/
USE [Gringotts]
GO
SELECT COUNT(*) AS [Count] FROM WizzardDeposits
/*2*/
SELECT MAX(MagicWandSize) AS [LongestMagicWand] FROM WizzardDeposits
/*3*/
SELECT DepositGroup,MAX(MagicWandSize) AS [LongestMagicWand] FROM WizzardDeposits
GROUP BY DepositGroup
/*4*/
SELECT TOP(2) DepositGroup FROM WizzardDeposits
GROUP BY DepositGroup
ORDER BY AVG(MagicWandSize)
/*5*/
SELECT DepositGroup,SUM(DepositAmount) AS [TotalSum] FROM WizzardDeposits
GROUP BY DepositGroup
/*6*/
SELECT DepositGroup,SUM(DepositAmount) AS [TotalSum] FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup
/*7*/
SELECT * FROM (
SELECT DepositGroup,SUM(DepositAmount) AS [TotalSum] FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup) AS totalDepositsQuery
WHERE TotalSum < 150000
ORDER BY TotalSum DESC
/*8*/
SELECT DepositGroup,MagicWandCreator,MIN(DepositCharge) AS MinDepositCharge FROM WizzardDeposits
GROUP BY DepositGroup,MagicWandCreator
ORDER BY MagicWandCreator,DepositGroup
/*9*/
SELECT *,COUNT(*) AS WizzardCount FROM 
(
	SELECT CASE	
		WHEN AGE <10 THEN '[0-10]'
		WHEN AGE >= 11 AND AGE <=20 THEN '[11-20]'
		WHEN AGE >= 21 AND AGE <=30 THEN '[21-30]'
		WHEN AGE >= 31 AND AGE <=40 THEN '[31-40]'
		WHEN AGE >= 41 AND AGE <=50 THEN '[41-50]'
		WHEN AGE >= 51 AND AGE <=60 THEN '[51-60]'
		ELSE '[61+]'
		END
		AS [Age Group]
	FROM WizzardDeposits
)
AS ageGroupQuery
GROUP BY [Age Group]
/*10*/
SELECT * FROM 
	(
		SELECT LEFT(FirstName,1) AS FirstLetter FROM WizzardDeposits
		WHERE DepositGroup = 'Troll Chest'
	) as temp
GROUP BY FirstLetter
/*11*/
SELECT DepositGroup,IsDepositExpired,AVG(DepositInterest) AS AverageInterest FROM WizzardDeposits
WHERE DepositStartDate >'01.01.1985'
GROUP BY DepositGroup,IsDepositExpired
ORDER BY DepositGroup DESC,IsDepositExpired
/*12*/
SELECT SUM([Difference]) AS [SumDifference] FROM 
(
	SELECT *,[Host Wizard Deposit] - [Guest Wizard Deposit] AS [Difference] FROM 
	(
		SELECT FirstName AS [Host Wizard],
		DepositAmount AS [Host Wizard Deposit],
		LEAD(FirstName) OVER (ORDER BY Id) AS [Guest Wizard],
		LEAD(DepositAmount) OVER (ORDER BY Id) AS [Guest Wizard Deposit]
		FROM WizzardDeposits
	) as temp
) as final
/*13*/
USE [SoftUni]
GO
SELECT DepartmentID,SUM(Salary) AS TotalSalary FROM Employees
GROUP BY DepartmentID
ORDER BY DepartmentID
/*14*/
SELECT DepartmentID,MIN(Salary) AS TotalSalary FROM Employees
WHERE DepartmentID IN (2,5,7) AND HireDate > '1.1.2000'
GROUP BY DepartmentID
ORDER BY DepartmentID
/*15*/
SELECT * INTO EmployeesWithHighSalary FROM Employees
WHERE Salary > 30000

DELETE FROM EmployeesWithHighSalary 
WHERE ManagerID=42

UPDATE EmployeesWithHighSalary
SET Salary += 5000
WHERE DepartmentID = 1

SELECT DepartmentID, AVG(Salary) AS AverageSalary FROM EmployeesWithHighSalary
GROUP BY DepartmentID
/*16*/
SELECT * FROM 
	(
	SELECT DepartmentID,MAX(Salary) AS [MaxSalary] FROM Employees
	GROUP BY DepartmentID
	) AS highestSalaryQuery
WHERE MaxSalary NOT BETWEEN 30000 AND 70000	
/*17*/
SELECT COUNT(EmployeeId) AS [Count] FROM Employees
WHERE ManagerID IS NULL
/*18*/
SELECT DISTINCT DepartmentID,Salary AS ThirdHighestSalary FROM 
(SELECT DepartmentId,Salary,
	DENSE_RANK() OVER (PARTITION BY DepartmentId ORDER BY SALARY DESC) AS [Rank] FROM Employees
) as temp
WHERE [Rank] IN (3)
/*19*/
SELECT TOP (10)  FirstName,LastName,DepartmentId FROM Employees as e
WHERE Salary > (
	SELECT AVG(Salary) FROM Employees as e2
	WHERE e2.DepartmentID=e.DepartmentID
	)
ORDER BY DepartmentID 
