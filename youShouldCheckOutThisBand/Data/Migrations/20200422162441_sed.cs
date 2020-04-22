using Microsoft.EntityFrameworkCore.Migrations;

namespace youShouldCheckOutThisBand.Migrations
{
    public partial class sed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "SpotifyId", "Name", "Uri" },
                values: new object[] { "6DPYiyq5kWVQS4RGwxzPC7", "Dr. Dre", "6DPYiyq5kWVQS4RGwxzPC7" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "SpotifyId",
                keyValue: "6DPYiyq5kWVQS4RGwxzPC7");
        }
    }
}
