using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SlapBott.Data.Migrations
{
    /// <inheritdoc />
    public partial class Addingchangedcombatstate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "PlayerCharacterCombatState",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "EnemyCombatState",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "CombatStateID",
                table: "Characters",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "PlayerCharacterCombatState");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "EnemyCombatState");

            migrationBuilder.DropColumn(
                name: "CombatStateID",
                table: "Characters");
        }
    }
}
