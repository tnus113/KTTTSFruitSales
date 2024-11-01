using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace btn.Migrations
{
    public partial class mayman : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImportBill_Employee_EmployeeId",
                table: "ImportBill");

            migrationBuilder.DropForeignKey(
                name: "FK_ImportBill_Provider_ProviderId",
                table: "ImportBill");

            migrationBuilder.DropForeignKey(
                name: "FK_ImportBillDetail_ImportBill_ImportBillId",
                table: "ImportBillDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_ImportBillDetail_Product_ProductId",
                table: "ImportBillDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_SellBillDetail_SellBillDetailId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_SellBill_Customer_CustomerId",
                table: "SellBill");

            migrationBuilder.DropForeignKey(
                name: "FK_SellBill_Employee_EmployeeId",
                table: "SellBill");

            migrationBuilder.DropForeignKey(
                name: "FK_SellBillDetail_SellBill_SellBillId",
                table: "SellBillDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SellBillDetail",
                table: "SellBillDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SellBill",
                table: "SellBill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Provider",
                table: "Provider");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImportBillDetail",
                table: "ImportBillDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImportBill",
                table: "ImportBill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee",
                table: "Employee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer",
                table: "Customer");

            migrationBuilder.RenameTable(
                name: "SellBillDetail",
                newName: "SellBillsDetails");

            migrationBuilder.RenameTable(
                name: "SellBill",
                newName: "SellBills");

            migrationBuilder.RenameTable(
                name: "Provider",
                newName: "Providers");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "ImportBillDetail",
                newName: "ImportBillDetails");

            migrationBuilder.RenameTable(
                name: "ImportBill",
                newName: "ImportBills");

            migrationBuilder.RenameTable(
                name: "Employee",
                newName: "Employees");

            migrationBuilder.RenameTable(
                name: "Customer",
                newName: "Customers");

            migrationBuilder.RenameIndex(
                name: "IX_SellBillDetail_SellBillId",
                table: "SellBillsDetails",
                newName: "IX_SellBillsDetails_SellBillId");

            migrationBuilder.RenameIndex(
                name: "IX_SellBill_EmployeeId",
                table: "SellBills",
                newName: "IX_SellBills_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_SellBill_CustomerId",
                table: "SellBills",
                newName: "IX_SellBills_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_SellBillDetailId",
                table: "Products",
                newName: "IX_Products_SellBillDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_ImportBillDetail_ProductId",
                table: "ImportBillDetails",
                newName: "IX_ImportBillDetails_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ImportBillDetail_ImportBillId",
                table: "ImportBillDetails",
                newName: "IX_ImportBillDetails_ImportBillId");

            migrationBuilder.RenameIndex(
                name: "IX_ImportBill_ProviderId",
                table: "ImportBills",
                newName: "IX_ImportBills_ProviderId");

            migrationBuilder.RenameIndex(
                name: "IX_ImportBill_EmployeeId",
                table: "ImportBills",
                newName: "IX_ImportBills_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SellBillsDetails",
                table: "SellBillsDetails",
                column: "SellBillDetailId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SellBills",
                table: "SellBills",
                column: "SellBillId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Providers",
                table: "Providers",
                column: "ProviderID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImportBillDetails",
                table: "ImportBillDetails",
                column: "ImportBillDetailId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImportBills",
                table: "ImportBills",
                column: "ImportBillId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "CustomerId");

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Address", "CustomerName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "China", "Jane", "0235241414" },
                    { 2, "America", "Dick", "0325257864" },
                    { 3, "VietNam", "Clare", "0942678251" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Address", "DateOfBirth", "EmployeeName", "Gender", "PhoneNumber", "Position" },
                values: new object[,]
                {
                    { 1, "China", new DateTime(2024, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Manaka", "Male", "0914736241", "Part-time worker" },
                    { 2, "China", new DateTime(2024, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "KDABest", "Female", "09148745441", "Part-time worker" },
                    { 3, "China", new DateTime(2024, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bruce Wayne", "Male", "0918746241", "Part-time worker" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Amount", "Character", "Color", "MoneyOnImport", "MoneyOnSell", "ProductName", "ProvidePlace", "SellBillDetailId", "Unit", "Uses" },
                values: new object[,]
                {
                    { 1, 10000, "Juicy", "Blue", 30000m, 40000m, "Chemistry", "China", null, "Kg", "Ngon" },
                    { 2, 5000, "Juicy", "Green", 40000m, 50000m, "Microeconomics", "America", null, "Kg", "Ngon" },
                    { 3, 15000, "Juicy", "Red", 60000m, 70000m, "Macroeconomics", "VietNam", null, "Kg", "Ngon" }
                });

            migrationBuilder.InsertData(
                table: "Providers",
                columns: new[] { "ProviderID", "Address", "PhoneNumber", "ProviderName" },
                values: new object[,]
                {
                    { 1, "China", "0235241414", "Vinamilk" },
                    { 2, "America", "0235511414", "HoyoFruit" },
                    { 3, "VietNam", "0975241414", "BanaHill" }
                });

            migrationBuilder.InsertData(
                table: "ImportBills",
                columns: new[] { "ImportBillId", "EmployeeId", "ImportsDate", "ProviderId", "TotalMoney" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 300000m },
                    { 2, 2, new DateTime(2023, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 400000m },
                    { 3, 3, new DateTime(2023, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 700000m }
                });

            migrationBuilder.InsertData(
                table: "SellBills",
                columns: new[] { "SellBillId", "CustomerId", "EmployeeId", "SalesDate", "TotalMoney" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2024, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 300000m },
                    { 2, 2, 2, new DateTime(2024, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 400000m },
                    { 3, 3, 3, new DateTime(2024, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 700000m }
                });

            migrationBuilder.InsertData(
                table: "ImportBillDetails",
                columns: new[] { "ImportBillDetailId", "ImportBillId", "ImportDiscount", "ProductId", "ProductImportAmount", "ProductName" },
                values: new object[,]
                {
                    { 1, 1, 30m, 1, 100m, "" },
                    { 2, 2, 30m, 2, 200m, "" },
                    { 3, 3, 30m, 3, 300m, "" }
                });

            migrationBuilder.InsertData(
                table: "SellBillsDetails",
                columns: new[] { "SellBillDetailId", "ProductSellAmount", "SellBillId", "SellDiscount" },
                values: new object[,]
                {
                    { 1, 10m, 1, 50m },
                    { 2, 20m, 2, 50m },
                    { 3, 30m, 3, 50m }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ImportBillDetails_ImportBills_ImportBillId",
                table: "ImportBillDetails",
                column: "ImportBillId",
                principalTable: "ImportBills",
                principalColumn: "ImportBillId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ImportBillDetails_Products_ProductId",
                table: "ImportBillDetails",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ImportBills_Employees_EmployeeId",
                table: "ImportBills",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ImportBills_Providers_ProviderId",
                table: "ImportBills",
                column: "ProviderId",
                principalTable: "Providers",
                principalColumn: "ProviderID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_SellBillsDetails_SellBillDetailId",
                table: "Products",
                column: "SellBillDetailId",
                principalTable: "SellBillsDetails",
                principalColumn: "SellBillDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_SellBills_Customers_CustomerId",
                table: "SellBills",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SellBills_Employees_EmployeeId",
                table: "SellBills",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SellBillsDetails_SellBills_SellBillId",
                table: "SellBillsDetails",
                column: "SellBillId",
                principalTable: "SellBills",
                principalColumn: "SellBillId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImportBillDetails_ImportBills_ImportBillId",
                table: "ImportBillDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ImportBillDetails_Products_ProductId",
                table: "ImportBillDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ImportBills_Employees_EmployeeId",
                table: "ImportBills");

            migrationBuilder.DropForeignKey(
                name: "FK_ImportBills_Providers_ProviderId",
                table: "ImportBills");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_SellBillsDetails_SellBillDetailId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_SellBills_Customers_CustomerId",
                table: "SellBills");

            migrationBuilder.DropForeignKey(
                name: "FK_SellBills_Employees_EmployeeId",
                table: "SellBills");

            migrationBuilder.DropForeignKey(
                name: "FK_SellBillsDetails_SellBills_SellBillId",
                table: "SellBillsDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SellBillsDetails",
                table: "SellBillsDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SellBills",
                table: "SellBills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Providers",
                table: "Providers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImportBills",
                table: "ImportBills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImportBillDetails",
                table: "ImportBillDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.DeleteData(
                table: "ImportBillDetails",
                keyColumn: "ImportBillDetailId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ImportBillDetails",
                keyColumn: "ImportBillDetailId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ImportBillDetails",
                keyColumn: "ImportBillDetailId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SellBillsDetails",
                keyColumn: "SellBillDetailId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SellBillsDetails",
                keyColumn: "SellBillDetailId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SellBillsDetails",
                keyColumn: "SellBillDetailId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ImportBills",
                keyColumn: "ImportBillId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ImportBills",
                keyColumn: "ImportBillId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ImportBills",
                keyColumn: "ImportBillId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SellBills",
                keyColumn: "SellBillId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SellBills",
                keyColumn: "SellBillId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SellBills",
                keyColumn: "SellBillId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Providers",
                keyColumn: "ProviderID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Providers",
                keyColumn: "ProviderID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Providers",
                keyColumn: "ProviderID",
                keyValue: 3);

            migrationBuilder.RenameTable(
                name: "SellBillsDetails",
                newName: "SellBillDetail");

            migrationBuilder.RenameTable(
                name: "SellBills",
                newName: "SellBill");

            migrationBuilder.RenameTable(
                name: "Providers",
                newName: "Provider");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Product");

            migrationBuilder.RenameTable(
                name: "ImportBills",
                newName: "ImportBill");

            migrationBuilder.RenameTable(
                name: "ImportBillDetails",
                newName: "ImportBillDetail");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "Employee");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "Customer");

            migrationBuilder.RenameIndex(
                name: "IX_SellBillsDetails_SellBillId",
                table: "SellBillDetail",
                newName: "IX_SellBillDetail_SellBillId");

            migrationBuilder.RenameIndex(
                name: "IX_SellBills_EmployeeId",
                table: "SellBill",
                newName: "IX_SellBill_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_SellBills_CustomerId",
                table: "SellBill",
                newName: "IX_SellBill_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_SellBillDetailId",
                table: "Product",
                newName: "IX_Product_SellBillDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_ImportBills_ProviderId",
                table: "ImportBill",
                newName: "IX_ImportBill_ProviderId");

            migrationBuilder.RenameIndex(
                name: "IX_ImportBills_EmployeeId",
                table: "ImportBill",
                newName: "IX_ImportBill_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_ImportBillDetails_ProductId",
                table: "ImportBillDetail",
                newName: "IX_ImportBillDetail_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ImportBillDetails_ImportBillId",
                table: "ImportBillDetail",
                newName: "IX_ImportBillDetail_ImportBillId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SellBillDetail",
                table: "SellBillDetail",
                column: "SellBillDetailId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SellBill",
                table: "SellBill",
                column: "SellBillId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Provider",
                table: "Provider",
                column: "ProviderID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImportBill",
                table: "ImportBill",
                column: "ImportBillId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImportBillDetail",
                table: "ImportBillDetail",
                column: "ImportBillDetailId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee",
                table: "Employee",
                column: "EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer",
                table: "Customer",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ImportBill_Employee_EmployeeId",
                table: "ImportBill",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ImportBill_Provider_ProviderId",
                table: "ImportBill",
                column: "ProviderId",
                principalTable: "Provider",
                principalColumn: "ProviderID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ImportBillDetail_ImportBill_ImportBillId",
                table: "ImportBillDetail",
                column: "ImportBillId",
                principalTable: "ImportBill",
                principalColumn: "ImportBillId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ImportBillDetail_Product_ProductId",
                table: "ImportBillDetail",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_SellBillDetail_SellBillDetailId",
                table: "Product",
                column: "SellBillDetailId",
                principalTable: "SellBillDetail",
                principalColumn: "SellBillDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_SellBill_Customer_CustomerId",
                table: "SellBill",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SellBill_Employee_EmployeeId",
                table: "SellBill",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SellBillDetail_SellBill_SellBillId",
                table: "SellBillDetail",
                column: "SellBillId",
                principalTable: "SellBill",
                principalColumn: "SellBillId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
