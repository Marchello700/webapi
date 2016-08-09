using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AcademySample.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsageData",
                columns: table => new
                {
                    UsageDataId = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    ComputerDetailId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    availableDiskSpace = table.Column<int>(nullable: false),
                    cpuUsage = table.Column<int>(nullable: false),
                    memoryUsage = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsageData", x => x.UsageDataId);
                });

            migrationBuilder.AddColumn<int>(
                name: "ComputerDetailId",
                table: "ComputerDetails",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ComputerDetailId",
                table: "ComputerDetails");

            migrationBuilder.DropTable(
                name: "UsageData");
        }
    }
}
