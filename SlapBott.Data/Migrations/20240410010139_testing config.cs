using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SlapBott.Data.Migrations
{
    /// <inheritdoc />
    public partial class testingconfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HadTurn",
                table: "PlayerCharacterCombatState",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HadTurn",
                table: "EnemyCombatState",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "EnemyTemplates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Stats = table.Column<string>(type: "TEXT", nullable: true),
                    RaceId = table.Column<int>(type: "INTEGER", nullable: true),
                    ClassId = table.Column<int>(type: "INTEGER", nullable: true),
                    LearnedSkillIds = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnemyTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnemyTemplates_CharacterClasses_ClassId",
                        column: x => x.ClassId,
                        principalTable: "CharacterClasses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EnemyTemplates_Races_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Races",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Races",
                columns: new[] { "Id", "BaseStats", "Name", "PerLevelStats" },
                values: new object[] { 5, "{\"Dexterity\":4,\"Strength\":4,\"Intelligence\":4,\"CritChance\":0,\"MaxHealth\":100,\"Health\":100,\"AttackDamage\":0,\"ArmorRating\":0,\"DodgeChance\":5,\"ChaosResistance\":0,\"FireResistance\":0,\"PhysicalResistance\":0,\"FrostResistance\":0,\"LightningResistance\":0,\"SpellPower\":0,\"PhysicalDamage\":0,\"ElementalDamage\":0,\"Speed\":0,\"ChaosDamage\":0}", 5, "{\"MaxHealth\":20}" });

            migrationBuilder.InsertData(
                table: "EnemyTemplates",
                columns: new[] { "Id", "ClassId", "Description", "LearnedSkillIds", "Name", "RaceId", "Stats" },
                values: new object[] { 1, 1, "a Pile of bones that has formed a silhouette of a Humanoid", "[1]", "Skeleton Warrior", 5, "{\"Id\":0,\"Character\":null,\"stats\":{\"Dexterity\":0,\"Strength\":0,\"Intelligence\":0,\"CritChance\":0,\"MaxHealth\":0,\"Health\":0,\"AttackDamage\":0,\"ArmorRating\":0,\"DodgeChance\":0,\"ChaosResistance\":0,\"FireResistance\":0,\"PhysicalResistance\":0,\"FrostResistance\":0,\"LightningResistance\":0,\"SpellPower\":0,\"PhysicalDamage\":0,\"ElementalDamage\":0,\"Speed\":0,\"ChaosDamage\":0},\"Health\":0,\"MaxHealth\":0,\"Strength\":0,\"Dexterity\":0,\"Intelligence\":0,\"CritChance\":0,\"AttackDamage\":0,\"SpellPower\":0,\"ChaosResistance\":0,\"FireResistance\":0,\"PhysicalResistance\":0,\"FrostResistance\":0,\"LightningResistance\":0,\"ArmorRating\":0,\"DodgeChance\":0}" });

            migrationBuilder.CreateIndex(
                name: "IX_EnemyTemplates_ClassId",
                table: "EnemyTemplates",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_EnemyTemplates_RaceId",
                table: "EnemyTemplates",
                column: "RaceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnemyTemplates");

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "HadTurn",
                table: "PlayerCharacterCombatState");

            migrationBuilder.DropColumn(
                name: "HadTurn",
                table: "EnemyCombatState");
        }
    }
}
