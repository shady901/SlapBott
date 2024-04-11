using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SlapBott.Data.Migrations
{
    /// <inheritdoc />
    public partial class testingaddedregion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RegionId",
                table: "Enemies",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RegionName = table.Column<int>(type: "INTEGER", nullable: false),
                    RaidBossId = table.Column<int>(type: "INTEGER", nullable: false),
                    isBossPending = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Regions_Enemies_RaidBossId",
                        column: x => x.RaidBossId,
                        principalTable: "Enemies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "EnemyTemplates",
                keyColumn: "Id",
                keyValue: 1,
                column: "Stats",
                value: "{\"resistanceTypes\":[10,14,11,12,13],\"Id\":0,\"Character\":null,\"stats\":{\"Dexterity\":0,\"Strength\":0,\"Intelligence\":0,\"CritChance\":0,\"MaxHealth\":0,\"Health\":0,\"AttackDamage\":0,\"ArmorRating\":0,\"DodgeChance\":0,\"ChaosResistance\":0,\"FireResistance\":0,\"PhysicalResistance\":0,\"FrostResistance\":0,\"LightningResistance\":0,\"SpellPower\":0,\"PhysicalDamage\":0,\"ElementalDamage\":0,\"Speed\":0,\"ChaosDamage\":0},\"Health\":0,\"MaxHealth\":0,\"Strength\":0,\"Dexterity\":0,\"Intelligence\":0,\"CritChance\":0,\"AttackDamage\":0,\"SpellPower\":0,\"ChaosResistance\":0,\"FireResistance\":0,\"PhysicalResistance\":0,\"FrostResistance\":0,\"LightningResistance\":0,\"ArmorRating\":0,\"DodgeChance\":0}");

            migrationBuilder.CreateIndex(
                name: "IX_Enemies_RegionId",
                table: "Enemies",
                column: "RegionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Regions_RaidBossId",
                table: "Regions",
                column: "RaidBossId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enemies_Regions_RegionId",
                table: "Enemies",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enemies_Regions_RegionId",
                table: "Enemies");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropIndex(
                name: "IX_Enemies_RegionId",
                table: "Enemies");

            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "Enemies");

            migrationBuilder.UpdateData(
                table: "EnemyTemplates",
                keyColumn: "Id",
                keyValue: 1,
                column: "Stats",
                value: "{\"Id\":0,\"Character\":null,\"stats\":{\"Dexterity\":0,\"Strength\":0,\"Intelligence\":0,\"CritChance\":0,\"MaxHealth\":0,\"Health\":0,\"AttackDamage\":0,\"ArmorRating\":0,\"DodgeChance\":0,\"ChaosResistance\":0,\"FireResistance\":0,\"PhysicalResistance\":0,\"FrostResistance\":0,\"LightningResistance\":0,\"SpellPower\":0,\"PhysicalDamage\":0,\"ElementalDamage\":0,\"Speed\":0,\"ChaosDamage\":0},\"Health\":0,\"MaxHealth\":0,\"Strength\":0,\"Dexterity\":0,\"Intelligence\":0,\"CritChance\":0,\"AttackDamage\":0,\"SpellPower\":0,\"ChaosResistance\":0,\"FireResistance\":0,\"PhysicalResistance\":0,\"FrostResistance\":0,\"LightningResistance\":0,\"ArmorRating\":0,\"DodgeChance\":0}");
        }
    }
}
