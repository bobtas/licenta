using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace cautsalonapp.Data.Migrations
{
    public partial class tabele : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clienti",
                columns: table => new
                {
                    Cod_client = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(nullable: true),
                    Prenume = table.Column<string>(nullable: true),
                    Sex = table.Column<int>(nullable: false),
                    Telefon = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Judet = table.Column<string>(nullable: true),
                    Adresa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("cod_client", x => x.Cod_client);
                });

            migrationBuilder.CreateTable(
                name: "Firme",
                columns: table => new
                {
                    Cod_firma = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Denumire = table.Column<string>(nullable: true),
                    Cui = table.Column<string>(nullable: true),
                    Registrul_comertului = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("cod_firma", x => x.Cod_firma);
                });

            migrationBuilder.CreateTable(
                name: "Servicii",
                columns: table => new
                {
                    Cod_serviciu = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Denumire = table.Column<string>(nullable: true),
                    Pret = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("cod_serviciu", x => x.Cod_serviciu);
                });

            migrationBuilder.CreateTable(
                name: "Programari",
                columns: table => new
                {
                    Cod_programare = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientCod_client = table.Column<int>(nullable: true),
                    Data = table.Column<DateTime>(nullable: false),
                    Observatii = table.Column<string>(nullable: true),
                    ServiciuCod_serviciu = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("cod_programare", x => x.Cod_programare);
                    table.ForeignKey(
                        name: "FK_Programari_Clienti_ClientCod_client",
                        column: x => x.ClientCod_client,
                        principalTable: "Clienti",
                        principalColumn: "Cod_client",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Programari_Servicii_ServiciuCod_serviciu",
                        column: x => x.ServiciuCod_serviciu,
                        principalTable: "Servicii",
                        principalColumn: "Cod_serviciu",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Saloane",
                columns: table => new
                {
                    Cod_salon = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(nullable: true),
                    Telefon_salon = table.Column<string>(nullable: true),
                    Telefon_sms = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true),
                    Facebook = table.Column<string>(nullable: true),
                    Judet = table.Column<string>(nullable: true),
                    Adresa = table.Column<string>(nullable: true),
                    Descriere = table.Column<string>(nullable: true),
                    Cod_firma = table.Column<int>(nullable: false),
                    FirmaCod_firma = table.Column<int>(nullable: true),
                    ServiciuCod_serviciu = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("cod_salon", x => x.Cod_salon);
                    table.ForeignKey(
                        name: "FK_Saloane_Firme_FirmaCod_firma",
                        column: x => x.FirmaCod_firma,
                        principalTable: "Firme",
                        principalColumn: "Cod_firma",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Saloane_Servicii_ServiciuCod_serviciu",
                        column: x => x.ServiciuCod_serviciu,
                        principalTable: "Servicii",
                        principalColumn: "Cod_serviciu",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Programari_ClientCod_client",
                table: "Programari",
                column: "ClientCod_client");

            migrationBuilder.CreateIndex(
                name: "IX_Programari_ServiciuCod_serviciu",
                table: "Programari",
                column: "ServiciuCod_serviciu");

            migrationBuilder.CreateIndex(
                name: "IX_Saloane_FirmaCod_firma",
                table: "Saloane",
                column: "FirmaCod_firma");

            migrationBuilder.CreateIndex(
                name: "IX_Saloane_ServiciuCod_serviciu",
                table: "Saloane",
                column: "ServiciuCod_serviciu");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Programari");

            migrationBuilder.DropTable(
                name: "Saloane");

            migrationBuilder.DropTable(
                name: "Clienti");

            migrationBuilder.DropTable(
                name: "Firme");

            migrationBuilder.DropTable(
                name: "Servicii");
        }
    }
}
