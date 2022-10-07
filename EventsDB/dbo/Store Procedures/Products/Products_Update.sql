CREATE PROCEDURE [dbo].[Products_Update]
    @ProductId INT,
    @VenueId INT,
    @HierarchyId INT,
    @Price INT
AS

UPDATE dbo.Products SET
    @VenueId = @VenueId,
    @HierarchyId = @HierarchyId,
    @Price = @Price

WHERE ProductId = @ProductId;