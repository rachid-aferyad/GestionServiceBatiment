CREATE PROCEDURE [dbo].[CSP_GetServiceByIdForAdmin]
	@ServiceId int
	As
Begin
	select * From [dbo].[V_ServiceAdmin] AS SA
	Where SA.[Id] = @ServiceId
	Return 1024;
End