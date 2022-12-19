CREATE PROCEDURE [dbo].[Events_Delete]
	@EventId INT
AS

DELETE FROM [dbo].EventProducts
WHERE EventId = @EventId
    
DELETE FROM [dbo].[Events]
WHERE EventId = @EventId