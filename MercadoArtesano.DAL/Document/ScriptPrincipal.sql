CREATE DATABASE MercadoArtesanoDB;
GO
USE MercadoArtesanoDB;
GO

CREATE TABLE Cities(
Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
[Name] NVARCHAR(20) NOT NULL,
);
GO

CREATE TABLE Roles(
Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
[Name] NVARCHAR(20) NOT NULL,

);
GO

CREATE TABLE Administrators (
Id INT NOT NULL PRIMARY KEY IDENTITY (1,1),
IdRoles INT NOT NULL DEFAULT 1,
[Name] VARCHAR (50) NOT NULL,
LastName VARCHAR (50) NOT NULL,
Phone VARCHAR (9) NOT NULL,
Email VARCHAR (50) NOT NULL,
[Login] VARCHAR(20) NOT NULL,
[Password] VARCHAR(50) NOT NULL,
[Status] tinyint NOT NULL,
CreationDate DATETIME NOT NULL,
ModificationDate DATETIME DEFAULT NULL,
CONSTRAINT Fk_Roles_Administrators FOREIGN KEY(IdRoles) REFERENCES Roles(Id), --Indica que si no exxiste el rol tampoco existe el registro--
);

CREATE TABLE Customers (
Id INT NOT NULL PRIMARY KEY IDENTITY (1,1),
IdRoles INT NOT NULL DEFAULT 2,
[Name] VARCHAR (50) NOT NULL,
LastName VARCHAR (50) NOT NULL,
IdCities INT NOT NULL,
Phone VARCHAR (9) NOT NULL,
Email VARCHAR (50) NOT NULL,
[Login] VARCHAR(20) NOT NULL,
[Password] VARCHAR(50) NOT NULL,
[Status] tinyint NOT NULL,
CreationDate DATETIME NOT NULL,
ModificationDate DATETIME DEFAULT NULL,
CONSTRAINT Fk_Roles_Customers FOREIGN KEY(IdRoles) REFERENCES Roles(Id), --Indica que si no exxiste el rol tampoco existe el registro--
CONSTRAINT Fk_Cities_Administrators FOREIGN KEY(IdCities) REFERENCES Cities(Id), --Indica que si no exxiste el rol tampoco existe el registro--
);

CREATE TABLE Stores (
Id INT NOT NULL PRIMARY KEY IDENTITY (1,1),
IdRoles INT NOT NULL DEFAULT 3,
[Name] VARCHAR (50) NOT NULL,
IdCities INT NOT NULL,
Phone VARCHAR (9) NOT NULL,
Email VARCHAR (50) NOT NULL,
[Description] VARCHAR(200) NOT NULL,
[Login] VARCHAR(20) NOT NULL,
[Password] VARCHAR(50) NOT NULL,
[Status] tinyint NOT NULL,
CreationDate DATETIME NOT NULL,
ModificationDate DATETIME DEFAULT NULL,
CONSTRAINT Fk_Roles_Stores FOREIGN KEY(IdRoles) REFERENCES Roles(Id), --Indica que si no exxiste el rol tampoco existe el registro--
CONSTRAINT Fk_Cities_Administrators FOREIGN KEY(IdCities) REFERENCES Cities(Id), --Indica que si no exxiste el rol tampoco existe el registro--
);

CREATE TABLE Categories(
Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
[Name] NVARCHAR(50) NOT NULL,
);
GO

CREATE TABLE Products(
Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
IdCategories INT NOT NULL,
[Name] NVARCHAR(50) NOT NULL,
[Description] VARCHAR(200) NOT NULL,
Price MONEY NOT NULL,
[Status] VARCHAR(11) NOT NULL,
CreationDate DATETIME NOT NULL,
ModificationDate DATETIME DEFAULT NULL,
CONSTRAINT Fk_Categories_Products FOREIGN KEY(IdCategories) REFERENCES Categories(Id), --Indica que si no exxiste el rol tampoco existe el registro--
);
GO