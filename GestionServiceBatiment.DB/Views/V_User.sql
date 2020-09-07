CREATE VIEW [dbo].[V_User]
	AS Select 
		U.[Id],
		U.[LastName],
		U.[FirstName],
		U.[Email],
		U.[Login],
		U.[BirthDate],
		U.[Active],
		U.[Role]
	From [dbo].[User] AS U