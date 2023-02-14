CREATE PROCEDURE Tickets_GetTickets
	@CustomerId INT
AS

SELECT [TicketId]
	  ,EP.EventId
	  ,E.EventTitle
      ,E.EventDateTime
	  ,E.VenueId
      ,V.Name AS VenueName
	  ,E.CategoryId
      ,C.CategoryName
      ,H.Name AS HierarchyName
	  ,P.Price
	  ,S.Name AS SectionName

FROM [Tickets] T
INNER JOIN Sections S ON S.SectionId = T.SectionId
INNER JOIN EventProducts EP ON EP.EventProductId = T.EventProductId
INNER JOIN [Events] E ON E.EventId = EP.EventId
INNER JOIN Products P ON P.ProductId = EP.ProductId
INNER JOIN Category C ON C.CategoryId = E.CategoryId
INNER JOIN Venue V ON V.VenueId = E.VenueId
INNER JOIN Hierarchy H ON H.HierarchyId = P.HierarchyId

WHERE T.OwnerId = @CustomerId