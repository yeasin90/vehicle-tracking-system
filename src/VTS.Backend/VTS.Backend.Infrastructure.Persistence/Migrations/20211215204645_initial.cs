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
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SerialNumber = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "(DATETIME('now'))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehiclePositions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Latitude = table.Column<double>(type: "REAL", nullable: false),
                    Longitude = table.Column<double>(type: "REAL", nullable: false),
                    VehilceId = table.Column<Guid>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiclePositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehiclePositions_Vehicles_VehilceId",
                        column: x => x.VehilceId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehiclePositions_VehilceId",
                table: "VehiclePositions",
                column: "VehilceId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_Id_SerialNumber",
                table: "Vehicles",
                columns: new[] { "Id", "SerialNumber" },
                unique: true);
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
