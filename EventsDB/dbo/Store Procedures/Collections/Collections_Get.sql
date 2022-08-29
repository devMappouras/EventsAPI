CREATE PROCEDURE [dbo].[Collections_Get]
	@CollectionId INT,
    @OrganiserId INT
AS

SELECT [CollectionId], C.Name AS CollectionName

FROM [dbo].[Collections] C
WHERE CollectionId = @CollectionId AND C.OrganiserId = @OrganiserId