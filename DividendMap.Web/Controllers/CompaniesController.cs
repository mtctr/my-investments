using DividendMap.Web.Data;
using DividendMap.Web.Domain.Entities;
using DividendMap.Web.Domain.Ports;
using DividendMap.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DividendMap.Web.Controllers;

public class CompaniesController : Controller
{    
    private readonly ICompanyRepository _companyRepository;    

    public CompaniesController(ICompanyRepository companyRepository)
    {
        _companyRepository = companyRepository;
    }

    // GET: Companies
    public async Task<IActionResult> Index()
    {
        return View(await _companyRepository.GetAll());
    }

    // GET: Companies/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)        
            return NotFound();

        var company = await _companyRepository.FirstOrDefault(m => m.Id == id);
        if (company == null)        
            return NotFound();
        

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
        await _companyRepository.Add(company);
        return RedirectToAction(nameof(Index));
    }

    // GET: Companies/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)        
            return NotFound();
        

        var company = await _companyRepository.GetById(id.GetValueOrDefault());
        if (company == null)        
            return NotFound();
        
        var viewModel = new CompanyViewModel
        {
            Id = company.Id,
            Name = company.Name,
            StockName = company.Ticker
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
            var company = await _companyRepository.GetById(id);
            company.ChangeName(viewModel.Name);
            company.ChangeStockName(viewModel.StockName);
            await _companyRepository.Update(company);            
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_companyRepository.Exists(id))
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
        if (id == null)        
            return NotFound();


        var company = await _companyRepository.GetById(id.GetValueOrDefault());
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
        var company = await _companyRepository.GetById(id);
        if (company != null)
        {
            await _companyRepository.Remove(company);
        }
        
        return RedirectToAction(nameof(Index));
    }    
}
