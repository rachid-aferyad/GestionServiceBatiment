CREATE VIEW [dbo].[V_ServiceCreator]
	AS SELECT
		S.[Id],
		S.[Title],
		S.[Description],
		S.[ImageURI],
		S.[CreationDate],
		S.[CategoryId],
		S.[CompanyId],
		S.[Active],
		S.[ActivedForValidation]
	FROM [dbo].[Service] S