CREATE PROCEDURE [dbo].[CSP_GetLatestRequests]
As
Begin
	select TOP 6 * From [dbo].[V_RequestListing]
	ORDER BY [CreationDate] DESC
End