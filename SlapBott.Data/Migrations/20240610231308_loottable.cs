using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SlapBott.Data.Migrations
{
    /// <inheritdoc />
    public partial class loottable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "lootTables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EnemyId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lootTables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_lootTables_Enemies_EnemyId",
                        column: x => x.EnemyId,
                        principalTable: "Enemies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "lootTablesItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LootTableId = table.Column<int>(type: "INTEGER", nullable: false),
                    ItemType = table.Column<int>(type: "INTEGER", nullable: false),
                    ItemId = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    GearRarety = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lootTablesItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_lootTablesItem_Consumables_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Consumables",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_lootTablesItem_Materials_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Materials",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_lootTablesItem_lootTables_LootTableId",
                        column: x => x.LootTableId,
                        principalTable: "lootTables",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_lootTables_EnemyId",
                table: "lootTables",
                column: "EnemyId");

            migrationBuilder.CreateIndex(
                name: "IX_lootTablesItem_ItemId",
                table: "lootTablesItem",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_lootTablesItem_LootTableId",
                table: "lootTablesItem",
                column: "LootTableId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "lootTablesItem");

            migrationBuilder.DropTable(
                name: "lootTables");
        }
    }
}
