CREATE TABLE [dbo].[Modification]
(
	[Id] INT NOT NULL IDENTItY,
	[ServiceId] INT NOT NULL,
	[ModificationDate] DATETIME NOT NULL,
	CONSTRAINT [PK_Modification] PRIMARY KEY([Id]),
	CONSTRAINT [FK_Modification_Service] 
		FOREIGN KEY ([ServiceId]) REFERENCES [Service]([Id])
)