CREATE PROCEDURE [dbo].[Categories_GetAll]
AS

SELECT [CategoryId], C.CategoryName
FROM [dbo].[Categories] C