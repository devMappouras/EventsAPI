CREATE PROCEDURE [dbo].[Organisers_Get]
	@OrganiserId INT
AS

SELECT Email, [Name] AS OrganiserName, Location, Logo

FROM [dbo].[Organisers]
WHERE OrganiserId = @OrganiserId