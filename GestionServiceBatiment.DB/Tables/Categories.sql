CREATE TABLE [dbo].[Category]
(
	[Id] INT NOT NULL IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	[Description] VARCHAR(255) NULL,
	[ParentId] int NULL,
	CONSTRAINT [PK_Category] PRIMARY KEY([Id]),
	CONSTRAINT [FK_Category_Category] FOREIGN KEY ([ParentId]) REFERENCES [dbo].[Category]([Id]),
	CONSTRAINT [UQ_CategoryName] UNIQUE([Name])
)