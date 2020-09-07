CREATE VIEW [dbo].[V_ServiceListing]
	AS SELECT
		S.[Id],
		S.[Title],
		S.[Description],
		S.[ImageURI],
		S.[CreationDate],
		S.[CategoryId],
		CAT.[Name] AS [CategoryName],
		S.[CompanyId],
		C.[Name] AS [CompanyName]
	FROM [dbo].[Service] S
		LEFT JOIN [dbo].[Company] C
		ON C.[Id] = S.[CompanyId]
			LEFT JOIN [dbo].[Category] CAT
			ON CAT.[Id] = S.[CategoryId]