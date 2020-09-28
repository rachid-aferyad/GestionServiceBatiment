CREATE VIEW [dbo].[V_Comment]
	AS SELECT
	   C.[Id]
      ,C.[Content]
      ,C.[CreationDate]
      ,C.[Star]
      ,C.[CreatorId]
      ,C.[CompanyId]
      ,C.[RequestId]
      ,C.[ServiceId]
      ,C.[ParentId]
	  ,U.[LastName]
	  ,U.[FirstName]
	  ,U.[Email]
	  ,U.[Login]
	  ,U.[BirthDate]
	
	FROM [dbo].[Comment] AS C
		
		JOIN [dbo].[V_User] AS U
		ON C.[CreatorId] = U.[Id]