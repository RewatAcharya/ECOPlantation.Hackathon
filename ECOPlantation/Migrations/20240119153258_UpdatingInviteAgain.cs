using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECOPlantation.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingInviteAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Invites",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Invites",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Invites");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Invites");
        }
    }
}
