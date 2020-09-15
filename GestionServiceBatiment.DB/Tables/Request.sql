CREATE TABLE [dbo].[Request]
(
	[Id] INT NOT NULL IDENTITY,
	[Title] VARCHAR(100) NOT NULL,
	[Description] VARCHAR(255) NULL,
	[ImageURI] VARCHAR(255) NULL,
	[CreationDate] DateTIME NOT NULL,
	[CreatorId] INT NOT NULL,
	[CategoryId] INT NULL,
	CONSTRAINT [PK_Request] PRIMARY KEY([Id]),
	CONSTRAINT [FK_Request_Creator]
		FOREIGN KEY ([CreatorId]) REFERENCES [User]([Id]),
	CONSTRAINT [FK_Request_Category]
		FOREIGN KEY ([CategoryId]) REFERENCES [Category]([Id]),
	CONSTRAINT [UQ_RequestTitle] UNIQUE([Title], [CreatorId])
)
