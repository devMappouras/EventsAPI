CREATE PROCEDURE [dbo].[Venues_GetAll]
AS

SELECT [VenueId] ,V.[Name], [Address], [Town], V.[CountryId], C.Name AS CountryName

FROM [dbo].[Venues] V
INNER JOIN Countries C ON C.CountryId = V.CountryId