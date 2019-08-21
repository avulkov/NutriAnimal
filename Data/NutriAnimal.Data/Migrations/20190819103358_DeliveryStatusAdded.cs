using Microsoft.EntityFrameworkCore.Migrations;

namespace NutriAnimal.Data.Migrations
{
    public partial class DeliveryStatusAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StatusId",
                table: "Deliveries",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_StatusId",
                table: "Deliveries",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_Statuses_StatusId",
                table: "Deliveries",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_Statuses_StatusId",
                table: "Deliveries");

            migrationBuilder.DropIndex(
                name: "IX_Deliveries_StatusId",
                table: "Deliveries");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Deliveries");
        }
    }
}
