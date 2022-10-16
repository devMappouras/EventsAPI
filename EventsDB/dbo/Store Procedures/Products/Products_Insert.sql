CREATE PROCEDURE [dbo].[Products_Insert]
    @VenueId INT,
    @HierarchyId INT,
    @OrganiserId INT,
    @Price DECIMAL(18,2)
AS

INSERT INTO dbo.Products (VenueId ,HierarchyId ,OrganiserId ,Price)
VALUES (@VenueId ,@HierarchyId ,@OrganiserId ,@Price);