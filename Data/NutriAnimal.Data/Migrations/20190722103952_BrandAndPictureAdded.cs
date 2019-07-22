using Microsoft.EntityFrameworkCore.Migrations;

namespace NutriAnimal.Data.Migrations
{
    public partial class BrandAndPictureAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PricePerDelivery",
                table: "DeliveryCompanies");

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "Products",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Products");

            migrationBuilder.AddColumn<decimal>(
                name: "PricePerDelivery",
                table: "DeliveryCompanies",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
