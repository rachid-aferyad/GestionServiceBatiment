CREATE PROCEDURE [dbo].[CSP_UpdateService]
	@Id int,
	@Title nvarchar(100),
	@Description varchar(255),
	@ImageURI varchar(255),
	@CategoryId int

AS
BEGIN
	UPDATE [dbo].[Service] 
		SET [Title] = @Title, [Description] = @Description, [ImageURI] = @ImageURI, [CategoryId] = @CategoryId
			Where [Id] = @Id;
		RETURN;
END

