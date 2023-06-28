CREATE DATABASE TaskManagerDb 

GO

USE TaskManagerDb

CREATE TABLE TaskModels
(
	Id INTEGER,
	Title NVARCHAR(150),
	[Description] NVARCHAR(500),
	[DateTime] DateTime,
	[Priority] TINYINT,
	[Status] TINYINT,
)