CREATE PROCEDURE [dbo].[CSP_GetAllCategories]
	As
Begin
	select * From [dbo].[Category]
	Return 1024;
End