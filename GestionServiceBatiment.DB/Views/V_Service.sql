CREATE VIEW [dbo].[V_Service]
	AS SELECT
		S.[Id],
		S.[Title],
		S.[Description],
		S.[ImageURI],
		S.[CreationDate],
		S.[CategoryId],
		S.[CompanyId]
	
	FROM [dbo].[Service] S