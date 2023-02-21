using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class clientCity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClientCity",
                table: "Clients",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientCity",
                table: "Clients");
        }
    }
}
