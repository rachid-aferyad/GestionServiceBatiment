CREATE PROCEDURE [dbo].[CSP_GetByParentName]
	@ParentName varchar(50)
AS
BEGIN
	Select * from [dbo].[Category]
	Where [ParentId] = (Select [Id] from [dbo].[Category] Where [Name] = @ParentName)
END