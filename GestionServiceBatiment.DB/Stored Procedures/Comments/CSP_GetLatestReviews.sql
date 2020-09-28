CREATE PROCEDURE [dbo].[CSP_GetLatestReviews]
AS
BEGIN
	Select TOP 6 * from [dbo].[V_Comment]
	ORDER BY [CreationDate] DESC
END