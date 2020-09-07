CREATE PROCEDURE [dbo].[CSP_AddCompany]
	@Name nvarchar(100),
	@VatNumber VARCHAR(25),
	@AddressStreet VARCHAR(100),
	@AddressNumber INT,
	@AddressMailBox VARCHAR(25),
	@AddressZipCode INT,
	@AddressCity VARCHAR(50),
	@AddressCountry VARCHAR(50),
	@ContractorId INT
As
Begin
	Insert into [dbo].[Company] ([Name], [VatNumber], [AddressStreet], [AddressNumber], [AddressMailBox], [AddressZipCode], [AddressCity],
		[AddressCountry], [ContractorId]) OUTPUT inserted.Id
	Values (@Name, @VatNumber, @AddressStreet, @AddressNumber, @AddressMailBox, @AddressZipCode, @AddressCity, @AddressCountry, @ContractorId);
	--select SCOPEIDENTITY();
End