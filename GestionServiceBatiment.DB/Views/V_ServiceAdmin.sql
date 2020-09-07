CREATE VIEW [dbo].[V_ServiceAdmin]
	AS SELECT
		S.[Id],
		S.[Title],
		S.[Description],
		S.[ImageURI],
		S.[CreationDate],
		S.[CompanyId],
		S.[CategoryId],
		S.[Active],
		S.[ActivedForValidation]
	FROM [dbo].[Service] S