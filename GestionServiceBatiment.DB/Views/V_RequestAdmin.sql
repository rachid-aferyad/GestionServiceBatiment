CREATE VIEW [dbo].[V_RequestAdmin]
	AS SELECT
		R.[Id],
		R.[Title],
		R.[Description],
		R.[ImageURI],
		R.[CreationDate],
		R.[CreatorId],
		R.[CategoryId]
	FROM [dbo].[Request] R