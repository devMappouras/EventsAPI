CREATE PROCEDURE [dbo].[Hierarchies_GetAll]
AS

SELECT [HierarchyId] AS Id ,[Name]
FROM [dbo].[Hierarchies]