CREATE PROCEDURE [dbo].[Products_Delete]
	@ProductId INT
AS


DELETE FROM [dbo].[Products]
WHERE ProductId = @ProductId