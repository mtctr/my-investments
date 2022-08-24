using DividendMap.Web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DividendMap.Web.Controllers
{
    public class DividendHistoryController : Controller
    {
        private readonly DividendsContext _context;

        public DividendHistoryController(DividendsContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Dividends.Include(x => x.Company).ToListAsync());
        }
    }
}
