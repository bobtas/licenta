using Microsoft.EntityFrameworkCore.Migrations;

namespace cautsalonapp.Data.Migrations
{
    public partial class addmotivanulare : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Motiv_anulare",
                table: "Programari",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3e508150-2355-4fc7-ad86-9463ca9025f1", "d75c5816-039c-40a2-a182-ce36ec975045", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "53e76bad-7800-49b4-a9bd-b00d176f223c", "86d4e38f-719b-4bf3-a6b5-aef1c09e712c", "salonowner", "SALONOWNER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "41b8611b-dda5-4e49-8bb2-6868d513dd92", "9519e9bd-3f59-4d31-a159-6a65c86d0d7c", "client", "CLIENT" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3e508150-2355-4fc7-ad86-9463ca9025f1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "41b8611b-dda5-4e49-8bb2-6868d513dd92");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "53e76bad-7800-49b4-a9bd-b00d176f223c");

            migrationBuilder.DropColumn(
                name: "Motiv_anulare",
                table: "Programari");

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
    }
}
