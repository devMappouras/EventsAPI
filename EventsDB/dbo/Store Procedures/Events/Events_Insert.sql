CREATE PROCEDURE [dbo].[Events_Insert]
    @EventTitle NVARCHAR(100),
    @EventDescription NVARCHAR(MAX),
    @EventDateTime DateTime,
    @BannerImage NVARCHAR(50),
    @CategoryId INT,
    @VenueId INT,
    @CollectionId INT,
    @OrganiserId INT
AS

INSERT INTO dbo.Events (EventTitle ,EventDescription ,EventDateTime ,BannerImage ,CategoryId ,VenueId ,CollectionId ,OrganiserId)
VALUES (@EventTitle ,@EventDescription ,@EventDateTime ,@BannerImage, @CategoryId ,@VenueId ,@CollectionId ,@OrganiserId);