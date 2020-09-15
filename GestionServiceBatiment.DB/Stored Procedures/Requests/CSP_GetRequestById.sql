CREATE PROCEDURE [dbo].[CSP_GetRequestById]
	@Id int
	As
Begin
	select * From [dbo].[V_RequestDetails] AS RD
	Where RD.[Id] = @Id
End