CREATE PROCEDURE [dbo].[CSP_GetByUser]
	@Table nvarchar(255),
	@UserId varchar(255)
AS
	DECLARE @sql NVARCHAR(64)

	SET @sql = 'SELECT * FROM [dbo].' + QUOTENAME(@Table) + ' Where [UserId] = ' + @UserId
 
	EXEC (@sql)
RETURN 0