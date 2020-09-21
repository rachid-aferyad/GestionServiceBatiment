CREATE PROCEDURE [dbo].[CSP_AddComment]
	@CreatorId int ,
	@Content varchar(1000),
	@CompanyId int,
	@ServiceId int,
	@RequestId int,
	@Star int,
	@ParentId int
AS
	Insert into [dbo].[Comment] ([Content], [CreationDate], [CreatorId], [CompanyId], [ServiceId], [RequestId], [Star], [ParentId]) OUTPUT inserted.Id
	Values (@Content, GETDATE(), @CreatorId, @CompanyId, @ServiceId, @RequestId, @Star, @ParentId);
	
RETURN 0
