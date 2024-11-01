using btn.Data;
using btn.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace btn.Controllers
{
    public class ProductController : Controller
    {
        private FruitSalesContext db;

        public ProductController(FruitSalesContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            var products = db.Products.ToList();
            return View(products);
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
    }
}