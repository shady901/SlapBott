using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SlapBott.Data.Migrations
{
    /// <inheritdoc />
    public partial class combatstateforeignkeychanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EnemyCombatState_CombatStates_Id",
                table: "EnemyCombatState");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerCharacterCombatState_CombatStates_Id",
                table: "PlayerCharacterCombatState");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "PlayerCharacterCombatState",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "EnemyCombatState",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "PlayerCharacterCombatState",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "EnemyCombatState",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddForeignKey(
                name: "FK_EnemyCombatState_CombatStates_Id",
                table: "EnemyCombatState",
                column: "Id",
                principalTable: "CombatStates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerCharacterCombatState_CombatStates_Id",
                table: "PlayerCharacterCombatState",
                column: "Id",
                principalTable: "CombatStates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
