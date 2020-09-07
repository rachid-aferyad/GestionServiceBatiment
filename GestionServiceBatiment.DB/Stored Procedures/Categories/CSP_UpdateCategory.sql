CREATE PROCEDURE [dbo].[CSP_UpdateCategory]
	@Id int,
	@Name nvarchar(100),
	@Description nvarchar(255)
As
Begin
	Update [dbo].[Category]
	SET [Name] = @Name, [Description] = @Description
	Where [Id] = @Id
End