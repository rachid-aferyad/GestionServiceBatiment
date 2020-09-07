CREATE PROCEDURE [dbo].[CSP_Delete]
	@Table varchar(50),
	@Id varchar(10)
As
Begin

	Declare @sql varchar(255)
	Set @sql = 'Delete From [dbo].' + QUOTENAME(@Table) + ' Where [dbo].' + QUOTENAME(@Table) + '[id] = ' +@Id
	
	EXEC (@sql)
End