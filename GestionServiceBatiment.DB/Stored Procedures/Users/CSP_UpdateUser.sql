CREATE PROCEDURE [dbo].[CSP_UpdateUser]
	@Id int,
	@LastName varchar(50),
	@FirstName varchar(50),
	@BirthDate Date
AS
BEGIN
	UPDATE [dbo].[User] 
		SET [LastName] = @LastName, [FirstName] = @FirstName, [BirthDate] = @BirthDate
		Where [Id] = @Id
END