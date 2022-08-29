CREATE PROCEDURE [dbo].[Organisers_GetAll]
AS

SELECT [Name] AS OrganiserName, Location, Logo
FROM [dbo].[Organisers] E