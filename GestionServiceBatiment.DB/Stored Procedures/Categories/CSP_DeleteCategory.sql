CREATE PROCEDURE [dbo].[CSP_DeleteCategory]
	@Id int
AS
	BEGIN
		Delete From [dbo].[Category]
			Where [Id] = @Id;
	END