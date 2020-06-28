CREATE DATABASE [ColonialJourney]
GO
USE [ColonialJourney]
GO
/*1*/
CREATE TABLE Planets
	(
		Id INT PRIMARY KEY IDENTITY,
		[Name] VARCHAR(30) NOT NULL
	)
CREATE TABLE Spaceports
	(
		Id INT PRIMARY KEY IDENTITY,
		[Name] VARCHAR(50) NOT NULL,
		PlanetId INT NOT NULL FOREIGN KEY REFERENCES Planets(Id)
	)
CREATE TABLE Spaceships
	(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	Manufacturer VARCHAR(30) NOT NULL,
	LightSpeedRate INT DEFAULT 0
	)
CREATE TABLE Colonists
	(
		Id INT PRIMARY KEY IDENTITY,
		FirstName VARCHAR(20) NOT NULL,
		LastName VARCHAR(20) NOT NULL,
		Ucn VARCHAR(10) NOT NULL UNIQUE,
		BirthDate DATE NOT NULL
	)
CREATE TABLE Journeys
	(
		Id INT PRIMARY KEY IDENTITY,
		JourneyStart DATETIME NOT NULL,
		JourneyEnd DATETIME NOT NULL,
		Purpose VARCHAR(11) CHECK(Purpose IN ('Medical', 'Technical', 'Educational', 'Military')),
		DestinationSpaceportId INT NOT NULL FOREIGN KEY REFERENCES Spaceports(Id),
		SpaceshipId INT NOT NULL FOREIGN KEY REFERENCES Spaceships(Id)
	)
CREATE TABLE TravelCards
	(
	Id INT PRIMARY KEY IDENTITY,
	CardNumber VARCHAR(10) NOT NULL UNIQUE CHECK(LEN(CardNumber)=10),
	JobDuringJourney VARCHAR(8) CHECK(JobDuringJourney IN ('Pilot', 'Engineer', 'Trooper', 'Cleaner', 'Cook')),
	ColonistId INT NOT NULL FOREIGN KEY REFERENCES Colonists(Id),
	JourneyId INT NOT NULL FOREIGN KEY REFERENCES Journeys(Id)
	)
/*2*/
INSERT INTO Planets 
	VALUES
		('Mars'),
		('Earth'),
		('Jupiter'),
		('Saturn')
INSERT INTO Spaceships([Name],[Manufacturer],[LightSpeedRate])
	VALUES
		('Golf','VW',3),
		('WakaWaka','Wakanda',4),
		('Falcon9','SpaceX',1),
		('Bed','Vidolov',6)
/*3*/
UPDATE Spaceships
	SET LightSpeedRate+=1
WHERE Id BETWEEN 8 AND 12
/*4*/
DELETE FROM TravelCards
	WHERE JourneyId IN (SELECT TOP (3) Id FROM Journeys)
DELETE TOP (3) FROM Journeys
/*5*/
SELECT 
	Id,
	FORMAT(JourneyStart,'dd/MM/yyyy') AS JourneyStart,
	FORMAT(JourneyEnd,'dd/MM/yyyy') AS JourneyEnd 
		FROM Journeys
WHERE Purpose LIKE 'Military'
ORDER BY JourneyStart 
/*6*/
SELECT 
	c.Id, (c.FirstName + ' ' + c.LastName) AS full_name
	FROM Colonists AS c
JOIN TravelCards AS tc ON c.Id = tc.ColonistId AND tc.JobDuringJourney = 'pilot'
ORDER BY c.Id
/*7*/
SELECT COUNT(*) AS [count] FROM Journeys AS j
JOIN TravelCards AS tc ON tc.JourneyId = j.Id
JOIN Colonists AS c ON c.Id = tc.ColonistId
WHERE j.Purpose LIKE 'technical'
/*8*/
	SELECT s.[Name],
	s.Manufacturer
	FROM Colonists AS c 
	JOIN TravelCards AS tc ON tc.ColonistId = c.Id
	JOIN Journeys AS j ON j.Id = tc.JourneyId
	JOIN Spaceships AS s ON s.Id = j.SpaceshipId
	WHERE DATEDIFF(YEAR,c.BirthDate,'2019')  < 30 AND tc.JobDuringJourney='Pilot'
	ORDER BY s.[Name]
/*9*/
SELECT * FROM (
		SELECT p.[Name] AS [PlanetName], COUNT(*) AS [JourneysCount] FROM Planets AS p 
JOIN Spaceports AS s ON s.PlanetId = p.Id
JOIN Journeys AS j ON j.DestinationSpaceportId = s.Id
GROUP BY p.[Name]) AS t
ORDER BY t.JourneysCount DESC, t.PlanetName
/*10*/
SELECT * FROM (
		SELECT tc.JobDuringJourney,(c.FirstName + ' ' + c.LastName) AS [FullName],
		DENSE_RANK() OVER (PARTITION BY tc.JobDuringJourney ORDER BY c.Birthdate ) AS [JobRank]
		FROM Colonists AS c
		JOIN TravelCards AS tc ON tc.ColonistId = c.Id) AS t
WHERE t.[JobRank] = 2
/*11*/
GO
CREATE FUNCTION dbo.udf_GetColonistsCount(@PlanetName VARCHAR (30))
RETURNS INT
	BEGIN
		RETURN (
		SELECT COUNT(*) FROM Planets AS p 
		JOIN Spaceports AS s ON s.PlanetId = p.Id
		JOIN Journeys AS j ON j.DestinationSpaceportId = s.Id
		JOIN TravelCards AS tc ON tc.JourneyId = j.Id
		JOIN Colonists AS c ON c.Id = tc.ColonistId
		WHERE p.Name = @PlanetName)
	END
GO

/*12*/
GO
CREATE PROCEDURE usp_ChangeJourneyPurpose(@JourneyId INT, @NewPurpose VARCHAR(11))
	AS 
	BEGIN
			IF((SELECT COUNT(*) FROM Journeys WHERE Id = @JourneyId) = 0)
				BEGIN
					THROW 50001, 'The journey does not exist!',1;
				END

			IF((SELECT Purpose FROM Journeys WHERE Id = @JourneyId) LIKE @NewPurpose)
				BEGIN
					THROW 50002, 'You cannot change the purpose!',1;
				END
		UPDATE Journeys
			SET Purpose = @NewPurpose
		WHERE Id = @JourneyId
	END