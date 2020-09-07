CREATE PROCEDURE [dbo].[CSP_GetCompanyById]
	@Id int
AS
BEGIN
	Select * from [dbo].[Company]
	Where [Id] = @Id
END