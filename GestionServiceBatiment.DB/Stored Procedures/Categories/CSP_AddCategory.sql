CREATE PROCEDURE [dbo].[CSP_AddCategory]
	@Name nvarchar(100),
	@Description nvarchar(255),
	@ParentId int
As
Begin
	Insert into [dbo].[Category] ([Name], [Description], [ParentId]) OUTPUT inserted.Id
	Values (@Name, @Description, @ParentId);
	--select SCOPEIDENTITY();
End