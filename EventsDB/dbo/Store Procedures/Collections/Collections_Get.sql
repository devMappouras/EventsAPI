CREATE PROCEDURE [dbo].[Events_Get]
	@EventId INT
AS

SELECT [EventId]
      ,[EventTitle]
      ,[EventDescription]
      ,[EventDateTime]
      ,[BannerImage]
      ,[VenueId]
      ,[CollectionId]
      ,[OrganiserId]

FROM [dbo].[Events]
WHERE EventId = @EventId