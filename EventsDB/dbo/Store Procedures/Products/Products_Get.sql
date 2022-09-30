CREATE PROCEDURE [dbo].[Products_Get]
	@ProductId INT,
    @OrganiserId INT
AS

SELECT [ProductId]
     ,[SectionId]
     ,[OrganiserId]
     ,[Capacity]
     ,[Name]

FROM [dbo].[Products] P

WHERE P.OrganiserId = @OrganiserId AND P.ProductId = @ProductId