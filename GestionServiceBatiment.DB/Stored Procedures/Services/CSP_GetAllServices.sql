CREATE PROCEDURE [dbo].[CSP_GetAllServices]
As
Begin
	select * From [dbo].[V_ServiceListing]
	Return 1024;
End