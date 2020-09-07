Create Trigger [dbo].[CTR_OnDeleteUser]
On [dbo].[User]
Instead Of Delete
As
Begin
	Update [dbo].[User] Set [Active] = 0
		where [Id] in (select [Id] from deleted)
End