CREATE PROCEDURE [dbo].[CSP_GetUserById]
	@id int
As
Begin
	select * From [dbo].[V_User] AS VU
	Where VU.[Id] = @id
End