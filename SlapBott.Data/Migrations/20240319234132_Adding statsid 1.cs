using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SlapBott.Data.Migrations
{
    /// <inheritdoc />
    public partial class Addingstatsid1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayersStats_Character_CharacterId",
                table: "PlayersStats");

            migrationBuilder.DropIndex(
                name: "IX_PlayersStats_CharacterId",
                table: "PlayersStats");

            migrationBuilder.DropColumn(
                name: "CharacterId",
                table: "PlayersStats");

            migrationBuilder.CreateIndex(
                name: "IX_Character_StatsId",
                table: "Character",
                column: "StatsId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Character_PlayersStats_StatsId",
                table: "Character",
                column: "StatsId",
                principalTable: "PlayersStats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Character_PlayersStats_StatsId",
                table: "Character");

            migrationBuilder.DropIndex(
                name: "IX_Character_StatsId",
                table: "Character");

            migrationBuilder.AddColumn<int>(
                name: "CharacterId",
                table: "PlayersStats",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PlayersStats_CharacterId",
                table: "PlayersStats",
                column: "CharacterId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayersStats_Character_CharacterId",
                table: "PlayersStats",
                column: "CharacterId",
                principalTable: "Character",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
