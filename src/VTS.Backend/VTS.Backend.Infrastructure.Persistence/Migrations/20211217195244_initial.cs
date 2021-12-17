using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VTS.Backend.Infrastructure.Persistence.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SerialNumber = table.Column<string>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedDateTimeStampInSeconds = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehiclePositions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Latitude = table.Column<double>(type: "REAL", nullable: false),
                    Longitude = table.Column<double>(type: "REAL", nullable: false),
                    VehicleId = table.Column<long>(type: "INTEGER", nullable: false),
                    CreatedDateTimeStampInSeconds = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiclePositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehiclePositions_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehiclePositions_CreatedDateTimeStampInSeconds",
                table: "VehiclePositions",
                column: "CreatedDateTimeStampInSeconds");

            migrationBuilder.CreateIndex(
                name: "IX_VehiclePositions_VehicleId",
                table: "VehiclePositions",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_Id",
                table: "Vehicles",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_SerialNumber",
                table: "Vehicles",
                column: "SerialNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_UserId",
                table: "Vehicles",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehiclePositions");

            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
