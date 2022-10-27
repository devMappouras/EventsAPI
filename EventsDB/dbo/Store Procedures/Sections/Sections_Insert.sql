CREATE PROCEDURE [dbo].[Sections_Insert]
    @Name NVARCHAR(100),
    @HierarchyId INT,
    @VenueId INT,
    @DefaultCapacity INT
AS

INSERT INTO dbo.Sections (Name ,HierarchyId ,VenueId, DefaultCapacity)
VALUES (@Name ,@HierarchyId ,@VenueId, @DefaultCapacity);