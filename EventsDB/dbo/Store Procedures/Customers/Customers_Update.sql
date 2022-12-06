CREATE PROCEDURE [dbo].[Customers_Update]
    @CustomerId INT,
    @FirstName NVARCHAR(100),
    @LastName NVARCHAR(100),
    @Email NVARCHAR(100),
    @CountryId INT
AS

UPDATE dbo.Customers SET
     FirstName = @FirstName,
     LastName = @LastName,
     Email = @Email,
     CountryId = @CountryId

WHERE CustomerId = @CustomerId;