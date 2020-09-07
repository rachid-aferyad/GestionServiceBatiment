CREATE PROCEDURE [dbo].[CSP_AddService]
	@Title nvarchar(100),
	@Description varchar(255),
	@ImageURI varchar(255),
	@CompanyId int,
	@CategoryId int

As
Begin
	Insert into [dbo].[Service] ([Title], [Description], [ImageURI], [CompanyId], [CategoryId], [CreationDate]) OUTPUT inserted.Id 
	Values (@Title, @Description, @ImageURI, @CompanyId, @CategoryId, GETDATE());
End