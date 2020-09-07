CREATE TRIGGER [dbo].[CTR_OnDeleteCategory]
	On [dbo].[Category]
After Delete
As
Begin
	If EXISTS(Select * from [dbo].[Service] Where [CategoryId] = (select [Id] from deleted))
	BEGIN
		UPDATE [dbo].[Service]
		SET [CategoryId] = 0
		Where [CategoryId] = (select [Id] from deleted)
	END
End