CREATE PROCEDURE [dbo].[Collections_GetAll]
    @OrganiserId INT
AS

SELECT [CollectionId], C.Name AS CollectionName

FROM [dbo].[Collections] C
WHERE C.OrganiserId = @OrganiserId