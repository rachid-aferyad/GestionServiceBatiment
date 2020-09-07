CREATE PROCEDURE [dbo].[CSP_GetRejectionsByRejector]
	@RejectorId int
As
Begin
	select * From [dbo].[Rejection] AS R
	Where R.[RejectorId] = @RejectorId
End