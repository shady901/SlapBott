using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SlapBott.Data.Migrations
{
    /// <inheritdoc />
    public partial class Addingaddednotmapped : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhysicalPower",
                table: "PlayersStats");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PhysicalPower",
                table: "PlayersStats",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
