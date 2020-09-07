CREATE PROCEDURE [dbo].[CSP_GetAllCompanies]
	As
Begin
	select * From [dbo].[Company]
	Return 1024;
End