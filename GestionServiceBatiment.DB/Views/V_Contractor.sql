CREATE VIEW [dbo].[V_Contractor]
	AS SELECT
		U.[Id],
		U.[LastName],
		U.[FirstName],
		U.[Email],
		U.[Login],
		U.[BirthDate],
		U.[Active],
		C.[Id] As companyId,
		C.[Name] AS [companyMame],
		C.[VatNumber] AS [companyVatMumber],
		C.[AddressMailBox] AS [CompanyAddressMailBox],
		C.[AddressNumber] AS [CompanyAddressNumber],
		C.[AddressStreet] AS [CompanyAddressStreet],
		C.[AddressCity] AS [CompanyAddressCity],
		C.[AddressCountry] AS [CompanyAddressCountry]
		FROM [dbo].[V_User] AS U
			LEFT JOIN [dbo].[Company] AS C
				ON C.[ContractorId] = U.[Id]