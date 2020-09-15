CREATE Trigger [dbo].[CTR_OnDeleteRequest]
	On [dbo].[Request]
After Delete
As
Begin
	Delete from [dbo].[Comment]
		where [RequestId] in (select [Id] from deleted)
End