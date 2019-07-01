-- Växla till databasen 'master'
USE master
GO

-- Skapa databasen
CREATE DATABASE CarRentalSupreme
GO

-- Växla till databasen 'CarRentalSupreme'
USE CarRentalSupreme
GO

-- Skapa tabellen 'Color'
CREATE TABLE Color
(
	Id tinyint PRIMARY KEY IDENTITY(1,1) NOT NULL, 
	ColorName NVARCHAR(50) NOT NULL
)
GO

-- Skapa tabellen 'Size'
CREATE TABLE Size
(
	Id tinyint PRIMARY KEY IDENTITY(1,1) NOT NULL, 
	Size NVARCHAR(50) NOT NULL,
	PriceCalculationFactor decimal(16,2) NOT NULL
)
GO

-- Skapa tabellen 'Brand'
CREATE TABLE Brand
(
	Id tinyint PRIMARY KEY IDENTITY NOT NULL,
	BrandName NVARCHAR(50) NOT NULL,
	Modell NVARCHAR(255) NOT NULL,
)

-- Skapa tabellen 'car' som kan ses som en kopplingstabell (junction table)
CREATE TABLE Car
(
	Id int PRIMARY KEY IDENTITY NOT NULL,
	ColorId tinyint NOT NULL REFERENCES Color(Id),
	SizeId tinyint NOT NULL REFERENCES Size(Id),
	BrandId tinyint NOT NULL REFERENCES Brand(Id)
)
GO

-- Skapa tabellen 'Address' för att lagra adresser.
CREATE TABLE Address
(
	Id int PRIMARY KEY IDENTITY,
	AddressName NVARCHAR(50) NULL,
	Street NVARCHAR(50) NULL, 
	ZipCode NVARCHAR(50) NULL,
	City NVARCHAR(50) NULL
)

-- Skapa tabellen 'person'
CREATE TABLE Person
(
	Id int PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(100) NOT NULL,
	LastName NVARCHAR(100) NOT NULL,
	SocialSecurityNumber NVARCHAR(20) NOT NULL,
	Email NVARCHAR(100) NOT NULL,
	AddressId int NOT NULL
)
GO

CREATE TABLE CustomerLevel
(
	Id int PRIMARY KEY IDENTITY,
	Name NVARCHAR(50) NOT NULL,
	DiscountFactor decimal(16,2)
)

CREATE TABLE Customer
(
	Id int PRIMARY KEY IDENTITY,
	CustomerLevelId int REFERENCES CustomerLevel(id),
	PersonId int REFERENCES Person(id)
)

CREATE TABLE Booking
(
	Id int PRIMARY KEY IDENTITY,
	CustomerId INT NOT NULL REFERENCES Customer(id),
	DriverId int NOT NULL REFERENCES Person(id),
	CarId int NOT NULL REFERENCES Car(id),
	FromDate datetime NOT NULL,
	ToDate datetime NOT NULL
)

CREATE TABLE PaymentMethod
(
	Id tinyint PRIMARY KEY IDENTITY(1,1) NOT NULL, 
	PaymentMethodName nvarchar(50)	
)

CREATE TABLE Payment
(
	Id int PRIMARY KEY IDENTITY,
	BookingId int NOT NULL REFERENCES Booking(id),	
	InvoiceAddressId int NULL REFERENCES Address(id),
	PaymentMethodId tinyint NULL REFERENCES PaymentMethod(id)
)

GO

-------------------------------------
-- INITIALIZE DATABASE
-------------------------------------
--INSERT Brand (BrandName, Modell)
--VALUES 
--('Volvo', 'XC70'),
--('Volvo', 'XC90'),
--('Volvo', 'V70'),
--('Volvo', 'V40'),
--('Volvo', 'V90'),
--('Volvo', 'Amazon')

SET IDENTITY_INSERT Brand ON
GO
INSERT Brand (Id, BrandName, Modell)
VALUES 
	(1, N'Volvo', 'XC70'),
	(2, N'Volvo', 'XC90'),
	(3, N'Volvo', 'V70'),
	(4, N'Volvo', 'V40'),
	(5, N'Volvo', 'V90'),
	(6, N'Volvo', 'Amazon'),
	(7, N'BMW', N'X1'),
	(8, N'BMW', N'X3'),
	(9, N'BMW', N'X5'),
	(10, N'Skôda', N'Fabia'),
	(11, N'Skôda', N'Octavia')
GO
SET IDENTITY_INSERT Brand OFF
GO
SELECT * FROM Brand
--DELETE Brand

INSERT Color (ColorName)
VALUES 
	(N'Röd'),
	(N'Grön'),
	(N'Lila'),
	(N'Blå')
GO

INSERT Size (Size, PriceCalculationFactor)
VALUES 
	(N'Mini', 0.5),
	(N'Normal', 1),
	(N'SUV', 2.5)

INSERT PaymentMethod (PaymentMethodName)
VALUES
	(N'Swish'),
	(N'Invoice'),
	(N'Credit Card'),
	(N'Postväxel')

INSERT CustomerLevel (Name, DiscountFactor)
VALUES
	(N'Standard', 0),
	(N'Premium', 0.10),
	(N'Gold',0.25),
	(N'Ruler of the galaxy', 0.50)

-------------------------------------

-- Lägg till en kolumn för registreringsnummer på bilarna
ALTER TABLE Car ADD
LicensePlate NVARCHAR(7) NOT NULL
GO

-------------------------------------
-- Stored procedures
-------------------------------------

CREATE PROCEDURE usp_CreateCar(
	@ColorId int,
	@SizeId int,
	@BrandId int,
	@LicensePlate nvarchar(7)
)
AS
BEGIN
	INSERT CAR (ColorId, BrandId, SizeId, LicensePlate)
	VALUES (
		@ColorId, 
		@BrandId,
		@SizeId,
		@LicensePlate
		)
END
GO

-- Create booking
CREATE PROCEDURE usp_CreateBooking(
	@CarId int,
	@FromDate datetime,
	@ToDate datetime,

	@FirstName NVARCHAR(50),
	@LastName NVARCHAR(50),
	@SocialSecurityNumber NVARCHAR(50),
	@Email NVARCHAR(100),

	@PaymentMethod int,
	@PaymentInvoiceAddressStreet NVARCHAR(50),
	@PaymentInvoiceAddressCity NVARCHAR(50),
	@PaymentInvoiceAddressZipCode NVARCHAR(50),
	@PaymentInvoiceAddressName NVARCHAR(50)
)
AS
BEGIN
	SELECT * FROM Car
	--INSERT ...
END

-------------------------------------
-- Execute stored procedure
-------------------------------------
EXEC usp_CreateCar 2, 1, 7, 'ABC 123'
GO

EXEC usp_CreateCar 3, 3, 4, 'DEF 456'
GO






-------------------------------------
-- Maintenance
-------------------------------------

--DROP DATABASE CarRentalSupreme
--GO




---- 1
--sp_helpconstraint carmodel

---- 2
--alter table carmodel
--drop constraint FK__CarModel__ColorI__398D8EEE

--sp_rename 'CarModel', 'Car'


