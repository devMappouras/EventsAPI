CREATE PROCEDURE [dbo].[Customers_GetAll]
AS

SELECT FirstName, LastName, Email, CountryId
FROM [dbo].[Customers]