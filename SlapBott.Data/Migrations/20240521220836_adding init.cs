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
                name: "DiscordGuilds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GuildId = table.Column<ulong>(type: "INTEGER", nullable: false),
                    CategoryId = table.Column<ulong>(type: "INTEGER", nullable: false),
                    ConfiguredChannels = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscordGuilds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CharacterId = table.Column<int>(type: "INTEGER", nullable: false),
                    Equiped = table.Column<string>(type: "TEXT", nullable: true),
                    Bag = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.Id);
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
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RegionName = table.Column<int>(type: "INTEGER", nullable: false),
                    isBossPending = table.Column<bool>(type: "INTEGER", nullable: false),
                    HasActiveBoss = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
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
                    RequiredWeaponType = table.Column<int>(type: "INTEGER", nullable: true),
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
                    CombatStateID = table.Column<int>(type: "INTEGER", nullable: false),
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
                        name: "FK_Characters_Inventories_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Characters_PlayersStats_StatsId",
                        column: x => x.StatsId,
                        principalTable: "PlayersStats",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Characters_Races_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Races",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateTable(
                name: "Enemies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CharacterId = table.Column<int>(type: "INTEGER", nullable: false),
                    IsDead = table.Column<bool>(type: "INTEGER", nullable: false),
                    RegionId = table.Column<int>(type: "INTEGER", nullable: true),
                    Discriminator = table.Column<string>(type: "TEXT", maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enemies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enemies_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Enemies_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id");
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
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Turns_CombatStates_TurnId_CombatStateId",
                        columns: x => new { x.TurnId, x.CombatStateId },
                        principalTable: "CombatStates",
                        principalColumns: new[] { "CurrentTurnId", "Id" });
                });

            migrationBuilder.CreateTable(
                name: "EnemyCombatState",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CombatStateId = table.Column<int>(type: "INTEGER", nullable: false),
                    ParticipantId = table.Column<int>(type: "INTEGER", nullable: false),
                    HadTurn = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnemyCombatState", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnemyCombatState_CombatStates_CombatStateId",
                        column: x => x.CombatStateId,
                        principalTable: "CombatStates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EnemyCombatState_Enemies_ParticipantId",
                        column: x => x.ParticipantId,
                        principalTable: "Enemies",
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
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TurnAttackRecord_Turns_TurnId",
                        column: x => x.TurnId,
                        principalTable: "Turns",
                        principalColumn: "Id");
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
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PlayerCharacterCombatState",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CombatStateId = table.Column<int>(type: "INTEGER", nullable: false),
                    ParticipantId = table.Column<int>(type: "INTEGER", nullable: false),
                    HadTurn = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerCharacterCombatState", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerCharacterCombatState_CombatStates_CombatStateId",
                        column: x => x.CombatStateId,
                        principalTable: "CombatStates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlayerCharacterCombatState_PlayerCharacter_ParticipantId",
                        column: x => x.ParticipantId,
                        principalTable: "PlayerCharacter",
                        principalColumn: "Id");
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
                    { 2, "{\"Dexterity\":4,\"Strength\":4,\"Intelligence\":4,\"CritChance\":0,\"MaxHealth\":100,\"Health\":100,\"AttackDamage\":0,\"ArmorRating\":0,\"DodgeChance\":5,\"ChaosResistance\":0,\"FireResistance\":0,\"PhysicalResistance\":0,\"FrostResistance\":0,\"LightningResistance\":0,\"SpellPower\":0,\"PhysicalDamage\":0,\"ElementalDamage\":0,\"Speed\":0,\"ChaosDamage\":0}", 2, "{\"MaxHealth\":20}" },
                    { 5, "{\"Dexterity\":4,\"Strength\":4,\"Intelligence\":4,\"CritChance\":0,\"MaxHealth\":100,\"Health\":100,\"AttackDamage\":0,\"ArmorRating\":0,\"DodgeChance\":5,\"ChaosResistance\":0,\"FireResistance\":0,\"PhysicalResistance\":0,\"FrostResistance\":0,\"LightningResistance\":0,\"SpellPower\":0,\"PhysicalDamage\":0,\"ElementalDamage\":0,\"Speed\":0,\"ChaosDamage\":0}", 5, "{\"MaxHealth\":20}" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "HasActiveBoss", "RegionName", "isBossPending" },
                values: new object[,]
                {
                    { 1, false, 5, false },
                    { 2, false, 4, false },
                    { 3, false, 1, false },
                    { 4, false, 3, false },
                    { 5, false, 2, false },
                    { 6, false, 0, false }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Description", "ElementalType", "Name", "RequiredWeaponType", "StatTypeRatio" },
                values: new object[] { 1, "You use All your force to create a Powerfull Strike", 4, "Strike", null, "{\"Strength\":0.4,\"Dexterity\":0.3,\"Intelligence\":0.25}" });

            migrationBuilder.InsertData(
                table: "EnemyTemplates",
                columns: new[] { "Id", "ClassId", "Description", "LearnedSkillIds", "Name", "RaceId", "Stats" },
                values: new object[] { 1, 1, "a Pile of bones that has formed a silhouette of a Humanoid", "[1]", "Skeleton Warrior", 5, "{\"resistanceTypes\":[10,14,11,12,13],\"Id\":0,\"stats\":{\"Dexterity\":0,\"Strength\":0,\"Intelligence\":0,\"CritChance\":0,\"MaxHealth\":0,\"Health\":0,\"AttackDamage\":0,\"ArmorRating\":0,\"DodgeChance\":0,\"ChaosResistance\":0,\"FireResistance\":0,\"PhysicalResistance\":0,\"FrostResistance\":0,\"LightningResistance\":0,\"SpellPower\":0,\"PhysicalDamage\":0,\"ElementalDamage\":0,\"Speed\":0,\"ChaosDamage\":0},\"Health\":0,\"MaxHealth\":0,\"Strength\":0,\"Dexterity\":0,\"Intelligence\":0,\"CritChance\":0,\"AttackDamage\":0,\"SpellPower\":0,\"ChaosResistance\":0,\"FireResistance\":0,\"PhysicalResistance\":0,\"FrostResistance\":0,\"LightningResistance\":0,\"ArmorRating\":0,\"DodgeChance\":0}" });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_ClassId",
                table: "Characters",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_InventoryId",
                table: "Characters",
                column: "InventoryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Characters_RaceId",
                table: "Characters",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_StatsId",
                table: "Characters",
                column: "StatsId");

            migrationBuilder.CreateIndex(
                name: "IX_Enemies_CharacterId",
                table: "Enemies",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Enemies_RegionId",
                table: "Enemies",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_EnemyCombatState_CombatStateId",
                table: "EnemyCombatState",
                column: "CombatStateId");

            migrationBuilder.CreateIndex(
                name: "IX_EnemyCombatState_ParticipantId",
                table: "EnemyCombatState",
                column: "ParticipantId");

            migrationBuilder.CreateIndex(
                name: "IX_EnemyTemplates_ClassId",
                table: "EnemyTemplates",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_EnemyTemplates_RaceId",
                table: "EnemyTemplates",
                column: "RaceId");

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
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_CharacterClasses_ClassId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Inventories_InventoryId",
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
                name: "DiscordGuilds");

            migrationBuilder.DropTable(
                name: "EnemyCombatState");

            migrationBuilder.DropTable(
                name: "EnemyTemplates");

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
                name: "Regions");

            migrationBuilder.DropTable(
                name: "CombatStates");

            migrationBuilder.DropTable(
                name: "CharacterClasses");

            migrationBuilder.DropTable(
                name: "Inventories");

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
