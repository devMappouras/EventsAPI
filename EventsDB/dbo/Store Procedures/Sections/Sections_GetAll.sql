CREATE PROCEDURE [dbo].[Sections_GetAll]
    @VenueId INT
AS

SELECT [SectionId], S.[Name], S.[HierarchyId], H.Name AS HierarchyName, S.DefaultCapacity

FROM [dbo].[Sections] S
INNER JOIN Hierarchies H ON H.HierarchyId = S.HierarchyId

WHERE VenueId = @VenueId