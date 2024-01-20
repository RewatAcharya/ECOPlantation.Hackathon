using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECOPlantation.Migrations
{
    /// <inheritdoc />
    public partial class EditVisitors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "Visitors");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "Visitors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
