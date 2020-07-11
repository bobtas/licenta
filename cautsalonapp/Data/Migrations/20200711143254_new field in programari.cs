using Microsoft.EntityFrameworkCore.Migrations;

namespace cautsalonapp.Data.Migrations
{
    public partial class newfieldinprogramari : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "af00e95f-5a73-4b17-95f4-ac9ee32effb6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c745ecd4-3d25-4866-9d52-b461863f958e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cca37161-fcdd-4e8e-8295-07b32d9d0b39");

            migrationBuilder.AddColumn<bool>(
                name: "Confirmata",
                table: "Programari",
                nullable: false,
                defaultValue: false);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Confirmata",
                table: "Programari");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c745ecd4-3d25-4866-9d52-b461863f958e", "71c9e32b-0c10-4bba-8fbf-3a5341f610af", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cca37161-fcdd-4e8e-8295-07b32d9d0b39", "a697e7bb-a05d-4933-9dc2-33240897cd39", "salonowner", "SALONOWNER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "af00e95f-5a73-4b17-95f4-ac9ee32effb6", "b13843ff-b7ce-4acd-85ad-d19a7fd22b34", "client", "CLIENT" });
        }
    }
}
