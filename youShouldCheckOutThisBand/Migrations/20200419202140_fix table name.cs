using Microsoft.EntityFrameworkCore.Migrations;

namespace youShouldCheckOutThisBand.Migrations
{
    public partial class fixtablename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    SpotifyId = table.Column<string>(nullable: false),
                    AlbumType = table.Column<string>(nullable: true),
                    Href = table.Column<string>(nullable: true),
                    Label = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ReleaseDate = table.Column<string>(nullable: true),
                    ReleaseDatePrecision = table.Column<string>(nullable: true),
                    Uri = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.SpotifyId);
                });

            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    SpotifyId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Uri = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.SpotifyId);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AlbumCovers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Height = table.Column<int>(nullable: false),
                    Width = table.Column<int>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    AlbumSpotifyId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlbumCovers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlbumCovers_Albums_AlbumSpotifyId",
                        column: x => x.AlbumSpotifyId,
                        principalTable: "Albums",
                        principalColumn: "SpotifyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tracks",
                columns: table => new
                {
                    SpotifyId = table.Column<string>(nullable: false),
                    AlbumSpotifyId = table.Column<string>(nullable: true),
                    Href = table.Column<string>(nullable: true),
                    PreviewUrl = table.Column<string>(nullable: true),
                    Uri = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracks", x => x.SpotifyId);
                    table.ForeignKey(
                        name: "FK_Tracks_Albums_AlbumSpotifyId",
                        column: x => x.AlbumSpotifyId,
                        principalTable: "Albums",
                        principalColumn: "SpotifyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ArtistAlbumJoinTable",
                columns: table => new
                {
                    ArtistSpotifyId = table.Column<string>(nullable: false),
                    AlbumSpotifyId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistAlbumJoinTable", x => new { x.ArtistSpotifyId, x.AlbumSpotifyId });
                    table.ForeignKey(
                        name: "FK_ArtistAlbumJoinTable_Albums_AlbumSpotifyId",
                        column: x => x.AlbumSpotifyId,
                        principalTable: "Albums",
                        principalColumn: "SpotifyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtistAlbumJoinTable_Artists_ArtistSpotifyId",
                        column: x => x.ArtistSpotifyId,
                        principalTable: "Artists",
                        principalColumn: "SpotifyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArtistImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Height = table.Column<int>(nullable: false),
                    Width = table.Column<int>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    ArtistSpotifyId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArtistImages_Artists_ArtistSpotifyId",
                        column: x => x.ArtistSpotifyId,
                        principalTable: "Artists",
                        principalColumn: "SpotifyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GenreAlbumJoinTable",
                columns: table => new
                {
                    GenreId = table.Column<int>(nullable: false),
                    AlbumSpotifyId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreAlbumJoinTable", x => new { x.AlbumSpotifyId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_GenreAlbumJoinTable_Albums_AlbumSpotifyId",
                        column: x => x.AlbumSpotifyId,
                        principalTable: "Albums",
                        principalColumn: "SpotifyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreAlbumJoinTable_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenreArtistJoinEntity",
                columns: table => new
                {
                    GenreId = table.Column<int>(nullable: false),
                    ArtistSpotifyId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreArtistJoinEntity", x => new { x.ArtistSpotifyId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_GenreArtistJoinEntity_Artists_ArtistSpotifyId",
                        column: x => x.ArtistSpotifyId,
                        principalTable: "Artists",
                        principalColumn: "SpotifyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreArtistJoinEntity_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrackArtistJoinEntity",
                columns: table => new
                {
                    ArtistSpotifyId = table.Column<string>(nullable: false),
                    TrackSpotifyId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackArtistJoinEntity", x => new { x.ArtistSpotifyId, x.TrackSpotifyId });
                    table.ForeignKey(
                        name: "FK_TrackArtistJoinEntity_Artists_ArtistSpotifyId",
                        column: x => x.ArtistSpotifyId,
                        principalTable: "Artists",
                        principalColumn: "SpotifyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrackArtistJoinEntity_Tracks_TrackSpotifyId",
                        column: x => x.TrackSpotifyId,
                        principalTable: "Tracks",
                        principalColumn: "SpotifyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlbumCovers_AlbumSpotifyId",
                table: "AlbumCovers",
                column: "AlbumSpotifyId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistAlbumJoinTable_AlbumSpotifyId",
                table: "ArtistAlbumJoinTable",
                column: "AlbumSpotifyId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistImages_ArtistSpotifyId",
                table: "ArtistImages",
                column: "ArtistSpotifyId");

            migrationBuilder.CreateIndex(
                name: "IX_GenreAlbumJoinTable_GenreId",
                table: "GenreAlbumJoinTable",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_GenreArtistJoinEntity_GenreId",
                table: "GenreArtistJoinEntity",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_TrackArtistJoinEntity_TrackSpotifyId",
                table: "TrackArtistJoinEntity",
                column: "TrackSpotifyId");

            migrationBuilder.CreateIndex(
                name: "IX_Tracks_AlbumSpotifyId",
                table: "Tracks",
                column: "AlbumSpotifyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlbumCovers");

            migrationBuilder.DropTable(
                name: "ArtistAlbumJoinTable");

            migrationBuilder.DropTable(
                name: "ArtistImages");

            migrationBuilder.DropTable(
                name: "GenreAlbumJoinTable");

            migrationBuilder.DropTable(
                name: "GenreArtistJoinEntity");

            migrationBuilder.DropTable(
                name: "TrackArtistJoinEntity");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropTable(
                name: "Tracks");

            migrationBuilder.DropTable(
                name: "Albums");
        }
    }
}
