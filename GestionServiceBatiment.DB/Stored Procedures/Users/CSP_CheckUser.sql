CREATE PROCEDURE [dbo].[CSP_CheckUser]
	--@Email nvarchar(255),
	@Login nvarchar(255),
	--@UserName nvarchar(255),
	@Password nvarchar(20)
As
Begin
	Select VU.*
	From [dbo].[V_User] AS VU
		JOIN [dbo].[User] AS U
			ON U.[Id] = VU.[Id] 
				And (VU.[Email] = @Login OR VU.[Login] = @Login)
				And U.[EncodedPassword] = [dbo].[SF_HashPassword](@Password)
End

--Begin
--	Select [FirstName], [LastName], [Login], [Email], [BirthDate], [Active], [Role]
--	From [dbo].[User] AS U
--				Where (U.[Email] = @Email And U.[Login] = @Login)
--				And U.[EncodedPassword] = HASHBYTES('SHA2_512', dbo.GetPreSalt() + @Password + dbo.GetPostSalt());
--End