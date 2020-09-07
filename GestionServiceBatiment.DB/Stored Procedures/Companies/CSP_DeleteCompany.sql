CREATE PROCEDURE [dbo].[CSP_DeleteCompany]
	@Id int
AS
	BEGIN
		Delete From [dbo].[Company]
			Where [Id] = @Id;
	END