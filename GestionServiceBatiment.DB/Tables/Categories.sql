CREATE TABLE [dbo].[Category]
(
	[Id] INT NOT NULL IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	[Description] VARCHAR(255) NULL,
	CONSTRAINT [PK_Category] PRIMARY KEY([Id]),
	CONSTRAINT [UQ_CategoryName] UNIQUE([Name])
)