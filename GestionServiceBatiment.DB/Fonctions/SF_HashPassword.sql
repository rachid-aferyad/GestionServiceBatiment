CREATE FUNCTION [dbo].[SF_HashPassword]
    (
	    @Password VARCHAR(20)
    )
RETURNS VARBINARY(64)
AS
BEGIN
    RETURN HASHBYTES('SHA2_512', CONCAT([dbo].[GetPreSalt](), @Password, [dbo].[GetPostSalt]()))
END