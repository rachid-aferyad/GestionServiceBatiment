CREATE VIEW [dbo].[V_RequestDetails]
	AS SELECT
		 R.[Id]
		,R.[Title]
		,R.[Description]
		,R.[ImageURI]
		,R.[CreationDate]
		
		,VU.[Id] AS CreatorId
		,VU.[Login] AS CreatorLogin
		,VU.[Email] AS CreatorEmail
		,VU.[LastName] AS CreatorLastName
		,VU.[FirstName] AS CreatorFirstName
		,VU.[BirthDate] AS CreatorBirthDate

		,VC.[Id] AS CategoryId
		,VC.[Name] AS CategoryName
		,VC.[Description] As CategoryDescription
		,VC.[ParentId] As CategoryParentId
		,VC.[ParentName] AS CategoryParentName
		,VC.[ParentDescription] AS CategoryParentDescription
	
	FROM [dbo].[Request] R
		
		JOIN [dbo].[V_User] VU
		ON VU.[Id] = R.[CreatorId]
			
			JOIN [dbo].[V_Category] VC
			ON VC.[Id] = R.[CategoryId]