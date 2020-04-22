using Microsoft.EntityFrameworkCore.Migrations;

namespace youShouldCheckOutThisBand.Migrations
{
    public partial class addeddefaltvalue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Votes",
                table: "Tracks",
                nullable: false,
                defaultValue: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Votes",
                table: "Tracks");
        }
    }
}
