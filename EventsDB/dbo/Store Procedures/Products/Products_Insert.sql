CREATE PROCEDURE [dbo].[Products_Insert]
    @VenueId INT,
    @HierarchyId INT,
    @OrganiserId INT,
    @Capacity INT,
    @Price INT
AS

INSERT INTO dbo.Products (VenueId ,HierarchyId ,OrganiserId ,Capacity, Price)
VALUES (@VenueId ,@HierarchyId ,@OrganiserId ,@Capacity, @Price);