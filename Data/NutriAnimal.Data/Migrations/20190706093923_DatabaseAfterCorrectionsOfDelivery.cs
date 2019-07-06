using Microsoft.EntityFrameworkCore.Migrations;

namespace NutriAnimal.Data.Migrations
{
    public partial class DatabaseAfterCorrectionsOfDelivery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "Deliveries");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "Deliveries",
                nullable: false,
                defaultValue: 0);
        }
    }
}
