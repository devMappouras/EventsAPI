CREATE PROCEDURE [dbo].[Products_Insert]
    @SectionId INT,
    @OrganiserId INT,
    @Capacity INT,
    @Name NVARCHAR(200)
AS

INSERT INTO dbo.Products (SectionId ,OrganiserId ,Capacity ,Name)
VALUES (@SectionId ,@OrganiserId ,@Capacity ,@Name);