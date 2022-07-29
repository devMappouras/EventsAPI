CREATE PROCEDURE [dbo].[Venues_Insert]
	@Name NVARCHAR(100),
	@Location NVARCHAR(100)
AS

INSERT INTO dbo.Venues (Name, Location)
VALUES (@Name, @Location);