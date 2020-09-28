CREATE VIEW [dbo].[V_Company]
	AS SELECT
	   C.[Id]
      ,C.[Name]
      ,C.[VatNumber]
      ,C.[AddressMailBox]
      ,C.[AddressNumber]
      ,C.[AddressStreet]
      ,C.[AddressCity]
      ,C.[AddressZipCode]
      ,C.[AddressCountry]
      ,C.[ContractorId]
      ,VU.[Login] AS ContractorLogin
      ,VU.[Email] AS ContractorEmail
      ,VU.[LastName] AS ContractorLastName 
      ,VU.[FirstName] AS ContractorFirstName
      ,VU.[BirthDate] AS ContractorBirthDate

  FROM [dbo].[Company] As C

  JOIN [dbo].[V_User] VU
		ON C.[ContractorId] = VU.[Id]
