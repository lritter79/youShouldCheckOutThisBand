IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Albums] (
    [SpotifyId] nvarchar(450) NOT NULL,
    [AlbumType] nvarchar(max) NULL,
    [Href] nvarchar(max) NULL,
    [Label] nvarchar(max) NULL,
    [Name] nvarchar(max) NULL,
    [ReleaseDate] nvarchar(max) NULL,
    [ReleaseDatePrecision] nvarchar(max) NULL,
    [Uri] nvarchar(max) NULL,
    CONSTRAINT [PK_Albums] PRIMARY KEY ([SpotifyId])
);

GO

CREATE TABLE [Artists] (
    [SpotifyId] nvarchar(450) NOT NULL,
    [Name] nvarchar(max) NULL,
    [Uri] nvarchar(max) NULL,
    CONSTRAINT [PK_Artists] PRIMARY KEY ([SpotifyId])
);

GO

CREATE TABLE [Genres] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_Genres] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [AlbumCovers] (
    [Id] int NOT NULL IDENTITY,
    [Height] int NOT NULL,
    [Width] int NOT NULL,
    [Url] nvarchar(max) NULL,
    [AlbumSpotifyId] nvarchar(450) NULL,
    CONSTRAINT [PK_AlbumCovers] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AlbumCovers_Albums_AlbumSpotifyId] FOREIGN KEY ([AlbumSpotifyId]) REFERENCES [Albums] ([SpotifyId]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Tracks] (
    [SpotifyId] nvarchar(450) NOT NULL,
    [AlbumSpotifyId] nvarchar(450) NULL,
    [Href] nvarchar(max) NULL,
    [PreviewUrl] nvarchar(max) NULL,
    [Uri] nvarchar(max) NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_Tracks] PRIMARY KEY ([SpotifyId]),
    CONSTRAINT [FK_Tracks_Albums_AlbumSpotifyId] FOREIGN KEY ([AlbumSpotifyId]) REFERENCES [Albums] ([SpotifyId]) ON DELETE NO ACTION
);

GO

CREATE TABLE [ArtistAlbumJoinEntity] (
    [ArtistSpotifyId] nvarchar(450) NOT NULL,
    [AlbumSpotifyId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_ArtistAlbumJoinEntity] PRIMARY KEY ([ArtistSpotifyId], [AlbumSpotifyId]),
    CONSTRAINT [FK_ArtistAlbumJoinEntity_Albums_AlbumSpotifyId] FOREIGN KEY ([AlbumSpotifyId]) REFERENCES [Albums] ([SpotifyId]) ON DELETE CASCADE,
    CONSTRAINT [FK_ArtistAlbumJoinEntity_Artists_ArtistSpotifyId] FOREIGN KEY ([ArtistSpotifyId]) REFERENCES [Artists] ([SpotifyId]) ON DELETE CASCADE
);

GO

CREATE TABLE [ArtistImages] (
    [Id] int NOT NULL IDENTITY,
    [Height] int NOT NULL,
    [Width] int NOT NULL,
    [Url] nvarchar(max) NULL,
    [ArtistSpotifyId] nvarchar(450) NULL,
    CONSTRAINT [PK_ArtistImages] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ArtistImages_Artists_ArtistSpotifyId] FOREIGN KEY ([ArtistSpotifyId]) REFERENCES [Artists] ([SpotifyId]) ON DELETE NO ACTION
);

GO

CREATE TABLE [GenreAlbumJoinEntity] (
    [GenreId] int NOT NULL,
    [AlbumSpotifyId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_GenreAlbumJoinEntity] PRIMARY KEY ([AlbumSpotifyId], [GenreId]),
    CONSTRAINT [FK_GenreAlbumJoinEntity_Albums_AlbumSpotifyId] FOREIGN KEY ([AlbumSpotifyId]) REFERENCES [Albums] ([SpotifyId]) ON DELETE CASCADE,
    CONSTRAINT [FK_GenreAlbumJoinEntity_Genres_GenreId] FOREIGN KEY ([GenreId]) REFERENCES [Genres] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [GenreArtistJoinEntity] (
    [GenreId] int NOT NULL,
    [ArtistSpotifyId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_GenreArtistJoinEntity] PRIMARY KEY ([ArtistSpotifyId], [GenreId]),
    CONSTRAINT [FK_GenreArtistJoinEntity_Artists_ArtistSpotifyId] FOREIGN KEY ([ArtistSpotifyId]) REFERENCES [Artists] ([SpotifyId]) ON DELETE CASCADE,
    CONSTRAINT [FK_GenreArtistJoinEntity_Genres_GenreId] FOREIGN KEY ([GenreId]) REFERENCES [Genres] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [TrackArtistJoinEntity] (
    [ArtistSpotifyId] nvarchar(450) NOT NULL,
    [TrackSpotifyId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_TrackArtistJoinEntity] PRIMARY KEY ([ArtistSpotifyId], [TrackSpotifyId]),
    CONSTRAINT [FK_TrackArtistJoinEntity_Artists_ArtistSpotifyId] FOREIGN KEY ([ArtistSpotifyId]) REFERENCES [Artists] ([SpotifyId]) ON DELETE CASCADE,
    CONSTRAINT [FK_TrackArtistJoinEntity_Tracks_TrackSpotifyId] FOREIGN KEY ([TrackSpotifyId]) REFERENCES [Tracks] ([SpotifyId]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_AlbumCovers_AlbumSpotifyId] ON [AlbumCovers] ([AlbumSpotifyId]);

GO

CREATE INDEX [IX_ArtistAlbumJoinEntity_AlbumSpotifyId] ON [ArtistAlbumJoinEntity] ([AlbumSpotifyId]);

GO

CREATE INDEX [IX_ArtistImages_ArtistSpotifyId] ON [ArtistImages] ([ArtistSpotifyId]);

GO

CREATE INDEX [IX_GenreAlbumJoinEntity_GenreId] ON [GenreAlbumJoinEntity] ([GenreId]);

GO

CREATE INDEX [IX_GenreArtistJoinEntity_GenreId] ON [GenreArtistJoinEntity] ([GenreId]);

GO

CREATE INDEX [IX_TrackArtistJoinEntity_TrackSpotifyId] ON [TrackArtistJoinEntity] ([TrackSpotifyId]);

GO

CREATE INDEX [IX_Tracks_AlbumSpotifyId] ON [Tracks] ([AlbumSpotifyId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200419191932_first migration', N'3.1.3');

GO

