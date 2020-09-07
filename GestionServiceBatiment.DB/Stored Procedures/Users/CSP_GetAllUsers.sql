CREATE PROCEDURE [dbo].[CSP_GetAllUsers]
	As
Begin
	select * From [dbo].[V_User] AS VU
End
