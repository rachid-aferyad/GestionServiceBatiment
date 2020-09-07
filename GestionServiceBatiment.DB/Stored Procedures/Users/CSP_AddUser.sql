CREATE PROCEDURE [dbo].[CSP_AddUser]
	--@id int,
	@LastName nvarchar(50),
	@FirstName nvarchar(50),
	@Email nvarchar(255),
	@Login nvarchar(255),
	@Password nvarchar(20),
	@BirthDate DATETIME,
	@Role nvarchar(25)

As
Begin
	Insert into [dbo].[User] ([LastName], [FirstName], [Email], [Login], [EncodedPassword], [BirthDate], [Role]) OUTPUT INSERTED.id
	Values (@LastName, @FirstName, @Email, @Login, [dbo].[SF_HashPassword](@Password), @BirthDate, @Role)
End