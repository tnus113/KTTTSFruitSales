using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace btn.Migrations
{
    public partial class up1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_SellBillsDetails_SellBillDetailId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_SellBillDetailId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SellBillDetailId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "SellBillsDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SellBillsDetails_ProductId",
                table: "SellBillsDetails",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_SellBillsDetails_Products_ProductId",
                table: "SellBillsDetails",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SellBillsDetails_Products_ProductId",
                table: "SellBillsDetails");

            migrationBuilder.DropIndex(
                name: "IX_SellBillsDetails_ProductId",
                table: "SellBillsDetails");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "SellBillsDetails");

            migrationBuilder.AddColumn<int>(
                name: "SellBillDetailId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_SellBillDetailId",
                table: "Products",
                column: "SellBillDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_SellBillsDetails_SellBillDetailId",
                table: "Products",
                column: "SellBillDetailId",
                principalTable: "SellBillsDetails",
                principalColumn: "SellBillDetailId");
        }
    }
}
