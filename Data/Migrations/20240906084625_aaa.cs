using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FrostbyteWebApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class aaa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "167343bb-552c-47d8-afc4-27c75aefc17e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e5f65b2-e6f8-4199-a940-e2611fa158d5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "97310d92-0d0e-42a8-b9e4-ff4b388355de");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bcb8e408-b9c7-4196-8741-6734cad93308");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d25cb9ca-66e8-4bc9-b0c5-b6f56400ca44");

            migrationBuilder.DropColumn(
                name: "Address1",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Address2",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Province",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "876d0ed3-bb61-46a9-a7e8-488add8c67e3", null, "supplier", "supplier" },
                    { "87996246-7883-4620-9885-86578c124762", null, "client", "client" },
                    { "9ef6c696-752b-4d7e-b683-9d3892cf1580", null, "PurchaseManager", "PurchasingManager" },
                    { "a4e8e061-899e-4d19-b1dc-b44238474dda", null, "admin", "admin" },
                    { "ec359a96-449b-433b-b035-641800276e24", null, "InventoryLiaison", "InventoryLiaison" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "876d0ed3-bb61-46a9-a7e8-488add8c67e3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "87996246-7883-4620-9885-86578c124762");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9ef6c696-752b-4d7e-b683-9d3892cf1580");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a4e8e061-899e-4d19-b1dc-b44238474dda");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ec359a96-449b-433b-b035-641800276e24");

            migrationBuilder.AddColumn<string>(
                name: "Address1",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address2",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Province",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ZipCode",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "167343bb-552c-47d8-afc4-27c75aefc17e", null, "supplier", "supplier" },
                    { "8e5f65b2-e6f8-4199-a940-e2611fa158d5", null, "InventoryLiaison", "InventoryLiaison" },
                    { "97310d92-0d0e-42a8-b9e4-ff4b388355de", null, "admin", "admin" },
                    { "bcb8e408-b9c7-4196-8741-6734cad93308", null, "client", "client" },
                    { "d25cb9ca-66e8-4bc9-b0c5-b6f56400ca44", null, "PurchaseManager", "PurchasingManager" }
                });
        }
    }
}
