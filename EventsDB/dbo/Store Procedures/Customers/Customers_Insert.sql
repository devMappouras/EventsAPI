CREATE PROCEDURE [dbo].[Customers_Insert]
    @Password NVARCHAR(MAX),
    @PasswordSalt NVARCHAR(MAX),
    @FirstName NVARCHAR(100),
    @LastName NVARCHAR(100),
    @Email NVARCHAR(100),
    @CountryId INT
    
AS

INSERT INTO dbo.Customers (Password, PasswordSalt, FirstName ,LastName ,Email, CountryId)
VALUES (@Password, @PasswordSalt, @FirstName ,@LastName ,@Email, @CountryId);