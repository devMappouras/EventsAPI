CREATE PROCEDURE [dbo].Organisers_GetInfoForValidation
	@Email NVARCHAR(50)
AS

SELECT OrganiserId, Email, Password, PasswordSalt, [Name] AS OrganiserName, Location, Logo

FROM [dbo].[Organisers]
WHERE Email = @Email