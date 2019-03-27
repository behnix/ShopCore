DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Comments]') AND [c].[name] = N'Content');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Comments] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Comments] ALTER COLUMN [Content] nvarchar(2000) NULL;

GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Categories]') AND [c].[name] = N'Name');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Categories] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Categories] ALTER COLUMN [Name] nvarchar(50) NOT NULL;

GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Categories]') AND [c].[name] = N'EnName');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Categories] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [Categories] ALTER COLUMN [EnName] nvarchar(50) NOT NULL;

GO

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Brands]') AND [c].[name] = N'Name');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Brands] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [Brands] ALTER COLUMN [Name] nvarchar(100) NOT NULL;

GO

DECLARE @var4 sysname;
SELECT @var4 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Brands]') AND [c].[name] = N'EnName');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Brands] DROP CONSTRAINT [' + @var4 + '];');
ALTER TABLE [Brands] ALTER COLUMN [EnName] nvarchar(100) NOT NULL;

GO

CREATE TABLE [InvoiceDetails] (
    [Id] int NOT NULL IDENTITY,
    [InvoiceId] int NOT NULL,
    [Quantity] int NOT NULL,
    [Price] decimal(18, 2) NOT NULL,
    [ProductId] int NOT NULL,
    CONSTRAINT [PK_InvoiceDetails] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_InvoiceDetails_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([ProductId]) ON DELETE CASCADE
);

GO

CREATE TABLE [Invoices] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [FactoredOn] datetime2 NOT NULL,
    [UserId] nvarchar(max) NULL,
    [CostumerName] nvarchar(max) NULL,
    [CostumerEmail] nvarchar(max) NULL,
    [CostumerPhone] nvarchar(max) NULL,
    [CostumerAddress] nvarchar(max) NULL,
    [NationCode] nvarchar(max) NULL,
    [EconomyCode] nvarchar(max) NULL,
    [ZipCode] nvarchar(max) NULL,
    [IsOfficial] bit NOT NULL,
    [State] nvarchar(max) NULL,
    [StateCode] nvarchar(max) NULL,
    [RefNum] nvarchar(max) NULL,
    [CId] nvarchar(max) NULL,
    [TransactionNo] nvarchar(max) NULL,
    [SecurePan] nvarchar(max) NULL,
    [MessageSent] nvarchar(max) NULL,
    [Purchased] bit NOT NULL,
    [Transported] bit NOT NULL,
    CONSTRAINT [PK_Invoices] PRIMARY KEY ([Id])
);

GO

CREATE INDEX [IX_InvoiceDetails_ProductId] ON [InvoiceDetails] ([ProductId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190307083122_AddInvoicesTable', N'2.1.8-servicing-32085');

GO

ALTER TABLE [Invoices] ADD [SessionId] nvarchar(max) NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190307085431_AddSessionIdToInvoicesTable', N'2.1.8-servicing-32085');

GO

DECLARE @var5 sysname;
SELECT @var5 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Invoices]') AND [c].[name] = N'UserId');
IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [Invoices] DROP CONSTRAINT [' + @var5 + '];');
ALTER TABLE [Invoices] ALTER COLUMN [UserId] int NOT NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190308074555_ChangeTypeOfUserIdInUsersTable', N'2.1.8-servicing-32085');

GO

ALTER TABLE [Invoices] ADD [Amount] bigint NOT NULL DEFAULT CAST(0 AS bigint);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190308080652_AddAmountToInvoicesTable', N'2.1.8-servicing-32085');

GO

