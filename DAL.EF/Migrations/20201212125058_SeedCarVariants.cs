using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.EF.Migrations
{
    public partial class SeedCarVariants : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CarVariants",
                columns: new[] { "Id", "CarTrimId", "Engine", "FuelType", "GearType", "IsAvailable", "Price", "Year" },
                values: new object[,]
                {
                    { 1L, 1L, "EK31", 0, 0, true, 2000, 2014 },
                    { 2L, 1L, "EK51", 0, 0, true, 2000, 2014 },
                    { 3L, 1L, "EK23", 0, 0, true, 2000, 2014 },
                    { 4L, 2L, "GX", 1, 1, true, 2000, 2014 },
                    { 5L, 3L, "V-TWIN", 1, 0, true, 2000, 2010 },
                    { 6L, 3L, "iGX", 0, 1, true, 2000, 2014 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CarVariants",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "CarVariants",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "CarVariants",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "CarVariants",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "CarVariants",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "CarVariants",
                keyColumn: "Id",
                keyValue: 6L);
        }
    }
}
