using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental.Persistence.EF.Migrations
{
    public partial class CarRefactored : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Engine",
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

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EngineCapacity", "EnginePower" },
                values: new object[] { 2.0m, 136 });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EngineCapacity", "EnginePower" },
                values: new object[] { 2.0m, 132 });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EngineCapacity", "EnginePower" },
                values: new object[] { 1.2m, 78 });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EngineCapacity", "EnginePower" },
                values: new object[] { 4.0m, 571 });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "EngineCapacity", "EnginePower" },
                values: new object[] { 2.0m, 211 });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "EngineCapacity", "EnginePower" },
                values: new object[] { 1.5m, 150 });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "EngineCapacity", "EnginePower" },
                values: new object[] { 1.6m, 114 });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "EngineCapacity", "EnginePower" },
                values: new object[] { 2.0m, 200 });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "EngineCapacity", "EnginePower" },
                values: new object[] { 1.6m, 102 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EngineCapacity",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "EnginePower",
                table: "Cars");

            migrationBuilder.AddColumn<string>(
                name: "Engine",
                table: "Cars",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                column: "Engine",
                value: "2.0 HDI 136HP");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "Engine",
                value: "2.0 132HP");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                column: "Engine",
                value: "1.2 78HP");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4,
                column: "Engine",
                value: "4.0 TFSI 571HP");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5,
                column: "Engine",
                value: "2.0 211HP");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 6,
                column: "Engine",
                value: "1.5 TSI 150HP");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 7,
                column: "Engine",
                value: "1.6 HDI 114HP");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 8,
                column: "Engine",
                value: "2.0 TFSI 200HP");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 9,
                column: "Engine",
                value: "1.6 102HP");
        }
    }
}
