using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SlapBott.Data.Migrations
{
    /// <inheritdoc />
    public partial class Addingsomemorebs2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Character_SubClass_CharacterClassId",
                table: "Character");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubClass",
                table: "SubClass");

            migrationBuilder.RenameTable(
                name: "SubClass",
                newName: "CharacterClass");

            migrationBuilder.AddColumn<int>(
                name: "RaceId",
                table: "PlayerCharacter",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubClassId",
                table: "Character",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "CharacterClass",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "CharacterClass",
                type: "TEXT",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "CharacterClass",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "RequiredLevel",
                table: "CharacterClass",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CharacterClass",
                table: "CharacterClass",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Race",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Race", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerCharacter_RaceId",
                table: "PlayerCharacter",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Character_SubClassId",
                table: "Character",
                column: "SubClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Character_CharacterClass_CharacterClassId",
                table: "Character",
                column: "CharacterClassId",
                principalTable: "CharacterClass",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Character_CharacterClass_SubClassId",
                table: "Character",
                column: "SubClassId",
                principalTable: "CharacterClass",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerCharacter_Race_RaceId",
                table: "PlayerCharacter",
                column: "RaceId",
                principalTable: "Race",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Character_CharacterClass_CharacterClassId",
                table: "Character");

            migrationBuilder.DropForeignKey(
                name: "FK_Character_CharacterClass_SubClassId",
                table: "Character");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerCharacter_Race_RaceId",
                table: "PlayerCharacter");

            migrationBuilder.DropTable(
                name: "Race");

            migrationBuilder.DropIndex(
                name: "IX_PlayerCharacter_RaceId",
                table: "PlayerCharacter");

            migrationBuilder.DropIndex(
                name: "IX_Character_SubClassId",
                table: "Character");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CharacterClass",
                table: "CharacterClass");

            migrationBuilder.DropColumn(
                name: "RaceId",
                table: "PlayerCharacter");

            migrationBuilder.DropColumn(
                name: "SubClassId",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "CharacterClass");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "CharacterClass");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "CharacterClass");

            migrationBuilder.DropColumn(
                name: "RequiredLevel",
                table: "CharacterClass");

            migrationBuilder.RenameTable(
                name: "CharacterClass",
                newName: "SubClass");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubClass",
                table: "SubClass",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Character_SubClass_CharacterClassId",
                table: "Character",
                column: "CharacterClassId",
                principalTable: "SubClass",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
