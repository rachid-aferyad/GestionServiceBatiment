CREATE PROCEDURE [dbo].[CSP_GetCommentsByParent]
	@ParentId int
AS
BEGIN
	Select * from [dbo].[Comment]
	Where [ParentId] = @ParentId
END