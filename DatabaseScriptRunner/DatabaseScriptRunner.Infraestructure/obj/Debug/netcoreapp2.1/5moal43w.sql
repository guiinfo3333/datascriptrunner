IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Databases] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [ConnectionString] nvarchar(max) NULL,
    CONSTRAINT [PK_Databases] PRIMARY KEY ([Id])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20191003180326_Data.DatabaseContext', N'2.1.11-servicing-32099');

GO

