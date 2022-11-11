using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkiService.Migrations
{
    public partial class Mitarbeiter3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MitarbeiterApiKey",
                table: "Mitarbeiters",
                newName: "MitarbeiterApiKeys");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MitarbeiterApiKeys",
                table: "Mitarbeiters",
                newName: "MitarbeiterApiKey");
        }
    }
}
