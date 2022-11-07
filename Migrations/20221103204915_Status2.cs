using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkiService.Migrations
{
    public partial class Status2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusID",
                table: "Clients",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_StatusID",
                table: "Clients",
                column: "StatusID");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Status_StatusID",
                table: "Clients",
                column: "StatusID",
                principalTable: "Status",
                principalColumn: "StatusID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Status_StatusID",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_StatusID",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "StatusID",
                table: "Clients");
        }
    }
}
