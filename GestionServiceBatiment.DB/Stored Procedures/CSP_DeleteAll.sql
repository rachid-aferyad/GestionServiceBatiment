CREATE PROCEDURE [dbo].[CSP_DeleteAll]
	@Table varchar(50)
As
Begin

	Declare @sql varchar(255)
	Set @sql = 'Delete From [dbo].' + QUOTENAME(@Table)
	
	EXEC (@sql)
End