CREATE TABLE [dbo].[Service]
(
	[Id] INT NOT NULL IDENTITY,
	[Title] VARCHAR(100) NOT NULL,
	[Description] VARCHAR(255) NULL,
	[ImageURI] VARCHAR(255) NULL,
	[ActivedForValidation] BIT NOT NULL DEFAULT 0,
	[Active] BIT NOT NULL DEFAULT 0,
	[CreationDate] DateTIME NOT NULL,
	[ValidationDate] DateTIME NULL,
	[CompanyId] INT NOT NULL,
	[ValidatorId] INT NULL,
	[CategoryId] INT NULL,
	CONSTRAINT [PK_Service] PRIMARY KEY([Id]),
	CONSTRAINT [FK_Service_Creator]
		FOREIGN KEY ([CompanyId]) REFERENCES [Company]([Id]),
	CONSTRAINT [FK_Service_Validator]
		FOREIGN KEY ([ValidatorId]) REFERENCES [User]([Id]),
	CONSTRAINT [FK_Service_Category]
		FOREIGN KEY ([CategoryId]) REFERENCES [Category]([Id]),
	CONSTRAINT [UQ_ServiceTitle] UNIQUE([Title], [CompanyId])
)