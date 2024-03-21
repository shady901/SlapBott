using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SlapBott.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingSkills : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Character_CharacterClasses_ClassId",
                table: "Character");

            migrationBuilder.DropForeignKey(
                name: "FK_Character_PlayersStats_StatsId",
                table: "Character");

            migrationBuilder.DropForeignKey(
                name: "FK_Character_Races_RaceId",
                table: "Character");

            migrationBuilder.DropForeignKey(
                name: "FK_Enemies_Character_CharacterId",
                table: "Enemies");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Character_CharacterId",
                table: "Inventories");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerCharacter_Character_CharacterId",
                table: "PlayerCharacter");

            migrationBuilder.DropForeignKey(
                name: "FK_Turns_Character_AttackerId",
                table: "Turns");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Character",
                table: "Character");

            migrationBuilder.RenameTable(
                name: "Character",
                newName: "Characters");

            migrationBuilder.RenameIndex(
                name: "IX_Character_StatsId",
                table: "Characters",
                newName: "IX_Characters_StatsId");

            migrationBuilder.RenameIndex(
                name: "IX_Character_RaceId",
                table: "Characters",
                newName: "IX_Characters_RaceId");

            migrationBuilder.RenameIndex(
                name: "IX_Character_ClassId",
                table: "Characters",
                newName: "IX_Characters_ClassId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Skills",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<int>(
                name: "CharacterId",
                table: "Skills",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LearnedSkill",
                table: "Characters",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Characters",
                table: "Characters",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "CharacterId", "Description", "ElementalType", "Name", "StatTypeRatio" },
                values: new object[] { 1, null, "You use All your force to create a Powerfull Strike", 4, "Strike", "{\"Strength\":0.4,\"Dexterity\":0.3,\"Intelligence\":0.25}" });

            migrationBuilder.CreateIndex(
                name: "IX_Skills_CharacterId",
                table: "Skills",
                column: "CharacterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_CharacterClasses_ClassId",
                table: "Characters",
                column: "ClassId",
                principalTable: "CharacterClasses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_PlayersStats_StatsId",
                table: "Characters",
                column: "StatsId",
                principalTable: "PlayersStats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Races_RaceId",
                table: "Characters",
                column: "RaceId",
                principalTable: "Races",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Enemies_Characters_CharacterId",
                table: "Enemies",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Characters_CharacterId",
                table: "Inventories",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerCharacter_Characters_CharacterId",
                table: "PlayerCharacter",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Characters_CharacterId",
                table: "Skills",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Turns_Characters_AttackerId",
                table: "Turns",
                column: "AttackerId",
                principalTable: "Characters",
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
                name: "FK_Enemies_Characters_CharacterId",
                table: "Enemies");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Characters_CharacterId",
                table: "Inventories");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerCharacter_Characters_CharacterId",
                table: "PlayerCharacter");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Characters_CharacterId",
                table: "Skills");

            migrationBuilder.DropForeignKey(
                name: "FK_Turns_Characters_AttackerId",
                table: "Turns");

            migrationBuilder.DropIndex(
                name: "IX_Skills_CharacterId",
                table: "Skills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Characters",
                table: "Characters");

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "CharacterId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "LearnedSkill",
                table: "Characters");

            migrationBuilder.RenameTable(
                name: "Characters",
                newName: "Character");

            migrationBuilder.RenameIndex(
                name: "IX_Characters_StatsId",
                table: "Character",
                newName: "IX_Character_StatsId");

            migrationBuilder.RenameIndex(
                name: "IX_Characters_RaceId",
                table: "Character",
                newName: "IX_Character_RaceId");

            migrationBuilder.RenameIndex(
                name: "IX_Characters_ClassId",
                table: "Character",
                newName: "IX_Character_ClassId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Skills",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Character",
                table: "Character",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Character_CharacterClasses_ClassId",
                table: "Character",
                column: "ClassId",
                principalTable: "CharacterClasses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Character_PlayersStats_StatsId",
                table: "Character",
                column: "StatsId",
                principalTable: "PlayersStats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Character_Races_RaceId",
                table: "Character",
                column: "RaceId",
                principalTable: "Races",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Enemies_Character_CharacterId",
                table: "Enemies",
                column: "CharacterId",
                principalTable: "Character",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Character_CharacterId",
                table: "Inventories",
                column: "CharacterId",
                principalTable: "Character",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerCharacter_Character_CharacterId",
                table: "PlayerCharacter",
                column: "CharacterId",
                principalTable: "Character",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Turns_Character_AttackerId",
                table: "Turns",
                column: "AttackerId",
                principalTable: "Character",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
