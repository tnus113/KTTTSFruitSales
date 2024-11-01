using btn.Data;
using btn.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace btn.Controllers
{
    public class ProductController : Controller
    {
        private FruitSalesContext db;
        private int pageSize = 3;
        public ProductController(FruitSalesContext context)
        {
            db = context;
        }
        public IActionResult Index(int? mid)
        {
            var products = (IQueryable<Product>)db.Products;
            if (mid != null)
            {
                products = (IQueryable<Product>)db.Products.Where(p => p.ProductId == mid);
            }
            int pageNum = (int)Math.Ceiling(products.Count() / (float)pageSize);
            ViewBag.pageNum = pageNum;
            var result = products.Take(pageSize).ToList();
            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product Product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(Product);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(Product);
        }

        public IActionResult Edit(int id)
        {
            var Product = db.Products.Find(id);
            if (Product == null)
            {
                return NotFound();
            }

            return View(Product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Product Product)
        {
            if (id != Product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(Product);
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!db.Products.Any(e => e.ProductId == id))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }

            return View(Product);
        }

        public IActionResult Delete(int id)
        {
            var Product = db.Products.Find(id);
            if (Product == null)
            {
                return NotFound();
            }
            return View(Product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var Product = db.Products.Find(id);
            if (Product == null)
            {
                return NotFound();
            }

            db.Products.Remove(Product);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult ProductById(int mid)
        {
            var product = db.Products.Where(l => l.ProductId == mid).ToList();
            return PartialView("ProductTable", product);
        }
        public IActionResult ProductFilter(int? mid, string? keyword, int? pageIndex)
        {
            var products = (IQueryable<Product>)db.Products;
            int page = (int)(pageIndex == null || pageIndex <= 0 ? 1 : pageIndex);
            if (mid != null)
            {
                products = products.Where(e => e.ProductId == mid);
                ViewBag.mid = mid;
            }
            if (!string.IsNullOrEmpty(keyword))
            {
                products = products.Where(l => l.ProductName.ToLower().Contains(keyword.ToLower()));
                ViewBag.keyword = keyword;
            }
            int pageNum = (int)Math.Ceiling(products.Count() / (float)pageSize);
            ViewBag.pageNum = pageNum;
            var result = products.Skip(pageSize * (page - 1)).Take(pageSize);
            return PartialView("ProductTable", result);
        }
    }
}