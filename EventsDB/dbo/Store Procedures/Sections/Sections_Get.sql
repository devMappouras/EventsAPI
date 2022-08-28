CREATE PROCEDURE [dbo].[Sections_Get]
	@SectionId INT
AS

SELECT [SectionId]
      ,[SectionTitle]
      ,[SectionDescription]
      ,[SectionDateTime]
      ,[BannerImage]
      ,[VenueId]
      ,[CollectionId]
      ,[OrganiserId]

FROM [dbo].[Sections]
WHERE SectionId = @SectionId