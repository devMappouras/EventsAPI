CREATE PROCEDURE [dbo].[Categories_Get]
	@CategoryId INT,
    @CategoryName INT
AS

SELECT [CategoryId], C.CategoryName AS CollectionName

FROM [dbo].[Categories] C
WHERE CategoryId = @CategoryId