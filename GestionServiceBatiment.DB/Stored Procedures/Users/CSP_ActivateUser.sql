CREATE PROCEDURE [dbo].[CSP_ActivateUser]
	@Id int
AS
BEGIN
	UPDATE [dbo].[User] 
		SET [Active] = 1
		Where [Id] = @Id
END