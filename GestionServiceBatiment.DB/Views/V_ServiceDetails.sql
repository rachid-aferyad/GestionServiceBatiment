CREATE VIEW [dbo].[V_ServiceDetails]
	AS SELECT
	   S.[Id]
      ,S.[Title]
      ,S.[Description]
      ,S.[ImageURI]
      ,S.[CreationDate]
	  
      ,VCOMP.[Id] AS CompanyId
      ,VCOMP.[Name] AS CompanyName
      ,VCOMP.[VatNumber] AS CompanyVatNumber
      ,VCOMP.[AddressMailBox] AS CompanyAddressMailBox
      ,VCOMP.[AddressNumber] AS CompanyAddressNumber
      ,VCOMP.[AddressStreet] AS CompanyAddressStreet
      ,VCOMP.[AddressCity] AS CompanyAddressCity
      ,VCOMP.[AddressZipCode] AS CompanyAddressZipCode
      ,VCOMP.[AddressCountry] AS CompanyAddressCountry
      
      ,VCOMP.[ContractorId]
	  ,VCOMP.[ContractorLogin]
      ,VCOMP.[ContractorEmail]
      ,VCOMP.[ContractorLastName]
      ,VCOMP.[ContractorFirstName]
      ,VCOMP.[ContractorBirthDate]

      ,VCAT.[Id] AS CategoryId
      ,VCAT.[Name] AS CategoryName
      ,VCAT.[Description] As CategoryDescription
      ,VCAT.[ParentId] As CategoryParentId
      ,VCAT.[ParentName] AS CategoryParentName
      ,VCAT.[ParentDescription] AS CategoryParentDescription
	
	FROM [dbo].[Service] S
		
		JOIN [dbo].[V_Company] VCOMP
		ON VCOMP.[Id] = S.[CompanyId]
			
			JOIN [dbo].[V_Category] VCAT
			ON VCAT.[Id] = S.[CategoryId]