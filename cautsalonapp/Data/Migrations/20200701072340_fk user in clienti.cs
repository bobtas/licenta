using Microsoft.EntityFrameworkCore.Migrations;

namespace cautsalonapp.Data.Migrations
{
    public partial class fkuserinclienti : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WebuserId",
                table: "Clienti",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clienti_WebuserId",
                table: "Clienti",
                column: "WebuserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clienti_AspNetUsers_WebuserId",
                table: "Clienti",
                column: "WebuserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clienti_AspNetUsers_WebuserId",
                table: "Clienti");

            migrationBuilder.DropIndex(
                name: "IX_Clienti_WebuserId",
                table: "Clienti");

            migrationBuilder.DropColumn(
                name: "WebuserId",
                table: "Clienti");
        }
    }
}
