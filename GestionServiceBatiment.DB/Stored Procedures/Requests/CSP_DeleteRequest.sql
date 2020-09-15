CREATE PROCEDURE [dbo].[CSP_DeleteRequest]
	@RequestId int
AS
	Delete From [dbo].[Request]
		Where [Id] = @RequestId
RETURN 0