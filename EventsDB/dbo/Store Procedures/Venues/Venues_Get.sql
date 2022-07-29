CREATE PROCEDURE [dbo].[Venues_Get]
	@VenueId INT
AS

SELECT [VenueId] ,[Name] ,[Location]
FROM [dbo].[Venues]
WHERE VenueId = @VenueId