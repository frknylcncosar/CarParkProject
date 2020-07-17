using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarPark.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Park",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParkingSpace = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Park", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Plaka = table.Column<string>(maxLength: 15, nullable: false),
                    ParkId = table.Column<int>(nullable: false),
                    EntryTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_Park_ParkId",
                        column: x => x.ParkId,
                        principalTable: "Park",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Park",
                columns: new[] { "Id", "ParkingSpace" },
                values: new object[] { 1, 0 });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "EntryTime", "ParkId", "Plaka" },
                values: new object[] { 1, new DateTime(2015, 6, 15, 13, 45, 0, 0, DateTimeKind.Unspecified), 1, "01FYC01" });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "EntryTime", "ParkId", "Plaka" },
                values: new object[] { 2, new DateTime(2015, 6, 15, 13, 45, 0, 0, DateTimeKind.Unspecified), 1, "01FYC01" });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ParkId",
                table: "Cars",
                column: "ParkId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Park");
        }
    }
}
