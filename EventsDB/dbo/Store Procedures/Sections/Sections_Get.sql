CREATE PROCEDURE [dbo].[Sections_Get]
	@SectionId INT
AS

SELECT [SectionId], [Name], [HierarchyId], [VenueId]
FROM [dbo].[Sections]
WHERE SectionId = @SectionId