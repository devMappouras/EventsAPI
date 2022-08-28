CREATE PROCEDURE [dbo].[Sections_Delete]
	@SectionId INT
AS

DELETE FROM [dbo].[Sections]
WHERE SectionId = @SectionId