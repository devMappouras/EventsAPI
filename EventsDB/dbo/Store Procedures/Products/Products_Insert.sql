CREATE PROCEDURE [dbo].[Products_Insert]
    @VenueId INT,
    @HierarchyId INT,
    @OrganiserId INT,
    @Price INT
AS

INSERT INTO dbo.Products (VenueId ,HierarchyId ,OrganiserId ,Price)
VALUES (@VenueId ,@HierarchyId ,@OrganiserId ,@Price);