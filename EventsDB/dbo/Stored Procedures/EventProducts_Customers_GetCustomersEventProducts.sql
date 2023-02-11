CREATE PROCEDURE EventProducts_Customers_GetCustomersEventProducts
	@EventId INT
AS

SELECT EP.EventProductId, EP.ProductId, P.HierarchyId, H.Name AS HierarchyName, P.Price, S.SectionId, S.Name AS SectionName, S.DefaultCapacity AS Capacity
FROM EventProducts EP
INNER JOIN [Events] E ON E.EventId = EP.EventId
INNER JOIN [Products] P ON P.ProductId = EP.ProductId
INNER JOIN Hierarchies H ON H.HierarchyId = P.HierarchyId
INNER JOIN Sections S ON S.HierarchyId = H.HierarchyId
WHERE EP.EventId = @EventId