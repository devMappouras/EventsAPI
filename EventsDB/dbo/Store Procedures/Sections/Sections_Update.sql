CREATE PROCEDURE [dbo].[Sections_Update]
    @SectionId INT,
    @Name NVARCHAR(100),
    @HierarchyId INT,
    @VenueId INT,
    @DefaultCapacity INT
AS

UPDATE dbo.Sections SET
    Name = @Name,
    HierarchyId = @HierarchyId,
    VenueId = @VenueId,
    DefaultCapacity = @DefaultCapacity

WHERE SectionId = @SectionId;