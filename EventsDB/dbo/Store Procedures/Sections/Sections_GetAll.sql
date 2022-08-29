CREATE PROCEDURE [dbo].[Sections_GetAll]
AS

SELECT [SectionId], [Name], [HierarchyId], [VenueId]
FROM [dbo].[Sections]