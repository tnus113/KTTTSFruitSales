using btn.Models;
using Microsoft.EntityFrameworkCore;

namespace btn.Data
{
    public class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new FruitSalesContext(serviceProvider
                .GetRequiredService<DbContextOptions<FruitSalesContext>>()))
            {
                context.Database.EnsureCreated();

                if (context.Customers.Any())
                {
                    return;
                }
                
                var customers = new Customer[]
                {
                    new Customer { CustomerId = 1, CustomerName = "Jane" , Address = "China", PhoneNumber = "0235241414"},
                    new Customer { CustomerId = 2, CustomerName = "Dick" , Address = "America", PhoneNumber = "0325257864" },
                    new Customer { CustomerId = 3, CustomerName = "Clare" , Address = "VietNam", PhoneNumber = "0942678251" }
                };

                foreach (var customer in customers)
                {
                    context.Customers.Add(customer);
                }
                context.SaveChanges();

                //
                if (context.Providers.Any())
                {
                    return;
                }

                var providers = new Provider[]
                {
                    new Provider { ProviderID = 1, ProviderName = "Vinamilk" , Address = "China", PhoneNumber = "0235241414"},
                    new Provider { ProviderID = 2, ProviderName = "HoyoFruit" , Address = "America", PhoneNumber = "0235511414" },
                    new Provider { ProviderID = 3, ProviderName = "BanaHill" , Address = "VietNam", PhoneNumber = "0975241414" }
                };

                foreach (var provider in providers)
                {
                    context.Providers.Add(provider);
                }
                context.SaveChanges();

                //
                if (context.Employees.Any())
                {
                    return;
                }
                    

                var employees = new Employee[]
                {
                    new Employee { EmployeeId = 1, EmployeeName = "Manaka", Address = "China", DateOfBirth = DateTime.Parse("2024-11-03"), Gender = "Male", PhoneNumber = "0914736241", Position = "Part-time worker" },
                    new Employee { EmployeeId = 2, EmployeeName = "KDABest", Address = "China", DateOfBirth = DateTime.Parse("2024-11-04"), Gender = "Female", PhoneNumber = "09148745441", Position = "Part-time worker"  },
                    new Employee { EmployeeId = 3, EmployeeName = "Bruce Wayne", Address = "China", DateOfBirth = DateTime.Parse("2024-11-05"), Gender = "Male", PhoneNumber = "0918746241", Position = "Part-time worker"  }
                };

                foreach (var employee in employees)
                {
                    context.Employees.Add(employee);
                }
                context.SaveChanges();

                //
                if (context.SellBills.Any())
                {
                    return;
                }

                var sellbills = new SellBill[]
                {
                    new SellBill { SellBillId = 1, SalesDate = DateTime.Parse("2024-11-03"), TotalMoney = 300000, CustomerId = 1 , EmployeeId = 1},
                    new SellBill { SellBillId = 2, SalesDate = DateTime.Parse("2024-08-07"), TotalMoney = 400000, CustomerId = 2, EmployeeId = 2 },
                    new SellBill { SellBillId = 3, SalesDate = DateTime.Parse("2024-08-03"), TotalMoney = 700000, CustomerId = 3, EmployeeId = 3 }
                };

                foreach (var sellbill in sellbills)
                {
                    context.SellBills.Add(sellbill);
                }
                context.SaveChanges();

                //
                if (context.ImportBills.Any())
                {
                    return;
                }
                var importbills = new ImportBill[]
                {
                    new ImportBill { ImportBillId = 1, ImportsDate = DateTime.Parse("2024-07-08"), TotalMoney = 300000, EmployeeId = 1, ProviderId = 1 },
                    new ImportBill { ImportBillId = 2, ImportsDate = DateTime.Parse("2023-11-03"), TotalMoney = 400000, EmployeeId = 2, ProviderId = 2 },
                    new ImportBill { ImportBillId = 3, ImportsDate = DateTime.Parse("2023-11-08"), TotalMoney = 700000, EmployeeId = 3, ProviderId = 3 }

                };

                foreach (var importbill in importbills)
                {
                    context.ImportBills.Add(importbill);
                }
                context.SaveChanges();

                // 
                if (context.Products.Any())
                {
                    return;
                } 

                var products = new Product[]
                {
                    new Product { ProductId = 1, ProductName = "Chemistry", MoneyOnImport = 30000, MoneyOnSell = 40000, Amount = 10000, Character = "Juicy", Color = "Blue", ProvidePlace = "China", Unit = "Kg", Uses = "Ngon" },
                    new Product { ProductId = 2, ProductName = "Microeconomics", MoneyOnImport = 40000, MoneyOnSell = 50000, Amount = 5000, Character = "Juicy", Color = "Green", ProvidePlace = "America", Unit = "Kg", Uses = "Ngon"  },
                    new Product { ProductId = 3, ProductName = "Macroeconomics", MoneyOnImport = 60000, MoneyOnSell = 70000 , Amount = 15000, Character = "Juicy", Color = "Red", ProvidePlace = "VietNam", Unit = "Kg", Uses = "Ngon" }
                };

                foreach (var product in products)
                {
                    context.Products.Add(product);
                }
                context.SaveChanges();

                // 
                if (context.SellBillsDetails.Any())
                {
                    return;
                }

                var sellBillDetails = new SellBillDetail[]
                {
                    new SellBillDetail { SellBillDetailId = 1,SellBillId = 1, ProductSellAmount = 10,  SellDiscount = 50 },
                    new SellBillDetail { SellBillDetailId = 2,SellBillId = 2, ProductSellAmount = 20,  SellDiscount = 50 },
                    new SellBillDetail { SellBillDetailId = 3,SellBillId = 3, ProductSellAmount = 30,  SellDiscount = 50 }
                };

                foreach (var sellBillDetail in sellBillDetails)
                {
                    context.SellBillsDetails.Add(sellBillDetail);
                }
                context.SaveChanges();

                // 
                if (context.ImportBillDetails.Any())
                {
                    return;
                }

                var importBillDetails = new ImportBillDetail[]
                {
                    new ImportBillDetail { ImportBillDetailId = 1,ImportBillId = 1, ProductImportAmount = 100, ProductId = 1, ImportDiscount = 30 },
                    new ImportBillDetail { ImportBillDetailId = 2,ImportBillId = 2, ProductImportAmount = 200, ProductId = 2, ImportDiscount = 30 },
                    new ImportBillDetail { ImportBillDetailId = 3,ImportBillId = 3, ProductImportAmount = 300, ProductId = 3, ImportDiscount = 30 }
                };

                foreach (var importBillDetail in importBillDetails)
                {
                    context.ImportBillDetails.Add(importBillDetail);
                }
                context.SaveChanges();
            }
        }

    }
}
