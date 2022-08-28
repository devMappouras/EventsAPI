CREATE PROCEDURE [dbo].[Collections_GetAll]
AS

SELECT [CollectionId], C.Name AS CollectionName

FROM [dbo].[Collections] E
INNER JOIN Venues V ON V.VenueId = E.VenueId
LEFT JOIN Collections C ON C.CollectionId = E.CollectionId