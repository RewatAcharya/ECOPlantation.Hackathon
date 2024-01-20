using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECOPlantation.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlantCounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoOfPlants = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantCounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DonationRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestPhotoURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonationRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DonationRequests_ApplicationUsers_RequestedBy",
                        column: x => x.RequestedBy,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Organiser = table.Column<int>(type: "int", nullable: false),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invites_ApplicationUsers_Organiser",
                        column: x => x.Organiser,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DonationPayments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DonatedBy = table.Column<int>(type: "int", nullable: false),
                    DonatedUserId = table.Column<int>(type: "int", nullable: true),
                    RequestedDonation = table.Column<int>(type: "int", nullable: false),
                    TotalDonation = table.Column<double>(type: "float", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonationPayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DonationPayments_ApplicationUsers_DonatedUserId",
                        column: x => x.DonatedUserId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DonationPayments_DonationRequests_RequestedDonation",
                        column: x => x.RequestedDonation,
                        principalTable: "DonationRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Visitors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VistorID = table.Column<int>(type: "int", nullable: false),
                    InviteID = table.Column<int>(type: "int", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Visitors_ApplicationUsers_VistorID",
                        column: x => x.VistorID,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Visitors_Invites_InviteID",
                        column: x => x.InviteID,
                        principalTable: "Invites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DonationPayments_DonatedUserId",
                table: "DonationPayments",
                column: "DonatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DonationPayments_RequestedDonation",
                table: "DonationPayments",
                column: "RequestedDonation");

            migrationBuilder.CreateIndex(
                name: "IX_DonationRequests_RequestedBy",
                table: "DonationRequests",
                column: "RequestedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Invites_Organiser",
                table: "Invites",
                column: "Organiser");

            migrationBuilder.CreateIndex(
                name: "IX_Visitors_InviteID",
                table: "Visitors",
                column: "InviteID");

            migrationBuilder.CreateIndex(
                name: "IX_Visitors_VistorID",
                table: "Visitors",
                column: "VistorID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DonationPayments");

            migrationBuilder.DropTable(
                name: "PlantCounts");

            migrationBuilder.DropTable(
                name: "Visitors");

            migrationBuilder.DropTable(
                name: "DonationRequests");

            migrationBuilder.DropTable(
                name: "Invites");

            migrationBuilder.DropTable(
                name: "ApplicationUsers");
        }
    }
}
