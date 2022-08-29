CREATE PROCEDURE [dbo].[Collections_Update]
    @CollectionId INT,
    @CollectionName NVARCHAR(100),
    @OrganiserId INT
AS

UPDATE dbo.Collections SET CollectionName = @CollectionName, OrganiserId = @OrganiserId  
WHERE CollectionId = @CollectionId