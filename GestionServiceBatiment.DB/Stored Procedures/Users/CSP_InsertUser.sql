CREATE PROCEDURE [dbo].[CSP_InsertUser]
	@LastName nvarchar(50),
	@FirstName nvarchar(50),
	@Email nvarchar(255),
	@Login nvarchar(255),
	@Password nvarchar(20),
	@BirthDate DATE,
	@Role nvarchar(25)

As
Begin
	Insert into [dbo].[User] ([LastName], [FirstName], [Email], [Login], [EncodedPassword], [BirthDate], [Role])
	Values (@LastName, @FirstName, @Email, @Login, [dbo].SF_HashPassword(@Password), @BirthDate, @Role);
	select SCOPE_IDENTITY();
End