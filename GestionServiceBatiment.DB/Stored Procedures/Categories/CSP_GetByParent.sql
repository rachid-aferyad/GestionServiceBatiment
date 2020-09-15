CREATE PROCEDURE [dbo].[CSP_GetByParent]
	@ParentId int
AS
BEGIN
	Select * from [dbo].[Category]
	Where [ParentId] = @ParentId
END