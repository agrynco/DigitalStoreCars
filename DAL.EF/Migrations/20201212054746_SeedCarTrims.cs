using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.EF.Migrations
{
    public partial class SeedCarTrims : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CarTrims",
                columns: new[] { "Id", "CarModelId", "IsAvailable", "Name" },
                values: new object[,]
                {
                    { 1L, 1L, true, "Premium" },
                    { 2L, 1L, true, "Limited" },
                    { 3L, 2L, true, "LX" },
                    { 4L, 2L, true, "EX" },
                    { 5L, 2L, true, "EX-L" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CarTrims",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "CarTrims",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "CarTrims",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "CarTrims",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "CarTrims",
                keyColumn: "Id",
                keyValue: 5L);
        }
    }
}
