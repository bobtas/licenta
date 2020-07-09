using Microsoft.EntityFrameworkCore.Migrations;

namespace cautsalonapp.Data.Migrations
{
    public partial class removecod_firma : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Saloane_Servicii_ServiciuCod_serviciu",
                table: "Saloane");

            migrationBuilder.DropIndex(
                name: "IX_Saloane_ServiciuCod_serviciu",
                table: "Saloane");

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
                name: "Cod_firma",
                table: "Saloane");

            migrationBuilder.DropColumn(
                name: "ServiciuCod_serviciu",
                table: "Saloane");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "Cod_firma",
                table: "Saloane",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ServiciuCod_serviciu",
                table: "Saloane",
                type: "int",
                nullable: true);

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
                name: "IX_Saloane_ServiciuCod_serviciu",
                table: "Saloane",
                column: "ServiciuCod_serviciu");

            migrationBuilder.AddForeignKey(
                name: "FK_Saloane_Servicii_ServiciuCod_serviciu",
                table: "Saloane",
                column: "ServiciuCod_serviciu",
                principalTable: "Servicii",
                principalColumn: "Cod_serviciu",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
