using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SlapBott.Data.Migrations
{
    /// <inheritdoc />
    public partial class matcons : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ItemID",
                table: "Equipment",
                newName: "MaterialId");

            migrationBuilder.AddColumn<int>(
                name: "ActivityType",
                table: "Items",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AreaType",
                table: "Items",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EnemyType",
                table: "Items",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FoundLevel",
                table: "Items",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Regions",
                table: "Items",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ConsumableId",
                table: "Equipment",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ActivityType", "AreaType", "EnemyType", "FoundLevel", "Regions" },
                values: new object[] { null, null, null, 0, null });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ActivityType", "AreaType", "EnemyType", "FoundLevel", "Regions" },
                values: new object[] { null, null, null, 0, null });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ActivityType", "AreaType", "EnemyType", "FoundLevel", "Regions" },
                values: new object[] { null, null, null, 0, null });

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_ConsumableId",
                table: "Equipment",
                column: "ConsumableId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_MaterialId",
                table: "Equipment",
                column: "MaterialId");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipment_Consumables_ConsumableId",
                table: "Equipment",
                column: "ConsumableId",
                principalTable: "Consumables",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipment_Materials_MaterialId",
                table: "Equipment",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipment_Consumables_ConsumableId",
                table: "Equipment");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipment_Materials_MaterialId",
                table: "Equipment");

            migrationBuilder.DropIndex(
                name: "IX_Equipment_ConsumableId",
                table: "Equipment");

            migrationBuilder.DropIndex(
                name: "IX_Equipment_MaterialId",
                table: "Equipment");

            migrationBuilder.DropColumn(
                name: "ActivityType",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "AreaType",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "EnemyType",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "FoundLevel",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Regions",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ConsumableId",
                table: "Equipment");

            migrationBuilder.RenameColumn(
                name: "MaterialId",
                table: "Equipment",
                newName: "ItemID");
        }
    }
}
