CREATE PROCEDURE [dbo].[CSP_UpdateCompany]
	@Id int,
	@Name nvarchar(100),
	@VatNumber VARCHAR(25),
	@AddressStreet VARCHAR(100),
	@AddressNumber INT,
	@AddressMailBox VARCHAR(25),
	@AddressZipCode INT,
	@AddressCity VARCHAR(50),
	@AddressCountry VARCHAR(50)
	--@ContractorId INT
As
Begin
	UPDATE [dbo].[Company] 
		SET [Name] = @Name, [VatNumber] = @VatNumber, [AddressStreet] = @AddressStreet, [AddressNumber] = @AddressNumber,
			[AddressMailBox] = @AddressMailBox, [AddressZipCode] = @AddressZipCode, [AddressCity] = @AddressCity, 
			[AddressCountry] = @AddressCountry
	Where [Id] = @Id
End