CREATE PROCEDURE [dbo].[CSP_GetByCompany]
	@Table nvarchar(255),
	@CompanyId varchar(255)
AS
	DECLARE @sql NVARCHAR(64)

	SET @sql = 'SELECT * FROM [dbo].' + QUOTENAME(@Table) + ' Where [CompanyId] = ' + @CompanyId
 
	EXEC (@sql)
RETURN 0