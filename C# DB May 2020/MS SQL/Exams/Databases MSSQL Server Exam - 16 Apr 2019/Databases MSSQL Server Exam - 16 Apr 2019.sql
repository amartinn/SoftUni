CREATE DATABASE Airport
GO
USE [Airport]
GO
/*1*/
CREATE TABLE Planes
	(
		Id INT PRIMARY KEY IDENTITY,
		[Name] VARCHAR(30) NOT NULL,
		Seats INT NOT NULL,
		[Range] INT NOT NULL
	)
CREATE TABLE Flights
	(
		Id INT PRIMARY KEY IDENTITY,
		DepartureTime DATETIME,
		ArrivalTime DATETIME,
		Origin VARCHAR(50) NOT NULL,
		Destination VARCHAR(50) NOT NULL,
		PlaneId INT NOT NULL FOREIGN KEY REFERENCES Planes(Id)
	)
CREATE TABLE Passengers
	(
		Id INT PRIMARY KEY IDENTITY,
		FirstName VARCHAR(30) NOT NULL,
		LastName VARCHAR(30) NOT NULL,
		Age INT NOT NULL,
		[Address] VARCHAR(30) NOT NULL,
		PassportId VARCHAR(11) NOT NULL
	)
CREATE TABLE LuggageTypes
	(
		Id INT PRIMARY KEY IDENTITY,
		[Type] VARCHAR(30) NOT NULL
	)
CREATE TABLE Luggages
	(
		Id INT PRIMARY KEY IDENTITY,
		LuggageTypeId INT NOT NULL FOREIGN KEY REFERENCES LuggageTypes(Id),
		PassengerId INT NOT NULL FOREIGN KEY REFERENCES Passengers(Id)
	)
CREATE TABLE Tickets
	(
		Id INT PRIMARY KEY IDENTITY,
		PassengerId INT NOT NULL FOREIGN KEY REFERENCES Passengers(Id),
		FlightId INT NOT NULL FOREIGN KEY REFERENCES Flights(Id),
		LuggageId INT NOT NULL FOREIGN KEY REFERENCES Luggages(Id),
		Price DECIMAL(15,2) NOT NULL
	)
/*2*/
INSERT INTO Planes([Name],Seats,[Range])
	VALUES
		('Airbus 336',	112,	5132),
		('Airbus 330',	432,	5325),
		('Boeing 369',	231,	2355),
		('Stelt 297	',	254,	2143),
		('Boeing 338',	165,	5111),
		('Airbus 558',	387,	1342),
		('Boeing 128',	345,	5541)
INSERT INTO LuggageTypes([Type])
	VALUES
		('Crossbody Bag	 '),
		('School Backpack'),
		('Shoulder Bag	 ')
/*3*/
UPDATE Tickets
 SET Price *= 1.13
 WHERE FlightId = (SELECT TOP(1) Id FROM Flights WHERE Destination = 'Carlsbad')
/*4*/
DELETE FROM Tickets
WHERE FlightId = (SELECT TOP(1) Id FROM Flights WHERE Destination = 'Ayn Halagim')

DELETE FROM Flights
WHERE Destination = 'Ayn Halagim'
/*5*/
SELECT Origin,Destination FROM Flights
	ORDER BY Origin,Destination
/*6*/
SELECT Id,[Name],Seats,[Range] FROM Planes
	WHERE [Name] LIKE '%tr%'
ORDER BY Id,[Name],Seats,[Range] 
/*7*/
SELECT FlightId,SUM(Price) AS Price FROM Tickets
GROUP BY FlightId
ORDER BY Price DESC,FlightId
/*8*/
SELECT TOP(10) p.FirstName,p.LastName,t.Price FROM Passengers AS p
JOIN Tickets AS t ON t.PassengerId=p.Id
ORDER BY t.Price DESC,p.FirstName,p.LastName
/*9*/
SELECT lt.[Type],COUNT(*) AS MostUsedLuggage FROM Luggages AS l
JOIN LuggageTypes AS lt ON l.LuggageTypeId = lt.Id
GROUP BY lt.[Type]
ORDER BY MostUsedLuggage DESC,lt.[Type] 
/*10*/
SELECT (p.FirstName + ' ' + p.LastName) AS [Full Name],f.Origin,f.Destination FROM Passengers AS p
JOIN Tickets AS t ON t.PassengerId = p.Id
JOIN Flights AS f ON f.Id = t.FlightId
ORDER BY [Full Name],f.Origin,f.Destination
/*11*/
SELECT p.FirstName,p.LastName,p.Age FROM Passengers AS p
LEFT JOIN Tickets AS t ON p.Id = t.PassengerId
WHERE t.Id IS NULL
ORDER BY p.Age DESC,p.FirstName,p.LastName
/*12*/
SELECT p.PassportId AS [Passport Id],p.[Address] FROM Passengers AS p
LEFT JOIN Luggages AS l ON p.Id = l.PassengerId
	WHERE l.Id IS NULL
ORDER BY p.PassportId,p.[Address]
/*13*/
SELECT p.FirstName, p.LastName, COUNT(t.Id) AS TotalTrips
     FROM Passengers AS p
LEFT JOIN Tickets AS t ON t.PassengerId = p.Id
 GROUP BY p.FirstName, p.LastName
 ORDER BY TotalTrips DESC, p.FirstName, p.LastName
/*14*/
SELECT p.FirstName + ' ' + p.LastName AS [Full Name],
		  pl.Name AS [Plane Name],
		  f.Origin + ' - ' + f.Destination AS [Trip],
		  lt.Type As [Luggage Type]
     FROM Passengers AS p
	 JOIN Tickets AS t ON t.PassengerId = p.Id
	 JOIN Flights AS f ON f.Id = t.FlightId
	 JOIN Planes AS pl ON pl.Id = f.PlaneId
	 JOIN Luggages AS l ON l.Id = t.LuggageId
	 JOIN LuggageTypes AS lt ON lt.Id = l.LuggageTypeId
ORDER BY [Full Name], Name,Origin, Destination, Type
/*15*/
SELECT k.FirstName, k.LastName, k.Destination, k.Price
  FROM (
	SELECT p.FirstName, p.LastName, f.Destination, t.Price,
		   DENSE_RANK() OVER(PARTITION BY p.FirstName, p.LastName ORDER BY t.Price DESC) As PriceRank
	  FROM Passengers AS p
	  JOIN Tickets AS t ON t.PassengerId = p.Id
	  JOIN Flights AS f ON f.Id = t.FlightId
  ) AS k 
  WHERE k.PriceRank = 1
  ORDER BY k.Price DESC, k.FirstName, k.LastName, k.Destination

/*16*/
   SELECT f.Destination, COUNT(t.Id) AS [Count]
     FROM Flights AS f
LEFT JOIN Tickets AS t ON t.FlightId = f.Id
 GROUP BY f.Destination
 ORDER BY [Count] DESC, f.Destination

/*17*/
   SELECT p.Name, p.Seats, COUNT(t.Id) AS PassengersCount
     FROM Planes AS p
LEFT JOIN Flights AS f ON f.PlaneId = p.Id
LEFT JOIN Tickets AS t ON t.FlightId = f.Id
 GROUP BY p.Name, p.Seats
 ORDER BY PassengersCount DESC, p.Name, p.Seats

/*18*/
GO
CREATE FUNCTION udf_CalculateTickets(@origin varchar(50), @destination varchar(50), @peopleCount int)
RETURNS VARCHAR(100)
AS
BEGIN

IF (@peopleCount <= 0)
BEGIN
	RETURN 'Invalid people count!'
END

DECLARE @tripId INT = (SELECT f.Id FROM Flights AS f
											  JOIN Tickets AS t ON t.FlightId = f.Id 
											  WHERE Destination = @destination AND Origin = @origin)
IF (@tripId IS NULL)
BEGIN
	RETURN 'Invalid flight!'
END

DECLARE @ticketPrice DECIMAL(15,2) = (SELECT t.Price FROM Flights AS f
											  JOIN Tickets AS t ON t.FlightId = f.Id 
											  WHERE Destination = @destination AND Origin = @origin)

DECLARE @totalPrice DECIMAL(15, 2) = @ticketPrice * @peoplecount;

RETURN 'Total price ' + CAST(@totalPrice as VARCHAR(30));
END

/*19*/
GO
CREATE PROCEDURE usp_CancelFlights
AS
UPDATE Flights
SET DepartureTime = NULL, ArrivalTime = NULL
WHERE ArrivalTime > DepartureTime

/*20*/
CREATE TABLE DeletedPlanes
(
	Id INT,
	Name VARCHAR(30),
	Seats INT,
	Range INT
)
GO
CREATE TRIGGER tr_DeletedPlanes ON Planes 
AFTER DELETE AS
  INSERT INTO DeletedPlanes (Id, Name, Seats, Range) 
      (SELECT Id, Name, Seats, Range FROM deleted)
