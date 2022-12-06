CREATE PROCEDURE [dbo].[Customers_Delete]
	@CustomerId INT
AS

DELETE FROM [dbo].[Customers]
WHERE CustomerId = @CustomerId