using btn.Data;
using btn.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MimeKit.Tnef;

namespace btn.Controllers
{
    public class SellBillController : Controller
    {
        private FruitSalesContext db;
        public SellBillController(FruitSalesContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            var sellBills = db.SellBills.Include(sb => sb.Customer).ToList();
            return View(sellBills);
        }
        public IActionResult Create()
        {
            ViewBag.Employees = new SelectList(db.Employees, "EmployeeId", "EmployeeName");
            ViewBag.Customers = new SelectList(db.Customers, "CustomerId", "CustomerName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SellBill sellbill)
        {
            if (ModelState.IsValid)
            {
                db.SellBills.Add(sellbill);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Employees = new SelectList(db.Employees, "EmployeeId", "EmployeeName");
            ViewBag.Customers = new SelectList(db.Customers, "CustomerId", "CustomerName");
            return View(sellbill);
        }

        public IActionResult Edit(int id)
        {
            var sellbill = db.SellBills.Find(id);
            if (sellbill == null)
            {
                return NotFound();
            }
            ViewBag.Employees = new SelectList(db.Employees, "EmployeeId", "EmployeeName", sellbill.EmployeeId);
            ViewBag.Customers = new SelectList(db.Customers, "CustomerId", "CustomerName", sellbill.CustomerId);
            return View(sellbill);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(SellBill sellbill)
        {
            

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(sellbill);
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return View();
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Employees = new SelectList(db.Employees, "EmployeeId", "EmployeeName", sellbill.EmployeeId);
            ViewBag.Customers = new SelectList(db.Customers, "CustomerId", "CustomerName", sellbill.CustomerId);
            return View(sellbill);
        }

        public IActionResult Delete(int id)
        {
            var sellbill = db.SellBills.Find(id);
            if (sellbill == null)
            {
                return NotFound();
            }
            return View(sellbill);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var sellbill = db.SellBills.Find(id);
            if (sellbill == null)
            {
                return NotFound();
            }

            db.SellBills.Remove(sellbill);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detail(int id)
        {
            var sellBill = db.SellBills
                .Include(sb => sb.SellBillDetails)
                .FirstOrDefault(sb => sb.SellBillId == id);

            if (sellBill == null)
            {
                return NotFound();
            }

            return View(sellBill);
        }

        public IActionResult CreateDetail(int sellbillId)
        {
            
            ViewBag.Products = new SelectList(db.Products, "ProductId", "ProductName");
            ViewBag.SellBills = new SelectList(db.SellBills, "SellBillId", "SellBillId");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateDetail(SellBillDetail sellbilldetail)
        {
            Console.WriteLine($"Received SellBillId: {sellbilldetail.SellBillId}");
            if (!db.SellBills.Any(b => b.SellBillId == sellbilldetail.SellBillId))
            {
                ModelState.AddModelError("SellBillId", "SellBillId không tồn tại trong bảng SellBills.");
                return View(sellbilldetail);
            }
            if (ModelState.IsValid)
            {
                db.SellBillsDetails.Add(sellbilldetail);
                db.SaveChanges();
                return RedirectToAction(nameof(Detail), new { id = sellbilldetail.SellBillId });
            }
            ViewBag.Products = new SelectList(db.Products, "ProductId", "ProductName");
            ViewBag.SellBills = new SelectList(db.SellBills, "SellBillId" , "SellBillId");
            return View(sellbilldetail);
        }

        public IActionResult EditDetail(int id)
        {
            var sellbilldetail = db.SellBillsDetails.Find(id);
            if (sellbilldetail == null)
            {
                return NotFound();
            }
            ViewBag.Products = new SelectList(db.Products, "ProductId", "ProductName", sellbilldetail.ProductId);
            ViewBag.SellBills = new SelectList(db.SellBills, "SellBillId", "SellBillId", sellbilldetail.SellBillId);
            return View(sellbilldetail);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditDetail(SellBillDetail sellbilldetail)
        {


            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(sellbilldetail);
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return View();
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Products = new SelectList(db.Products, "ProductId", "ProductName", sellbilldetail.ProductId);
            ViewBag.SellBills = new SelectList(db.SellBills, "SellBillId", "SellBillId", sellbilldetail.SellBillId);
            return View(sellbilldetail);
        }

        public IActionResult DeleteDetail(int id)
        {
            var sellbilldetail = db.SellBillsDetails.Find(id);
            if (sellbilldetail == null)
            {
                return NotFound();
            }
            return View(sellbilldetail);
        }

        [HttpPost, ActionName("DeleteDetail")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteDetailConfirmed(int id)
        {
            var sellbilldetail = db.SellBillsDetails.Find(id);
            if (sellbilldetail == null)
            {
                return NotFound();
            }

            db.SellBillsDetails.Remove(sellbilldetail);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
