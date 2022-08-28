CREATE PROCEDURE [dbo].[Collections_Delete]
	@CollectionId INT
AS

DELETE FROM [dbo].[Collections]
WHERE CollectionId = @CollectionId