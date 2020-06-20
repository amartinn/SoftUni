/*1*/
USE SoftUni 
GO
CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000 
AS
BEGIN
	SELECT FirstName,LastName FROM Employees
	WHERE Salary > 35000
END
GO
/*2*/
CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber(@salary Decimal(18,4))
AS
BEGIN 
SELECT FirstName,LastName FROM Employees
WHERE Salary >=@salary
END
GO
/*3*/
CREATE PROCEDURE usp_GetTownsStartingWith (@townName VARCHAR(50))
AS
BEGIN 
SELECT [Name] AS Town FROM Towns
WHERE LEFT([Name],LEN(@townName)) = @townName
END
GO
/*4*/
CREATE PROCEDURE usp_GetEmployeesFromTown (@townName VARCHAR(50))
AS
BEGIN
SELECT FirstName,LastName FROM Employees AS e
JOIN Addresses AS a
ON e.AddressID = a.AddressID
JOIN Towns AS t
ON t.TownID=a.TownID
WHERE t.[Name] =@townName
END

/*5*/
GO
CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4)) 
RETURNS VARCHAR(7)
AS
BEGIN
DECLARE @SalaryLevel VARCHAR(7);
	IF(@salary < 30000)
	BEGIN
	SET @SalaryLevel = 'Low';
	END
	ELSE IF(@salary BETWEEN 30000 AND 50000)
	BEGIN
	SET @SalaryLevel = 'Average';
	END
	ELSE
	BEGIN
	SET @SalaryLevel = 'High';
	END
RETURN @SalaryLevel
END
GO
/*6*/
CREATE PROCEDURE usp_EmployeesBySalaryLevel (@salary NVARCHAR(7))
AS
BEGIN
SELECT FirstName,LastName FROM Employees
WHERE dbo.ufn_GetSalaryLevel(Salary) LIKE @salary
END
GO
/*7*/
CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(50) , @word VARCHAR(50))
RETURNS BIT
AS
BEGIN 
DECLARE	@WordLenght INT = LEN(@word);
DECLARE @Index INT = 1;
WHILE(@Index <=@WordLenght)
BEGIN
	IF(CHARINDEX(SUBSTRING(@word,@Index,1),@setOfLetters)=0)
	BEGIN
		RETURN 0
	END
	SET @Index+=1
	END
	RETURN 1
END
GO
/*8*/
CREATE PROCEDURE usp_DeleteEmployeesFromDepartment (@departmentId INT) AS
ALTER TABLE Employees
DROP CONSTRAINT FK_Employees_Employees

ALTER TABLE EmployeesProjects
DROP CONSTRAINT FK_EmployeesProjects_Employees

ALTER TABLE EmployeesProjects
ADD CONSTRAINT FK_EmployeesProjects_Employees FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID) ON DELETE CASCADE

ALTER TABLE Departments
DROP CONSTRAINT FK_Departments_Employees

ALTER TABLE Departments
ALTER COLUMN ManagerID INT NULL

UPDATE Departments
SET ManagerID = NULL
WHERE DepartmentID = @departmentId

UPDATE Employees
SET ManagerID = NULL
WHERE DepartmentID = @departmentId

DELETE FROM Employees
WHERE DepartmentID = @departmentId AND ManagerID IS NULL

DELETE FROM Departments
WHERE DepartmentID = @departmentId

IF OBJECT_ID('[Employees].[FK_Employees_Employees]') IS NULL
    ALTER TABLE [Employees] WITH NOCHECK
        ADD CONSTRAINT [FK_Employees_Employees] FOREIGN KEY ([ManagerID]) REFERENCES [Employees]([EmployeeID]) ON DELETE NO ACTION ON UPDATE NO ACTION

IF OBJECT_ID('[Departments].[FK_Departments_Employees]') IS NULL
    ALTER TABLE [Departments] WITH NOCHECK
        ADD CONSTRAINT [FK_Departments_Employees] FOREIGN KEY ([ManagerID]) REFERENCES [Employees]([EmployeeID]) ON DELETE NO ACTION ON UPDATE NO ACTION

SELECT COUNT(*) FROM Employees
WHERE DepartmentID = @departmentId

EXEC usp_DeleteEmployeesFromDepartment 4
GO
/*9*/
USE Bank
GO

CREATE PROCEDURE usp_GetHoldersFullName AS
BEGIN
SELECT CONCAT(FirstName, ' ', LastName) AS [Full Name] FROM AccountHolders
END
GO
/*10*/
CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan(@money DECIMAL(16,2)) AS
BEGIN
SELECT ah.FirstName, ah.LastName FROM Accounts AS a
JOIN AccountHolders AS ah
ON a.AccountHolderId = ah.Id
GROUP BY ah.FirstName, ah.LastName
HAVING SUM(a.Balance) > @money
END

GO
/*11*/
CREATE FUNCTION ufn_CalculateFutureValue(@Sum DECIMAL(16, 2), @Interest FLOAT, @Years INT) 
RETURNS DECIMAL(20, 4) AS
BEGIN
	DECLARE @FutureValue DECIMAL(20, 4) = @Sum * POWER(1 + @Interest, @Years)
	RETURN @FutureValue
END
GO
/*12*/
CREATE PROCEDURE usp_CalculateFutureValueForAccount(@AccountID INT, @InterestRate FLOAT) AS
BEGIN
SELECT 
	a.Id AS [Account Id], 
	ah.FirstName AS [First Name],
	ah.LastName AS [Last Name],
	a.Balance AS [Current Balance],
	dbo.ufn_CalculateFutureValue(a.Balance, @InterestRate, 5) AS [Balance in 5 years] 
	FROM Accounts AS a
JOIN AccountHolders AS ah
ON a.AccountHolderId = ah.Id AND a.Id = @AccountID
END
GO
/*13*/
USE Diablo
GO

CREATE FUNCTION ufn_CashInUsersGames(@gameName VARCHAR(MAX))
RETURNS TABLE AS
RETURN	SELECT SUM(Cash) AS SumCash FROM
	(
		SELECT ug.Cash, ROW_NUMBER() OVER(ORDER BY Cash DESC) AS RowNum FROM UsersGames AS ug
		JOIN Games AS g
		ON g.Id = ug.GameId
		WHERE g.Name = @gameName
	) AS AllGameRows
	WHERE RowNum % 2 = 1
GO

