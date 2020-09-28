CREATE PROCEDURE [dbo].[CSP_GetTopCategories]
	As
Begin
	Select C.[Id], c.[Name], TC.[NbrServices]
	
	from  [dbo].[Category] AS C

	JOIN (Select TOP 6 S.[CategoryId] AS [Id], Count(S.[Id]) AS NbrServices
	
		from [dbo].[Service] AS S

		GROUP BY S.[CategoryId]

		ORDER BY NbrServices DESC
		) AS TC

		ON TC.[Id] = C.[Id]
End