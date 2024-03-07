using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SlapBott.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingRegistration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DiscordID",
                table: "Character",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Character",
                type: "character varying(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DiscordId = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    ActiveCharacterId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Character_ActiveCharacterId",
                        column: x => x.ActiveCharacterId,
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Character_DiscordID",
                table: "Character",
                column: "DiscordID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ActiveCharacterId",
                table: "Users",
                column: "ActiveCharacterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Character_Users_DiscordID",
                table: "Character",
                column: "DiscordID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Character_Users_DiscordID",
                table: "Character");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Character_DiscordID",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "DiscordID",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Character");
        }
    }
}
