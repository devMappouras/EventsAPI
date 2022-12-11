CREATE PROCEDURE [dbo].Customers_GetInfoForValidation
	@Email NVARCHAR(50)
AS

SELECT CustomerId, Email, Password, PasswordSalt, FirstName, LastName, CountryId

FROM [dbo].[Customers]
WHERE Email = @Email