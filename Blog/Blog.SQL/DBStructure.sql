CREATE DATABASE [Blog]
USE [Blog]
GO

CREATE TABLE [UserRoles]
(
	[Id] int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Name] varchar(50) NOT NULL
)

CREATE TABLE [Users]
(
	[Id] int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[FirstName] varchar(50) NOT NULL,
	[LastName] varchar(50) NOT NULL,
	[Username] varchar(50) NOT NULL,
	[Password] varchar(50) NOT NULL,
	[Role] int FOREIGN KEY REFERENCES [UserRoles](Id)
)

CREATE TABLE [Categories]
(
	[Id] int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Name] varchar(50) NOT NULL,	
)

CREATE TABLE [Posts]
(
	[Id] int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[UserId] int FOREIGN KEY REFERENCES [Users](Id) NOT NULL,
	[CategoryId] int FOREIGN KEY REFERENCES [Categories](Id) NOT NULL,
	[Title] varchar(50) NOT NULL,
	[Content] VARBINARY(MAX),
	[Created] DATETIME NOT NULL,
	[Updated] DATETIME NOT NULL
)

CREATE TABLE [Comments]
(
	[Id] int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[UserId] int FOREIGN KEY REFERENCES [Users](Id) NOT NULL,
	[PostId] int FOREIGN KEY REFERENCES [Posts](Id) NOT NULL,
	[Title] varchar(50) NOT NULL,
	[Content] VARBINARY(MAX),
	[Created] DATETIME NOT NULL,
	[Updated] DATETIME NOT NULL
)