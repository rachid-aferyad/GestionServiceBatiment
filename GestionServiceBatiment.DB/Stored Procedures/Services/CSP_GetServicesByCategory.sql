CREATE PROCEDURE [dbo].[CSP_GetServicesByCategory]
	@CategoryId int
As
Begin
	select * From [dbo].[V_ServiceListing] AS SL
	Where SL.[CategoryId] = @CategoryId
End