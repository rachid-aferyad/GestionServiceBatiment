CREATE PROCEDURE [dbo].[CSP_GetById]
	@table VARCHAR(255), 
	@id varchar(25)

AS
BEGIN
	DECLARE @sql NVARCHAR(64)

	SET @sql = 'SELECT * FROM [dbo].' + QUOTENAME(@table) + ' Where [Id] = ' + @id
 
	EXEC (@sql)
END