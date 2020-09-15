CREATE PROCEDURE [dbo].[CSP_GetAllRequests]
As
Begin
	select * From [dbo].[V_RequestListing]
	Return 1024;
End