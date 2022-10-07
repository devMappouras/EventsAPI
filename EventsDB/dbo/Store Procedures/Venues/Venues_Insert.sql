CREATE PROCEDURE [dbo].[Venues_Insert]
	@Name NVARCHAR(100),
	@Address NVARCHAR(100),
	@Town NVARCHAR(100),
	@CountryId INT
AS

INSERT INTO dbo.Venues (Name, Address, Town, CountryId)
VALUES (@Name, @Address, @Town, @CountryId);