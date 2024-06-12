using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SlapBott.Data.Migrations
{
    /// <inheritdoc />
    public partial class loottable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameColumn(
                name: "Profession",
                table: "Materials",
                newName: "CanBeUsedInProffesions");

            migrationBuilder.RenameColumn(
                name: "ActivityType",
                table: "Items",
                newName: "AcuiredThroughType");

            migrationBuilder.AddColumn<int>(
                name: "CharacterId",
                table: "lootTables",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AcuiredThroughType", "AreaType", "Description", "EnemyType", "FoundLevel", "Regions" },
                values: new object[] { 1, 1, "An Ore Found in Caves that can be used to Craft Iron Gear at a BlackSmith", 0, 2, 4 });

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 1,
                column: "CanBeUsedInProffesions",
                value: "[1]");

            migrationBuilder.CreateIndex(
                name: "IX_lootTables_CharacterId",
                table: "lootTables",
                column: "CharacterId");

            migrationBuilder.AddForeignKey(
                name: "FK_lootTables_Characters_CharacterId",
                table: "lootTables",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_lootTables_Characters_CharacterId",
                table: "lootTables");

            migrationBuilder.DropIndex(
                name: "IX_lootTables_CharacterId",
                table: "lootTables");

            migrationBuilder.DropColumn(
                name: "CharacterId",
                table: "lootTables");

            migrationBuilder.RenameColumn(
                name: "CanBeUsedInProffesions",
                table: "Materials",
                newName: "Profession");

            migrationBuilder.RenameColumn(
                name: "AcuiredThroughType",
                table: "Items",
                newName: "ActivityType");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ActivityType", "AreaType", "Description", "EnemyType", "FoundLevel", "Regions" },
                values: new object[] { null, null, "", null, 0, null });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "ActivityType", "AreaType", "Description", "EnemyType", "FoundLevel", "Name", "Regions" },
                values: new object[,]
                {
                    { 2, null, null, "", null, 0, "Herbs", null },
                    { 3, null, null, "", null, 0, "Cloth", null }
                });

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 1,
                column: "Profession",
                value: "Blacksmith");

            migrationBuilder.InsertData(
                table: "Materials",
                columns: new[] { "Id", "Profession" },
                values: new object[,]
                {
                    { 2, "Alchemist" },
                    { 3, "Tailor" }
                });
        }
    }
}
