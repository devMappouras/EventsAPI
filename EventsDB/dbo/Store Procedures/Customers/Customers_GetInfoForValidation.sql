CREATE PROCEDURE [dbo].Customers_GetInfoForValidation
	@Username NVARCHAR(50)
AS

SELECT CustomerId, Username, Password, PasswordSalt, FirstName, LastName, Email, CountryId

FROM [dbo].[Customers]
WHERE Username = @Username