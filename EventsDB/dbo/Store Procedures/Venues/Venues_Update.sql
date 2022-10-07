CREATE PROCEDURE [dbo].[Venues_Update]
	@VenueId INT,
	@Name NVARCHAR(100),
	@Address NVARCHAR(100),
	@Town NVARCHAR(100),
	@CountryId INT
AS

UPDATE dbo.Venues 
SET Name = @Name,
    Address = @Address,
    Town = @Town,
    CountryId = @CountryId


WHERE VenueId = @VenueId;