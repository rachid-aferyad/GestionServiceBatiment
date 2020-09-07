CREATE PROCEDURE [dbo].[CSP_AddCategory]
	@Name nvarchar(100),
	@Description nvarchar(255)
As
Begin
	Insert into [dbo].[Category] ([Name], [Description]) OUTPUT inserted.Id
	Values (@Name, @Description);
	--select SCOPEIDENTITY();
End