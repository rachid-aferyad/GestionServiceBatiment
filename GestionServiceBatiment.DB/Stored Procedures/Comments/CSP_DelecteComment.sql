CREATE PROCEDURE [dbo].[CSP_DelecteComment]
	@CommentId int
AS
	Delete From [dbo].[Comment]
		Where [Id] = @CommentId or [ParentId] = @CommentId
RETURN 0