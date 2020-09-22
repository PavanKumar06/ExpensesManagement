using Microsoft.EntityFrameworkCore.Migrations;

namespace ExpensesManagement.api.Migrations
{
    public partial class FinalTax : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FinalTaxes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    FoodAmount = table.Column<int>(nullable: false),
                    FuelAmount = table.Column<int>(nullable: false),
                    HraAmount = table.Column<int>(nullable: false),
                    TravelAmount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinalTaxes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FinalTaxes");
        }
    }
}
