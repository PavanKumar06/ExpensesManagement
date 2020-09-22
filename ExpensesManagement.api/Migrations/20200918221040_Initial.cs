using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExpensesManagement.api.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaxExemptions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    FoodAmount = table.Column<int>(nullable: false),
                    FuelAmount = table.Column<int>(nullable: false),
                    HraAmount = table.Column<int>(nullable: false),
                    TravelAmount = table.Column<int>(nullable: false),
                    FoodPath = table.Column<string>(nullable: true),
                    FuelPath = table.Column<string>(nullable: true),
                    HraPath = table.Column<string>(nullable: true),
                    TravelPath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxExemptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: true),
                    DateOfJoining = table.Column<DateTime>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true),
                    Salary = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaxExemptions");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
