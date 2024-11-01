using btn.Data;
using btn.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace btn.Controllers
{
    public class CustomerController : Controller
    {
        private FruitSalesContext db;
        private int pageSize = 3;
        public CustomerController(FruitSalesContext context)
        {
            db = context;
        }
        public IActionResult Index(int? mid)
        {
            var customers = (IQueryable<Customer>)db.Customers;
            if (mid != null)
            {
                customers = (IQueryable<Customer>)db.Customers.Where(p => p.CustomerId == mid);
            }
            int pageNum = (int)Math.Ceiling(customers.Count() / (float)pageSize);
            ViewBag.pageNum = pageNum;
            var result = customers.Take(pageSize).ToList();
            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        public IActionResult Edit(int id)
        {
            var customer = db.Customers.Find(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(customer);
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!db.Customers.Any(e => customer.CustomerId == id))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }

            return View(customer);
        }

        public IActionResult Delete(int id)
        {
            var customer = db.Customers.Find(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var customer = db.Customers.Find(id);
            if (customer == null)
            {
                return NotFound();
            }

            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult CustomerById(int mid)
        {
            var customers = db.Customers.Where(l => l.CustomerId == mid).ToList();
            return PartialView("CustomerTable", customers);
        }

        public IActionResult CustomerFilter(int? mid, string? keyword, int? pageIndex)
        {
            var customers = (IQueryable<Customer>)db.Customers;
            int page = (int)(pageIndex == null || pageIndex <= 0 ? 1 : pageIndex);
            if (mid != null)
            {
                customers = customers.Where(e => e.CustomerId == mid);
                ViewBag.mid = mid;
            }
            if (!string.IsNullOrEmpty(keyword))
            {
                customers = customers.Where(l => l.CustomerName.ToLower().Contains(keyword.ToLower()));
                ViewBag.keyword = keyword;
            }
            int pageNum = (int)Math.Ceiling(customers.Count() / (float)pageSize);
            ViewBag.pageNum = pageNum;
            var result = customers.Skip(pageSize * (page - 1)).Take(pageSize);
            return PartialView("CustomerTable", result);
        }
    }
}