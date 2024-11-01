using btn.Data;
using btn.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace btn.Controllers
{
    public class EmployeeController : Controller
    {
        private FruitSalesContext db;
        private int pageSize = 3;
        public EmployeeController(FruitSalesContext context)
        {
            db = context;
        }
        public IActionResult Index(int? mid)
        {
            var employees = (IQueryable<Employee>)db.Employees;
            if (mid != null)
            {
                employees = (IQueryable<Employee>)db.Employees.Where(p => p.EmployeeId == mid);
            }
            int pageNum = (int)Math.Ceiling(employees.Count() / (float)pageSize);
            ViewBag.pageNum = pageNum;
            var result = employees.Take(pageSize).ToList();
            return View(result);
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

        public IActionResult EmployeeById(int mid)
        {
            var employees = db.Employees.Where(l => l.EmployeeId == mid).ToList();
            return PartialView("EmployeeTable", employees);
        }

        public IActionResult EmployeeFilter(int? mid, string? keyword, int? pageIndex)
        {
            var employees = (IQueryable<Employee>)db.Employees;
            int page = (int)(pageIndex == null || pageIndex <= 0 ? 1 : pageIndex);
            if (mid != null)
            {
                employees = employees.Where(e => e.EmployeeId == mid);
                ViewBag.mid = mid;
            }
            if (!string.IsNullOrEmpty(keyword))
            {
                employees = employees.Where(l => l.EmployeeName.ToLower().Contains(keyword.ToLower()));
                ViewBag.keyword = keyword;
            }
            int pageNum = (int)Math.Ceiling(employees.Count() / (float)pageSize);
            ViewBag.pageNum = pageNum;
            var result = employees.Skip(pageSize * (page - 1)).Take(pageSize);
            return PartialView("EmployeeTable", result);
        }
    }
}