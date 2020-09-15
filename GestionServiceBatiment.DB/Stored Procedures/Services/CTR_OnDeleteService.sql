CREATE Trigger [dbo].[CTR_OnDeleteService]
	On [dbo].[Service]
Instead Of Delete
As
Begin
	Update [dbo].[Service] Set [Active] = 0
		where [Id] in (select [Id] from deleted)

	Delete from [dbo].[Comment]
		where [ServiceId] in (select [Id] from deleted)
End