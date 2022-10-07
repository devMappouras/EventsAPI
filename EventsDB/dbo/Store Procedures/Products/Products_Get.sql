CREATE PROCEDURE [dbo].[Products_Get]
	@ProductId INT,
    @OrganiserId INT
AS

SELECT [ProductId]
     ,P.[VenueId]
     ,V.Name AS VenueName
     ,P.[HierarchyId]
     ,H.Name AS HierarchyName
     ,[Price]

FROM [dbo].[Products] P
INNER JOIN Venues V ON V.VenueId = P.VenueId
INNER JOIN Hierarchies H ON H.HierarchyId = P.HierarchyId

WHERE P.OrganiserId = @OrganiserId AND P.ProductId = @ProductId