CREATE PROCEDURE [dbo].[CSP_GetRejectionsByService]
	@ServiceId int
As
Begin
	select * From [dbo].[Rejection] AS R
	Where R.[ServiceId] = @ServiceId
End