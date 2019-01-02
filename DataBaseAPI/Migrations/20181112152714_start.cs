using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBaseAPI.Migrations
{
    public partial class start : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HornTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    Decoration = table.Column<string>(nullable: true),
                    Material = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HornTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Unicorns",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Breed = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsSold = table.Column<bool>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Origin = table.Column<string>(nullable: true),
                    HornTypesId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unicorns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Unicorns_HornTypes_HornTypesId",
                        column: x => x.HornTypesId,
                        principalTable: "HornTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Unicorns_HornTypesId",
                table: "Unicorns",
                column: "HornTypesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Unicorns");

            migrationBuilder.DropTable(
                name: "HornTypes");
        }
    }
}
