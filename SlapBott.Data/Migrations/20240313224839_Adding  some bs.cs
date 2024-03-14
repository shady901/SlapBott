using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SlapBott.Data.Migrations
{
    /// <inheritdoc />
    public partial class Addingsomebs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Character_Users_DiscordID",
                table: "Character");

            migrationBuilder.DropForeignKey(
                name: "FK_Character_Users_TempCharacter_DiscordID",
                table: "Character");

            migrationBuilder.DropForeignKey(
                name: "FK_Character_Users_TemporaryCharacterId",
                table: "Character");

            migrationBuilder.DropForeignKey(
                name: "FK_Enemies_SubClass_CharacterClassId",
                table: "Enemies");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerCharacterCombatState_Character_ParticipantId",
                table: "PlayerCharacterCombatState");

            migrationBuilder.DropIndex(
                name: "IX_Character_DiscordID",
                table: "Character");

            migrationBuilder.DropIndex(
                name: "IX_Character_TempCharacter_DiscordID",
                table: "Character");

            migrationBuilder.DropIndex(
                name: "IX_Character_TemporaryCharacterId",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "TemporaryCharacterId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CharExp",
                table: "Enemies");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Enemies");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Enemies");

            migrationBuilder.DropColumn(
                name: "DiscordID",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "HasLeveled",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "TempCharacter_DiscordID",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "TemporaryCharacterId",
                table: "Character");

            migrationBuilder.RenameColumn(
                name: "CharacterClassId",
                table: "Enemies",
                newName: "CharacterId");

            migrationBuilder.RenameIndex(
                name: "IX_Enemies_CharacterClassId",
                table: "Enemies",
                newName: "IX_Enemies_CharacterId");

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
                        name: "FK_PlayerCharacter_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerCharacter_Users_RegistrationId",
                        column: x => x.RegistrationId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerCharacter_CharacterId",
                table: "PlayerCharacter",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerCharacter_RegistrationId",
                table: "PlayerCharacter",
                column: "RegistrationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enemies_Character_CharacterId",
                table: "Enemies",
                column: "CharacterId",
                principalTable: "Character",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerCharacterCombatState_PlayerCharacter_ParticipantId",
                table: "PlayerCharacterCombatState",
                column: "ParticipantId",
                principalTable: "PlayerCharacter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enemies_Character_CharacterId",
                table: "Enemies");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerCharacterCombatState_PlayerCharacter_ParticipantId",
                table: "PlayerCharacterCombatState");

            migrationBuilder.DropTable(
                name: "PlayerCharacter");

            migrationBuilder.RenameColumn(
                name: "CharacterId",
                table: "Enemies",
                newName: "CharacterClassId");

            migrationBuilder.RenameIndex(
                name: "IX_Enemies_CharacterId",
                table: "Enemies",
                newName: "IX_Enemies_CharacterClassId");

            migrationBuilder.AddColumn<int>(
                name: "TemporaryCharacterId",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<ulong>(
                name: "CharExp",
                table: "Enemies",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0ul);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Enemies",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Enemies",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "DiscordID",
                table: "Character",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Character",
                type: "TEXT",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "HasLeveled",
                table: "Character",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "TempCharacter_DiscordID",
                table: "Character",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TemporaryCharacterId",
                table: "Character",
                type: "INTEGER",
                nullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Enemies_SubClass_CharacterClassId",
                table: "Enemies",
                column: "CharacterClassId",
                principalTable: "SubClass",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerCharacterCombatState_Character_ParticipantId",
                table: "PlayerCharacterCombatState",
                column: "ParticipantId",
                principalTable: "Character",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
