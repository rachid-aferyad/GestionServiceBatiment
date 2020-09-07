CREATE TABLE [dbo].[Rejection]
(
	[Id] INT NOT NULL IDENTItY,
	[RejectorId] INT NOT NULL,
	[ServiceId] INT NOT NULL,
	[RejectionDate] DATETIME NOT NULL,
	[Comment] VARCHAR(255) NOT NULL,
	CONSTRAINT [PK_Rejection] PRIMARY KEY([Id]),
	CONSTRAINT [FK_Rejection_User] 
		FOREIGN KEY ([RejectorId]) REFERENCES [User]([Id]),
	CONSTRAINT [FK_Rejection_Service] 
		FOREIGN KEY ([ServiceId]) REFERENCES [Service]([Id])
)