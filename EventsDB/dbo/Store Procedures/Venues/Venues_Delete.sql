CREATE PROCEDURE [dbo].[Venues_Delete]
	@VenueId INT
AS

DELETE FROM [dbo].[Venues]
WHERE VenueId = @VenueId