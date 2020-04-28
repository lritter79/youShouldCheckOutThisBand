SELECT TOP(1) [a].[Id], [a].[AccessFailedCount], [a].[ConcurrencyStamp], [a].[Email], [a].[EmailConfirmed], [a].[FirstName], [a].[LastName], [a].[LockoutEnabled], [a].[LockoutEnd], [a].[NormalizedEmail], [a].[NormalizedUserName], [a].[PasswordHash], [a].[PhoneNumber], [a].[PhoneNumberConfirmed], [a].[SecurityStamp], [a].[TwoFactorEnabled], [a].[UserName]
      FROM [AspNetUsers] AS [a]
      WHERE [a].[NormalizedUserName] = @__normalizedUserName_0
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (3ms) [Parameters=[@__user_Id_0='?' (Size = 450)], CommandType='Text', CommandTimeout='30']
      SELECT [a].[Id], [a].[ClaimType], [a].[ClaimValue], [a].[UserId]
      FROM [AspNetUserClaims] AS [a]
      WHERE [a].[UserId] = @__user_Id_0
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (4ms) [Parameters=[@__userId_0='?' (Size = 450)], CommandType='Text', CommandTimeout='30']
      SELECT [a0].[Name]
      FROM [AspNetUserRoles] AS [a]
      INNER JOIN [AspNetRoles] AS [a0] ON [a].[RoleId] = [a0].[Id]
      WHERE [a].[UserId] = @__userId_0
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (2ms) [Parameters=[@__normalizedUserName_0='?' (Size = 256)], CommandType='Text', CommandTimeout='30']
      SELECT TOP(1) [a].[Id], [a].[AccessFailedCount], [a].[ConcurrencyStamp], [a].[Email], [a].[EmailConfirmed], [a].[FirstName], [a].[LastName], [a].[LockoutEnabled], [a].[LockoutEnd], [a].[NormalizedEmail], [a].[NormalizedUserName], [a].[PasswordHash], [a].[PhoneNumber], [a].[PhoneNumberConfirmed], [a].[SecurityStamp], [a].[TwoFactorEnabled], [a].[UserName]
      FROM [AspNetUsers] AS [a]
      WHERE [a].[NormalizedUserName] = @__normalizedUserName_0
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (2ms) [Parameters=[@__recommendation_Track_Uri_0='?' (Size = 450)], CommandType='Text', CommandTimeout='30']
      SELECT CASE
          WHEN EXISTS (
              SELECT 1
              FROM [Tracks] AS [t]
              WHERE [t].[Uri] = @__recommendation_Track_Uri_0) THEN CAST(1 AS bit)
          ELSE CAST(0 AS bit)
      END
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (2ms) [Parameters=[@__recommendation_Track_Album_Uri_0='?' (Size = 450)], CommandType='Text', CommandTimeout='30']
      SELECT CASE
          WHEN EXISTS (
              SELECT 1
              FROM [Albums] AS [a]
              WHERE [a].[Uri] = @__recommendation_Track_Album_Uri_0) THEN CAST(1 AS bit)
          ELSE CAST(0 AS bit)
      END
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (1ms) [Parameters=[@__artistJoinEntity_Artist_Uri_0='?' (Size = 450)], CommandType='Text', CommandTimeout='30']
      SELECT CASE
          WHEN EXISTS (
              SELECT 1
              FROM [Artists] AS [a]
              WHERE [a].[Uri] = @__artistJoinEntity_Artist_Uri_0) THEN CAST(1 AS bit)
          ELSE CAST(0 AS bit)
      END
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (1ms) [Parameters=[@__artistJoinEntity_Track_Uri_0='?' (Size = 450)], CommandType='Text', CommandTimeout='30']
      SELECT CASE
          WHEN EXISTS (
              SELECT 1
              FROM [Tracks] AS [t]
              WHERE [t].[Uri] = @__artistJoinEntity_Track_Uri_0) THEN CAST(1 AS bit)
          ELSE CAST(0 AS bit)
      END
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (0ms) [Parameters=[@__artistJoinEntity_Artist_Uri_0='?' (Size = 450)], CommandType='Text', CommandTimeout='30']
      SELECT CASE
          WHEN EXISTS (
              SELECT 1
              FROM [Artists] AS [a]
              WHERE [a].[Uri] = @__artistJoinEntity_Artist_Uri_0) THEN CAST(1 AS bit)
          ELSE CAST(0 AS bit)
      END
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (0ms) [Parameters=[@__artistJoinEntity_Track_Uri_0='?' (Size = 450)], CommandType='Text', CommandTimeout='30']
      SELECT CASE
          WHEN EXISTS (
              SELECT 1
              FROM [Tracks] AS [t]
              WHERE [t].[Uri] = @__artistJoinEntity_Track_Uri_0) THEN CAST(1 AS bit)
          ELSE CAST(0 AS bit)
      END
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (7ms) [Parameters=[@__entity_equality_recommendation_User_0_Id='?' (Size = 450), @__entity_equality_recommendation_Track_1_Id='?' (DbType = Int32)], CommandType='Text', CommandTimeout='30']
      SELECT CASE
          WHEN EXISTS (
              SELECT 1
              FROM [Recommendations] AS [r]
              LEFT JOIN [AspNetUsers] AS [a] ON [r].[UserId] = [a].[Id]
              INNER JOIN [Tracks] AS [t] ON [r].[TrackId] = [t].[Id]
              WHERE ([a].[Id] = @__entity_equality_recommendation_User_0_Id) AND ([t].[Id] = @__entity_equality_recommendation_Track_1_Id)) THEN CAST(1 AS bit)
          ELSE CAST(0 AS bit)
      END
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (3ms) [Parameters=[@p0='?' (Size = 4000), @p1='?' (Size = 4000), @p2='?' (Size = 4000), @p3='?' (Size = 4000), @p4='?' (Size = 4000), @p5='?' (Size = 4000), @p6='?' (Size = 450)], CommandType='Text', CommandTimeout='30']
      SET NOCOUNT ON;
      INSERT INTO [Albums] ([AlbumType], [Href], [Label], [Name], [ReleaseDate], [ReleaseDatePrecision], [Uri])
      VALUES (@p0, @p1, @p2, @p3, @p4, @p5, @p6);
      SELECT [Id]
      FROM [Albums]
      WHERE @@ROWCOUNT = 1 AND [Id] = scope_identity();
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (3ms) [Parameters=[@p0='?' (Size = 4000), @p1='?' (Size = 4000), @p2='?' (Size = 4000), @p3='?' (Size = 450)], CommandType='Text', CommandTimeout='30']
      SET NOCOUNT ON;
      INSERT INTO [Artists] ([Href], [Name], [Type], [Uri])
      VALUES (@p0, @p1, @p2, @p3);
      SELECT [Id]
      FROM [Artists]
      WHERE @@ROWCOUNT = 1 AND [Id] = scope_identity();
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (1ms) [Parameters=[@p0='?' (Size = 4000), @p1='?' (Size = 4000), @p2='?' (Size = 4000), @p3='?' (Size = 450)], CommandType='Text', CommandTimeout='30']
      SET NOCOUNT ON;
      INSERT INTO [Artists] ([Href], [Name], [Type], [Uri])
      VALUES (@p0, @p1, @p2, @p3);
      SELECT [Id]
      FROM [Artists]
      WHERE @@ROWCOUNT = 1 AND [Id] = scope_identity();
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (21ms) [Parameters=[@p4='?' (DbType = Int32), @p5='?' (DbType = Int32), @p6='?' (Size = 4000), @p7='?' (DbType = Int32), @p8='?' (DbType = Int32), @p9='?' (DbType = Int32), @p10='?' (Size = 4000), @p11='?' (DbType = Int32), @p12='?' (DbType = Int32), @p13='?' (DbType = Int32), @p14='?' (Size = 4000), @p15='?' (DbType = Int32), @p16='?' (DbType = Int32), @p17='?' (DbType = Int32), @p18='?' (Size = 4000), @p19='?' (DbType = Int32), @p20='?' (DbType = Int32), @p21='?' (DbType = Int32), @p22='?' (Size = 4000), @p23='?' (DbType = Int32), @p24='?' (DbType = Int32), @p25='?' (DbType = Int32), @p26='?' (Size = 4000), @p27='?' (DbType = Int32), @p28='?' (DbType = Int32), @p29='?' (DbType = Int32), @p30='?' (Size = 4000), @p31='?' (DbType = Int32), @p32='?' (DbType = Int32), @p33='?' (Size = 4000), @p34='?' (Size = 4000), @p35='?' (Size = 4000), @p36='?' (Size = 450)], CommandType='Text', CommandTimeout='30']
      SET NOCOUNT ON;
      DECLARE @inserted0 TABLE ([Id] int, [_Position] [int]);
      MERGE [ArtistImages] USING (
      VALUES (@p4, @p5, @p6, @p7, 0),
      (@p8, @p9, @p10, @p11, 1),
      (@p12, @p13, @p14, @p15, 2),
      (@p16, @p17, @p18, @p19, 3),
      (@p20, @p21, @p22, @p23, 4),
      (@p24, @p25, @p26, @p27, 5),
      (@p28, @p29, @p30, @p31, 6)) AS i ([ArtistId], [Height], [Url], [Width], _Position) ON 1=0
      WHEN NOT MATCHED THEN
      INSERT ([ArtistId], [Height], [Url], [Width])
      VALUES (i.[ArtistId], i.[Height], i.[Url], i.[Width])
      OUTPUT INSERTED.[Id], i._Position
      INTO @inserted0;

      SELECT [t].[Id] FROM [ArtistImages] t
      INNER JOIN @inserted0 i ON ([t].[Id] = [i].[Id])
      ORDER BY [i].[_Position];

      INSERT INTO [Tracks] ([AlbumId], [Href], [Name], [PreviewUrl], [Uri])
      VALUES (@p32, @p33, @p34, @p35, @p36);
      SELECT [Id], [DownVotes], [UpVotes]
      FROM [Tracks]
      WHERE @@ROWCOUNT = 1 AND [Id] = scope_identity();
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (3ms) [Parameters=[@p0='?' (DbType = Int32), @p1='?' (DbType = Int32)], CommandType='Text', CommandTimeout='30']
      SET NOCOUNT ON;
      INSERT INTO [ArtistsTracks] ([ArtistId], [TrackId])
      VALUES (@p0, @p1);
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (1ms) [Parameters=[@p0='?' (DbType = Int32), @p1='?' (DbType = Int32)], CommandType='Text', CommandTimeout='30']
      SET NOCOUNT ON;
      INSERT INTO [ArtistsTracks] ([ArtistId], [TrackId])
      VALUES (@p0, @p1);
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (5ms) [Parameters=[@p0='?' (DbType = Int32), @p1='?' (Size = 450)], CommandType='Text', CommandTimeout='30']
      SET NOCOUNT ON;
      INSERT INTO [Recommendations] ([TrackId], [UserId])
      VALUES (@p0, @p1);
      SELECT [Id]
      FROM [Recommendations]
      WHERE @@ROWCOUNT = 1 AND [Id] = scope_identity();
