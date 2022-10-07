CREATE PROCEDURE [dbo].[Venues_Get]
	@VenueId INT
AS

SELECT [VenueId] ,V.[Name], [Address], [Town], V.[CountryId], C.Name AS CountryName

FROM [dbo].[Venues] V
INNER JOIN Countries C ON C.CountryId = V.CountryId

WHERE VenueId = @VenueId