using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvidentaMasini.Data.Migrations
{
    public partial class secondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "combustionTypes",
                columns: table => new
                {
                    combustionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    combustion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_combustionTypes", x => x.combustionId);
                });

            migrationBuilder.CreateTable(
                name: "cars",
                columns: table => new
                {
                    vin = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    make = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    capacity = table.Column<int>(type: "int", nullable: false),
                    combustionId = table.Column<int>(type: "int", nullable: false),
                    weight = table.Column<int>(type: "int", nullable: false),
                    color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    power = table.Column<int>(type: "int", nullable: false),
                    civ = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    plates = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    registration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    owner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    revision = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cars", x => x.vin);
                    table.ForeignKey(
                        name: "FK_cars_combustionTypes_combustionId",
                        column: x => x.combustionId,
                        principalTable: "combustionTypes",
                        principalColumn: "combustionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cars_combustionId",
                table: "cars",
                column: "combustionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cars");

            migrationBuilder.DropTable(
                name: "combustionTypes");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");
        }
    }
}
