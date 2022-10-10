CREATE PROCEDURE [dbo].[Products_Update]
    @ProductId INT,
    @VenueId INT,
    @HierarchyId INT,
    @OrganiserId INT,
    @Price DECIMAL(18,2)
AS

UPDATE dbo.Products SET
    VenueId = @VenueId,
    HierarchyId = @HierarchyId,
    Price = @Price

WHERE ProductId = @ProductId AND OrganiserId = @OrganiserId;