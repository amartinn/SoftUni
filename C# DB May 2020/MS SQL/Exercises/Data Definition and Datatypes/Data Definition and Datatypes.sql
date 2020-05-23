/* 1 */

CREATE DATABASE Minions
USE Minions

/* 2 */

CREATE TABLE [Minions] (
[Id] int PRIMARY KEY NOT NULL,
[Name] NVARCHAR(30) NOT NULL,
[Age] INT,
)

CREATE TABLE [Towns] (
[Id] int PRIMARY KEY NOT NULL,
[Name] NVARCHAR(30) NOT NULL,
)

/* 3 */

ALTER TABLE Minions
ADD [Townid] INT FOREIGN KEY REFERENCES Towns(Id)

/* 4 */
INSERT INTO Towns(Id,[Name]) VALUES 
(1, 'Sofia'),
(2, 'Plovdiv'),
(3, 'Varna')

INSERT INTO Minions(Id,[Name],Age,TownId) VALUES
(1,	'Kevin', 22, 1),
(2,	'Bob', 15, 3),
(3,	'Steward', NULL, 2)

/* 5 */

TRUNCATE TABLE Minions

/* 6 */

DROP TABLE Minions
DROP TABLE Towns

/* 7 */

CREATE TABLE People (
Id INT PRIMARY KEY Identity,
[Name] NVARCHAR(200) NOT NULL,
Picture VARBINARY(MAX) CHECK(DATALENGTH(Picture)<=1024 *1024 *2),
Height DECIMAL(3,2),
[Weight] DECIMAL(5,2),
Gender CHAR(1) CHECK(Gender='m' OR Gender='f') NOT NULL,
Birthdate DATE NOT NULL,
Biography  NVARCHAR(MAX)
)

INSERT INTO People ([Name], Picture, Height, [Weight], Gender, Birthdate, Biography) VALUES
('Ivana Marinova', NULL, 1.80, 75.32, 'm', Convert(DateTime,'20200606',112), 'Orc'),
('Simona Todorova', NULL, 1.80, 75.32, 'm', Convert(DateTime,'20200606',112), 'Undead'),
('Martin Petrov', NULL, 1.80, 75.32, 'f', Convert(DateTime,'20200606',112), 'Tauren'),
('Angel Ivanov', NULL, 1.80, 75.32, 'f', Convert(DateTime,'20200606',112), 'Troll'),
('Teodor Svetoslavov', NULL, 1.80, 75.32, 'm', Convert(DateTime,'20200606',112), 'Blood elf')


/* 8 */

CREATE TABLE Users(
Id BIGINT UNIQUE IDENTITY,
Username VARCHAR(30) UNIQUE NOT NULL,
[Password] VARCHAR(26) NOT NULL,
ProfilePicture VARBINARY(MAX) CHECK(DATALENGTH(ProfilePicture) <= 900*1024),
LastLoginTime DATETIME,
IsDeleted BIT
CONSTRAINT PK_Users Primary Key(Id)
)
INSERT INTO Users VALUES 
('Pesho','192345',NULL,NULL,0),
('Stamat','192345',NULL,NULL,1),
('Yoan','192345',NULL,NULL,0),
('Plamen','192345',NULL,NULL,1),
('Denis','192345',NULL,NULL,1)

/* 9 */

ALTER TABLE Users
DROP CONSTRAINT PK_Users

ALTER TABLE Users
ADD CONSTRAINT PK_Users PRIMARY KEY (Id,Username)

/* 10 */

ALTER TABLE Users
ADD CONSTRAINT CH_PWD CHECK([Password]>=5)

/* 11 */

ALTER TABLE Users
ADD DEFAULT GETDATE() FOR LastLoginTime

/* 12 */

ALTER TABLE Users
DROP CONSTRAINT PK_Users

ALTER TABLE Users
ADD CONSTRAINT PK_Id
PRIMARY KEY (Id)

ALTER TABLE Users
ADD CONSTRAINT UQ_Username
UNIQUE(Username)

/* 13 */
CREATE DATABASE Movies
USE Movies
CREATE TABLE Directors (
Id INT IDENTITY PRIMARY KEY NOT NULL,
DirectorName NVARCHAR(30) NOT NULL,
Notes NVARCHAR(100))

CREATE TABLE Genres (
Id INT IDENTITY PRIMARY KEY  NOT NULL,
GenreName NVARCHAR(10) NOT NULL,
Notes NVARCHAR(100))

CREATE TABLE Categories (
Id INT IDENTITY PRIMARY KEY  NOT NULL,
CategoryName NVARCHAR(10) NOT NULL,
Notes NVARCHAR(100))

CREATE TABLE Movies (
Id INT IDENTITY PRIMARY KEY  NOT NULL,
Title NVARCHAR(20)  NOT NULL,
DirectorId INT FOREIGN KEY REFERENCES Directors(Id)  NOT NULL,
CopyrightYear INT NOT NULL CHECK(DATALENGTH(CopyrightYear) = 4),
[Length] TIME  NOT NULL,
GenreId INT FOREIGN KEY REFERENCES Genres(Id)  NOT NULL,
CategoryId INT FOREIGN KEY REFERENCES Categories(Id)  NOT NULL)

INSERT INTO Directors VALUES
('Ivan Petrov',NULL),
('Yordan Ivanov',NULL),
('Petko Petkov',NULL),
('Yanislav Marinov',NULL),
('Hristo Ezilev',NULL)

INSERT INTO Genres VALUES 
('Action',NULL),
('Comedy',NULL),
('Drama',NULL),
('Sci-Fi',NULL),
('Crime',NULL)

INSERT INTO Categories VALUES
('Action',NULL),
('Comedy',NULL),
('Drama',NULL),
('Sci-Fi',NULL),
('Crime',NULL)


INSERT INTO Movies VALUES
('Matrix',1,1935,'3:15:00',1,3),
('Matrix',1,1935,'3:15:00',1,3),
('Matrix',1,1935,'3:15:00',1,3),
('Matrix',1,1935,'3:15:00',1,3),
('Matrix',1,1935,'3:15:00',1,3)

/* 14 */
CREATE DATABASE CarRental
USE CarRental

CREATE TABLE Categories (
Id INT PRIMARY KEY IDENTITY NOT NULL, 
CategoryName NVARCHAR(30) NOT NULL, 
DailyRate INT NOT NULL, 
WeeklyRate INT NOT NULL, 
MonthlyRate INT NOT NULL, 
WeekendRate INT NOT NULL)

CREATE TABLE Cars (
Id INT PRIMARY KEY IDENTITY NOT NULL, 
PlateNumber NVARCHAR(20) NOT NULL UNIQUE, 
Manufacturer NVARCHAR(30) NOT NULL, 
Model  NVARCHAR(30) NOT NULL, 
CarYear INT NOT NULL, 
CategoryId INT NOT NULL FOREIGN KEY REFERENCES Categories(Id), 
Doors INT NOT NULL, 
Picture VARBINARY(MAX), 
Condition NVARCHAR(30), 
Available BIT NOT NULL)

CREATE TABLE Employees (
Id INT PRIMARY KEY IDENTITY NOT NULL,
FirstName NVARCHAR(20) NOT NULL, 
LastName NVARCHAR(20) NOT NULL, 
Title NVARCHAR(20), 
Notes NVARCHAR(MAX))

CREATE TABLE Customers (
Id INT PRIMARY KEY IDENTITY NOT NULL,
DriverLicenceNumber NVARCHAR(50) NOT NULL,
FullName NVARCHAR(50) NOT NULL,
[Address] NVARCHAR(100) NOT NULL,
City NVARCHAR(100) NOT NULL,
ZIPCode NVARCHAR(30),
Notes NVARCHAR(MAX))

CREATE TABLE RentalOrders (
Id  INT PRIMARY KEY IDENTITY NOT NULL,
EmployeeId INT NOT NULL FOREIGN KEY REFERENCES Employees(Id),
CustomerId INT NOT NULL FOREIGN KEY REFERENCES Customers(Id),
CarId INT NOT NULL FOREIGN KEY REFERENCES Cars(Id),
TankLevel INT NOT NULL,
KilometrageStart INT NOT NULL,
KilometrageEnd INT NOT NULL,
TotalKilometrage INT, 
StartDate DATE NOT NULL,
EndDate DATE NOT NULL,
TotalDays as DATEDIFF(DAY,StartDate,EndDate),
RateApplied INT NOT NULL,
TaxRate as RateApplied * 0.2,
OrderStatus BIT NOT NULL,
Notes NVARCHAR(MAX))

INSERT INTO Categories VALUES
('Sport Car', 13, 125, 1956, 180),
('SUV', 13, 125, 1956, 180),
('Economic', 13, 125, 1956, 180)

INSERT INTO Cars VALUES
('X5311KP', 'Audi', 'A4', 2010, 1, 4, NULL, 'Excellent', 1),
('X5931AH', 'Opel', 'Astra', 2000, 2, 3, NULL, 'Very good', 1),
('CT17754GT', 'Volkswagen', 'Passat', 2008, 3, 5, NULL, 'Poor', 0)

INSERT INTO Employees VALUES
('Ivan', 'Ivanov', NULL, NULL),
('Yordan', 'Yordanov', NULL, NULL),
('Petar', 'Angelov', NULL, NULL)

INSERT INTO Customers(DriverLicenceNumber, FullName, [Address], City) VALUES
('3870900', 'Lily McLay', 'Mulberry Circle', 'Fitchburg'),
('6057741', 'Simone Queiroz', '366 N. Second Ave.', 'Fort Worth'),
('6057741', 'Terry Smith', '505 S. Ridgeview St.', 'Independence')

INSERT INTO RentalOrders(EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, 
StartDate, EndDate, RateApplied, OrderStatus) VALUES
(1, 1, 1, 100, 193562, 194533, '2020-05-19', '2020-05-20',35, 1),
(3, 3, 3, 100, 193562, 194533, '2020-05-19', '2020-05-20',35, 1),
(2, 2, 2, 100, 193562, 194533, '2020-05-19', '2020-05-20',35, 1)
/* 15 */

CREATE DATABASE Hotel
USE Hotel

CREATE TABLE Employees (
Id INT PRIMARY KEY IDENTITY NOT NULL,
FirstName NVARCHAR(20) NOT NULL, 
LastName NVARCHAR(20) NOT NULL, 
Title NVARCHAR(20), 
Notes NVARCHAR(MAX))

CREATE TABLE Customers (
AccountNumber INT NOT NULL PRIMARY KEY IDENTITY, 
FirstName NVARCHAR(30) NOT NULL, 
LastName NVARCHAR(30) NOT NULL,
PhoneNumber NVARCHAR(10) NOT NULL,
EmergencyName NVARCHAR(20),
EmergencyNumber INT , 
Notes NVARCHAR(MAX))

CREATE TABLE RoomStatus (
RoomStatus NVARCHAR(30) NOT NULL PRIMARY KEY,
Notes NVARCHAR(MAX))

CREATE TABLE RoomTypes (
RoomType NVARCHAR(30) NOT NULL PRIMARY KEY,
Notes NVARCHAR(MAX))

CREATE TABLE BedTypes (
BedType NVARCHAR(30) NOT NULL PRIMARY KEY, 
Notes NVARCHAR(MAX))

CREATE TABLE Rooms (
RoomNumber INT NOT NULL PRIMARY KEY, 
RoomType NVARCHAR(30) NOT NULL FOREIGN KEY REFERENCES RoomTypes(RoomType), 
BedType  NVARCHAR(30) NOT NULL FOREIGN KEY REFERENCES BedTypes(BedType) ,
Rate DECIMAL(6,2) NOT NULL, 
RoomStatus NVARCHAR(30) NOT NULL FOREIGN KEY REFERENCES RoomStatus(RoomStatus) , 
Notes NVARCHAR(MAX))

CREATE TABLE Payments (
Id  INT NOT NULL PRIMARY KEY IDENTITY,
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
PaymentDate DATE NOT NULL, 
AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber), 
FirstDateOccupied DATE NOT NULL, 
LastDateOccupied DATE NOT NULL, 
TotalDays AS DATEDIFF(DAY,FirstDateOccupied,LastDateOccupied),
AmountCharged DECIMAL(7,2) NOT NULL, 
TaxRate DECIMAL(7,2) NOT NULL,
TaxAmount AS AmountCharged*TaxRate,
PaymentTotal AS AmountCharged+ AmountCharged*TaxRate, 
Notes NVARCHAR(MAX))

CREATE TABLE Occupancies (
Id  INT NOT NULL PRIMARY KEY IDENTITY,
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
DateOccupied DATE NOT NULL,
AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber),
RoomNumber INT FOREIGN KEY REFERENCES Rooms(RoomNumber) NOT NULL,
RateApplied DECIMAL(7,2) NOT NULL,
PhoneCharge  DECIMAL(8,2) NOT NULL,
Notes NVARCHAR(MAX))

INSERT INTO Employees(FirstName, LastNAme) VALUES
('Martin', 'Petrov'),
('Stoyan', 'Yordanov'),
('Petar', 'Petrov')

INSERT INTO Customers(FirstName, LastName, PhoneNumber) VALUES
('Ivana', 'Petrova', '+359898563'),
('Gancho', 'Stoykov', '+359877562'),
('Genadi', 'Dimchov', '+359896325')

INSERT INTO RoomStatus(RoomStatus) VALUES
('Free'),
('Taken'),
('In Construction')

INSERT INTO RoomTypes(RoomType) VALUES
('apartament'),
('studio'),
('penthause')

INSERT INTO BedTypes(BedType) VALUES
('single'),
('double'),
('enourmous')


INSERT INTO Rooms(RoomNumber, RoomType, BedType, Rate, RoomStatus) VALUES
(239, 'studio', 'single', 1350.0, 'Free'),
(240, 'studio', 'single', 150.0, 'Free'),
(241, 'studio', 'single', 256.0, 'Free')


INSERT INTO Payments(EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, AmountCharged, TaxRate) VALUES
(1, '2020-05-23', 1, '2020-05-28', '2020-06-30', 300, 0.5),
(2, '2020-05-23', 3, '2020-05-28', '2020-06-30', 300, 0.5),
(3, '2020-05-23', 2, '2020-05-28', '2020-06-30', 300, 0.5)

INSERT INTO Occupancies(EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge) VALUES
(2, '2020-05-28', 1, 239, 10.35, 113.3),
(2, '2020-05-28', 1, 239, 10.35, 113.3),
(3, '2020-05-28', 1, 239, 10.35, 113.3)
/* 16 */

CREATE DATABASE Softuni
USE Softuni

CREATE TABLE Towns (
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(30) NOT NULL)

CREATE TABLE Addresses (
Id INT PRIMARY KEY IDENTITY, 
AddressText NVARCHAR(50) NOT NULL, 
TownId INT FOREIGN KEY REFERENCES Towns(Id))

CREATE TABLE Departments (
Id INT PRIMARY KEY IDENTITY, 
[Name] NVARCHAR(30))

CREATE TABLE Employees (
Id INT PRIMARY KEY IDENTITY, 
FirstName NVARCHAR(30) NOT NULL, 
MiddleName NVARCHAR(30) NOT NULL, 
LastName NVARCHAR(30) NOT NULL, 
JobTitle NVARCHAR(30) NOT NULL,
DepartmentId INT FOREIGN KEY REFERENCES Departments(Id),
HireDate DATE NOT NULL, 
Salary DECIMAL(7,2) NOT NULL, 
AddressId INT FOREIGN KEY REFERENCES Addresses(Id))
/* 17 */

BACKUP DATABASE Softuni TO DISK = 'C:\Users\User\Desktop\softuni-backup.bak'

DROP DATABASE Softuni

RESTORE DATABASE Softuni FROM DISK = 'C:\Users\User\Desktop\softuni-backup.bak'

USE Softuni

/* 18 */

INSERT INTO Towns VALUES
('Sofia'),
('Plovdiv'),
('Varna'),
('Burgas')

INSERT INTO Departments VALUES
('Engineering'), 
('Sales'), 
('Marketing'), 
('Software Development'), 
('Quality Assurance')

INSERT INTO Addresses VALUES
('1370  Lynn Ogden Lane',1),
('2473  Hill Croft Farm Road',2),
('2915  Don Jackson Lane',3),
('2921  Don Jackson Lane',4),
('3172  Gordon Street',4)

INSERT INTO Employees(FirstName,MiddleName, LastName, JobTitle,DepartmentId,HireDate, Salary, AddressId) VALUES
('Ivan', 'Ivanov', 'Ivanov','.NET Developer',4,'2013-02-01',3500.00,1),
('Petar','Petrov','Petrov','Senior Engineer',1,'2004-03-02',4000.00,2),
('Maria','Petrova','Ivanova','Intern',	5,'2016-08-28',525.25,3),
('Georgi','Teziev','Ivanov','CEO',	2, '2007-12-09',3000.00,4),
('Peter','Pan','Pan','Intern',3,'2016-08-28',599.88,5)

/* 19 */

SELECT * FROM Towns

SELECT * FROM Departments

SELECT * FROM Employees

/* 20 */

SELECT * FROM Towns ORDER BY [NAME] ASC

SELECT * FROM Departments ORDER BY [NAME] ASC

SELECT * FROM Employees ORDER BY Salary DESC

/* 21 */

SELECT [Name] FROM Towns ORDER BY [NAME] ASC
	   
SELECT [Name] FROM Departments ORDER BY [NAME] ASC
	   
SELECT FirstName, LastName, JobTitle, Salary FROM Employees ORDER BY Salary DESC
/* 22 */

UPDATE Employees
SET Salary=Salary*1.1
SELECT Salary FROM Employees

/* 23 */
USE Hotel
UPDATE Payments
SET TaxRate=TaxRate*0.97	

SELECT TaxRate FROM Payments

/* 24 */

DELETE FROM Occupancies