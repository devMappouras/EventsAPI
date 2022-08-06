CREATE PROCEDURE [dbo].[Events_GetAll]
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