CREATE PROCEDURE [dbo].[Venues_Get]
	@VenueId INT
AS

SELECT [VenueId] ,[Name] ,[Address], [Town], [CountryId]
FROM [dbo].[Venues]
WHERE VenueId = @VenueId