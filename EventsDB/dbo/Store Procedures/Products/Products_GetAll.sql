CREATE PROCEDURE [dbo].[Products_GetAll]
    @OrganiserId INT
AS

SELECT [ProductId]
     ,[SectionId]
     ,[OrganiserId]
     ,[Capacity]
     ,[Name]

FROM [dbo].[Products] P

WHERE P.OrganiserId = @OrganiserId