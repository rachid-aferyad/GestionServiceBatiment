CREATE PROCEDURE [dbo].[CSP_GetRequestsByUser]
	@UserId int
As
Begin
	select * From [dbo].[V_RequestCreator] AS RC
	Where RC.[CreatorId] = @UserId
End