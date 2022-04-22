﻿--
-- Script was generated by Devart dbForge Studio 2019 for SQL Server, Version 5.7.31.0
-- Product home page: http://www.devart.com/dbforge/sql/studio
-- Script date 22.04.2022 21:18:30
-- Server version: 12.00.0041
--


SET DATEFORMAT ymd
SET ARITHABORT, ANSI_PADDING, ANSI_WARNINGS, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER, ANSI_NULLS, NOCOUNT ON
SET NUMERIC_ROUNDABORT, IMPLICIT_TRANSACTIONS, XACT_ABORT OFF
GO

--
-- Create table [dbo].[Users]
--
PRINT (N'Create table [dbo].[Users]')
GO
IF OBJECT_ID(N'dbo.Users', 'U') IS NULL
CREATE TABLE dbo.Users (
  Id int IDENTITY,
  FirstName nvarchar(25) NOT NULL,
  LastName nvarchar(25) NOT NULL,
  Address nvarchar(100) NULL,
  Email nvarchar(30) NOT NULL,
  PhoneNumber nvarchar(13) NOT NULL,
  UserType int NOT NULL,
  CreatedOnDate datetime2 NOT NULL,
  CONSTRAINT PK_Users PRIMARY KEY CLUSTERED (Id)
)
GO

--
-- Create table [dbo].[InvoiceDetails]
--
PRINT (N'Create table [dbo].[InvoiceDetails]')
GO
IF OBJECT_ID(N'dbo.InvoiceDetails', 'U') IS NULL
CREATE TABLE dbo.InvoiceDetails (
  Id int IDENTITY,
  InvoiceId int NOT NULL,
  ProductId int NOT NULL,
  ProductName nvarchar(30) NOT NULL,
  ProductPrice decimal(18, 2) NOT NULL,
  ProductQuantity int NOT NULL,
  DerivedProductCost decimal(18, 2) NOT NULL,
  DiscountPrice decimal(18, 2) NOT NULL,
  TotalDerivedCost decimal(18, 2) NOT NULL,
  CreatedOnDate datetime2 NOT NULL,
  CONSTRAINT PK_InvoiceDetails PRIMARY KEY CLUSTERED (Id)
)
GO

--
-- Create table [dbo].[Invoice]
--
PRINT (N'Create table [dbo].[Invoice]')
GO
IF OBJECT_ID(N'dbo.Invoice', 'U') IS NULL
CREATE TABLE dbo.Invoice (
  Id int IDENTITY,
  UserId int NOT NULL,
  InvoiceNumber nvarchar(25) NOT NULL,
  OrderId int NOT NULL,
  OrderTotal decimal(18, 2) NOT NULL,
  Total decimal(18, 2) NOT NULL,
  CreatedOnDate datetime2 NOT NULL,
  CONSTRAINT PK_Invoice PRIMARY KEY CLUSTERED (Id)
)
GO

--
-- Create table [dbo].[Discounts]
--
PRINT (N'Create table [dbo].[Discounts]')
GO
IF OBJECT_ID(N'dbo.Discounts', 'U') IS NULL
CREATE TABLE dbo.Discounts (
  Id int IDENTITY,
  Name nvarchar(25) NOT NULL,
  Type int NOT NULL,
  Rate decimal(18, 2) NOT NULL,
  IsRatePercentage bit NOT NULL,
  CreatedOnDate datetime2 NOT NULL,
  CONSTRAINT PK_Discounts PRIMARY KEY CLUSTERED (Id)
)
GO
-- 
-- Dumping data for table Discounts
--
PRINT (N'Dumping data for table Discounts')
SET IDENTITY_INSERT dbo.Discounts ON
GO
INSERT dbo.Discounts(Id, Name, Type, Rate, IsRatePercentage, CreatedOnDate) VALUES (1, N'Employee Discount', 2, 30.00, CONVERT(bit, 'True'), '0001-01-01 00:00:00.0000000')
INSERT dbo.Discounts(Id, Name, Type, Rate, IsRatePercentage, CreatedOnDate) VALUES (2, N'Affiliate Discount', 1, 10.00, CONVERT(bit, 'True'), '0001-01-01 00:00:00.0000000')
INSERT dbo.Discounts(Id, Name, Type, Rate, IsRatePercentage, CreatedOnDate) VALUES (3, N'Loyal Customer Discount', 3, 5.00, CONVERT(bit, 'True'), '0001-01-01 00:00:00.0000000')
INSERT dbo.Discounts(Id, Name, Type, Rate, IsRatePercentage, CreatedOnDate) VALUES (4, N'Price Discount', 4, 5.00, CONVERT(bit, 'False'), '0001-01-01 00:00:00.0000000')
GO
SET IDENTITY_INSERT dbo.Discounts OFF
GO
-- 
-- Dumping data for table Invoice
--
PRINT (N'Dumping data for table Invoice')
SET IDENTITY_INSERT dbo.Invoice ON
GO
INSERT dbo.Invoice(Id, UserId, InvoiceNumber, OrderId, OrderTotal, Total, CreatedOnDate) VALUES (1, 1, N'A001', 1, 0.00, 500.00, '2022-04-22 10:34:27.0826838')
INSERT dbo.Invoice(Id, UserId, InvoiceNumber, OrderId, OrderTotal, Total, CreatedOnDate) VALUES (2, 2, N'A002', 2, 0.00, 1500.00, '2022-04-22 10:34:27.0826996')
INSERT dbo.Invoice(Id, UserId, InvoiceNumber, OrderId, OrderTotal, Total, CreatedOnDate) VALUES (3, 3, N'A003', 3, 0.00, 990.00, '2022-04-22 10:34:27.0827002')
INSERT dbo.Invoice(Id, UserId, InvoiceNumber, OrderId, OrderTotal, Total, CreatedOnDate) VALUES (4, 4, N'A004', 4, 0.00, 920.00, '2022-04-22 10:34:27.0827005')
INSERT dbo.Invoice(Id, UserId, InvoiceNumber, OrderId, OrderTotal, Total, CreatedOnDate) VALUES (5, 4, N'TST11', 10, 38.00, 26.60, '2022-04-22 16:02:35.2608874')
INSERT dbo.Invoice(Id, UserId, InvoiceNumber, OrderId, OrderTotal, Total, CreatedOnDate) VALUES (6, 4, N'T0001', 0, 38.00, 26.60, '2022-04-22 16:07:22.0059799')
INSERT dbo.Invoice(Id, UserId, InvoiceNumber, OrderId, OrderTotal, Total, CreatedOnDate) VALUES (7, 4, N'T0001', 0, 38.00, 26.60, '2022-04-22 16:08:26.1612189')
INSERT dbo.Invoice(Id, UserId, InvoiceNumber, OrderId, OrderTotal, Total, CreatedOnDate) VALUES (8, 4, N'T0001', 0, 38.00, 26.60, '2022-04-22 16:09:29.1557358')
INSERT dbo.Invoice(Id, UserId, InvoiceNumber, OrderId, OrderTotal, Total, CreatedOnDate) VALUES (9, 4, N'T0001', 0, 38.00, 26.60, '2022-04-22 16:10:08.9582753')
INSERT dbo.Invoice(Id, UserId, InvoiceNumber, OrderId, OrderTotal, Total, CreatedOnDate) VALUES (10, 4, N'T0001', 0, 38.00, 26.60, '2022-04-22 17:18:59.9007902')
INSERT dbo.Invoice(Id, UserId, InvoiceNumber, OrderId, OrderTotal, Total, CreatedOnDate) VALUES (11, 3, N'BILL108', 0, 38.00, 34.20, '2022-04-22 17:27:17.9908760')
INSERT dbo.Invoice(Id, UserId, InvoiceNumber, OrderId, OrderTotal, Total, CreatedOnDate) VALUES (12, 1, N'BILL5529', 0, 38.00, 36.10, '2022-04-22 17:27:34.2845634')
INSERT dbo.Invoice(Id, UserId, InvoiceNumber, OrderId, OrderTotal, Total, CreatedOnDate) VALUES (13, 2, N'BILL1179', 0, 38.00, 36.10, '2022-04-22 17:27:36.6194888')
INSERT dbo.Invoice(Id, UserId, InvoiceNumber, OrderId, OrderTotal, Total, CreatedOnDate) VALUES (14, 3, N'BILL8455', 0, 38.00, 34.20, '2022-04-22 17:28:24.0078594')
INSERT dbo.Invoice(Id, UserId, InvoiceNumber, OrderId, OrderTotal, Total, CreatedOnDate) VALUES (15, 1, N'BILL7569', 0, 38.00, 36.10, '2022-04-22 17:28:34.1441005')
INSERT dbo.Invoice(Id, UserId, InvoiceNumber, OrderId, OrderTotal, Total, CreatedOnDate) VALUES (16, 2, N'BILL9254', 0, 38.00, 36.10, '2022-04-22 17:28:36.4103149')
GO
SET IDENTITY_INSERT dbo.Invoice OFF
GO
-- 
-- Dumping data for table InvoiceDetails
--
PRINT (N'Dumping data for table InvoiceDetails')
SET IDENTITY_INSERT dbo.InvoiceDetails ON
GO
INSERT dbo.InvoiceDetails(Id, InvoiceId, ProductId, ProductName, ProductPrice, ProductQuantity, DerivedProductCost, DiscountPrice, TotalDerivedCost, CreatedOnDate) VALUES (1, 1, 2, N'Invoice Item 2', 20.00, 2, 40.00, 2.00, 38.00, '2022-04-22 10:34:27.0836304')
INSERT dbo.InvoiceDetails(Id, InvoiceId, ProductId, ProductName, ProductPrice, ProductQuantity, DerivedProductCost, DiscountPrice, TotalDerivedCost, CreatedOnDate) VALUES (2, 1, 4, N'Invoice Item 4', 482.00, 1, 482.00, 20.00, 462.00, '2022-04-22 10:34:27.0836504')
INSERT dbo.InvoiceDetails(Id, InvoiceId, ProductId, ProductName, ProductPrice, ProductQuantity, DerivedProductCost, DiscountPrice, TotalDerivedCost, CreatedOnDate) VALUES (3, 2, 40, N'Invoice Item 40', 50.00, 5, 250.00, 0.00, 250.00, '2022-04-22 10:34:27.0836514')
INSERT dbo.InvoiceDetails(Id, InvoiceId, ProductId, ProductName, ProductPrice, ProductQuantity, DerivedProductCost, DiscountPrice, TotalDerivedCost, CreatedOnDate) VALUES (4, 3, 3, N'Invoice Item 3', 50.00, 5, 250.00, 25.00, 225.00, '2022-04-22 10:34:27.0836517')
INSERT dbo.InvoiceDetails(Id, InvoiceId, ProductId, ProductName, ProductPrice, ProductQuantity, DerivedProductCost, DiscountPrice, TotalDerivedCost, CreatedOnDate) VALUES (5, 3, 5, N'Invoice Item 5', 400.00, 1, 400.00, 20.00, 380.00, '2022-04-22 10:34:27.0836521')
INSERT dbo.InvoiceDetails(Id, InvoiceId, ProductId, ProductName, ProductPrice, ProductQuantity, DerivedProductCost, DiscountPrice, TotalDerivedCost, CreatedOnDate) VALUES (6, 3, 15, N'Invoice Item 15', 77.00, 5, 385.00, 0.00, 385.00, '2022-04-22 10:34:27.0836526')
INSERT dbo.InvoiceDetails(Id, InvoiceId, ProductId, ProductName, ProductPrice, ProductQuantity, DerivedProductCost, DiscountPrice, TotalDerivedCost, CreatedOnDate) VALUES (7, 4, 105, N'Invoice Item 105', 200.00, 5, 1000.00, 80.00, 920.00, '2022-04-22 10:34:27.0836529')
INSERT dbo.InvoiceDetails(Id, InvoiceId, ProductId, ProductName, ProductPrice, ProductQuantity, DerivedProductCost, DiscountPrice, TotalDerivedCost, CreatedOnDate) VALUES (8, 5, 1, N'Item Name 1', 20.00, 2, 40.00, 2.00, 38.00, '2022-04-22 12:37:15.7780000')
INSERT dbo.InvoiceDetails(Id, InvoiceId, ProductId, ProductName, ProductPrice, ProductQuantity, DerivedProductCost, DiscountPrice, TotalDerivedCost, CreatedOnDate) VALUES (9, 6, 1, N'Invoice Item', 20.00, 2, 40.00, 2.00, 38.00, '2022-04-22 16:07:21.1891511')
INSERT dbo.InvoiceDetails(Id, InvoiceId, ProductId, ProductName, ProductPrice, ProductQuantity, DerivedProductCost, DiscountPrice, TotalDerivedCost, CreatedOnDate) VALUES (10, 7, 1, N'Invoice Item', 20.00, 2, 40.00, 2.00, 38.00, '2022-04-22 16:08:20.9454208')
INSERT dbo.InvoiceDetails(Id, InvoiceId, ProductId, ProductName, ProductPrice, ProductQuantity, DerivedProductCost, DiscountPrice, TotalDerivedCost, CreatedOnDate) VALUES (11, 8, 1, N'Invoice Item', 20.00, 2, 40.00, 2.00, 38.00, '2022-04-22 16:09:28.2940744')
INSERT dbo.InvoiceDetails(Id, InvoiceId, ProductId, ProductName, ProductPrice, ProductQuantity, DerivedProductCost, DiscountPrice, TotalDerivedCost, CreatedOnDate) VALUES (12, 9, 1, N'Invoice Item', 20.00, 2, 40.00, 2.00, 38.00, '2022-04-22 16:10:08.0747978')
INSERT dbo.InvoiceDetails(Id, InvoiceId, ProductId, ProductName, ProductPrice, ProductQuantity, DerivedProductCost, DiscountPrice, TotalDerivedCost, CreatedOnDate) VALUES (13, 10, 1, N'Invoice Item', 20.00, 2, 40.00, 2.00, 38.00, '2022-04-22 17:18:59.0684872')
INSERT dbo.InvoiceDetails(Id, InvoiceId, ProductId, ProductName, ProductPrice, ProductQuantity, DerivedProductCost, DiscountPrice, TotalDerivedCost, CreatedOnDate) VALUES (14, 11, 1, N'Invoice Item', 20.00, 2, 40.00, 2.00, 38.00, '2022-04-22 17:27:17.1438338')
INSERT dbo.InvoiceDetails(Id, InvoiceId, ProductId, ProductName, ProductPrice, ProductQuantity, DerivedProductCost, DiscountPrice, TotalDerivedCost, CreatedOnDate) VALUES (15, 12, 1, N'Invoice Item', 20.00, 2, 40.00, 2.00, 38.00, '2022-04-22 17:27:33.4265207')
INSERT dbo.InvoiceDetails(Id, InvoiceId, ProductId, ProductName, ProductPrice, ProductQuantity, DerivedProductCost, DiscountPrice, TotalDerivedCost, CreatedOnDate) VALUES (16, 13, 1, N'Invoice Item', 20.00, 2, 40.00, 2.00, 38.00, '2022-04-22 17:27:36.3058365')
INSERT dbo.InvoiceDetails(Id, InvoiceId, ProductId, ProductName, ProductPrice, ProductQuantity, DerivedProductCost, DiscountPrice, TotalDerivedCost, CreatedOnDate) VALUES (17, 14, 1, N'Invoice Item', 20.00, 2, 40.00, 2.00, 38.00, '2022-04-22 17:28:23.0581684')
INSERT dbo.InvoiceDetails(Id, InvoiceId, ProductId, ProductName, ProductPrice, ProductQuantity, DerivedProductCost, DiscountPrice, TotalDerivedCost, CreatedOnDate) VALUES (18, 15, 1, N'Invoice Item', 20.00, 2, 40.00, 2.00, 38.00, '2022-04-22 17:28:33.2879070')
INSERT dbo.InvoiceDetails(Id, InvoiceId, ProductId, ProductName, ProductPrice, ProductQuantity, DerivedProductCost, DiscountPrice, TotalDerivedCost, CreatedOnDate) VALUES (19, 16, 1, N'Invoice Item', 20.00, 2, 40.00, 2.00, 38.00, '2022-04-22 17:28:36.1091300')
GO
SET IDENTITY_INSERT dbo.InvoiceDetails OFF
GO
-- 
-- Dumping data for table Users
--
PRINT (N'Dumping data for table Users')
SET IDENTITY_INSERT dbo.Users ON
GO
INSERT dbo.Users(Id, FirstName, LastName, Address, Email, PhoneNumber, UserType, CreatedOnDate) VALUES (1, N'İsmail', N'AKTI', NULL, N'iismailakti@gmail.com', N'123456789', 3, '2019-04-22 10:34:27.0797635')
INSERT dbo.Users(Id, FirstName, LastName, Address, Email, PhoneNumber, UserType, CreatedOnDate) VALUES (2, N'Mehmet', N'KAPLAN', NULL, N'user2@email.com', N'12345678910', 3, '2022-01-22 10:34:27.0816867')
INSERT dbo.Users(Id, FirstName, LastName, Address, Email, PhoneNumber, UserType, CreatedOnDate) VALUES (3, N'Penny', N'Jackson', NULL, N'user3@email.com', N'123456789', 1, '2021-04-22 10:34:27.0816973')
INSERT dbo.Users(Id, FirstName, LastName, Address, Email, PhoneNumber, UserType, CreatedOnDate) VALUES (4, N'Amy', N'Fowler', NULL, N'user4@email.com', N'123456789', 2, '2017-04-22 10:34:27.0816981')
INSERT dbo.Users(Id, FirstName, LastName, Address, Email, PhoneNumber, UserType, CreatedOnDate) VALUES (5, N'Raj', N'Koothrappali', NULL, N'user5@email.com', N'123456789', 2, '2019-04-22 10:34:27.0816984')
GO
SET IDENTITY_INSERT dbo.Users OFF
GO
SET NOEXEC OFF
GO