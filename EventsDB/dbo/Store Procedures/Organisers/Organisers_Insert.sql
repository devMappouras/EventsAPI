CREATE PROCEDURE [dbo].[Organisers_Insert]
    @Email NVARCHAR(50),
    @Password NVARCHAR(MAX),
    @PasswordSalt NVARCHAR(MAX),
    @Name NVARCHAR(100),
    @Location NVARCHAR(100),
    @Logo NVARCHAR(100),
    @RoleId INT
    
AS

INSERT INTO dbo.Organisers (Email, Password, PasswordSalt, Name ,Location ,Logo, RoleId)
VALUES (@Email, @Password, @PasswordSalt, @Name ,@Location ,@Logo, @RoleId);