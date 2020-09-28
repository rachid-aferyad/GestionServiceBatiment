CREATE PROCEDURE [dbo].[CSP_GetTopCategories]
	As
Begin
	Select TOP 6 VS.*, Count(VS.[Id]) AS NbrServices
	
	from [dbo].[V_Service] AS VS

	GROUP BY VS.[CategoryId]

	ORDER BY NbrServices DESC
End