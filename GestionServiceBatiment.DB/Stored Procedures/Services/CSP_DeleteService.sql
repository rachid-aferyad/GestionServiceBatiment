CREATE PROCEDURE [dbo].[CSP_DeleteService]
	@ServiceId int
AS
	Delete From [dbo].[Service]
		Where [Id] = @ServiceId
RETURN 0