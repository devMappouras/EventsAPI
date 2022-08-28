CREATE PROCEDURE [dbo].[Organisers_Delete]
	@OrganiserId INT
AS

DELETE FROM [dbo].[Organisers]
WHERE OrganiserId = @OrganiserId