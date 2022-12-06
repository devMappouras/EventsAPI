CREATE PROCEDURE [dbo].[Customers_Insert]
    @Username NVARCHAR(50),
    @Password NVARCHAR(MAX),
    @PasswordSalt NVARCHAR(MAX),
    @FirstName NVARCHAR(100),
    @LastName NVARCHAR(100),
    @Email NVARCHAR(100),
    @CountryId INT
    
AS

INSERT INTO dbo.Customers (Username, Password, PasswordSalt, FirstName ,LastName ,Email, CountryId)
VALUES (@Username, @Password, @PasswordSalt, @FirstName ,@LastName ,@Email, @CountryId);