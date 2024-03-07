using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SlapBott.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingTurns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.CreateTable(
                name: "CombatState",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ChannelID = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    CurrentTurnId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CombatState", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubClass",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubClass", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Character",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HasLeveled = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CharExp = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    CharacterClassId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Character_SubClass_CharacterClassId",
                        column: x => x.CharacterClassId,
                        principalTable: "SubClass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Turns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TurnId = table.Column<int>(type: "integer", nullable: false),
                    CombatStateId = table.Column<int>(type: "integer", nullable: false),
                    AttackerId = table.Column<int>(type: "integer", nullable: false),
                    CurrentTurnId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Turns_Character_AttackerId",
                        column: x => x.AttackerId,
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Turns_CombatState_CombatStateId",
                        column: x => x.CombatStateId,
                        principalTable: "CombatState",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TurnAttackRecord",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SkillId = table.Column<int>(type: "integer", nullable: false),
                    TurnId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TurnAttackRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TurnAttackRecord_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TurnAttackRecord_Turns_TurnId",
                        column: x => x.TurnId,
                        principalTable: "Turns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Character_CharacterClassId",
                table: "Character",
                column: "CharacterClassId");

            migrationBuilder.CreateIndex(
                name: "IX_TurnAttackRecord_SkillId",
                table: "TurnAttackRecord",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_TurnAttackRecord_TurnId",
                table: "TurnAttackRecord",
                column: "TurnId");

            migrationBuilder.CreateIndex(
                name: "IX_Turns_AttackerId",
                table: "Turns",
                column: "AttackerId");

            migrationBuilder.CreateIndex(
                name: "IX_Turns_CombatStateId",
                table: "Turns",
                column: "CombatStateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TurnAttackRecord");

            migrationBuilder.DropTable(
                name: "Turns");

            migrationBuilder.DropTable(
                name: "Character");

            migrationBuilder.DropTable(
                name: "CombatState");

            migrationBuilder.DropTable(
                name: "SubClass");

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Description", "ElementalType", "Name", "StatTypeRatio" },
                values: new object[,]
                {
                    { 1, "", 1, "Name", "{\"Speed\":1.0}" },
                    { 2, "", 1, "Name", "{\"Speed\":1.0}" }
                });
        }
    }
}
