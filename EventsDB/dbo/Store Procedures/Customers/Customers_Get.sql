﻿CREATE PROCEDURE [dbo].[Customers_Get]
	@CustomerId INT
AS

SELECT FirstName, LastName, Email, CountryId

FROM [dbo].[Customers]
WHERE CustomerId = @CustomerId