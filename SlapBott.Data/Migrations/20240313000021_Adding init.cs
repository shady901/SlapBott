using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SlapBott.Data.Migrations
{
    /// <inheritdoc />
    public partial class Addinginit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CombatStates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ChannelID = table.Column<ulong>(type: "INTEGER", nullable: false),
                    CurrentTurnId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CombatStates", x => x.Id);
                    table.UniqueConstraint("AK_CombatStates_CurrentTurnId_Id", x => new { x.CurrentTurnId, x.Id });
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    ElementalType = table.Column<int>(type: "INTEGER", nullable: false),
                    StatTypeRatio = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubClass",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubClass", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enemies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    CharExp = table.Column<ulong>(type: "INTEGER", nullable: false),
                    CharacterClassId = table.Column<int>(type: "INTEGER", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enemies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enemies_SubClass_CharacterClassId",
                        column: x => x.CharacterClassId,
                        principalTable: "SubClass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnemyCombatState",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    ParticipantId = table.Column<int>(type: "INTEGER", nullable: false),
                    CombatStateId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnemyCombatState", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnemyCombatState_CombatStates_CombatStateId",
                        column: x => x.CombatStateId,
                        principalTable: "CombatStates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnemyCombatState_CombatStates_Id",
                        column: x => x.Id,
                        principalTable: "CombatStates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnemyCombatState_Enemies_ParticipantId",
                        column: x => x.ParticipantId,
                        principalTable: "Enemies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Character",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HasLeveled = table.Column<bool>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    CharExp = table.Column<ulong>(type: "INTEGER", nullable: false),
                    CharacterClassId = table.Column<int>(type: "INTEGER", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", maxLength: 21, nullable: false),
                    DiscordID = table.Column<int>(type: "INTEGER", nullable: true),
                    TempCharacter_DiscordID = table.Column<int>(type: "INTEGER", nullable: true),
                    TemporaryCharacterId = table.Column<int>(type: "INTEGER", nullable: true)
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
                name: "PlayerCharacterCombatState",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    ParticipantId = table.Column<int>(type: "INTEGER", nullable: false),
                    CombatStateId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerCharacterCombatState", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerCharacterCombatState_Character_ParticipantId",
                        column: x => x.ParticipantId,
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerCharacterCombatState_CombatStates_CombatStateId",
                        column: x => x.CombatStateId,
                        principalTable: "CombatStates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerCharacterCombatState_CombatStates_Id",
                        column: x => x.Id,
                        principalTable: "CombatStates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Turns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TurnId = table.Column<int>(type: "INTEGER", nullable: false),
                    CombatStateId = table.Column<int>(type: "INTEGER", nullable: false),
                    AttackerId = table.Column<int>(type: "INTEGER", nullable: false)
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
                        name: "FK_Turns_CombatStates_TurnId_CombatStateId",
                        columns: x => new { x.TurnId, x.CombatStateId },
                        principalTable: "CombatStates",
                        principalColumns: new[] { "CurrentTurnId", "Id" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DiscordId = table.Column<ulong>(type: "INTEGER", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    ActiveCharacterId = table.Column<int>(type: "INTEGER", nullable: false),
                    TemporaryCharacterId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Character_ActiveCharacterId",
                        column: x => x.ActiveCharacterId,
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TurnAttackRecord",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SkillId = table.Column<int>(type: "INTEGER", nullable: false),
                    TurnId = table.Column<int>(type: "INTEGER", nullable: false)
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
                name: "IX_Character_DiscordID",
                table: "Character",
                column: "DiscordID");

            migrationBuilder.CreateIndex(
                name: "IX_Character_TempCharacter_DiscordID",
                table: "Character",
                column: "TempCharacter_DiscordID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Character_TemporaryCharacterId",
                table: "Character",
                column: "TemporaryCharacterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Enemies_CharacterClassId",
                table: "Enemies",
                column: "CharacterClassId");

            migrationBuilder.CreateIndex(
                name: "IX_EnemyCombatState_CombatStateId",
                table: "EnemyCombatState",
                column: "CombatStateId");

            migrationBuilder.CreateIndex(
                name: "IX_EnemyCombatState_ParticipantId",
                table: "EnemyCombatState",
                column: "ParticipantId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerCharacterCombatState_CombatStateId",
                table: "PlayerCharacterCombatState",
                column: "CombatStateId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerCharacterCombatState_ParticipantId",
                table: "PlayerCharacterCombatState",
                column: "ParticipantId");

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
                name: "IX_Turns_TurnId_CombatStateId",
                table: "Turns",
                columns: new[] { "TurnId", "CombatStateId" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_ActiveCharacterId",
                table: "Users",
                column: "ActiveCharacterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Character_Users_DiscordID",
                table: "Character",
                column: "DiscordID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Character_Users_TempCharacter_DiscordID",
                table: "Character",
                column: "TempCharacter_DiscordID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Character_Users_TemporaryCharacterId",
                table: "Character",
                column: "TemporaryCharacterId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Character_SubClass_CharacterClassId",
                table: "Character");

            migrationBuilder.DropForeignKey(
                name: "FK_Character_Users_DiscordID",
                table: "Character");

            migrationBuilder.DropForeignKey(
                name: "FK_Character_Users_TempCharacter_DiscordID",
                table: "Character");

            migrationBuilder.DropForeignKey(
                name: "FK_Character_Users_TemporaryCharacterId",
                table: "Character");

            migrationBuilder.DropTable(
                name: "EnemyCombatState");

            migrationBuilder.DropTable(
                name: "PlayerCharacterCombatState");

            migrationBuilder.DropTable(
                name: "TurnAttackRecord");

            migrationBuilder.DropTable(
                name: "Enemies");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Turns");

            migrationBuilder.DropTable(
                name: "CombatStates");

            migrationBuilder.DropTable(
                name: "SubClass");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Character");
        }
    }
}
