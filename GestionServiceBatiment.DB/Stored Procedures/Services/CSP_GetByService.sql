CREATE PROCEDURE [dbo].[CSP_GetByService]
	@Table nvarchar(255),
	@ServiceId varchar(255)
AS
	DECLARE @sql NVARCHAR(64)

	SET @sql = 'SELECT * FROM [dbo].' + QUOTENAME(@table) + ' Where [ServiceId] = ' + @ServiceId
 
	EXEC (@sql)
RETURN 0
