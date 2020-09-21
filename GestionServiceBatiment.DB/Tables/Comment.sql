CREATE TABLE [dbo].[Comment]
(
	[Id] INT NOT NULL IDENTITY,
	[Content] VARCHAR(1000) NOT NULL,
	[CreationDate] DateTIME NOT NULL,
	[Star] int Default 0,
	[CreatorId] INT NOT NULL,
	[CompanyId] INT NULL,
	[RequestId] INT NULL,
	[ServiceId] INT NULL,
	[ParentId] int NULL,
	CONSTRAINT [PK_Comment] PRIMARY KEY([Id]),
	CONSTRAINT [FK_Comment_Comment] 
		FOREIGN KEY ([ParentId]) REFERENCES [dbo].[Comment]([Id]),
	CONSTRAINT [FK_Comment_User]
		FOREIGN KEY ([CreatorId]) REFERENCES [User]([Id]),
	CONSTRAINT [FK_Comment_Company]
		FOREIGN KEY ([CompanyId]) REFERENCES [Company]([Id]),
	CONSTRAINT [FK_Comment_Service]
		FOREIGN KEY ([ServiceId]) REFERENCES [Service]([Id]),
	CONSTRAINT [FK_Comment_Request]
		FOREIGN KEY ([RequestId]) REFERENCES [Request]([Id])
)