CREATE PROCEDURE [dbo].[CSP_AddRequest]
	@Title nvarchar(100),
	@Description varchar(255),
	@ImageURI varchar(255),
	@CreatorId int,
	@CategoryId int

As
Begin
	Insert into [dbo].[Request] ([Title], [Description], [ImageURI], [CreatorId], [CategoryId], [CreationDate]) OUTPUT inserted.Id 
	Values (@Title, @Description, @ImageURI, @CreatorId, @CategoryId, GETDATE());
End