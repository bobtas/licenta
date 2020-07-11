using Microsoft.EntityFrameworkCore.Migrations;

namespace cautsalonapp.Data.Migrations
{
    public partial class addstatusforprogramari : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b641580-da15-43ed-91dc-5cd630e4fb5f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b54cac44-549f-4d64-acb8-fc19aaf1204b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c463ae6e-b0a7-4b2a-94d9-66143431e68d");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Programari",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dc577b2e-bb2e-45ac-9a2b-8cbf96f78104", "6c2cd747-df9e-44fd-b9eb-e735b4a6a8f3", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2db1a25e-ce32-4043-8a07-5347279ba2fd", "fffff01c-ddac-4cef-ba77-16f7204db0bf", "salonowner", "SALONOWNER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "790901a5-2482-44ec-9909-003e986b757c", "79a84e12-1cab-426c-943a-ef9cb6eec084", "client", "CLIENT" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2db1a25e-ce32-4043-8a07-5347279ba2fd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "790901a5-2482-44ec-9909-003e986b757c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dc577b2e-bb2e-45ac-9a2b-8cbf96f78104");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Programari");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b54cac44-549f-4d64-acb8-fc19aaf1204b", "f9c05ad8-948a-4163-95a1-88a30add2f70", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c463ae6e-b0a7-4b2a-94d9-66143431e68d", "702f7247-85d6-4e27-b50d-c98e18907145", "salonowner", "SALONOWNER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5b641580-da15-43ed-91dc-5cd630e4fb5f", "8da5de11-abba-433c-b4e3-2e067132ddcb", "client", "CLIENT" });
        }
    }
}
