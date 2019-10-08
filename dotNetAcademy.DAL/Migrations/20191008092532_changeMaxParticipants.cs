using Microsoft.EntityFrameworkCore.Migrations;

namespace dotNetAcademy.DAL.Migrations
{
    public partial class changeMaxParticipants : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MaxParticants",
                table: "Customers",
                newName: "MaxParticipants");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MaxParticipants",
                table: "Customers",
                newName: "MaxParticants");
        }
    }
}
