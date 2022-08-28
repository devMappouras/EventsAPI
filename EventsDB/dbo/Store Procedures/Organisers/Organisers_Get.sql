CREATE PROCEDURE [dbo].[Organisers_Get]
	@OrganiserId INT
AS

SELECT [Name] AS OrganiserName, Location, Logo

FROM [dbo].[Organisers]
WHERE OrganiserId = @OrganiserId