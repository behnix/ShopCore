CREATE TABLE [Sliders] (
    [SliderId] int NOT NULL IDENTITY,
    [SliderName] nvarchar(100) NOT NULL,
    [SliderImage] nvarchar(200) NOT NULL,
    [SliderTitle1] nvarchar(50) NULL,
    [SliderTitle2] nvarchar(50) NULL,
    [SliderTitle3] nvarchar(50) NULL,
    [SliderButtonText] nvarchar(50) NULL,
    [SliderButtonLink] nvarchar(200) NULL,
    [SliderType] tinyint NOT NULL,
    [SliderStartTime] datetime2 NOT NULL,
    [SliderEndTime] datetime2 NOT NULL,
    [IsActive] bit NOT NULL,
    CONSTRAINT [PK_Sliders] PRIMARY KEY ([SliderId])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190312091629_AddSlidersTable', N'2.1.8-servicing-32085');

GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Sliders]') AND [c].[name] = N'SliderImage');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Sliders] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Sliders] ALTER COLUMN [SliderImage] nvarchar(max) NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190312135645_RemoveSliderImageRequired', N'2.1.8-servicing-32085');

GO

