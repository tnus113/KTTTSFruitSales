using btn.Data;
using btn.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace btn.Controllers
{
    public class EmployeeController : Controller
    {
        private FruitSalesContext db;
        public EmployeeController(FruitSalesContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            var Employees = db.Employees.ToList();
            return View(Employees);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(Employee Employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(Employee);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(Employee);
        }

        public IActionResult Edit(int id)
        {
            var Employee = db.Employees.Find(id);
            if (Employee == null)
            {
                return NotFound();
            }
            return View(Employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Employee Employee)
        {
            if (id != Employee.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(Employee);
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!db.Employees.Any(e => Employee.EmployeeId == id))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }

            return View(Employee);
        }

        public IActionResult Delete(int id)
        {
            var Employee = db.Employees.Find(id);
            if (Employee == null)
            {
                return NotFound();
            }
            return View(Employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var Employee = db.Employees.Find(id);
            if (Employee == null)
            {
                return NotFound();
            }

            db.Employees.Remove(Employee);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}