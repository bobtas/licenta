using Microsoft.EntityFrameworkCore.Migrations;

namespace cautsalonapp.Data.Migrations
{
    public partial class programariservicii : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SalonCod_salon",
                table: "Programari",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WebuserId",
                table: "Programari",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WebuserId",
                table: "Firme",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SaloaneServicii",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalonCod_salon = table.Column<int>(nullable: true),
                    ServiciuCod_serviciu = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaloaneServicii_Saloane_SalonCod_salon",
                        column: x => x.SalonCod_salon,
                        principalTable: "Saloane",
                        principalColumn: "Cod_salon",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SaloaneServicii_Servicii_ServiciuCod_serviciu",
                        column: x => x.ServiciuCod_serviciu,
                        principalTable: "Servicii",
                        principalColumn: "Cod_serviciu",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "49becfba-3fac-46d4-9720-b280c42f9d0f", "e04a0a24-59d0-43d9-8325-3d0da9ebbb1c", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "96c3d875-71f5-4b65-8dc5-227f758c9601", "c0933a62-05a0-4d1e-a9e5-bff78b2a1ce5", "salonowner", "SALONOWNER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "221202ec-e216-4a3a-9e7a-35f8156dabc2", "cde063a9-0f67-4b0d-92ea-5e9adbeaf0d3", "client", "CLIENT" });

            migrationBuilder.CreateIndex(
                name: "IX_Programari_SalonCod_salon",
                table: "Programari",
                column: "SalonCod_salon");

            migrationBuilder.CreateIndex(
                name: "IX_Programari_WebuserId",
                table: "Programari",
                column: "WebuserId");

            migrationBuilder.CreateIndex(
                name: "IX_Firme_WebuserId",
                table: "Firme",
                column: "WebuserId");

            migrationBuilder.CreateIndex(
                name: "IX_SaloaneServicii_SalonCod_salon",
                table: "SaloaneServicii",
                column: "SalonCod_salon");

            migrationBuilder.CreateIndex(
                name: "IX_SaloaneServicii_ServiciuCod_serviciu",
                table: "SaloaneServicii",
                column: "ServiciuCod_serviciu");

            migrationBuilder.AddForeignKey(
                name: "FK_Firme_AspNetUsers_WebuserId",
                table: "Firme",
                column: "WebuserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Programari_Saloane_SalonCod_salon",
                table: "Programari",
                column: "SalonCod_salon",
                principalTable: "Saloane",
                principalColumn: "Cod_salon",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Programari_AspNetUsers_WebuserId",
                table: "Programari",
                column: "WebuserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Firme_AspNetUsers_WebuserId",
                table: "Firme");

            migrationBuilder.DropForeignKey(
                name: "FK_Programari_Saloane_SalonCod_salon",
                table: "Programari");

            migrationBuilder.DropForeignKey(
                name: "FK_Programari_AspNetUsers_WebuserId",
                table: "Programari");

            migrationBuilder.DropTable(
                name: "SaloaneServicii");

            migrationBuilder.DropIndex(
                name: "IX_Programari_SalonCod_salon",
                table: "Programari");

            migrationBuilder.DropIndex(
                name: "IX_Programari_WebuserId",
                table: "Programari");

            migrationBuilder.DropIndex(
                name: "IX_Firme_WebuserId",
                table: "Firme");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "221202ec-e216-4a3a-9e7a-35f8156dabc2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49becfba-3fac-46d4-9720-b280c42f9d0f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "96c3d875-71f5-4b65-8dc5-227f758c9601");

            migrationBuilder.DropColumn(
                name: "SalonCod_salon",
                table: "Programari");

            migrationBuilder.DropColumn(
                name: "WebuserId",
                table: "Programari");

            migrationBuilder.DropColumn(
                name: "WebuserId",
                table: "Firme");
        }
    }
}
