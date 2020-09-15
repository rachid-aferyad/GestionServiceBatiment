CREATE VIEW [dbo].[V_RequestListing]
	AS SELECT
		R.[Id],
		R.[Title],
		R.[Description],
		R.[ImageURI],
		R.[CreationDate],
		R.[CategoryId],
		CAT.[Name] AS [CategoryName],
		R.[CreatorId],
		C.[Name] AS [CompanyName]
	FROM [dbo].[Request] R
		LEFT JOIN [dbo].[Company] C
		ON C.[Id] = R.[CreatorId]
			LEFT JOIN [dbo].[Category] CAT
			ON CAT.[Id] = R.[CategoryId]