CREATE PROCEDURE [dbo].[Products_Update]
    @ProductId INT,
    @VenueId INT,
    @HierarchyId INT,
    @Capacity INT,
    @Price INT
AS

UPDATE dbo.Products SET
    @VenueId = @VenueId,
    @HierarchyId = @HierarchyId,
    @Capacity = @Capacity,
    @Price = @Price

WHERE ProductId = @ProductId;