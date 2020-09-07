CREATE PROCEDURE [dbo].[CSP_GetCompanyByContractorId]
	@ContractorId int
AS
BEGIN
	Select * from [dbo].[Company]
	Where [ContractorId] = @ContractorId
END