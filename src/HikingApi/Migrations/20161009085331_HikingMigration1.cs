using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HikingApi.Migrations
{
    public partial class HikingMigration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trails",
                columns: table => new
                {
                    TrailId = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Difficulty = table.Column<decimal>(nullable: false),
                    Length = table.Column<decimal>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Rating = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trails", x => x.TrailId);
                });

            migrationBuilder.CreateTable(
                name: "MapPoints",
                columns: table => new
                {
                    MapPointId = table.Column<string>(nullable: false),
                    Elevation = table.Column<double>(nullable: false),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    Order = table.Column<double>(nullable: false),
                    TrailId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MapPoints", x => x.MapPointId);
                    table.ForeignKey(
                        name: "FK_MapPoints_Trails_TrailId",
                        column: x => x.TrailId,
                        principalTable: "Trails",
                        principalColumn: "TrailId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MapPoints_TrailId",
                table: "MapPoints",
                column: "TrailId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MapPoints");

            migrationBuilder.DropTable(
                name: "Trails");
        }
    }
}
