CREATE PROCEDURE [dbo].[Sections_Insert]
    @Name NVARCHAR(100),
    @HierarchyId INT,
    @VenueId INT
AS

INSERT INTO dbo.Sections (Name ,HierarchyId ,VenueId)
VALUES (@Name ,@HierarchyId ,@VenueId);