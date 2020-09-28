CREATE VIEW [dbo].[V_ServiceListing]
	AS SELECT
		S.[Id],
		S.[Title],
		S.[Description],
		S.[ImageURI],
		S.[CreationDate],
		S.[CategoryId],
		S.[CompanyId],
		CAT.[Name] AS [CategoryName],
		COMP.[Name] AS [CompanyName]
	
	FROM [dbo].[Service] S
		
		JOIN [dbo].[Company] COMP
		ON COMP.[Id] = S.[CompanyId]
			
			JOIN [dbo].[Category] CAT
			ON CAT.[Id] = S.[CategoryId]