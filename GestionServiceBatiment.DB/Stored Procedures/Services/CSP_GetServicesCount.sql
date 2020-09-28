CREATE PROCEDURE [dbo].[CSP_GetServicesCount]
	As
Begin
	select Count(*) From [dbo].[V_Service]
End