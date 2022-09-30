CREATE PROCEDURE [dbo].[Products_Update]
    @ProductId INT,
    @SectionId INT,
    @OrganiserId INT,
    @Capacity INT,
    @Name NVARCHAR(200)
AS

UPDATE dbo.Products SET
    @SectionId = @SectionId,
    @OrganiserId = @OrganiserId,
    @Capacity = @Capacity,
    @Name = @Name,

WHERE ProductId = @ProductId;