CREATE PROCEDURE [dbo].[Collections_Get]
	@CollectionId INT
AS

SELECT [CollectionId], C.Name AS CollectionName

FROM [dbo].[Collections]
WHERE CollectionId = @CollectionId