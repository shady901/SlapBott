using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SlapBott.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingClassconfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClassId",
                table: "Character",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CharacterClasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<int>(type: "INTEGER", nullable: false),
                    BaseStats = table.Column<string>(type: "TEXT", nullable: false),
                    PerLevelStats = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterClasses", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CharacterClasses",
                columns: new[] { "Id", "BaseStats", "Name", "PerLevelStats" },
                values: new object[,]
                {
                    { 1, "{\"Dexterity\":4,\"Strength\":4,\"Intelligence\":4,\"CritChance\":0,\"MaxHealth\":100,\"Health\":100,\"AttackDamage\":0,\"ArmorRating\":0,\"DodgeChance\":5,\"ChaosResistance\":0,\"FireResistance\":0,\"PhysicalResistance\":0,\"FrostResistance\":0,\"LightningResistance\":0,\"SpellPower\":0,\"PhysicalDamage\":0,\"ElementalDamage\":0,\"Speed\":0,\"ChaosDamage\":0}", 1, "{\"MaxHealth\":20,\"Strength\":1}" },
                    { 2, "{\"Dexterity\":4,\"Strength\":4,\"Intelligence\":4,\"CritChance\":0,\"MaxHealth\":100,\"Health\":100,\"AttackDamage\":0,\"ArmorRating\":0,\"DodgeChance\":5,\"ChaosResistance\":0,\"FireResistance\":0,\"PhysicalResistance\":0,\"FrostResistance\":0,\"LightningResistance\":0,\"SpellPower\":0,\"PhysicalDamage\":0,\"ElementalDamage\":0,\"Speed\":0,\"ChaosDamage\":0}", 2, "{\"SpellPower\":1,\"Intelligence\":1}" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Character_ClassId",
                table: "Character",
                column: "ClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Character_CharacterClasses_ClassId",
                table: "Character",
                column: "ClassId",
                principalTable: "CharacterClasses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Character_CharacterClasses_ClassId",
                table: "Character");

            migrationBuilder.DropTable(
                name: "CharacterClasses");

            migrationBuilder.DropIndex(
                name: "IX_Character_ClassId",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "ClassId",
                table: "Character");
        }
    }
}
