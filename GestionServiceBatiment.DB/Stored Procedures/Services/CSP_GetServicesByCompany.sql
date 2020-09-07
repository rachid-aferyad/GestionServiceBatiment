CREATE PROCEDURE [dbo].[CSP_GetServicesByCompany]
	@CompanyId int
As
Begin
	select * From [dbo].[V_ServiceCreator] AS SC
	Where SC.[CompanyId] = @CompanyId
End