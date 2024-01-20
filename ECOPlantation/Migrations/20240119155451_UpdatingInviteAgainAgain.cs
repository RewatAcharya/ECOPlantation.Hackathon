using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECOPlantation.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingInviteAgainAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EventName",
                table: "Invites",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventName",
                table: "Invites");
        }
    }
}
