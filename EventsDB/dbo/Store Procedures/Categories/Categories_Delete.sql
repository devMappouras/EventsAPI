CREATE PROCEDURE [dbo].[Categories_Delete]
	@CategoryId INT
AS

DELETE FROM [dbo].[Categories]
WHERE CategoryId = @CategoryId