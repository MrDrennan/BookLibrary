USE master

IF DB_ID('LibraryDB') IS NOT NULL
	DROP DATABASE LibraryDB
GO

CREATE DATABASE LibraryDB
GO

USE LibraryDB
GO

CREATE TABLE Book
(
	ISBN	char(13)		PRIMARY KEY
	,Price	smallmoney		NOT NULL
	,Title	varchar(100)	NOT NULL
)
GO

INSERT INTO Book (ISBN, Price, Title)
	VALUES ('9781503280786', 7.76, 'Moby Dick')
		,('9781890774943', 32.71, 'Murach''s C# 2015')
		,('9781890774967', 53.54, 'Murach''s SQL Server 2016 for Developers')