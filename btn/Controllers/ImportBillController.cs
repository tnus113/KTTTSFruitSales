using btn.Data;
using btn.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace btn.Controllers
{
    public class ImportBillController : Controller
    {
        private FruitSalesContext db;
        public ImportBillController(FruitSalesContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            var importBills = db.ImportBills.Include(ib => ib.Provider).ToList();
            return View(importBills);
        }
        public IActionResult Create()
        {
            ViewBag.Employees = new SelectList(db.Employees, "EmployeeId", "EmployeeName");
            ViewBag.Providers = new SelectList(db.Providers, "ProviderID", "ProviderName");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ImportBill importbill)
        {
            if (ModelState.IsValid)
            {
                db.ImportBills.Add(importbill);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Employees = new SelectList(db.Employees, "EmployeeId", "EmployeeName");
            ViewBag.Providers = new SelectList(db.Providers, "ProviderID", "ProviderName");
            return View(importbill);
        }

        public IActionResult Edit(int id)
        {
            var importbill = db.ImportBills.Find(id);
            if (importbill == null)
            {
                return NotFound();
            }
            ViewBag.Employees = new SelectList(db.Employees, "EmployeeId", "EmployeeName", importbill.EmployeeId);
            ViewBag.Providers = new SelectList(db.Providers, "ProviderID", "ProviderName", importbill.ProviderId);
            return View(importbill);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ImportBill importbill)
        {
            if (id != importbill.ImportBillId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(importbill);
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!db.ImportBills.Any(e => e.ImportBillId == id))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Employees = new SelectList(db.Employees, "EmployeeId", "EmployeeName", importbill.EmployeeId);
            ViewBag.Providers = new SelectList(db.Providers, "ProviderID", "ProviderName", importbill.ProviderId);
            return View(importbill);
        }

        public IActionResult Delete(int id)
        {
            var importbill = db.ImportBills.Find(id);
            if (importbill == null)
            {
                return NotFound();
            }
            return View(importbill);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var importbill = db.ImportBills.Find(id);
            if (importbill == null)
            {
                return NotFound();
            }

            db.ImportBills.Remove(importbill);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detail(int id)
        {
            var ImportBill = db.ImportBills
                .Include(sb => sb.ImportBillDetails)
                .FirstOrDefault(sb => sb.ImportBillId == id);

            if (ImportBill == null)
            {
                return NotFound();
            }

            return View(ImportBill);
        }

        public IActionResult CreateDetail(int importbillid)
        {

            ViewBag.Products = new SelectList(db.Products, "ProductId", "ProductName");
            ViewBag.ImportBills = new SelectList(db.ImportBills, "ImportBillId", "ImportBillId");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateDetail(ImportBillDetail Importbilldetail)
        {
            Console.WriteLine($"Received ImportBillId: {Importbilldetail.ImportBillId}");
            if (!db.ImportBills.Any(b => b.ImportBillId == Importbilldetail.ImportBillId))
            {
                ModelState.AddModelError("ImportBillId", "ImportBillId không tồn tại trong bảng ImportBills.");
                return View(Importbilldetail);
            }
            if (ModelState.IsValid)
            {
                db.ImportBillDetails.Add(Importbilldetail);
                db.SaveChanges();
                return RedirectToAction(nameof(Detail), new { id = Importbilldetail.ImportBillId });
            }
            ViewBag.Products = new SelectList(db.Products, "ProductId", "ProductName");
            ViewBag.ImportBills = new SelectList(db.ImportBills, "ImportBillId", "ImportBillId");
            return View(Importbilldetail);
        }

        public IActionResult EditDetail(int id)
        {
            var Importbilldetail = db.ImportBillDetails.Find(id);
            if (Importbilldetail == null)
            {
                return NotFound();
            }
            ViewBag.Products = new SelectList(db.Products, "ProductId", "ProductName", Importbilldetail.ProductId);
            ViewBag.ImportBills = new SelectList(db.ImportBills, "ImportBillId", "ImportBillId", Importbilldetail.ImportBillId);
            return View(Importbilldetail);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditDetail(ImportBillDetail Importbilldetail)
        {


            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(Importbilldetail);
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return View();
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Products = new SelectList(db.Products, "ProductId", "ProductName", Importbilldetail.ProductId);
            ViewBag.ImportBills = new SelectList(db.ImportBills, "ImportBillId", "ImportBillId", Importbilldetail.ImportBillId);
            return View(Importbilldetail);
        }

        public IActionResult DeleteDetail(int id)
        {
            var Importbilldetail = db.ImportBillDetails.Find(id);
            if (Importbilldetail == null)
            {
                return NotFound();
            }
            return View(Importbilldetail);
        }

        [HttpPost, ActionName("DeleteDetail")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteDetailConfirmed(int id)
        {
            var Importbilldetail = db.ImportBillDetails.Find(id);
            if (Importbilldetail == null)
            {
                return NotFound();
            }

            db.ImportBillDetails.Remove(Importbilldetail);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
