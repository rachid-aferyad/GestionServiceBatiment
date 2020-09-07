CREATE TABLE [dbo].[Company]
(
	[Id] INT NOT NULL IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	[VatNumber] VARCHAR(25) NOT NULL,
	[AddressMailBox] VARCHAR(25) NOT NULL,
	[AddressNumber] INT NOT NULL,
	[AddressStreet] VARCHAR(100) NOT NULL,
	[AddressCity] VARCHAR(50) NOT NULL,
	[AddressZipCode] int NOT NULL,
	[AddressCountry] VARCHAR(50) NOT NULL,
	[ContractorId] INT NOT NULL,
	CONSTRAINT [PK_Company] PRIMARY KEY([Id]),
	CONSTRAINT [UQ_CompanyName] UNIQUE([Name]),
	CONSTRAINT [UQ_CompanyVatNumber] UNIQUE([VatNumber]),
	CONSTRAINT [UQ_CompanyAddress]
		UNIQUE([AddressMailBox], [AddressNumber],[AddressStreet], [AddressCity], [AddressCountry]),
	CONSTRAINT [FK_Company_User] 
		FOREIGN KEY ([ContractorId]) REFERENCES [User]([Id])
)