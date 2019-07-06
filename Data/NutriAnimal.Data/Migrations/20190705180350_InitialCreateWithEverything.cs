using Microsoft.EntityFrameworkCore.Migrations;

namespace NutriAnimal.Data.Migrations
{
    public partial class InitialCreateWithEverything : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Weight",
                table: "Products",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Products");
        }
    }
}
