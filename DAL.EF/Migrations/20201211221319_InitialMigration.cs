using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.EF.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarModels",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 150, nullable: false),
                    BrandName = table.Column<string>(maxLength: 150, nullable: false),
                    IsAvailable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 150, nullable: false),
                    Email = table.Column<string>(maxLength: 70, nullable: false),
                    Phone = table.Column<string>(maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarTrims",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 150, nullable: false),
                    IsAvailable = table.Column<bool>(nullable: false),
                    CarModelId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarTrims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarTrims_CarModels_CarModelId",
                        column: x => x.CarModelId,
                        principalTable: "CarModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarOrders",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    ModelName = table.Column<string>(maxLength: 150, nullable: false),
                    TrimName = table.Column<string>(maxLength: 150, nullable: false),
                    Engine = table.Column<string>(maxLength: 150, nullable: false),
                    FuelType = table.Column<int>(nullable: false),
                    GearType = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    BankLoanDuration = table.Column<int>(nullable: false),
                    BankLoanDownPayment = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    BankLoanMonthlyPayment = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    CustomerId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarOrders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarVariants",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Engine = table.Column<string>(maxLength: 150, nullable: false),
                    FuelType = table.Column<int>(nullable: false),
                    GearType = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    IsAvailable = table.Column<bool>(nullable: false),
                    CarTrimId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarVariants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarVariants_CarTrims_CarTrimId",
                        column: x => x.CarTrimId,
                        principalTable: "CarTrims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarModels_Name",
                table: "CarModels",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarOrders_CustomerId",
                table: "CarOrders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CarTrims_CarModelId",
                table: "CarTrims",
                column: "CarModelId");

            migrationBuilder.CreateIndex(
                name: "IX_CarVariants_CarTrimId",
                table: "CarVariants",
                column: "CarTrimId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarOrders");

            migrationBuilder.DropTable(
                name: "CarVariants");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "CarTrims");

            migrationBuilder.DropTable(
                name: "CarModels");
        }
    }
}
