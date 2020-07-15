using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace ParkingControll.Infra.Data.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prices",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Removed = table.Column<bool>(nullable: false),
                    Value = table.Column<decimal>(nullable: false),
                    Additional = table.Column<decimal>(nullable: false),
                    Tolerance = table.Column<int>(nullable: false),
                    Initial = table.Column<DateTime>(nullable: false),
                    Final = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Removed = table.Column<bool>(nullable: false),
                    Plate = table.Column<string>(nullable: false),
                    CameIn = table.Column<DateTime>(nullable: false),
                    Exited = table.Column<DateTime>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    TotalTimeInParking = table.Column<string>(nullable: true),
                    TotalTimePaid = table.Column<string>(nullable: true),
                    AmountPaid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prices");

            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
