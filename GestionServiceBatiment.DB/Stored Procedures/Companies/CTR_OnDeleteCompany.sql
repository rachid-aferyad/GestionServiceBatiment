CREATE Trigger [dbo].[CTR_OnDeleteCompany]
	On [dbo].[Company]
Instead Of Delete
As
Begin
	Delete from [dbo].[Comment]
		where [CompanyId] in (select [Id] from deleted)
End