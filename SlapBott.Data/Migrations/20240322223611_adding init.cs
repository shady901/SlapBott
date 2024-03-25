using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SlapBott.Data.Migrations
{
    /// <inheritdoc />
    public partial class addinginit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "PlayersStats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    stats = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayersStats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Races",
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
                    table.PrimaryKey("PK_Races", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    ElementalType = table.Column<int>(type: "INTEGER", nullable: false),
                    StatTypeRatio = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    CharExp = table.Column<ulong>(type: "INTEGER", nullable: false),
                    StatsId = table.Column<int>(type: "INTEGER", nullable: false),
                    InventoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    RaceId = table.Column<int>(type: "INTEGER", nullable: true),
                    ClassId = table.Column<int>(type: "INTEGER", nullable: true),
                    LearnedSkillIds = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Characters_CharacterClasses_ClassId",
                        column: x => x.ClassId,
                        principalTable: "CharacterClasses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Characters_PlayersStats_StatsId",
                        column: x => x.StatsId,
                        principalTable: "PlayersStats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Characters_Races_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Races",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Enemies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CharacterId = table.Column<int>(type: "INTEGER", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enemies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enemies_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CharacterId = table.Column<int>(type: "INTEGER", nullable: false),
                    Equiped = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventories_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
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
                        name: "FK_Turns_Characters_AttackerId",
                        column: x => x.AttackerId,
                        principalTable: "Characters",
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
                name: "Equipment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ItemID = table.Column<int>(type: "INTEGER", nullable: false),
                    CharID = table.Column<int>(type: "INTEGER", nullable: false),
                    Seed = table.Column<ulong>(type: "INTEGER", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    ItemLevel = table.Column<int>(type: "INTEGER", nullable: false),
                    SlotID = table.Column<int>(type: "INTEGER", nullable: false),
                    Count = table.Column<int>(type: "INTEGER", nullable: false),
                    InventoryId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipment_Inventories_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventories",
                        principalColumn: "Id");
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

            migrationBuilder.CreateTable(
                name: "PlayerCharacter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HasLeveled = table.Column<bool>(type: "INTEGER", nullable: false),
                    DiscordId = table.Column<ulong>(type: "INTEGER", nullable: false),
                    RegistrationId = table.Column<int>(type: "INTEGER", nullable: false),
                    CharacterId = table.Column<int>(type: "INTEGER", nullable: false),
                    IsTemp = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerCharacter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerCharacter_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
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
                    table.ForeignKey(
                        name: "FK_PlayerCharacterCombatState_PlayerCharacter_ParticipantId",
                        column: x => x.ParticipantId,
                        principalTable: "PlayerCharacter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Registration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DiscordId = table.Column<ulong>(type: "INTEGER", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    ActiveCharacterId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registration", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Registration_PlayerCharacter_ActiveCharacterId",
                        column: x => x.ActiveCharacterId,
                        principalTable: "PlayerCharacter",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "CharacterClasses",
                columns: new[] { "Id", "BaseStats", "Name", "PerLevelStats" },
                values: new object[,]
                {
                    { 1, "{\"Dexterity\":4,\"Strength\":4,\"Intelligence\":4,\"CritChance\":0,\"MaxHealth\":100,\"Health\":100,\"AttackDamage\":0,\"ArmorRating\":0,\"DodgeChance\":5,\"ChaosResistance\":0,\"FireResistance\":0,\"PhysicalResistance\":0,\"FrostResistance\":0,\"LightningResistance\":0,\"SpellPower\":0,\"PhysicalDamage\":0,\"ElementalDamage\":0,\"Speed\":0,\"ChaosDamage\":0}", 1, "{\"MaxHealth\":20,\"Strength\":1}" },
                    { 2, "{\"Dexterity\":4,\"Strength\":4,\"Intelligence\":4,\"CritChance\":0,\"MaxHealth\":100,\"Health\":100,\"AttackDamage\":0,\"ArmorRating\":0,\"DodgeChance\":5,\"ChaosResistance\":0,\"FireResistance\":0,\"PhysicalResistance\":0,\"FrostResistance\":0,\"LightningResistance\":0,\"SpellPower\":0,\"PhysicalDamage\":0,\"ElementalDamage\":0,\"Speed\":0,\"ChaosDamage\":0}", 2, "{\"SpellPower\":1,\"Intelligence\":1}" }
                });

            migrationBuilder.InsertData(
                table: "Races",
                columns: new[] { "Id", "BaseStats", "Name", "PerLevelStats" },
                values: new object[,]
                {
                    { 1, "{\"Dexterity\":4,\"Strength\":4,\"Intelligence\":4,\"CritChance\":0,\"MaxHealth\":100,\"Health\":100,\"AttackDamage\":0,\"ArmorRating\":0,\"DodgeChance\":5,\"ChaosResistance\":0,\"FireResistance\":0,\"PhysicalResistance\":0,\"FrostResistance\":0,\"LightningResistance\":0,\"SpellPower\":0,\"PhysicalDamage\":0,\"ElementalDamage\":0,\"Speed\":0,\"ChaosDamage\":0}", 1, "{\"Dexterity\":1}" },
                    { 2, "{\"Dexterity\":4,\"Strength\":4,\"Intelligence\":4,\"CritChance\":0,\"MaxHealth\":100,\"Health\":100,\"AttackDamage\":0,\"ArmorRating\":0,\"DodgeChance\":5,\"ChaosResistance\":0,\"FireResistance\":0,\"PhysicalResistance\":0,\"FrostResistance\":0,\"LightningResistance\":0,\"SpellPower\":0,\"PhysicalDamage\":0,\"ElementalDamage\":0,\"Speed\":0,\"ChaosDamage\":0}", 2, "{\"MaxHealth\":20}" }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Description", "ElementalType", "Name", "StatTypeRatio" },
                values: new object[] { 1, "You use All your force to create a Powerfull Strike", 4, "Strike", "{\"Strength\":0.4,\"Dexterity\":0.3,\"Intelligence\":0.25}" });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_ClassId",
                table: "Characters",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_RaceId",
                table: "Characters",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_StatsId",
                table: "Characters",
                column: "StatsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Enemies_CharacterId",
                table: "Enemies",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_EnemyCombatState_CombatStateId",
                table: "EnemyCombatState",
                column: "CombatStateId");

            migrationBuilder.CreateIndex(
                name: "IX_EnemyCombatState_ParticipantId",
                table: "EnemyCombatState",
                column: "ParticipantId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_InventoryId",
                table: "Equipment",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_CharacterId",
                table: "Inventories",
                column: "CharacterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlayerCharacter_CharacterId",
                table: "PlayerCharacter",
                column: "CharacterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlayerCharacter_RegistrationId",
                table: "PlayerCharacter",
                column: "RegistrationId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerCharacterCombatState_CombatStateId",
                table: "PlayerCharacterCombatState",
                column: "CombatStateId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerCharacterCombatState_ParticipantId",
                table: "PlayerCharacterCombatState",
                column: "ParticipantId");

            migrationBuilder.CreateIndex(
                name: "IX_Registration_ActiveCharacterId",
                table: "Registration",
                column: "ActiveCharacterId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerCharacter_Registration_RegistrationId",
                table: "PlayerCharacter",
                column: "RegistrationId",
                principalTable: "Registration",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_CharacterClasses_ClassId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_PlayersStats_StatsId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Races_RaceId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerCharacter_Characters_CharacterId",
                table: "PlayerCharacter");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerCharacter_Registration_RegistrationId",
                table: "PlayerCharacter");

            migrationBuilder.DropTable(
                name: "EnemyCombatState");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "PlayerCharacterCombatState");

            migrationBuilder.DropTable(
                name: "TurnAttackRecord");

            migrationBuilder.DropTable(
                name: "Enemies");

            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Turns");

            migrationBuilder.DropTable(
                name: "CombatStates");

            migrationBuilder.DropTable(
                name: "CharacterClasses");

            migrationBuilder.DropTable(
                name: "PlayersStats");

            migrationBuilder.DropTable(
                name: "Races");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Registration");

            migrationBuilder.DropTable(
                name: "PlayerCharacter");
        }
    }
}
