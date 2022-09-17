CREATE PROCEDURE [dbo].Organisers_GetInfoForValidation
	@Username NVARCHAR(50)
AS

SELECT Username, Password, PasswordSalt, [Name] AS OrganiserName, Location, Logo

FROM [dbo].[Organisers]
WHERE Username = @Username