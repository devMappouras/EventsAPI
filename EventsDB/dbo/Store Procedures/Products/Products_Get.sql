CREATE PROCEDURE [dbo].[Products_Get]
	@ProductId INT,
    @OrganiserId INT
AS

SELECT [ProductId]
     ,[VenueId]
     ,[Capacity]
     ,[HierarchyId]
     ,[Price]

FROM [dbo].[Products] P

WHERE P.OrganiserId = @OrganiserId AND P.ProductId = @ProductId