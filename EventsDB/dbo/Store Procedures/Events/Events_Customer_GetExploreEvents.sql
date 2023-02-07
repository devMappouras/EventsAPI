CREATE PROCEDURE Events_Customer_GetExploreEvents
@CustomerId INT
AS

SELECT TOP 50 
            [EventId]
           ,[EventTitle]
           ,[EventDateTime]
           ,[BannerImage]
		   ,EventDescription
           ,C.CategoryName
           ,V.Name AS VenueName
FROM [Events] E
         INNER JOIN Venues V ON V.VenueId = E.VenueId
		 INNER JOIN Categories C ON C.CategoryId = E.CategoryId
ORDER BY E.EventDateTime