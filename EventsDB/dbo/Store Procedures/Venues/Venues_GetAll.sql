CREATE PROCEDURE [dbo].[Venues_GetAll]
AS

SELECT [VenueId] ,[Name] ,[Location]
FROM [dbo].[Venues]