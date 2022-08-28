CREATE PROCEDURE [dbo].[Organisers_Insert]
    @Name NVARCHAR(100),
    @Location NVARCHAR(100),
    @Logo NVARCHAR(100)
    
AS

INSERT INTO dbo.Organisers (Name ,Location ,Logo)
VALUES (@Name ,@Location ,@Logo);