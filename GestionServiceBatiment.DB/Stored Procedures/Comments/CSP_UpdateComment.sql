CREATE PROCEDURE [dbo].[CSP_UpdateComment]
	@Id int,
	@Content varchar(1000),
	@Star int
As
Begin
	UPDATE [dbo].[Comment] 
		SET [Content] = @Content, [Star] = @Star
	Where [Id] = @Id
End