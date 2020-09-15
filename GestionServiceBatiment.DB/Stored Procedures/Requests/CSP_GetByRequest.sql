CREATE PROCEDURE [dbo].[CSP_GetByRequest]
	@Table nvarchar(255),
	@RequestId varchar(255)
AS
	DECLARE @sql NVARCHAR(64)

	SET @sql = 'SELECT * FROM [dbo].' + QUOTENAME(@Table) + ' Where [ServiceId] = ' + @RequestId
 
	EXEC (@sql)
RETURN 0
