using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental.Persistence.EF.Migrations
{
    public partial class SeedDataAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CarAddresses",
                columns: new[] { "Id", "City", "PostalCode", "Street" },
                values: new object[,]
                {
                    { 1, "Rzeszow", "35-064", "Targowa 17" },
                    { 2, "Krakow", "30-072", "Rostafinskiego 9" },
                    { 3, "Wroclaw", "50-416", "Generala Romualda Traugutta 25" }
                });

            migrationBuilder.InsertData(
                table: "PriceCategories",
                columns: new[] { "Id", "Category", "Multiplier" },
                values: new object[,]
                {
                    { 1, "Basic", 1.0m },
                    { 2, "Standard", 1.3m },
                    { 3, "Medium", 1.6m },
                    { 4, "Premium", 2.0m }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "AVGFuelConsumption", "CarAddressId", "Engine", "Mark", "Model", "NumberOfCars", "PriceCategoryId", "YearOfProduction" },
                values: new object[,]
                {
                    { 1, 6.2m, 1, "2.0 HDI 136HP", "Peugeot", "407", 5, 2, 2004 },
                    { 2, 10.5m, 2, "2.0 132HP", "Peugeot", "406 Coupe", 2, 2, 1998 },
                    { 3, 5.5m, 1, "1.2 78HP", "Suzuki", "Swift", 4, 2, 2017 },
                    { 4, 13.5m, 1, "4.0 TFSI 571HP", "Audi", "S8", 2, 4, 2022 },
                    { 5, 9.2m, 2, "2.0 211HP", "Mercedes-Benz", "GLE", 9, 4, 2021 },
                    { 6, 5.5m, 2, "1.5 TSI 150HP", "Volkswagen", "T-Roc", 1, 3, 2022 },
                    { 7, 5.5m, 2, "1.6 HDI 114HP", "Citroen", "DS4", 3, 3, 2012 },
                    { 8, 9.0m, 3, "2.0 TFSI 200HP", "Skoda", "Octavia", 5, 1, 2006 },
                    { 9, 8.5m, 3, "1.6 102HP", "Seat", "Leon", 2, 1, 2007 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "CarAddresses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CarAddresses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CarAddresses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PriceCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PriceCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PriceCategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PriceCategories",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
