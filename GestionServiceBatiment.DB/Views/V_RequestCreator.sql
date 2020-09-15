CREATE VIEW [dbo].[V_RequestCreator]
	AS SELECT
		R.[Id],
		R.[Title],
		R.[Description],
		R.[ImageURI],
		R.[CreationDate],
		R.[CategoryId],
		R.[CreatorId]
	FROM [dbo].[Request] R