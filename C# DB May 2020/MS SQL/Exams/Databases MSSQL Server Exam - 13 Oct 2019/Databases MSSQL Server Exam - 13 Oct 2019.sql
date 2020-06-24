CREATE DATABASE [Bitbucket]
GO
USE [Bitbucket]
GO
/*1*/
CREATE TABLE Users
(
	Id INT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) NOT NULL,
	[Password] VARCHAR(30) NOT NULL,
	Email VARCHAR(50) NOT NULL
)
CREATE TABLE Repositories
	(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
	)
CREATE TABLE RepositoriesContributors
	(
	RepositoryId INT NOT NULL FOREIGN KEY REFERENCES Repositories(Id),
	ContributorId INT NOT NULL FOREIGN KEY REFERENCES Users(Id),
	PRIMARY KEY(RepositoryId,ContributorId)
	)
CREATE TABLE Issues
	(
	Id INT PRIMARY KEY IDENTITY,
	Title VARCHAR(255) NOT NULL,
	IssueStatus VARCHAR(6) NOT NULL,
	RepositoryId INT NOT NULL FOREIGN KEY REFERENCES Repositories(Id),
	AssigneeId INT NOT NULL FOREIGN KEY REFERENCES Users(Id)
	)
CREATE TABLE Commits
	(
	Id INT PRIMARY KEY IDENTITY,
	[Message] VARCHAR(255) NOT NULL,
	IssueId INT FOREIGN KEY REFERENCES Issues(id),
	RepositoryId INT NOT NULL FOREIGN KEY REFERENCES Repositories(Id),
	ContributorId INT NOT NULL FOREIGN KEY REFERENCES Users(Id)	
	)
CREATE TABLE Files
	(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(100) NOT NULL,
	Size DECIMAL(17,2) NOT NULL,
	ParentId INT FOREIGN KEY REFERENCES Files(Id),
	CommitId INT NOT NULL FOREIGN KEY REFERENCES Commits(Id)
	)
/*2*/
GO
INSERT INTO Files(Name,Size,ParentId,CommitId)
	VALUES 
		('Trade.idk',	2598.0,	1,1),
		('menu.net',	9238.31,	2,	2),
		('Administrate.soshy',	1246.93,	3,	3),
		('Controller.php',	7353.15,	4,	4),
		('Find.java',	9957.86,	5,	5),
		('Controller.json',	14034.87,	3,	6),
		('Operate.xix',	7662.92,	7,	7)

INSERT INTO Issues(Title,IssueStatus,RepositoryId,AssigneeId)
	VALUES
		('Critical Problem with HomeController.cs file',	'open',	1,4),
		('Typo fix in Judge.html',	'open',	4,	3),
		('Implement documentation for UsersService.cs',	'closed',	8,2),
		('Unreachable code in Index.cs',	'open',	9,8)
/*3*/
UPDATE Issues
	SET IssueStatus = 'closed'
	WHERE AssigneeId=6
/*4*/

DROP DATABASE [Bitbucket]
GO
DELETE FROM Repositories
	WHERE Id IN
(
	SELECT * 
	FROM RepositoriesContributors AS rc
	JOIN Commits AS c ON rc.RepositoryId = c.RepositoryId
	JOIN Files AS f ON f.CommitId = c.Id
	JOIN Issues AS i ON i.RepositoryId = c.RepositoryId
		WHERE rc.RepositoryId = 3
)

DELETE FROM RepositoriesContributors
	WHERE RepositoryId = 3
DELETE FROM Files
	
DELETE FROM Commits
	WHERE RepositoryId = 3

DELETE FROM Repositories
	WHERE Id = 3
/*5*/
SELECT 
	Id,
	[Message],
	RepositoryId,
	ContributorId 
FROM Commits
ORDER BY Id,[Message],RepositoryId,ContributorId 
/*6*/
SELECT Id,[Name],Size FROM Files
	WHERE [Name] LIKE '%html%' AND Size > 1000
ORDER BY Size DESC,Id,[Name]
/*7*/
SELECT i.Id,(u.Username + ' ' + ':' +' ' + i.Title) AS [IssueAssignee] FROM Issues AS i
JOIN Users AS u ON i.AssigneeId = u.Id
ORDER BY i.Id DESC,i.AssigneeId
/*8*/
SELECT f.Id,f.[Name],f.Size FROM Files AS f
WHERE f.Id NOT IN (f.ParentId)
ORDER BY f.Id,f.[Name],f.Size
/*9*/
SELECT TOP(5) r.Id, r.[Name], COUNT(c.RepositoryId) AS [Commits] FROM Repositories AS r
JOIN Commits AS c
ON c.RepositoryId = r.Id
LEFT JOIN RepositoriesContributors AS rc
ON rc.RepositoryId = r.Id
GROUP BY r.Id, r.[Name]
ORDER BY [Commits] DESC, r.Id, r.[Name]
/*10*/
SELECT u.Username,AVG(f.Size) AS Size FROM Users AS u
JOIN Commits AS c ON c.ContributorId=u.Id
JOIN Files AS f  ON f.CommitId = c.Id
GROUP BY u.Username
ORDER BY Size DESC,u.Username
/*11*/
GO
CREATE FUNCTION udf_UserTotalCommits(@username VARCHAR(30))
	RETURNS INT
		AS
			BEGIN
				DECLARE @totalCommitsByUser INT = (
					SELECT COUNT(*) FROM Commits AS c
						JOIN Users AS u ON u.Username=@username AND u.Id=c.ContributorId)
			RETURN @totalCommitsByUser
			END
GO
/*12*/	
CREATE PROCEDURE usp_FindByExtension(@extension VARCHAR(10))
	AS
		BEGIN
			SELECT Id,[Name],(Size + 'KB') AS Size FROM Files
				WHERE RIGHT([Name],LEN(@extension)) = @extension
			ORDER BY Id,[Name],Size DESC
		END
GO