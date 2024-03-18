using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SlapBott.Data.Migrations
{
    /// <inheritdoc />
    public partial class addingsomechanges2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PlayerCharacter_CharacterId",
                table: "PlayerCharacter");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerCharacter_CharacterId",
                table: "PlayerCharacter",
                column: "CharacterId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PlayerCharacter_CharacterId",
                table: "PlayerCharacter");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerCharacter_CharacterId",
                table: "PlayerCharacter",
                column: "CharacterId");
        }
    }
}
