CREATE PROCEDURE [dbo].[CSP_GetAll]
	@table VARCHAR(255)

AS
BEGIN
	DECLARE @sql NVARCHAR(64)

	SET @sql = 'SELECT * FROM [dbo].' + QUOTENAME(@table)
 
	EXEC (@sql)
END