CREATE PROCEDURE Products_GetSelectedProducts
    @EventId INT
AS

SELECT  EP.ProductId,
		P.[HierarchyId],
		H.Name AS HierarchyName,
		Price

FROM EventProducts EP
INNER JOIN Products P ON P.ProductId = EP.ProductId
INNER JOIN Hierarchies H ON H.HierarchyId = P.HierarchyId

WHERE EP.EventId = @EventId