using Microsoft.AspNetCore.Mvc;
using btn.Data;
using btn.Models;

namespace btn.ViewComponents
{
    public class ProviderViewComponent : ViewComponent
    {
        FruitSalesContext db;
        List<Provider> providers;

        public ProviderViewComponent(FruitSalesContext _context)
        {
            db = _context;
            providers = db.Providers.ToList();
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("RenderProvider", providers);
        }
    }
}
