using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace btn.Migrations
{
    public partial class alterTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Provider",
                columns: table => new
                {
                    ProviderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProviderName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provider", x => x.ProviderID);
                });

            migrationBuilder.CreateTable(
                name: "SellBill",
                columns: table => new
                {
                    SellBillId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    SalesDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalMoney = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellBill", x => x.SellBillId);
                    table.ForeignKey(
                        name: "FK_SellBill_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SellBill_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImportBill",
                columns: table => new
                {
                    ImportBillId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    ProviderId = table.Column<int>(type: "int", nullable: false),
                    ImportsDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalMoney = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportBill", x => x.ImportBillId);
                    table.ForeignKey(
                        name: "FK_ImportBill_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImportBill_Provider_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Provider",
                        principalColumn: "ProviderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SellBillDetail",
                columns: table => new
                {
                    SellBillDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SellBillId = table.Column<int>(type: "int", nullable: false),
                    ProductSellAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SellDiscount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellBillDetail", x => x.SellBillDetailId);
                    table.ForeignKey(
                        name: "FK_SellBillDetail_SellBill_SellBillId",
                        column: x => x.SellBillId,
                        principalTable: "SellBill",
                        principalColumn: "SellBillId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProvidePlace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Uses = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    MoneyOnImport = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MoneyOnSell = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Character = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SellBillDetailId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Product_SellBillDetail_SellBillDetailId",
                        column: x => x.SellBillDetailId,
                        principalTable: "SellBillDetail",
                        principalColumn: "SellBillDetailId");
                });

            migrationBuilder.CreateTable(
                name: "ImportBillDetail",
                columns: table => new
                {
                    ImportBillDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImportBillId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductImportAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImportDiscount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportBillDetail", x => x.ImportBillDetailId);
                    table.ForeignKey(
                        name: "FK_ImportBillDetail_ImportBill_ImportBillId",
                        column: x => x.ImportBillId,
                        principalTable: "ImportBill",
                        principalColumn: "ImportBillId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImportBillDetail_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImportBill_EmployeeId",
                table: "ImportBill",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ImportBill_ProviderId",
                table: "ImportBill",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_ImportBillDetail_ImportBillId",
                table: "ImportBillDetail",
                column: "ImportBillId");

            migrationBuilder.CreateIndex(
                name: "IX_ImportBillDetail_ProductId",
                table: "ImportBillDetail",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_SellBillDetailId",
                table: "Product",
                column: "SellBillDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_SellBill_CustomerId",
                table: "SellBill",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_SellBill_EmployeeId",
                table: "SellBill",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_SellBillDetail_SellBillId",
                table: "SellBillDetail",
                column: "SellBillId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImportBillDetail");

            migrationBuilder.DropTable(
                name: "ImportBill");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Provider");

            migrationBuilder.DropTable(
                name: "SellBillDetail");

            migrationBuilder.DropTable(
                name: "SellBill");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}
