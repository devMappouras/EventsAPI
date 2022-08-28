CREATE PROCEDURE [dbo].[Events_Update]
    @EventId INT,
    @EventTitle NVARCHAR(100),
    @EventDescription NVARCHAR(MAX),
    @EventDateTime DateTime,
    @BannerImage NVARCHAR(50),
    @VenueId INT,
    @CollectionId INT,
    @OrganiserId INT
AS

UPDATE dbo.Events SET 
    EventTitle = @EventTitle, 
    EventDescription = @EventDescription, 
    EventDateTime = @EventDateTime,
    BannerImage = @BannerImage,
    VenueId = @VenueId,
    CollectionId = @CollectionId,
    OrganiserId = @OrganiserId

WHERE EventId = @EventId;