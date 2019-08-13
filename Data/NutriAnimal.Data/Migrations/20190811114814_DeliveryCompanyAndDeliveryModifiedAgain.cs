using Microsoft.EntityFrameworkCore.Migrations;

namespace NutriAnimal.Data.Migrations
{
    public partial class DeliveryCompanyAndDeliveryModifiedAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_AspNetUsers_RecipientId",
                table: "Deliveries");

            migrationBuilder.DropIndex(
                name: "IX_Deliveries_RecipientId",
                table: "Deliveries");

            migrationBuilder.RenameColumn(
                name: "RecipientId",
                table: "Deliveries",
                newName: "Recipient");

            migrationBuilder.AlterColumn<string>(
                name: "Recipient",
                table: "Deliveries",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IssuedById",
                table: "Deliveries",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_IssuedById",
                table: "Deliveries",
                column: "IssuedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_AspNetUsers_IssuedById",
                table: "Deliveries",
                column: "IssuedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_AspNetUsers_IssuedById",
                table: "Deliveries");

            migrationBuilder.DropIndex(
                name: "IX_Deliveries_IssuedById",
                table: "Deliveries");

            migrationBuilder.DropColumn(
                name: "IssuedById",
                table: "Deliveries");

            migrationBuilder.RenameColumn(
                name: "Recipient",
                table: "Deliveries",
                newName: "RecipientId");

            migrationBuilder.AlterColumn<string>(
                name: "RecipientId",
                table: "Deliveries",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_RecipientId",
                table: "Deliveries",
                column: "RecipientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_AspNetUsers_RecipientId",
                table: "Deliveries",
                column: "RecipientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
