using btn.Data;
using btn.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace btn.Controllers
{
    public class ProviderController : Controller
    {
        private FruitSalesContext db;
        private int pageSize = 3;
        public ProviderController(FruitSalesContext context)
        {
            db = context;
        }
        public IActionResult Index(int? mid)
        {
            var providers = (IQueryable<Provider>)db.Providers;
            if (mid != null)
            {
                providers = (IQueryable<Provider>)db.Providers.Where(p => p.ProviderID == mid);
            }
            int pageNum = (int)Math.Ceiling(providers.Count() / (float)pageSize);
            ViewBag.pageNum = pageNum;
            var result = providers.Take(pageSize).ToList();
            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Provider provider)
        {
            if (ModelState.IsValid)
            {
                db.Providers.Add(provider);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(provider);
        }

        public IActionResult Edit(int id)
        {
            var provider = db.Providers.Find(id);
            if (provider == null)
            {
                return NotFound();
            }

            return View(provider);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Provider provider)
        {
            if (id != provider.ProviderID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(provider);
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!db.Providers.Any(e => e.ProviderID == id))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }

            return View(provider);
        }

        public IActionResult Delete(int id)
        {
            var provider = db.Providers.Find(id);
            if (provider == null)
            {
                return NotFound();
            }
            return View(provider);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var provider = db.Providers.Find(id);
            if (provider == null)
            {
                return NotFound();
            }

            db.Providers.Remove(provider);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ProviderById(int mid)
        {
            var provider = db.Providers.Where(l =>  l.ProviderID == mid).ToList();
            return PartialView("ProviderTable", provider);
        }

        public IActionResult ProviderFilter(int? mid, string? keyword, int? pageIndex)
        {
            var providers = (IQueryable<Provider>) db.Providers;
            int page = (int) (pageIndex == null || pageIndex <= 0 ? 1 : pageIndex);
            if (mid != null)
            {
                providers = providers.Where(e => e.ProviderID == mid);
                ViewBag.mid = mid;
            }
            if (!string.IsNullOrEmpty(keyword))
            {
                providers = providers.Where(l => l.ProviderName.ToLower().Contains(keyword.ToLower()));
                ViewBag.keyword = keyword;
            }
            int pageNum = (int)Math.Ceiling(providers.Count() / (float)pageSize);
            ViewBag.pageNum = pageNum;
            var result = providers.Skip(pageSize * (page - 1)).Take(pageSize);
            return PartialView("ProviderTable",result);
        }
    }
}