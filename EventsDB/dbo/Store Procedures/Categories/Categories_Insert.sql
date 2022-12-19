CREATE PROCEDURE [dbo].[Categories_Insert]
    @CategoryName NVARCHAR(100)
AS

INSERT INTO dbo.Categories (CategoryName)
VALUES  (@CategoryName);