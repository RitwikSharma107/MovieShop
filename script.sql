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

CREATE TABLE [Genres] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(24) NOT NULL,
    CONSTRAINT [PK_Genres] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240718065452_InitialMigration', N'8.0.7');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240718065739_DbMigration', N'8.0.7');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Casts] (
    [Id] int NOT NULL IDENTITY,
    [Gender] nvarchar(MAX) NOT NULL,
    [Name] nvarchar(128) NOT NULL,
    [ProfilePath] nvarchar(2084) NOT NULL,
    [TmdbUrl] nvarchar(MAX) NOT NULL,
    CONSTRAINT [PK_Casts] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Movies] (
    [Id] int NOT NULL IDENTITY,
    [BackdropUrl] nvarchar(2084) NULL,
    [Budget] decimal(18,2) NOT NULL,
    [CreatedBy] nvarchar(MAX) NULL,
    [CreatedDate] datetime2 NOT NULL,
    [ImdbUrl] nvarchar(2084) NULL,
    [OriginalLanguage] nvarchar(64) NULL,
    [Overview] nvarchar(MAX) NULL,
    [PostedUrl] nvarchar(2084) NULL,
    [Price] decimal(18,2) NOT NULL,
    [ReleaseDate] datetime2 NOT NULL,
    [Revenue] decimal(18,2) NOT NULL,
    [RunTime] int NOT NULL,
    [Tagline] nvarchar(512) NULL,
    [Title] nvarchar(256) NULL,
    [TmdbUrl] nvarchar(2084) NULL,
    [UpdatedBy] nvarchar(MAX) NULL,
    [UpdatedDate] datetime2 NOT NULL,
    CONSTRAINT [PK_Movies] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Roles] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(20) NOT NULL,
    CONSTRAINT [PK_Roles] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Users] (
    [Id] int NOT NULL IDENTITY,
    [DateOfBirth] datetime2 NOT NULL,
    [Email] nvarchar(256) NOT NULL,
    [FirstName] nvarchar(128) NOT NULL,
    [HashedPassword] nvarchar(1024) NOT NULL,
    [IsLocked] bit NOT NULL,
    [Lastname] nvarchar(128) NOT NULL,
    [PhoneNumber] nvarchar(16) NULL,
    [ProfilePictureUrl] nvarchar(MAX) NULL,
    [Salt] nvarchar(1024) NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [MovieCasts] (
    [CastId] int NOT NULL,
    [Character] nvarchar(450) NOT NULL,
    [MovieId] int NOT NULL,
    CONSTRAINT [FK_MovieCasts_Casts_CastId] FOREIGN KEY ([CastId]) REFERENCES [Casts] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_MovieCasts_Movies_MovieId] FOREIGN KEY ([MovieId]) REFERENCES [Movies] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [MovieGenres] (
    [GenresId] int NOT NULL,
    [MoviesId] int NOT NULL,
    CONSTRAINT [FK_MovieGenres_Genres_GenresId] FOREIGN KEY ([GenresId]) REFERENCES [Genres] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_MovieGenres_Movies_MoviesId] FOREIGN KEY ([MoviesId]) REFERENCES [Movies] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Trailers] (
    [Id] int NOT NULL IDENTITY,
    [MovieId] int NOT NULL,
    [Name] nvarchar(2084) NOT NULL,
    [TrailerUrl] nvarchar(2084) NOT NULL,
    CONSTRAINT [PK_Trailers] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Trailers_Movies_MovieId] FOREIGN KEY ([MovieId]) REFERENCES [Movies] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Favorites] (
    [MovieId] int NOT NULL,
    [UserId] int NOT NULL,
    CONSTRAINT [FK_Favorites_Movies_MovieId] FOREIGN KEY ([MovieId]) REFERENCES [Movies] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Favorites_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Purchases] (
    [MovieId] int NOT NULL,
    [UserId] int NOT NULL,
    [PurchaseDateTime] datetime2 NOT NULL,
    [PurchaseNumber] uniqueidentifier NOT NULL,
    [TotalPrice] decimal(18,2) NOT NULL,
    CONSTRAINT [FK_Purchases_Movies_MovieId] FOREIGN KEY ([MovieId]) REFERENCES [Movies] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Purchases_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Reviews] (
    [MovieId] int NOT NULL,
    [UserId] int NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [Rating] decimal(3,2) NOT NULL,
    [ReviewText] nvarchar(MAX) NOT NULL,
    CONSTRAINT [FK_Reviews_Movies_MovieId] FOREIGN KEY ([MovieId]) REFERENCES [Movies] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Reviews_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [UserRoles] (
    [RoleId] int NOT NULL,
    [UserId] int NOT NULL,
    CONSTRAINT [FK_UserRoles_Roles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Roles] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_UserRoles_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Favorites_MovieId] ON [Favorites] ([MovieId]);
GO

CREATE INDEX [IX_Favorites_UserId] ON [Favorites] ([UserId]);
GO

CREATE INDEX [IX_MovieCasts_CastId] ON [MovieCasts] ([CastId]);
GO

CREATE INDEX [IX_MovieCasts_MovieId] ON [MovieCasts] ([MovieId]);
GO

CREATE INDEX [IX_MovieGenres_GenresId] ON [MovieGenres] ([GenresId]);
GO

CREATE INDEX [IX_MovieGenres_MoviesId] ON [MovieGenres] ([MoviesId]);
GO

CREATE INDEX [IX_Purchases_MovieId] ON [Purchases] ([MovieId]);
GO

CREATE INDEX [IX_Purchases_UserId] ON [Purchases] ([UserId]);
GO

CREATE INDEX [IX_Reviews_MovieId] ON [Reviews] ([MovieId]);
GO

CREATE INDEX [IX_Reviews_UserId] ON [Reviews] ([UserId]);
GO

CREATE INDEX [IX_Trailers_MovieId] ON [Trailers] ([MovieId]);
GO

CREATE INDEX [IX_UserRoles_RoleId] ON [UserRoles] ([RoleId]);
GO

CREATE INDEX [IX_UserRoles_UserId] ON [UserRoles] ([UserId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240718074509_TableMigration', N'8.0.7');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [MovieGenres] DROP CONSTRAINT [FK_MovieGenres_Genres_GenresId];
GO

ALTER TABLE [MovieGenres] DROP CONSTRAINT [FK_MovieGenres_Movies_MoviesId];
GO

EXEC sp_rename N'[Movies].[PostedUrl]', N'PosterUrl', N'COLUMN';
GO

EXEC sp_rename N'[MovieGenres].[MoviesId]', N'MovieId', N'COLUMN';
GO

EXEC sp_rename N'[MovieGenres].[GenresId]', N'GenreId', N'COLUMN';
GO

EXEC sp_rename N'[MovieGenres].[IX_MovieGenres_MoviesId]', N'IX_MovieGenres_MovieId', N'INDEX';
GO

EXEC sp_rename N'[MovieGenres].[IX_MovieGenres_GenresId]', N'IX_MovieGenres_GenreId', N'INDEX';
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Movies]') AND [c].[name] = N'UpdatedDate');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Movies] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Movies] ALTER COLUMN [UpdatedDate] datetime2 NULL;
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Movies]') AND [c].[name] = N'RunTime');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Movies] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Movies] ALTER COLUMN [RunTime] int NULL;
GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Movies]') AND [c].[name] = N'Revenue');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Movies] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [Movies] ALTER COLUMN [Revenue] decimal(18,2) NULL;
GO

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Movies]') AND [c].[name] = N'ReleaseDate');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Movies] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [Movies] ALTER COLUMN [ReleaseDate] datetime2 NULL;
GO

DECLARE @var4 sysname;
SELECT @var4 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Movies]') AND [c].[name] = N'Price');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Movies] DROP CONSTRAINT [' + @var4 + '];');
ALTER TABLE [Movies] ALTER COLUMN [Price] decimal(5,2) NULL;
GO

DECLARE @var5 sysname;
SELECT @var5 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Movies]') AND [c].[name] = N'CreatedDate');
IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [Movies] DROP CONSTRAINT [' + @var5 + '];');
ALTER TABLE [Movies] ALTER COLUMN [CreatedDate] datetime2 NULL;
GO

DECLARE @var6 sysname;
SELECT @var6 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Movies]') AND [c].[name] = N'Budget');
IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [Movies] DROP CONSTRAINT [' + @var6 + '];');
ALTER TABLE [Movies] ALTER COLUMN [Budget] decimal(18,2) NULL;
GO

ALTER TABLE [MovieGenres] ADD CONSTRAINT [FK_MovieGenres_Genres_GenreId] FOREIGN KEY ([GenreId]) REFERENCES [Genres] ([Id]) ON DELETE CASCADE;
GO

ALTER TABLE [MovieGenres] ADD CONSTRAINT [FK_MovieGenres_Movies_MovieId] FOREIGN KEY ([MovieId]) REFERENCES [Movies] ([Id]) ON DELETE CASCADE;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240718082140_TableMigration_Edit', N'8.0.7');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DROP INDEX [IX_MovieCasts_MovieId] ON [MovieCasts];
GO

ALTER TABLE [MovieCasts] ADD CONSTRAINT [PK_MovieCasts] PRIMARY KEY ([MovieId], [CastId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240720202248_MovieCastMigration', N'8.0.7');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DROP INDEX [IX_MovieGenres_MovieId] ON [MovieGenres];
GO

ALTER TABLE [MovieGenres] ADD CONSTRAINT [PK_MovieGenres] PRIMARY KEY ([MovieId], [GenreId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240722044448_MovieGenreMigration', N'8.0.7');
GO

COMMIT;
GO

