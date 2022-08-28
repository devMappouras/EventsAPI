CREATE PROCEDURE [dbo].[Collections_Insert]
    @CollectionName NVARCHAR(100),
    @OrganiserId INT
AS

INSERT INTO dbo.Collections (CollectionName, OrganiserId)
VALUES  (@CollectionName, @OrganiserId);