CREATE PROCEDURE [dbo].[Events_Get]
	@EventId INT,
    @OrganiserId INT
AS

SELECT [EventId]
     ,[EventTitle]
     ,[EventDescription]
     ,[EventDateTime]
     ,[BannerImage]
     ,E.[VenueId]
     ,V.Name AS VenueName
     ,E.[CollectionId]
     ,C.Name AS CollectionName

FROM [dbo].[Events] E
INNER JOIN Venues V ON V.VenueId = E.VenueId
LEFT JOIN Collections C ON C.CollectionId = E.CollectionId

WHERE E.OrganiserId = @OrganiserId AND E.EventId = @EventId