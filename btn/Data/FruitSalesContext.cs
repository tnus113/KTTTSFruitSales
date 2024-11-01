using btn.Models;
using Microsoft.EntityFrameworkCore;

namespace btn.Data
{
    public class FruitSalesContext : DbContext
    {
        public FruitSalesContext(DbContextOptions<FruitSalesContext> options) : base(options) { }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Provider> Providers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<SellBill> SellBills { get; set; }
        public virtual DbSet<ImportBill> ImportBills { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<SellBillDetail> SellBillsDetails { get; set; }
        public virtual DbSet<ImportBillDetail> ImportBillDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Customer>().ToTable(nameof(Customer));
            //modelBuilder.Entity<Provider>().ToTable(nameof(Provider));
            //modelBuilder.Entity<Employee>().ToTable(nameof(Employee));
            //modelBuilder.Entity<SellBill>().ToTable(nameof(SellBill));
            //modelBuilder.Entity<ImportBill>().ToTable(nameof(ImportBill));
            //modelBuilder.Entity<Product>().ToTable(nameof(Product));
            //modelBuilder.Entity<SellBillDetail>().ToTable(nameof(SellBillDetail));
            //modelBuilder.Entity<ImportBillDetail>().ToTable(nameof(ImportBillDetail));

            modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerId = 1, CustomerName = "Jane", Address = "China", PhoneNumber = "0235241414" },
                    new Customer { CustomerId = 2, CustomerName = "Dick", Address = "America", PhoneNumber = "0325257864" },
                    new Customer { CustomerId = 3, CustomerName = "Clare", Address = "VietNam", PhoneNumber = "0942678251" }
                );

            modelBuilder.Entity<Provider>().HasData(
                new Provider { ProviderID = 1, ProviderName = "Vinamilk", Address = "China", PhoneNumber = "0235241414" },
                    new Provider { ProviderID = 2, ProviderName = "HoyoFruit", Address = "America", PhoneNumber = "0235511414" },
                    new Provider { ProviderID = 3, ProviderName = "BanaHill", Address = "VietNam", PhoneNumber = "0975241414" }
                );

            modelBuilder.Entity<Employee>().HasData(
                new Employee { EmployeeId = 1, EmployeeName = "Manaka", Address = "China", DateOfBirth = DateTime.Parse("2024-11-03"), Gender = "Male", PhoneNumber = "0914736241", Position = "Part-time worker" },
                    new Employee { EmployeeId = 2, EmployeeName = "KDABest", Address = "China", DateOfBirth = DateTime.Parse("2024-11-04"), Gender = "Female", PhoneNumber = "09148745441", Position = "Part-time worker" },
                    new Employee { EmployeeId = 3, EmployeeName = "Bruce Wayne", Address = "China", DateOfBirth = DateTime.Parse("2024-11-05"), Gender = "Male", PhoneNumber = "0918746241", Position = "Part-time worker" }
                );

            modelBuilder.Entity<SellBill>().HasData(
                new SellBill { SellBillId = 1, SalesDate = DateTime.Parse("2024-11-03"), TotalMoney = 300000, CustomerId = 1, EmployeeId = 1 },
                    new SellBill { SellBillId = 2, SalesDate = DateTime.Parse("2024-08-07"), TotalMoney = 400000, CustomerId = 2, EmployeeId = 2 },
                    new SellBill { SellBillId = 3, SalesDate = DateTime.Parse("2024-08-03"), TotalMoney = 700000, CustomerId = 3, EmployeeId = 3 }
                );

            modelBuilder.Entity<ImportBill>().HasData(
                new ImportBill { ImportBillId = 1, ImportsDate = DateTime.Parse("2024-07-08"), TotalMoney = 300000, EmployeeId = 1, ProviderId = 1 },
                    new ImportBill { ImportBillId = 2, ImportsDate = DateTime.Parse("2023-11-03"), TotalMoney = 400000, EmployeeId = 2, ProviderId = 2 },
                    new ImportBill { ImportBillId = 3, ImportsDate = DateTime.Parse("2023-11-08"), TotalMoney = 700000, EmployeeId = 3, ProviderId = 3 }

                );

            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, ProductName = "Chemistry", MoneyOnImport = 30000, MoneyOnSell = 40000, Amount = 10000, Character = "Juicy", Color = "Blue", ProvidePlace = "China", Unit = "Kg", Uses = "Ngon" },
                    new Product { ProductId = 2, ProductName = "Microeconomics", MoneyOnImport = 40000, MoneyOnSell = 50000, Amount = 5000, Character = "Juicy", Color = "Green", ProvidePlace = "America", Unit = "Kg", Uses = "Ngon" },
                    new Product { ProductId = 3, ProductName = "Macroeconomics", MoneyOnImport = 60000, MoneyOnSell = 70000, Amount = 15000, Character = "Juicy", Color = "Red", ProvidePlace = "VietNam", Unit = "Kg", Uses = "Ngon" }
                );

            modelBuilder.Entity<SellBillDetail>().HasData(
                new SellBillDetail { SellBillDetailId = 1, SellBillId = 1, ProductSellAmount = 10, SellDiscount = 50 },
                    new SellBillDetail { SellBillDetailId = 2, SellBillId = 2, ProductSellAmount = 20, SellDiscount = 50 },
                    new SellBillDetail { SellBillDetailId = 3, SellBillId = 3, ProductSellAmount = 30, SellDiscount = 50 }
                );

            modelBuilder.Entity<ImportBillDetail>().HasData(
                new ImportBillDetail { ImportBillDetailId = 1, ImportBillId = 1, ProductImportAmount = 100, ImportDiscount = 30},
                    new ImportBillDetail { ImportBillDetailId = 2, ImportBillId = 2, ProductImportAmount = 200, ImportDiscount = 30},
                    new ImportBillDetail { ImportBillDetailId = 3, ImportBillId = 3, ProductImportAmount = 300, ImportDiscount = 30}
                );
            //modelBuilder.Entity<SellBillDetail>()
            //.HasMany(s => s.Products)
            //.WithOne(p => p.SellBillDetails)
            //.HasForeignKey(p => p.SellBillDetailId);
        }
    }
}
