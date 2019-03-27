ALTER TABLE [Settings] ADD [Logo] nvarchar(50) NULL;

GO

ALTER TABLE [Settings] ADD [Style] nvarchar(50) NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190319160047_AddLogoAndStylePropInSettingsTable', N'2.1.8-servicing-32085');

GO

