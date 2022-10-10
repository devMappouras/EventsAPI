CREATE PROCEDURE [dbo].[Hierarchies_GetAllByVenue]
    @VenueId INT
AS

SELECT DISTINCT S.[HierarchyId] AS Id ,H.[Name]

FROM Sections S
INNER JOIN Hierarchies H ON H.HierarchyId = S.HierarchyId

WHERE S.VenueId = @VenueId