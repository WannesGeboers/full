using Microsoft.EntityFrameworkCore.Migrations;

namespace dotNetAcademy.DAL.Migrations
{
    public partial class customerAddressChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Customers",
                newName: "StreetAndNumber");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Customers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "StreetAndNumber",
                table: "Customers",
                newName: "Address");
        }
    }
}
