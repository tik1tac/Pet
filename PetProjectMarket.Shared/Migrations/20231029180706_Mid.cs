using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PetProjectMarket.Shared.Migrations
{
    /// <inheritdoc />
    public partial class Mid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ae67a47-1b72-4649-b1c6-2ddc1d300f10");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6f0eb37c-ff6d-49b8-82cd-7ce0e2cb960f");

            migrationBuilder.DropColumn(
                name: "SEOTeg",
                table: "ProductsEntities");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "84b40265-5448-4958-b747-d3718264830e", null, "VISITOR", "Visitor" },
                    { "d4854a9f-8e79-4ce9-878f-0ec7646197a1", null, "Admin", "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "84b40265-5448-4958-b747-d3718264830e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d4854a9f-8e79-4ce9-878f-0ec7646197a1");

            migrationBuilder.AddColumn<string>(
                name: "SEOTeg",
                table: "ProductsEntities",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5ae67a47-1b72-4649-b1c6-2ddc1d300f10", null, "VISITOR", "Byuer" },
                    { "6f0eb37c-ff6d-49b8-82cd-7ce0e2cb960f", null, "ADMINISTRATOR", "Admin" }
                });
        }
    }
}
