ALTER TABLE [Settings] ADD [MerchantId] nvarchar(50) NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190312200630_AddMerchantIdToSettingsTable', N'2.1.8-servicing-32085');

GO

