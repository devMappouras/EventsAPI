CREATE PROCEDURE [dbo].[Products_GetAll]
    @OrganiserId INT
AS

SELECT [ProductId]
     ,[VenueId]
     ,[Capacity]
     ,[HierarchyId]
     ,[Price]

FROM [dbo].[Products] P

WHERE P.OrganiserId = @OrganiserId