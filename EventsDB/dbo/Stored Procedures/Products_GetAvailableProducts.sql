CREATE PROCEDURE Products_GetAvailableProducts
    @EventId INT,
	@OrganiserId INT
AS

DECLARE @VenueId INT;
SELECT @VenueId = VenueId FROM Events WHERE EventId = @EventId;

SELECT [ProductId]
     ,P.[HierarchyId]
     ,H.Name AS HierarchyName
     ,[Price]

FROM [dbo].[Products] P
INNER JOIN Hierarchies H ON H.HierarchyId = P.HierarchyId

WHERE P.OrganiserId = @OrganiserId AND P.VenueId = @VenueId