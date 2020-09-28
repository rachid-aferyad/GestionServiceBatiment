CREATE VIEW [dbo].[V_Category]
	AS SELECT  
       C.[Id]
      ,C.[Name]
      ,C.[Description]
      ,C.[ParentId]
      ,CP.[Name] AS ParentName
      ,CP.[Description] AS ParentDescription
  
  FROM [dbo].[Category] AS C

  JOIN [dbo].[Category] AS CP
  ON C.[ParentId] = CP.[Id]