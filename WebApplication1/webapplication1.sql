IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231215061153_Owner', N'7.0.14');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231215063713_AddOwnerAndCarTables', N'7.0.14');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DROP TABLE [AspNetRoleClaims];
GO

DROP TABLE [AspNetUserClaims];
GO

DROP TABLE [AspNetUserLogins];
GO

DROP TABLE [AspNetUserRoles];
GO

DROP TABLE [AspNetUserTokens];
GO

DROP TABLE [AspNetRoles];
GO

DROP TABLE [AspNetUsers];
GO

CREATE TABLE [Cars] (
    [CarId] int NOT NULL IDENTITY,
    [CarName] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Cars] PRIMARY KEY ([CarId])
);
GO

CREATE TABLE [Owners] (
    [OwnerId] int NOT NULL IDENTITY,
    [OwnerName] nvarchar(max) NOT NULL,
    [Car] nvarchar(max) NOT NULL,
    [DateOfPurchase] datetime2 NOT NULL,
    CONSTRAINT [PK_Owners] PRIMARY KEY ([OwnerId])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231215091804_AddCar', N'7.0.14');
GO

COMMIT;
GO

