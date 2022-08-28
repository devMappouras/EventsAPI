CREATE PROCEDURE [dbo].[Sections_GetAll]
AS

SELECT [SectionId]
      ,[SectionTitle]
      ,[SectionDescription]
      ,[SectionDateTime]
      ,[BannerImage]
      ,E.[VenueId]
      ,V.Name AS VenueName
      ,E.[CollectionId]
      ,C.Name AS CollectionName
      ,[OrganiserId]

FROM [dbo].[Sections] E
INNER JOIN Venues V ON V.VenueId = E.VenueId
LEFT JOIN Collections C ON C.CollectionId = E.CollectionId