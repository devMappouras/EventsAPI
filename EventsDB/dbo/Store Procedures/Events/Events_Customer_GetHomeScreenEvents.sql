CREATE PROCEDURE [dbo].[Events_Customer_GetHomeScreenEvents]
@CustomerId INT
AS

DECLARE @CustomerCountryId INT;
SELECT @CustomerCountryId = CountryId FROM Customers C WHERE C.CustomerId = @CustomerId

SELECT TOP 5 [EventId]
           ,[EventTitle]
           ,[EventDateTime]
		   ,EventDescription
           ,C.CategoryName
           ,V.Name AS VenueName
FROM [Events] E
         INNER JOIN Venues V ON V.VenueId = E.VenueId AND V.CountryId = @CustomerCountryId
		 INNER JOIN Categories C ON C.CategoryId = E.CategoryId
ORDER BY E.EventDateTime