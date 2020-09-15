CREATE VIEW [dbo].[V_RequestDetails]
	AS SELECT
		R.[Id],
		R.[Title],
		R.[Description],
		R.[ImageURI],
		R.[CreationDate],
		R.[CategoryId],
		C.[Name] AS [CategoryName],
		R.[CreatorId],
		U.[Login] AS [UserName]
	FROM [dbo].[Request] R
		LEFT JOIN [dbo].[User] U
		ON U.[Id] = R.[CreatorId]
			LEFT JOIN [dbo].[Category] C
			ON C.[Id] = R.[CategoryId]