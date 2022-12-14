using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental.Persistence.EF.Migrations
{
    public partial class EntitiesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Street = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarAddresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PriceCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Multiplier = table.Column<decimal>(type: "decimal(2,1)", precision: 2, scale: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YearOfProduction = table.Column<int>(type: "int", nullable: false),
                    Engine = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    AVGFuelConsumption = table.Column<decimal>(type: "decimal(3,1)", precision: 3, scale: 1, nullable: false),
                    NumberOfCars = table.Column<int>(type: "int", nullable: false),
                    CarAddressId = table.Column<int>(type: "int", nullable: false),
                    PriceCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_CarAddresses_CarAddressId",
                        column: x => x.CarAddressId,
                        principalTable: "CarAddresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_PriceCategories_PriceCategoryId",
                        column: x => x.PriceCategoryId,
                        principalTable: "PriceCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CarAddressId",
                table: "Cars",
                column: "CarAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_PriceCategoryId",
                table: "Cars",
                column: "PriceCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "CarAddresses");

            migrationBuilder.DropTable(
                name: "PriceCategories");
        }
    }
}
