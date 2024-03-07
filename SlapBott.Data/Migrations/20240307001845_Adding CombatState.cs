using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SlapBott.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingCombatState : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Turns_CombatStates_Id_TurnId",
                table: "Turns");

            migrationBuilder.DropIndex(
                name: "IX_Turns_Id_TurnId",
                table: "Turns");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_CombatStates_Id_CurrentTurnId",
                table: "CombatStates");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Turns",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_CombatStates_CurrentTurnId_Id",
                table: "CombatStates",
                columns: new[] { "CurrentTurnId", "Id" });

            migrationBuilder.CreateIndex(
                name: "IX_Turns_TurnId_CombatStateId",
                table: "Turns",
                columns: new[] { "TurnId", "CombatStateId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Turns_CombatStates_TurnId_CombatStateId",
                table: "Turns",
                columns: new[] { "TurnId", "CombatStateId" },
                principalTable: "CombatStates",
                principalColumns: new[] { "CurrentTurnId", "Id" },
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Turns_CombatStates_TurnId_CombatStateId",
                table: "Turns");

            migrationBuilder.DropIndex(
                name: "IX_Turns_TurnId_CombatStateId",
                table: "Turns");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_CombatStates_CurrentTurnId_Id",
                table: "CombatStates");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Turns",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_CombatStates_Id_CurrentTurnId",
                table: "CombatStates",
                columns: new[] { "Id", "CurrentTurnId" });

            migrationBuilder.CreateIndex(
                name: "IX_Turns_Id_TurnId",
                table: "Turns",
                columns: new[] { "Id", "TurnId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Turns_CombatStates_Id_TurnId",
                table: "Turns",
                columns: new[] { "Id", "TurnId" },
                principalTable: "CombatStates",
                principalColumns: new[] { "Id", "CurrentTurnId" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
