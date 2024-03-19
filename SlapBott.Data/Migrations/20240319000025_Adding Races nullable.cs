using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SlapBott.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingRacesnullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Character_Races_RaceId",
                table: "Character");

            migrationBuilder.AlterColumn<int>(
                name: "RaceId",
                table: "Character",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Character_Races_RaceId",
                table: "Character",
                column: "RaceId",
                principalTable: "Races",
                principalColumn: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Character_Races_RaceId",
                table: "Character");

            migrationBuilder.AlterColumn<int>(
                name: "RaceId",
                table: "Character",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Character_Races_RaceId",
                table: "Character",
                column: "RaceId",
                principalTable: "Races",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
