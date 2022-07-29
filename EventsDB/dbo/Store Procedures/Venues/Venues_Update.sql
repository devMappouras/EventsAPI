CREATE PROCEDURE [dbo].[Venues_Update]
	@VenueId INT,
	@Name NVARCHAR(100),
	@Location NVARCHAR(100)
AS

UPDATE dbo.Venues 
SET Name = @Name, Location = @Location
WHERE VenueId = @VenueId;