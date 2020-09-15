CREATE PROCEDURE [dbo].[CSP_GetRequestsByCategory]
	@CategoryId int
As
Begin
	select * From [dbo].[V_RequestListing] AS RL
	Where RL.[CategoryId] = @CategoryId
End