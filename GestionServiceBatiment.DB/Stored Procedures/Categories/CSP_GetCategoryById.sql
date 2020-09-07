CREATE PROCEDURE [dbo].[CSP_GetCategoryById]
	@Id int
AS
BEGIN
	Select * from [dbo].[Category]
	Where [Id] = @Id
END