CREATE PROCEDURE [dbo].[CSP_ChangePassword]
	@Id varchar(25),
	@Password varchar(20)
AS
BEGIN
	UPDATE [dbo].[User] 
	SET [EncodedPassword] = [dbo].[SF_HashPassword](@Password)
	Where [Id] = @Id

	--Declare @sql varchar(MAX)

	--Set @sql = 'UPDATE [dbo].[User] SET [EncodedPassword] = ' + CAST([dbo].[SF_HashPassword](@Password) AS NVARCHAR(MAX)) + ' Where [dbo].[User][id] = ' +@Id
	
	--EXEC (@sql)
END