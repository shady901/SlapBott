using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SlapBott.Data.Migrations
{
    /// <inheritdoc />
    public partial class seeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "", "Iron Ore" },
                    { 2, "", "Herbs" },
                    { 3, "", "Cloth" }
                });

            migrationBuilder.InsertData(
                table: "Materials",
                columns: new[] { "Id", "Profession" },
                values: new object[,]
                {
                    { 1, "Blacksmith" },
                    { 2, "Alchemist" },
                    { 3, "Tailor" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
