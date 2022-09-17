CREATE PROCEDURE [dbo].[Organisers_Update]
    @OrganiserId INT,
    @Name NVARCHAR(100),
    @Location NVARCHAR(100),
    @Logo NVARCHAR(100)
AS

UPDATE dbo.Organisers SET
    Name = @Name,
    Location = @Location,
    Logo = @Logo

WHERE OrganiserId = @OrganiserId;