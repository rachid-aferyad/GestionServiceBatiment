CREATE PROCEDURE [dbo].[CSP_DeleteUser]
	@Id int
As
Begin
	Delete
	From [dbo].[User]
	where [Id] = @Id;
End