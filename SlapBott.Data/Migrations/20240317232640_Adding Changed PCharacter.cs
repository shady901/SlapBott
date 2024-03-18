using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SlapBott.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingChangedPCharacter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "CharacterClass");

            migrationBuilder.DropTable(
                name: "Race");

            migrationBuilder.DropIndex(
                name: "IX_PlayerCharacter_RaceId",
                table: "PlayerCharacter");

            migrationBuilder.DropIndex(
                name: "IX_Character_CharacterClassId",
                table: "Character");

            migrationBuilder.DropIndex(
                name: "IX_Character_SubClassId",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "RaceId",
                table: "PlayerCharacter");

            migrationBuilder.DropColumn(
                name: "CharacterClassId",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "SubClassId",
                table: "Character");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Character",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RaceId",
                table: "PlayerCharacter",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Character",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CharacterClassId",
                table: "Character",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SubClassId",
                table: "Character",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CharacterClass",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", maxLength: 21, nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    RequiredLevel = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterClass", x => x.Id);
                });

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
                name: "IX_Character_CharacterClassId",
                table: "Character",
                column: "CharacterClassId");

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
    }
}
