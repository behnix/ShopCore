ALTER TABLE [Users] ADD [Address] nvarchar(max) NULL;

GO

ALTER TABLE [Users] ADD [CellPhone] nvarchar(max) NULL;

GO

ALTER TABLE [Users] ADD [ZipCode] nvarchar(max) NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190309094339_AddAddressZipCodeCellPhoneToUsersTable', N'2.1.8-servicing-32085');

GO

