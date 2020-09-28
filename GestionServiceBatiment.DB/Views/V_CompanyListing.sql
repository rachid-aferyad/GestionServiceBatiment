CREATE VIEW [dbo].[V_CompanyListing]
	AS SELECT
	   C.[Id]
      ,C.[Name]
      ,C.[ContractorId]
      ,VU.[Login] AS ContractorLogin
      ,VU.[LastName] AS ContractorLastName 
      ,VU.[FirstName] AS ContractorFirstName

  FROM [dbo].[Company] As C

  JOIN [dbo].[V_User] VU
		ON C.[ContractorId] = VU.[Id]
