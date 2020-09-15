CREATE PROCEDURE [dbo].[CSP_GetCategoryByName]
	@Name varchar(50)
AS
BEGIN
	Select * from [dbo].[Category]
	Where [Name] = @Name
END