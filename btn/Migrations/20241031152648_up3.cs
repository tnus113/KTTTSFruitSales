using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace btn.Migrations
{
    public partial class up3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SellBillsDetails_Products_ProductId",
                table: "SellBillsDetails");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "SellBillsDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "SellBillsDetails",
                keyColumn: "SellBillDetailId",
                keyValue: 1,
                column: "ProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "SellBillsDetails",
                keyColumn: "SellBillDetailId",
                keyValue: 2,
                column: "ProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "SellBillsDetails",
                keyColumn: "SellBillDetailId",
                keyValue: 3,
                column: "ProductId",
                value: null);

            migrationBuilder.AddForeignKey(
                name: "FK_SellBillsDetails_Products_ProductId",
                table: "SellBillsDetails",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SellBillsDetails_Products_ProductId",
                table: "SellBillsDetails");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "SellBillsDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "SellBillsDetails",
                keyColumn: "SellBillDetailId",
                keyValue: 1,
                column: "ProductId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "SellBillsDetails",
                keyColumn: "SellBillDetailId",
                keyValue: 2,
                column: "ProductId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "SellBillsDetails",
                keyColumn: "SellBillDetailId",
                keyValue: 3,
                column: "ProductId",
                value: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_SellBillsDetails_Products_ProductId",
                table: "SellBillsDetails",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
