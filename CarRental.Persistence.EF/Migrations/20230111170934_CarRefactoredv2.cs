using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental.Persistence.EF.Migrations
{
    public partial class CarRefactoredv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EngineCapacity",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "EnginePower",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "NumberOfCars",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "YearOfProduction",
                table: "Cars");

            migrationBuilder.AddColumn<string>(
                name: "RegistrationNumber",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegistrationNumber",
                table: "Cars");

            migrationBuilder.AddColumn<decimal>(
                name: "EngineCapacity",
                table: "Cars",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "EnginePower",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfCars",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "YearOfProduction",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EngineCapacity", "EnginePower", "NumberOfCars", "YearOfProduction" },
                values: new object[] { 2.0m, 136, 5, 2004 });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EngineCapacity", "EnginePower", "NumberOfCars", "YearOfProduction" },
                values: new object[] { 2.0m, 132, 2, 1998 });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EngineCapacity", "EnginePower", "NumberOfCars", "YearOfProduction" },
                values: new object[] { 1.2m, 78, 4, 2017 });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EngineCapacity", "EnginePower", "NumberOfCars", "YearOfProduction" },
                values: new object[] { 4.0m, 571, 2, 2022 });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "EngineCapacity", "EnginePower", "NumberOfCars", "YearOfProduction" },
                values: new object[] { 2.0m, 211, 9, 2021 });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "EngineCapacity", "EnginePower", "NumberOfCars", "YearOfProduction" },
                values: new object[] { 1.5m, 150, 1, 2022 });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "EngineCapacity", "EnginePower", "NumberOfCars", "YearOfProduction" },
                values: new object[] { 1.6m, 114, 3, 2012 });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "EngineCapacity", "EnginePower", "NumberOfCars", "YearOfProduction" },
                values: new object[] { 2.0m, 200, 5, 2006 });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "EngineCapacity", "EnginePower", "NumberOfCars", "YearOfProduction" },
                values: new object[] { 1.6m, 102, 2, 2007 });
        }
    }
}
