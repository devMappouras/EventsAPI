CREATE PROCEDURE [dbo].[Collections_Update]
    @CollectionId INT,
    @CollectionName NVARCHAR(100),
    @OrganiserId INT
AS

UPDATE dbo.Collections SET Name = @CollectionName, OrganiserId = @OrganiserId  
WHERE CollectionId = @CollectionId