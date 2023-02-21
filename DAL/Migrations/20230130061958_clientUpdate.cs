using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class clientUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientAddress",
                table: "Clients");

            migrationBuilder.AddColumn<string>(
                name: "CliebtFax",
                table: "Clients",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClientPhoneNumber",
                table: "Clients",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClientStreetAddress",
                table: "Clients",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CliebtFax",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "ClientPhoneNumber",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "ClientStreetAddress",
                table: "Clients");

            migrationBuilder.AddColumn<string>(
                name: "ClientAddress",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
