using DividendMap.Web.Data;
using DividendMap.Web.Domain.Entities;
using DividendMap.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DividendMap.Web.Controllers;

public class CompaniesController : Controller
{
    private readonly DividendsContext _context;

    public CompaniesController(DividendsContext context)
    {
        _context = context;
    }

    // GET: Companies
    public async Task<IActionResult> Index()
    {
        return _context.Companies != null ?
                    View(await _context.Companies.ToListAsync()) :
                    Problem("Entity set 'DividendsContext.Companies'  is null.");
    }

    // GET: Companies/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null || _context.Companies == null)
        {
            return NotFound();
        }

        var company = await _context.Companies
            .FirstOrDefaultAsync(m => m.Id == id);
        if (company == null)
        {
            return NotFound();
        }

        return View(company);
    }

    // GET: Companies/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Companies/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CompanyViewModel viewModel)
    {
        if (!ModelState.IsValid)
            return View(viewModel);

        var company = new Company(viewModel.Name, viewModel.StockName);
        _context.Add(company);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    // GET: Companies/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null || _context.Companies == null)
        {
            return NotFound();
        }

        var company = await _context.Companies.FindAsync(id);
        if (company == null)
        {
            return NotFound();
        }
        var viewModel = new CompanyViewModel
        {
            Id = company.Id,
            Name = company.Name,
            StockName = company.StockName
        };
        return View(viewModel);
    }

    // POST: Companies/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, CompanyViewModel viewModel)
    {
        if (id != viewModel.Id)
            return NotFound();


        if (!ModelState.IsValid)
            return View(viewModel);

        try
        {
            var company = await _context.Companies.FindAsync(id);
            company.ChangeName(viewModel.Name);
            company.ChangeStockName(viewModel.StockName);
            _context.Update(company);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CompanyExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
        return RedirectToAction(nameof(Index));
    }

    // GET: Companies/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null || _context.Companies == null)
        {
            return NotFound();
        }

        var company = await _context.Companies
            .FirstOrDefaultAsync(m => m.Id == id);
        if (company == null)
        {
            return NotFound();
        }

        return View(company);
    }

    // POST: Companies/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (_context.Companies == null)
        {
            return Problem("Entity set 'DividendsContext.Companies'  is null.");
        }
        var company = await _context.Companies.FindAsync(id);
        if (company != null)
        {
            _context.Companies.Remove(company);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool CompanyExists(int id)
    {
        return (_context.Companies?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}
