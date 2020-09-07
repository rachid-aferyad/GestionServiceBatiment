CREATE PROCEDURE [dbo].[CSP_GetServiceById]
	@Id int
	As
Begin
	select * From [dbo].[V_ServiceDetails] AS SD
	Where SD.[Id] = @Id
End