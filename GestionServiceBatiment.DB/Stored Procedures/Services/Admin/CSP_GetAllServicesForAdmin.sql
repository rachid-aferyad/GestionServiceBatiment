CREATE PROCEDURE [dbo].[CSP_GetAllServicesForAdmin]
	As
Begin
	select * From [dbo].[V_ServiceAdmin]
	Return 1024;
End