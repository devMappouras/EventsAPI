CREATE PROCEDURE [dbo].[Organisers_Insert]
    @Username NVARCHAR(50),
    @Password NVARCHAR(MAX),
    @PasswordSalt NVARCHAR(MAX),
    @Name NVARCHAR(100),
    @Location NVARCHAR(100),
    @Logo NVARCHAR(100),
    @RoleId INT
    
AS

INSERT INTO dbo.Organisers (Username, Password, PasswordSalt, Name ,Location ,Logo, RoleId)
VALUES (@Username, @Password, @PasswordSalt, @Name ,@Location ,@Logo, @RoleId);