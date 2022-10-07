CREATE PROCEDURE [dbo].[Venues_GetAll]
AS

SELECT [VenueId] ,[Name], [Address], [Town], [CountryId]
FROM [dbo].[Venues]