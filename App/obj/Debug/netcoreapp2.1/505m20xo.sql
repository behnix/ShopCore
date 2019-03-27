IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Roles] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(256) NULL,
    [NormalizedName] nvarchar(256) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    [DisplayName] nvarchar(max) NULL,
    [CreatedOn] datetime2 NOT NULL,
    CONSTRAINT [PK_Roles] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Users] (
    [Id] int NOT NULL IDENTITY,
    [UserName] nvarchar(256) NULL,
    [NormalizedUserName] nvarchar(256) NULL,
    [Email] nvarchar(256) NULL,
    [NormalizedEmail] nvarchar(256) NULL,
    [EmailConfirmed] bit NOT NULL,
    [PasswordHash] nvarchar(max) NULL,
    [SecurityStamp] nvarchar(max) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    [PhoneNumber] nvarchar(max) NULL,
    [PhoneNumberConfirmed] bit NOT NULL,
    [TwoFactorEnabled] bit NOT NULL,
    [LockoutEnd] datetimeoffset NULL,
    [LockoutEnabled] bit NOT NULL,
    [AccessFailedCount] int NOT NULL,
    [FirstName] nvarchar(max) NULL,
    [LastName] nvarchar(max) NULL,
    [Age] int NOT NULL,
    [Gender] int NOT NULL,
    [RegisteredOn] datetime2 NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [RoleClaims] (
    [Id] int NOT NULL IDENTITY,
    [RoleId] int NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    [GivenOn] datetime2 NOT NULL,
    CONSTRAINT [PK_RoleClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_RoleClaims_Roles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Roles] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [UserClaims] (
    [Id] int NOT NULL IDENTITY,
    [UserId] int NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_UserClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_UserClaims_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [UserLogins] (
    [LoginProvider] nvarchar(450) NOT NULL,
    [ProviderKey] nvarchar(450) NOT NULL,
    [ProviderDisplayName] nvarchar(max) NULL,
    [UserId] int NOT NULL,
    [LoggedOn] datetime2 NOT NULL,
    CONSTRAINT [PK_UserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
    CONSTRAINT [FK_UserLogins_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [UserRoles] (
    [UserId] int NOT NULL,
    [RoleId] int NOT NULL,
    [GivenOn] datetime2 NOT NULL,
    CONSTRAINT [PK_UserRoles] PRIMARY KEY ([UserId], [RoleId]),
    CONSTRAINT [FK_UserRoles_Roles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Roles] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_UserRoles_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [UserTokens] (
    [UserId] int NOT NULL,
    [LoginProvider] nvarchar(450) NOT NULL,
    [Name] nvarchar(450) NOT NULL,
    [Value] nvarchar(max) NULL,
    [GeneratedOn] datetime2 NOT NULL,
    CONSTRAINT [PK_UserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
    CONSTRAINT [FK_UserTokens_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_RoleClaims_RoleId] ON [RoleClaims] ([RoleId]);

GO

CREATE UNIQUE INDEX [RoleNameIndex] ON [Roles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;

GO

CREATE INDEX [IX_UserClaims_UserId] ON [UserClaims] ([UserId]);

GO

CREATE INDEX [IX_UserLogins_UserId] ON [UserLogins] ([UserId]);

GO

CREATE INDEX [IX_UserRoles_RoleId] ON [UserRoles] ([RoleId]);

GO

CREATE INDEX [EmailIndex] ON [Users] ([NormalizedEmail]);

GO

CREATE UNIQUE INDEX [UserNameIndex] ON [Users] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190210165615_InitialDatabase', N'2.1.4-rtm-31024');

GO

CREATE TABLE [Faqs] (
    [FaqId] int NOT NULL IDENTITY,
    [FaqQuestion] nvarchar(500) NOT NULL,
    [FaqAnswer] nvarchar(max) NULL,
    [FaqIsPublished] bit NOT NULL,
    [FaqName] nvarchar(100) NOT NULL,
    [FaqEmail] nvarchar(100) NULL,
    [FaqLike] int NOT NULL,
    [FaqDateTime] datetime2 NOT NULL,
    CONSTRAINT [PK_Faqs] PRIMARY KEY ([FaqId])
);

GO

CREATE TABLE [Groups] (
    [GroupId] int NOT NULL IDENTITY,
    [GroupTitle] nvarchar(50) NOT NULL,
    CONSTRAINT [PK_Groups] PRIMARY KEY ([GroupId])
);

GO

CREATE TABLE [Pages] (
    [PageId] int NOT NULL IDENTITY,
    [PageTitle] nvarchar(max) NOT NULL,
    [PageTitleInBrowser] nvarchar(100) NOT NULL,
    [PageDescriptionForSearchEngines] nvarchar(150) NOT NULL,
    [PageContent] nvarchar(max) NULL,
    [PageCreateDate] datetime2 NOT NULL,
    [PageUpdateDate] datetime2 NULL,
    [PageVisit] int NOT NULL,
    [PageShortUrl] nvarchar(max) NULL,
    [RelatedPostGroup] int NOT NULL,
    [QuantityPostInPage] int NOT NULL,
    CONSTRAINT [PK_Pages] PRIMARY KEY ([PageId])
);

GO

CREATE TABLE [Settings] (
    [SettingId] int NOT NULL IDENTITY,
    [SiteName] nvarchar(120) NOT NULL,
    [SiteDescription] nvarchar(160) NOT NULL,
    [SiteTel] nvarchar(100) NULL,
    [SiteAddress] nvarchar(500) NULL,
    [SiteEmail] nvarchar(max) NOT NULL,
    [SiteEmailPassword] nvarchar(100) NULL,
    [SiteSmtp] nvarchar(100) NULL,
    [SiteSmsNumber] nvarchar(100) NULL,
    [SiteSmsSigniture] nvarchar(100) NULL,
    [SiteTelegramId] nvarchar(100) NULL,
    [SiteInstagramId] nvarchar(100) NULL,
    [SiteTwitterId] nvarchar(100) NULL,
    [SiteFacebookId] nvarchar(100) NULL,
    [SiteCopyRightText] nvarchar(300) NOT NULL,
    [AboutUs] nvarchar(max) NULL,
    [Index] nvarchar(max) NULL,
    [Slogan1] nvarchar(300) NOT NULL,
    [Slogan2] nvarchar(300) NOT NULL,
    [Service1] nvarchar(100) NOT NULL,
    [Service1Icon] nvarchar(max) NOT NULL,
    [Service1Description] nvarchar(300) NOT NULL,
    [Service2] nvarchar(100) NOT NULL,
    [Service2Icon] nvarchar(max) NOT NULL,
    [Service2Description] nvarchar(300) NOT NULL,
    [Service3] nvarchar(100) NOT NULL,
    [Service3Icon] nvarchar(max) NOT NULL,
    [Service3Description] nvarchar(300) NOT NULL,
    [Service4] nvarchar(100) NOT NULL,
    [Service4Icon] nvarchar(max) NOT NULL,
    [Service4Description] nvarchar(300) NOT NULL,
    [ContactTitle] nvarchar(120) NULL,
    [ContactDescription] nvarchar(160) NULL,
    [FaqTitle] nvarchar(120) NULL,
    [FaqDescription] nvarchar(160) NULL,
    [AboutUsTitle] nvarchar(120) NULL,
    [FaqText] nvarchar(max) NULL,
    [AboutUsDescription] nvarchar(160) NULL,
    [SiteNameInEnglish] nvarchar(max) NULL,
    [QuantityPostInIndex] int NOT NULL,
    [SmtpPort] int NOT NULL,
    CONSTRAINT [PK_Settings] PRIMARY KEY ([SettingId])
);

GO

CREATE TABLE [Tags] (
    [TagId] int NOT NULL IDENTITY,
    [TagTitle] nvarchar(100) NOT NULL,
    CONSTRAINT [PK_Tags] PRIMARY KEY ([TagId])
);

GO

CREATE TABLE [Posts] (
    [PostId] int NOT NULL IDENTITY,
    [GroupId] int NOT NULL,
    [PostTitle] nvarchar(150) NULL,
    [PostTitleInBrowser] nvarchar(65) NOT NULL,
    [PostDescription] nvarchar(500) NULL,
    [PostDescriptionForSearchEngines] nvarchar(155) NOT NULL,
    [PostContent] nvarchar(max) NULL,
    [PostCreationDate] datetime2 NOT NULL,
    [PostUpdateDate] datetime2 NULL,
    [PostVisit] int NOT NULL,
    [PostSource] nvarchar(300) NULL,
    [PostImage] nvarchar(200) NULL,
    [Author] int NOT NULL,
    [IsPublished] bit NOT NULL,
    [ShortUrl] nvarchar(max) NULL,
    CONSTRAINT [PK_Posts] PRIMARY KEY ([PostId]),
    CONSTRAINT [FK_Posts_Users_Author] FOREIGN KEY ([Author]) REFERENCES [Users] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Posts_Groups_GroupId] FOREIGN KEY ([GroupId]) REFERENCES [Groups] ([GroupId]) ON DELETE CASCADE
);

GO

CREATE TABLE [PostTags] (
    [PostTagId] int NOT NULL IDENTITY,
    [PostId] int NOT NULL,
    [TagId] int NOT NULL,
    CONSTRAINT [PK_PostTags] PRIMARY KEY ([PostTagId]),
    CONSTRAINT [FK_PostTags_Posts_PostId] FOREIGN KEY ([PostId]) REFERENCES [Posts] ([PostId]) ON DELETE CASCADE,
    CONSTRAINT [FK_PostTags_Tags_TagId] FOREIGN KEY ([TagId]) REFERENCES [Tags] ([TagId]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_Posts_Author] ON [Posts] ([Author]);

GO

CREATE INDEX [IX_Posts_GroupId] ON [Posts] ([GroupId]);

GO

CREATE INDEX [IX_PostTags_PostId] ON [PostTags] ([PostId]);

GO

CREATE INDEX [IX_PostTags_TagId] ON [PostTags] ([TagId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190216154110_AddBlogsTable', N'2.1.4-rtm-31024');

GO

ALTER TABLE [Users] ADD [UserAvatar] nvarchar(max) NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190218075252_AddUserAvatar', N'2.1.4-rtm-31024');

GO

ALTER TABLE [Settings] ADD [ContactWorkHour] nvarchar(100) NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190218090118_AddContactWorkHour', N'2.1.4-rtm-31024');

GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Settings]') AND [c].[name] = N'SiteName');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Settings] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Settings] ALTER COLUMN [SiteName] nvarchar(65) NOT NULL;

GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Settings]') AND [c].[name] = N'SiteDescription');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Settings] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Settings] ALTER COLUMN [SiteDescription] nvarchar(155) NOT NULL;

GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Settings]') AND [c].[name] = N'FaqTitle');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Settings] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [Settings] ALTER COLUMN [FaqTitle] nvarchar(65) NULL;

GO

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Settings]') AND [c].[name] = N'FaqDescription');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Settings] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [Settings] ALTER COLUMN [FaqDescription] nvarchar(155) NULL;

GO

DECLARE @var4 sysname;
SELECT @var4 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Settings]') AND [c].[name] = N'ContactTitle');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Settings] DROP CONSTRAINT [' + @var4 + '];');
ALTER TABLE [Settings] ALTER COLUMN [ContactTitle] nvarchar(65) NULL;

GO

DECLARE @var5 sysname;
SELECT @var5 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Settings]') AND [c].[name] = N'ContactDescription');
IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [Settings] DROP CONSTRAINT [' + @var5 + '];');
ALTER TABLE [Settings] ALTER COLUMN [ContactDescription] nvarchar(155) NULL;

GO

DECLARE @var6 sysname;
SELECT @var6 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Settings]') AND [c].[name] = N'AboutUsTitle');
IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [Settings] DROP CONSTRAINT [' + @var6 + '];');
ALTER TABLE [Settings] ALTER COLUMN [AboutUsTitle] nvarchar(65) NULL;

GO

DECLARE @var7 sysname;
SELECT @var7 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Settings]') AND [c].[name] = N'AboutUsDescription');
IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [Settings] DROP CONSTRAINT [' + @var7 + '];');
ALTER TABLE [Settings] ALTER COLUMN [AboutUsDescription] nvarchar(155) NULL;

GO

ALTER TABLE [Settings] ADD [Terms] nvarchar(max) NULL;

GO

ALTER TABLE [Settings] ADD [TermsDescription] nvarchar(155) NULL;

GO

ALTER TABLE [Settings] ADD [TermsTitle] nvarchar(65) NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190218185256_addTermsInSettingsTable', N'2.1.4-rtm-31024');

GO

ALTER TABLE [Users] ADD [GeneratedKey] nvarchar(max) NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190219164725_GeneratedKeyInUsersTable', N'2.1.4-rtm-31024');

GO

CREATE TABLE [Brands] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [EnName] nvarchar(max) NULL,
    [Logo] nvarchar(max) NULL,
    CONSTRAINT [PK_Brands] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Categories] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [EnName] nvarchar(max) NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Comments] (
    [Id] int NOT NULL IDENTITY,
    [ProductId] int NOT NULL,
    [UserId] int NOT NULL,
    [Content] nvarchar(max) NULL,
    [CommentedOn] datetime2 NOT NULL,
    [IsConfirmed] bit NOT NULL,
    CONSTRAINT [PK_Comments] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Comments_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [ConfigGroups] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [Title] nvarchar(max) NULL,
    [Order] int NOT NULL,
    [CategoryId] int NOT NULL,
    CONSTRAINT [PK_ConfigGroups] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Products] (
    [ProductId] int NOT NULL IDENTITY,
    [Title] nvarchar(max) NOT NULL,
    [MetaTitle] nvarchar(max) NOT NULL,
    [MetaDescription] nvarchar(max) NOT NULL,
    [Model] nvarchar(max) NULL,
    [Guarantee] nvarchar(max) NULL,
    [Status] nvarchar(max) NULL,
    [Visit] int NOT NULL,
    [Like] int NOT NULL,
    [CommentOn] bit NOT NULL,
    [Published] bit NOT NULL,
    [DateTime] datetime2 NOT NULL,
    [Price] bigint NOT NULL,
    [PricePromotion] bigint NOT NULL,
    [PriceCoworker] bigint NOT NULL,
    [PriceCoworkerPromotion] bigint NOT NULL,
    [TempPrice] bigint NOT NULL,
    [TempPriceCoworker] bigint NOT NULL,
    [BrandId] int NOT NULL,
    [CategoryId] int NOT NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY ([ProductId]),
    CONSTRAINT [FK_Products_Brands_BrandId] FOREIGN KEY ([BrandId]) REFERENCES [Brands] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Products_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Categories] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [ConfigCharts] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [Title] nvarchar(max) NULL,
    [Order] int NOT NULL,
    [CategoryId] int NOT NULL,
    [ConfigGroupId] int NOT NULL,
    [FilterType] nvarchar(max) NULL,
    [ConfigDescription] nvarchar(max) NULL,
    [ConfigDescriptionComplete] nvarchar(max) NULL,
    CONSTRAINT [PK_ConfigCharts] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ConfigCharts_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Categories] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ConfigCharts_ConfigGroups_ConfigGroupId] FOREIGN KEY ([ConfigGroupId]) REFERENCES [ConfigGroups] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Images] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [Type] nvarchar(max) NULL,
    [ProductId] int NOT NULL,
    [ImageOrder] int NOT NULL,
    CONSTRAINT [PK_Images] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Images_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([ProductId]) ON DELETE CASCADE
);

GO

CREATE TABLE [ConfigDetails] (
    [Id] int NOT NULL IDENTITY,
    [ProductId] int NULL,
    [ConfigChartId] int NOT NULL,
    [Value] nvarchar(max) NULL,
    [ConfigGroupId] int NOT NULL,
    CONSTRAINT [PK_ConfigDetails] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ConfigDetails_ConfigCharts_ConfigChartId] FOREIGN KEY ([ConfigChartId]) REFERENCES [ConfigCharts] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ConfigDetails_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([ProductId]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_Comments_UserId] ON [Comments] ([UserId]);

GO

CREATE INDEX [IX_ConfigCharts_CategoryId] ON [ConfigCharts] ([CategoryId]);

GO

CREATE INDEX [IX_ConfigCharts_ConfigGroupId] ON [ConfigCharts] ([ConfigGroupId]);

GO

CREATE INDEX [IX_ConfigDetails_ConfigChartId] ON [ConfigDetails] ([ConfigChartId]);

GO

CREATE INDEX [IX_ConfigDetails_ProductId] ON [ConfigDetails] ([ProductId]);

GO

CREATE UNIQUE INDEX [IX_Images_ProductId] ON [Images] ([ProductId]);

GO

CREATE INDEX [IX_Products_BrandId] ON [Products] ([BrandId]);

GO

CREATE INDEX [IX_Products_CategoryId] ON [Products] ([CategoryId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190220131029_AddProductsRelatedTables', N'2.1.4-rtm-31024');

GO

ALTER TABLE [Products] ADD [Sales] int NOT NULL DEFAULT 0;

GO

ALTER TABLE [Products] ADD [ShortUrl] nvarchar(max) NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190221051508_AddProductsShortUrlProp', N'2.1.4-rtm-31024');

GO

ALTER TABLE [Images] DROP CONSTRAINT [FK_Images_Products_ProductId];

GO

DROP INDEX [IX_Images_ProductId] ON [Images];

GO

DECLARE @var8 sysname;
SELECT @var8 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Products]') AND [c].[name] = N'PriceCoworkerPromotion');
IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [Products] DROP CONSTRAINT [' + @var8 + '];');
ALTER TABLE [Products] DROP COLUMN [PriceCoworkerPromotion];

GO

DECLARE @var9 sysname;
SELECT @var9 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Products]') AND [c].[name] = N'TempPrice');
IF @var9 IS NOT NULL EXEC(N'ALTER TABLE [Products] DROP CONSTRAINT [' + @var9 + '];');
ALTER TABLE [Products] DROP COLUMN [TempPrice];

GO

DECLARE @var10 sysname;
SELECT @var10 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Products]') AND [c].[name] = N'TempPriceCoworker');
IF @var10 IS NOT NULL EXEC(N'ALTER TABLE [Products] DROP CONSTRAINT [' + @var10 + '];');
ALTER TABLE [Products] DROP COLUMN [TempPriceCoworker];

GO

EXEC sp_rename N'[Products].[DateTime]', N'CreatedOn', N'COLUMN';

GO

DECLARE @var11 sysname;
SELECT @var11 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Products]') AND [c].[name] = N'Title');
IF @var11 IS NOT NULL EXEC(N'ALTER TABLE [Products] DROP CONSTRAINT [' + @var11 + '];');
ALTER TABLE [Products] ALTER COLUMN [Title] nvarchar(100) NOT NULL;

GO

DECLARE @var12 sysname;
SELECT @var12 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Products]') AND [c].[name] = N'MetaTitle');
IF @var12 IS NOT NULL EXEC(N'ALTER TABLE [Products] DROP CONSTRAINT [' + @var12 + '];');
ALTER TABLE [Products] ALTER COLUMN [MetaTitle] nvarchar(65) NOT NULL;

GO

DECLARE @var13 sysname;
SELECT @var13 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Products]') AND [c].[name] = N'MetaDescription');
IF @var13 IS NOT NULL EXEC(N'ALTER TABLE [Products] DROP CONSTRAINT [' + @var13 + '];');
ALTER TABLE [Products] ALTER COLUMN [MetaDescription] nvarchar(155) NOT NULL;

GO

ALTER TABLE [Products] ADD [Description] nvarchar(1000) NOT NULL DEFAULT N'';

GO

ALTER TABLE [Products] ADD [Image] nvarchar(max) NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190221102557_AddImageAndDescriptionForProducsTable', N'2.1.4-rtm-31024');

GO

DECLARE @var14 sysname;
SELECT @var14 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Products]') AND [c].[name] = N'Status');
IF @var14 IS NOT NULL EXEC(N'ALTER TABLE [Products] DROP CONSTRAINT [' + @var14 + '];');
ALTER TABLE [Products] ALTER COLUMN [Status] int NOT NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190221125255_ChangeStatusPropToEnum', N'2.1.4-rtm-31024');

GO

DECLARE @var15 sysname;
SELECT @var15 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Products]') AND [c].[name] = N'Status');
IF @var15 IS NOT NULL EXEC(N'ALTER TABLE [Products] DROP CONSTRAINT [' + @var15 + '];');
ALTER TABLE [Products] ALTER COLUMN [Status] bit NOT NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190221133916_ChangeStatusPropToBool', N'2.1.4-rtm-31024');

GO

ALTER TABLE [ConfigDetails] DROP CONSTRAINT [FK_ConfigDetails_Products_ProductId];

GO

DROP INDEX [IX_ConfigDetails_ProductId] ON [ConfigDetails];

GO

DECLARE @var16 sysname;
SELECT @var16 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ConfigDetails]') AND [c].[name] = N'ProductId');
IF @var16 IS NOT NULL EXEC(N'ALTER TABLE [ConfigDetails] DROP CONSTRAINT [' + @var16 + '];');
ALTER TABLE [ConfigDetails] ALTER COLUMN [ProductId] int NOT NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190223162824_AddProductIdPropToConfigDetailsTable', N'2.1.4-rtm-31024');

GO

DECLARE @var17 sysname;
SELECT @var17 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ConfigDetails]') AND [c].[name] = N'ProductId');
IF @var17 IS NOT NULL EXEC(N'ALTER TABLE [ConfigDetails] DROP CONSTRAINT [' + @var17 + '];');
ALTER TABLE [ConfigDetails] ALTER COLUMN [ProductId] int NULL;

GO

CREATE INDEX [IX_ConfigDetails_ProductId] ON [ConfigDetails] ([ProductId]);

GO

ALTER TABLE [ConfigDetails] ADD CONSTRAINT [FK_ConfigDetails_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([ProductId]) ON DELETE NO ACTION;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190223163152_RemoveProductIdPropToConfigDetailsTable', N'2.1.4-rtm-31024');

GO

ALTER TABLE [ConfigDetails] DROP CONSTRAINT [FK_ConfigDetails_Products_ProductId];

GO

DROP INDEX [IX_ConfigDetails_ProductId] ON [ConfigDetails];

GO

DECLARE @var18 sysname;
SELECT @var18 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ConfigDetails]') AND [c].[name] = N'ProductId');
IF @var18 IS NOT NULL EXEC(N'ALTER TABLE [ConfigDetails] DROP CONSTRAINT [' + @var18 + '];');
ALTER TABLE [ConfigDetails] ALTER COLUMN [ProductId] int NOT NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190223230041_RemoveProductAndAddProductIdToConfigDetailsTable', N'2.1.4-rtm-31024');

GO

ALTER TABLE [Categories] ADD [CategoryImage] nvarchar(max) NULL;

GO

ALTER TABLE [Categories] ADD [ParentId] int NOT NULL DEFAULT 0;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190224073835_AddParentIdAndCategoryImagePropToCategoriesTable', N'2.1.4-rtm-31024');

GO

