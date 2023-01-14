using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental.Persistence.EF.Migrations
{
    public partial class CarAddressUserAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddedById",
                table: "CarAddresses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarAddresses_AddedById",
                table: "CarAddresses",
                column: "AddedById");

            migrationBuilder.AddForeignKey(
                name: "FK_CarAddresses_Users_AddedById",
                table: "CarAddresses",
                column: "AddedById",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarAddresses_Users_AddedById",
                table: "CarAddresses");

            migrationBuilder.DropIndex(
                name: "IX_CarAddresses_AddedById",
                table: "CarAddresses");

            migrationBuilder.DropColumn(
                name: "AddedById",
                table: "CarAddresses");
        }
    }
}
