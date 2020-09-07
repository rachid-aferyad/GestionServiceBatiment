CREATE Trigger [dbo].[CTR_OnModifyService]
	On [dbo].[Service]
After Update
As
Begin
	Declare @ServiceId int = (select [Id] from inserted);
	Insert into [dbo].[Modification] ([ServiceId], [ModificationDate])
		Values(@ServiceId, GETDATE());
End