CREATE PROCEDURE [dbo].[CSP_GetSupCategories]
	As
Begin
	select * From [dbo].[Category]
	Where [ParentId] is null
	Return 1024;
End