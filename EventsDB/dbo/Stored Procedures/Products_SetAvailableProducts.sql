CREATE PROCEDURE [dbo].[Products_SetAvailableProducts]
    @EventId INT,
	@ProductsIds NVARCHAR(MAX)
AS

DELETE EventProducts WHERE EventId = @EventId;

INSERT INTO EventProducts(EventId, ProductId)
SELECT @EventId, CAST(VALUE AS INT) FROM STRING_SPLIT(@ProductsIds, ',');