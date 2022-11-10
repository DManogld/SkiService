using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkiService.Migrations
{
    public partial class Kommentar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Kommentar",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Kommentar",
                table: "Clients");
        }
    }
}
