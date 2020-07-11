using Microsoft.EntityFrameworkCore.Migrations;

namespace cautsalonapp.Data.Migrations
{
    public partial class removerequiredonanulare : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9db5f94b-db45-4f9a-931d-d69f459e4c2f", "64836753-ae6c-4673-a787-a06cea948492", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4729ef50-3b0e-4aa3-8761-c901fa099b70", "ba308781-fbe5-4446-b168-e74bc5930277", "salonowner", "SALONOWNER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b0780ce2-dd2e-4f17-9816-0c9f9a7bb62c", "d0624a53-9d97-4163-beb2-89c45143c291", "client", "CLIENT" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4729ef50-3b0e-4aa3-8761-c901fa099b70");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9db5f94b-db45-4f9a-931d-d69f459e4c2f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b0780ce2-dd2e-4f17-9816-0c9f9a7bb62c");

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
    }
}
